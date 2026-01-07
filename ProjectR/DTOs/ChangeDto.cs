namespace ProjectR.DTOs
{
    public class ChangeDto
    {
        public int Id { get; set; }
        public string ChangeHash { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int IssueId { get; set; }
    }
}
