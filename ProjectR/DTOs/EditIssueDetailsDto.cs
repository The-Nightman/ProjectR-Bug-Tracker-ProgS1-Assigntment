namespace ProjectR.DTOs
{
    public class EditIssueDetailsDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Severity { get; set; }
        public required string Status { get; set; }
    }
}
