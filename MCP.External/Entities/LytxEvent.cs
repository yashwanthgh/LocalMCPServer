using System.Text.Json.Serialization;

namespace MCP.External.Entities
{
    public class LytxEvent
    {
        [JsonPropertyName("Event ID")]
        public string? EventId { get; set; }

        public string? Driver { get; set; }

        [JsonPropertyName("Employee ID")]
        public string? EmployeeId { get; set; }

        public string? Group { get; set; }

        public string? Vehicle { get; set; }

        public string? Device { get; set; }

        public string? Date { get; set; }

        public string? Time { get; set; }

        public string? Score { get; set; }

        public string? Status { get; set; }

        public string? Trigger { get; set; }

        public string? Behaviors { get; set; }
    }
}
