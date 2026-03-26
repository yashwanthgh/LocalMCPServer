using MCP.External.Data;
using MCP.External.Entities;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;

namespace MCP.External.Accessors
{
    [McpServerToolType]
    public class RecognitionAccessor
    {
        #region Private Methods

        private async Task<List<PositiveRecognition>> GetRecognition()
        {
            using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(RecognitionHistoryStaticResource.RecognitionHistoryJson));
            var jsonDoc = await JsonDocument.ParseAsync(stream);
            var recognitionElement = jsonDoc.RootElement.GetProperty("recognitionHistory");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var recognition = JsonSerializer.Deserialize<List<PositiveRecognition>>(recognitionElement.GetRawText(), options);
            return recognition ?? new List<PositiveRecognition>();
        }

        private async Task<string> GetRecognitionAsString(List<PositiveRecognition>? recognition)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var recognitionToSerialize = recognition ?? new List<PositiveRecognition>();
            using var stream = new MemoryStream();
            await JsonSerializer.SerializeAsync(stream, recognitionToSerialize, options);
            stream.Position = 0;
            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }

        #endregion

        #region Public Methods

        [McpServerTool, Description("Get all recognition records")]
        public async Task<string> GetAllRecognition()
        {
            return await GetRecognitionAsString(await GetRecognition());
        }

        [McpServerTool, Description("Get recognition records by driver or issued-by name")]
        public async Task<string> GetRecognitionByUser(string user)
        {
            var recognition = await GetRecognition();
            var filtered = recognition.Where(r =>
                r.Driver != null && r.Driver.Equals(user, StringComparison.OrdinalIgnoreCase)
                || r.IssuedBy != null && r.IssuedBy.Equals(user, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            return await GetRecognitionAsString(filtered);
        }

        [McpServerTool, Description("Get recognition records by type (e.g. Event Recognition, Driver Recognition)")]
        public async Task<string> GetRecognitionByType(string type)
        {
            var recognition = await GetRecognition();
            var filtered = recognition.Where(r =>
                r.Type != null && r.Type.Equals(type, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            return await GetRecognitionAsString(filtered);
        }

        [McpServerTool, Description("Get recognition records by group")]
        public async Task<string> GetRecognitionByGroup(string group)
        {
            var recognition = await GetRecognition();
            var filtered = recognition.Where(r =>
                r.Group != null && r.Group.Contains(group, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            return await GetRecognitionAsString(filtered);
        }

        [McpServerTool, Description("Get recognition records by event ID")]
        public async Task<string> GetRecognitionByEventId(string eventId)
        {
            var recognition = await GetRecognition();
            var filtered = recognition.Where(r =>
                r.EventId != null && r.EventId.Equals(eventId, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            return await GetRecognitionAsString(filtered);
        }

        [McpServerTool, Description("Get recognition records by issued date")]
        public async Task<string> GetRecognitionByDate(string issuedDate)
        {
            var recognition = await GetRecognition();
            var filtered = recognition.Where(r =>
                r.IssuedDate != null && r.IssuedDate.Equals(issuedDate, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            return await GetRecognitionAsString(filtered);
        }

        [McpServerTool, Description("Get recognition records by keyword in recognition reason")]
        public async Task<string> GetRecognitionByReason(string keyword)
        {
            var recognition = await GetRecognition();
            var filtered = recognition.Where(r =>
                r.RecognitionReason != null && r.RecognitionReason.Contains(keyword, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            return await GetRecognitionAsString(filtered);
        }

        #endregion
    }
}
