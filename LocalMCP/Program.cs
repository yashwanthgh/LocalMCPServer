using MCP.External.Accessors;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LocalMCP
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, MCP Server!");

            var builder = Host.CreateEmptyApplicationBuilder(settings : null);

            builder.Services.AddMcpServer()
                .WithStdioServerTransport()
                .WithToolsFromAssembly(typeof(ExternalBooksAccessor).Assembly);

            var app = builder.Build();

            await app.RunAsync();
        }
    }
}
