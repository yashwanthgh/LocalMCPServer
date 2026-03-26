using MCP.External.Accessors;
using Polly;
using Polly.Extensions.Http;
using Refit;

namespace LocalMCP
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddMcpServer()
                .WithHttpTransport()
                .WithToolsFromAssembly(typeof(ExternalBooksAccessor).Assembly);

            builder.Services.AddRefitClient<IWeatherService>()
                .ConfigureHttpClient(client =>
                {
                    client.BaseAddress = new Uri("http://api.weatherapi.com/");
                    client.Timeout = TimeSpan.FromSeconds(10);
                })
                .AddPolicyHandler(GetRetryPolicy())
                .AddPolicyHandler(GetCircuitBreakerPolicy());

            var app = builder.Build();

            app.MapGet("/health", () => Results.Ok("Healthy"));

            app.MapMcp();

            await app.RunAsync();

        }

        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()   // 5xx, 408
                .WaitAndRetryAsync(
                    retryCount: 3,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (outcome, timespan, retryCount, context) =>
                    {
                        // log retry attempt here
                    });
        }

        static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(
                    handledEventsAllowedBeforeBreaking: 5,
                    durationOfBreak: TimeSpan.FromSeconds(30));
        }
    }
}
