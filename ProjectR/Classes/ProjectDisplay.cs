namespace ProjectR.Classes
{
    public class ProjectDisplay(int projectId, string projectName, DateTime createdAt, List<IssueListItem> issues)
    {
        private readonly int _projectId = projectId;
        private string _projectName = projectName;
        private DateTime _createdAt = createdAt;
        private List<IssueListItem> _issues = issues;

        public int ProjectId
        {
            get => _projectId;
        }

        public string ProjectName
        {
            get => _projectName;
            set => _projectName = value;
        }

        public DateTime CreatedAt
        {
            get => _createdAt;
            set => _createdAt = value;
        }

        public List<IssueListItem> Issues
        {
            get => _issues;
            set => _issues = value;
        }
    }
}
