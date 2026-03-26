using System.Text.Json.Serialization;

namespace MCP.External.Entities
{
    public class LytxUser
    {
        public string? Name { get; set; }

        [JsonPropertyName("Employee Id")]
        public string? EmployeeId { get; set; }

        [JsonPropertyName("Roles (Group)")]
        public string? RolesGroup { get; set; }

        public string? Status { get; set; }

        public string? Login { get; set; }

        public string? Username { get; set; }

        [JsonPropertyName("Last Login Date")]
        public string? LastLoginDate { get; set; }
    }
}
