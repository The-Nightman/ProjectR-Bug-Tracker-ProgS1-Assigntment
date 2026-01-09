namespace ProjectR.DTOs
{
    public class AddNewIssueDto
    {
        public required int ProjectId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Severity { get; set; }
        public required string Status { get; set; }
        public required DateTime CreatedAt { get; set; }
    }
}
