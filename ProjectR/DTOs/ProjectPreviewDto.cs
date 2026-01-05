namespace ProjectR.DTOs
{
    public class ProjectPreviewDto
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public int OpenIssues { get; set; }

        public int CriticalIssues { get; set; }

        public int ThisWeekIssues { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
