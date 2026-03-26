using MCP.External.Data;
using MCP.External.Entities;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;

namespace MCP.External.Accessors
{
    [McpServerToolType]
    internal class RecognitionHistoryAccessor
    {
        #region Private Methods

        private async Task<List<PositiveRecognition>> GetRecognitionHistory()
        {
            using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(RecognitionHistoryStaticResource.RecognitionHistoryJson));
            var jsonDoc = await JsonDocument.ParseAsync(stream);
            var recognitionHistoryElement = jsonDoc.RootElement.GetProperty("recognitionHistory");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var recognitionHistory = JsonSerializer.Deserialize<List<PositiveRecognition>>(recognitionHistoryElement.GetRawText(), options);
            return recognitionHistory ?? new List<PositiveRecognition>();
        }

        private async Task<string> GetRecognitionHistoryAsString(List<PositiveRecognition>? recognitionHistory)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var recognitionHistoryToSerialize = recognitionHistory ?? new List<PositiveRecognition>();
            using var stream = new MemoryStream();
            await JsonSerializer.SerializeAsync(stream, recognitionHistoryToSerialize, options);
            stream.Position = 0;
            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }

        #endregion

        #region Public Methods

        [McpServerTool, Description("Get all Recognition History")]
        public async Task<string> GetAllRecognitionHistory()
        {
            return await GetRecognitionHistoryAsString(await GetRecognitionHistory());
        }

        [McpServerTool, Description("Get Recognition History by driver or issued by")]
        public async Task<string> GetRecognitionHistoryByUser(string user)
        {
            var recognitionHistory = await GetRecognitionHistory();
            var filteredRecognitionHistory = recognitionHistory.Where(recognition =>
                recognition.Driver != null && recognition.Driver.Equals(user, StringComparison.OrdinalIgnoreCase)
                || recognition.IssuedBy != null && recognition.IssuedBy.Equals(user, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            return await GetRecognitionHistoryAsString(filteredRecognitionHistory);
        }

        [McpServerTool, Description("Get Recognition History by type")]
        public async Task<string> GetRecognitionHistoryByType(string type)
        {
            var recognitionHistory = await GetRecognitionHistory();
            var filteredRecognitionHistory = recognitionHistory.Where(recognition =>
                recognition.Type != null && recognition.Type.Equals(type, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            return await GetRecognitionHistoryAsString(filteredRecognitionHistory);
        }

        [McpServerTool, Description("Get Recognition History by group")]
        public async Task<string> GetRecognitionHistoryByGroup(string group)
        {
            var recognitionHistory = await GetRecognitionHistory();
            var filteredRecognitionHistory = recognitionHistory.Where(recognition =>
                recognition.Group != null && recognition.Group.Contains(group, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            return await GetRecognitionHistoryAsString(filteredRecognitionHistory);
        }

        [McpServerTool, Description("Get Recognition History by event ID")]
        public async Task<string> GetRecognitionHistoryByEventId(string eventId)
        {
            var recognitionHistory = await GetRecognitionHistory();
            var filteredRecognitionHistory = recognitionHistory.Where(recognition =>
                recognition.EventId != null && recognition.EventId.Equals(eventId, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            return await GetRecognitionHistoryAsString(filteredRecognitionHistory);
        }

        [McpServerTool, Description("Get Recognition History by issued date")]
        public async Task<string> GetRecognitionHistoryByDate(string issuedDate)
        {
            var recognitionHistory = await GetRecognitionHistory();
            var filteredRecognitionHistory = recognitionHistory.Where(recognition =>
                recognition.IssuedDate != null && recognition.IssuedDate.Equals(issuedDate, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            return await GetRecognitionHistoryAsString(filteredRecognitionHistory);
        }

        [McpServerTool, Description("Search Recognition History by keyword in recognition reason")]
        public async Task<string> SearchRecognitionHistoryByReason(string keyword)
        {
            var recognitionHistory = await GetRecognitionHistory();
            var filteredRecognitionHistory = recognitionHistory.Where(recognition =>
                recognition.RecognitionReason != null && recognition.RecognitionReason.Contains(keyword, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            return await GetRecognitionHistoryAsString(filteredRecognitionHistory);
        }

        #endregion
    }
}
