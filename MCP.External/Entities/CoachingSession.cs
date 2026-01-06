namespace MCP.External.Entities
{
    public class CoachingSession
    {
        public int CoachingSessionId { get; set; }
        public string? Coach { get; set; }
        public string? Driver { get; set; }
        public DateTime CoachingDate { get; set; }
        public string? CoachingSessionNotes { get; set; }
        public string? CoachingSessionActionPlan { get; set; }
    }
}
