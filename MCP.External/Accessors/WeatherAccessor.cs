using ModelContextProtocol.Server;
using Refit;
using System.ComponentModel;

namespace MCP.External.Accessors
{
    [McpServerToolType]
    public class WeatherAccessor
    {
        private readonly IWeatherService _weatherService;
        private readonly string apiKey = "cca5a86e94fe47bbbc3120440251809";

        public WeatherAccessor(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [McpServerTool, Description("Get current weather for a specified city")]
        public async Task<string> GetWeather(string cityName)
        {
            var apiResponse = await _weatherService.GetWeatherAsync(
                apiKey: apiKey,
                city: cityName,
                aqi: "no"
            );

            if (!apiResponse.IsSuccessStatusCode)
            {
                // log error, status code, correlation id
                return $"Error retrieving weather data for '{cityName}': {apiResponse.StatusCode}";
            }

            return apiResponse.Content ?? $"No weather data returned for '{cityName}'.";
        }
    }

    public interface IWeatherService
    {
        [Get("/v1/current.json")]
        Task<ApiResponse<string>> GetWeatherAsync(
            [AliasAs("key")] string apiKey
            , [AliasAs("q")] string city
            , [AliasAs("aqi")] string aqi);
    }
}
