using ModelContextProtocol.Server;
using System.ComponentModel;

namespace MCP.External.Accessors
{
    [McpServerToolType]
    public class ExternalWeatherAccessor
    {
        private readonly HttpClient _httpClient;

        private ExternalWeatherAccessor()
        {
            _httpClient = new HttpClient();
        }

        [McpServerTool, Description("Get current weather information for a specified city.")]
        public async Task<string> GetWeatherAsync(string cityName)
        {
            var apiUrl = $"http://api.weatherapi.com/v1/current.json?key={"cca5a86e94fe47bbbc3120440251809"}&q={cityName}&aqi=no";

            try
            {
                HttpResponseMessage responseMessage = await _httpClient.GetAsync(apiUrl);

                responseMessage.EnsureSuccessStatusCode();

                var responseContent = await responseMessage.Content.ReadAsStringAsync();

                return responseContent;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                return null;
            }
        }
    }
}
