namespace MCP.External.Entities
{
    public class PositiveRecognition
    {
        public int RecognitionId { get; set; }
        public string? Type { get; set; }
        public string? Driver { get; set; }
        public string? EventId { get; set; }
        public string? IssuedBy { get; set; }
        public string? IssuedDate { get; set; }
        public string? RecognitionReason { get; set; }
        public string? Group { get; set; }
    }
}
