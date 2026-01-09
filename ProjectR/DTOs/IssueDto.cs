namespace ProjectR.DTOs
{
    public class IssueDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Severity { get; set; }
        public string Status { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<ChangeDto> Changes { get; set; } = [];
        public List<MediaDto> Media { get; set; } = [];
        public int ProjectId { get; set; }
    }
}
