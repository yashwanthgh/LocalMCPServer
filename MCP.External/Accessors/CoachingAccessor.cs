using MCP.External.Data;
using MCP.External.Entities;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;

namespace MCP.External.Accessors
{
    [McpServerToolType]
    public class CoachingAccessor
    {
        #region Private Methods

        private async Task<List<CoachingSession>> GetCoachingSessions()
        {
            using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(CoachingStaticResource.CoachingSessions));
            var jsonDoc = await JsonDocument.ParseAsync(stream);
            var coachingSessionsElement = jsonDoc.RootElement.GetProperty("coachingSessions");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var coachingSessions = JsonSerializer.Deserialize<List<CoachingSession>>(coachingSessionsElement.GetRawText(), options);
            return coachingSessions ?? new List<CoachingSession>();
        }

        private async Task<string> GetCoachingSessionsAsString(List<CoachingSession>? coachingSessions)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var coachingSessionsToSerialize = coachingSessions ?? new List<CoachingSession>();
            using var stream = new MemoryStream();
            await JsonSerializer.SerializeAsync(stream, coachingSessionsToSerialize, options);
            stream.Position = 0;
            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }

        #endregion

        #region Public Methods

        [McpServerTool, Description("Get all coaching sessions")]
        public async Task<string> GetAllCoachingSessions()
        {
            return await GetCoachingSessionsAsString(await GetCoachingSessions());
        }

        [McpServerTool, Description("Get coaching sessions by coach or driver name")]
        public async Task<string> GetCoachingSessionsByUser(string user)
        {
            var coachingSessions = await GetCoachingSessions();
            var filteredCoachingSessions = coachingSessions.Where(coachingSession =>
            coachingSession.Coach != null && coachingSession.Coach.Equals(user, StringComparison.OrdinalIgnoreCase)
            || coachingSession.Driver != null && coachingSession.Driver.Equals(user, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            return await GetCoachingSessionsAsString(filteredCoachingSessions);
        }

        [McpServerTool, Description("Get coaching sessions by date")]
        public async Task<string> GetCoachingSessionsByDate(DateTime date)
        {
            var coachingSessions = await GetCoachingSessions();
            var filteredCoachingSessions = coachingSessions.Where(coachingSession =>
            coachingSession.CoachingDate != DateTime.MinValue && coachingSession.CoachingDate == date
            ).ToList();

            return await GetCoachingSessionsAsString(filteredCoachingSessions);
        }

        #endregion
    }
}
