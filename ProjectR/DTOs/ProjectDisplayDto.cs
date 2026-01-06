namespace ProjectR.DTOs
{
    public class ProjectDisplayDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public List<IssuePreviewDto> Issues { get; set; } = [];
    }
}
