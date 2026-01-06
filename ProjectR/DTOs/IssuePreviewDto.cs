namespace ProjectR.DTOs
{
    public class IssuePreviewDto
    {
        public int IssueId { get; set; }
        public string IssueName { get; set; }
        public int ChangesCount { get; set; }
        public string Status { get; set; }
        public string Severity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
