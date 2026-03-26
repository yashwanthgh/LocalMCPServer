using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Amazon;
using Amazon.BedrockRuntime;
using Amazon.BedrockRuntime.Model;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using ModelContextProtocol.Client;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(opts =>
    opts.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();
app.UseCors();
app.UseDefaultFiles();
app.UseStaticFiles();

const string McpServerUrl = "http://mcp-alb-241104355.us-east-1.elb.amazonaws.com/sse";
const string BedrockModelId = "us.anthropic.claude-sonnet-4-6";
const string AwsRegion = "us-east-1";
const string AwsProfile = "105927215370_LytxHackathonUser";

const string SystemPrompt =
    "You are a helpful assistant with access to three tools: " +
    "weather (get current weather for any city), " +
    "books (browse a catalog of books by category), and " +
    "coaching sessions (look up driver coaching sessions by coach, driver, or date). " +
    "Use these tools proactively whenever they can help answer the user's question. " +
    "Always be concise and friendly.";

static AmazonBedrockRuntimeClient CreateBedrockClient()
{
    var chain = new CredentialProfileStoreChain();
    if (chain.TryGetAWSCredentials(AwsProfile, out var credentials))
        return new AmazonBedrockRuntimeClient(credentials, RegionEndpoint.GetBySystemName(AwsRegion));

    // Fall back to default credential chain (env vars, IAM role, etc.)
    return new AmazonBedrockRuntimeClient(RegionEndpoint.GetBySystemName(AwsRegion));
}

static async Task<JsonObject> InvokeClaudeAsync(
    AmazonBedrockRuntimeClient bedrock,
    string systemPrompt,
    List<JsonObject> messages,
    List<JsonObject>? tools = null)
{
    var body = new JsonObject
    {
        ["anthropic_version"] = "bedrock-2023-05-31",
        ["max_tokens"] = 4096,
        ["system"] = systemPrompt,
        ["messages"] = new JsonArray(messages.Select(m => (JsonNode)m.DeepClone()).ToArray())
    };

    if (tools is { Count: > 0 })
        body["tools"] = new JsonArray(tools.Select(t => (JsonNode)t.DeepClone()).ToArray());

    var request = new InvokeModelRequest
    {
        ModelId = BedrockModelId,
        ContentType = "application/json",
        Accept = "application/json",
        Body = new MemoryStream(Encoding.UTF8.GetBytes(body.ToJsonString()))
    };

    var response = await bedrock.InvokeModelAsync(request);
    var json = await new StreamReader(response.Body).ReadToEndAsync();
    return JsonNode.Parse(json)!.AsObject();
}

app.MapPost("/api/chat", async (ChatRequest req, ILoggerFactory loggerFactory) =>
{
    try
    {
        var logger = loggerFactory.CreateLogger("ChatApp");

        // Connect to MCP server
        var transport = new SseClientTransport(
            new SseClientTransportOptions { Endpoint = new Uri(McpServerUrl) },
            loggerFactory);

        await using var mcp = await McpClientFactory.CreateAsync(
            transport,
            new McpClientOptions { ClientInfo = new() { Name = "ChatApp", Version = "1.0.0" } },
            loggerFactory);

        // Fetch tools and build Bedrock tool schema
        var mcpTools = await mcp.ListToolsAsync();
        var bedrockTools = mcpTools.Select(t =>
        {
            var toolDef = new JsonObject
            {
                ["name"] = t.Name,
                ["description"] = t.Description ?? t.Name
            };

            // Build input_schema from MCP JsonSchema
            var inputSchema = new JsonObject { ["type"] = "object" };
            var props = new JsonObject();
            var required = new JsonArray();

            if (t.JsonSchema.ValueKind == JsonValueKind.Object)
            {
                if (t.JsonSchema.TryGetProperty("properties", out var propsEl) &&
                    propsEl.ValueKind == JsonValueKind.Object)
                {
                    foreach (var prop in propsEl.EnumerateObject())
                        props[prop.Name] = JsonNode.Parse(prop.Value.GetRawText());
                }
                if (t.JsonSchema.TryGetProperty("required", out var reqEl) &&
                    reqEl.ValueKind == JsonValueKind.Array)
                {
                    foreach (var r in reqEl.EnumerateArray())
                        required.Add(r.GetString());
                }
            }

            inputSchema["properties"] = props;
            if (required.Count > 0)
                inputSchema["required"] = required;

            toolDef["input_schema"] = inputSchema;
            return toolDef;
        }).ToList();

        // Build message history
        var messages = req.Messages.Select(m => new JsonObject
        {
            ["role"] = m.Role,
            ["content"] = m.Content
        }).ToList();

        var toolCallLog = new List<ToolCallEntry>();
        string finalText = string.Empty;

        // Agentic loop
        while (true)
        {
            var response = await InvokeClaudeAsync(CreateBedrockClient(), SystemPrompt, messages, bedrockTools);

            var stopReason = response["stop_reason"]?.GetValue<string>();
            var contentArray = response["content"]?.AsArray() ?? new JsonArray();

            var assistantContent = new JsonArray();
            var toolResults = new JsonArray();

            foreach (var block in contentArray)
            {
                var blockObj = block!.AsObject();
                var type = blockObj["type"]?.GetValue<string>();

                if (type == "text")
                {
                    finalText = blockObj["text"]?.GetValue<string>() ?? string.Empty;
                    assistantContent.Add(blockObj.DeepClone());
                }
                else if (type == "tool_use")
                {
                    assistantContent.Add(blockObj.DeepClone());

                    var toolName = blockObj["name"]?.GetValue<string>() ?? string.Empty;
                    var toolId = blockObj["id"]?.GetValue<string>() ?? string.Empty;
                    var toolInput = blockObj["input"]?.AsObject() ?? new JsonObject();

                    // Convert JsonObject to Dictionary for MCP
                    var args = toolInput.ToDictionary(
                        kvp => kvp.Key,
                        kvp => (object?)(kvp.Value?.GetValue<object>() ?? kvp.Value?.ToString()));

                    string toolResultText;
                    try
                    {
                        var callResult = await mcp.CallToolAsync(toolName,
                            args.ToDictionary(k => k.Key, k => k.Value));
                        toolResultText = callResult.IsError == true
                            ? "Tool returned an error."
                            : string.Join("\n", callResult.Content
                                .Where(c => c.Type == "text")
                                .Select(c => (c as ModelContextProtocol.Protocol.TextContentBlock)?.Text ?? string.Empty));
                    }
                    catch (Exception ex)
                    {
                        toolResultText = $"Error calling {toolName}: {ex.Message}";
                        logger.LogError(ex, "Tool call failed: {Tool}", toolName);
                    }

                    toolCallLog.Add(new ToolCallEntry(toolName, toolInput.ToJsonString(), toolResultText));

                    toolResults.Add(new JsonObject
                    {
                        ["type"] = "tool_result",
                        ["tool_use_id"] = toolId,
                        ["content"] = toolResultText
                    });
                }
            }

            if (stopReason != "tool_use" || toolResults.Count == 0)
                break;

            // Feed results back
            messages.Add(new JsonObject
            {
                ["role"] = "assistant",
                ["content"] = assistantContent.DeepClone()
            });
            messages.Add(new JsonObject
            {
                ["role"] = "user",
                ["content"] = toolResults.DeepClone()
            });
        }

        return Results.Ok(new ChatResponse(finalText, toolCallLog));
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger("ChatApp");
        logger.LogError(ex, "Error in /api/chat");
        return Results.Problem(detail: ex.ToString(), title: ex.Message, statusCode: 500);
    }
});

// Endpoint to list available tools (used by the UI sidebar)
app.MapGet("/api/tools", async (ILoggerFactory loggerFactory) =>
{
    var transport = new SseClientTransport(
        new SseClientTransportOptions { Endpoint = new Uri(McpServerUrl) },
        loggerFactory);

    await using var mcp = await McpClientFactory.CreateAsync(
        transport,
        new McpClientOptions { ClientInfo = new() { Name = "ChatApp", Version = "1.0.0" } },
        loggerFactory);

    var tools = await mcp.ListToolsAsync();
    return Results.Ok(tools.Select(t => new { t.Name, t.Description }));
});

await app.RunAsync();

// ── Request / response models ─────────────────────────────────────────────────
record ChatMessage(string Role, string Content);
record ChatRequest(IReadOnlyList<ChatMessage> Messages);
record ToolCallEntry(string Tool, string Input, string Output);
record ChatResponse(string Response, IReadOnlyList<ToolCallEntry> ToolCalls);
