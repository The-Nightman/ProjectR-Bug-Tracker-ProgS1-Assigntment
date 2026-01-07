namespace ProjectR.Classes
{
    public class IssueDisplay(
        int issueId,
        string name,
        string description,
        string severity,
        string status,
        DateTime createdAt,
        DateTime lastUpdated,
        List<ChangeDisplay> changesList,
        List<MediaDisplay> mediaList,
        int projectId
    )
    {
        private readonly int _issueId = issueId;
        private string _name = name;
        private string _description = description;
        private string _severity = severity;
        private string _status = status;
        private DateTime _createdAt = createdAt;
        private DateTime _lastUpdated = lastUpdated;
        private List<ChangeDisplay> _changesList = changesList;
        private List<MediaDisplay> _mediaList = mediaList;
        private readonly int _projectId = projectId;

        public int IssueId
        {
            get => _issueId;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public string Severity
        {
            get => _severity;
            set => _severity = value;
        }

        public string Status
        {
            get => _status;
            set => _status = value;
        }

        public DateTime CreatedAt
        {
            get => _createdAt;
            set => _createdAt = value;
        }

        public DateTime LastUpdated
        {
            get => _lastUpdated;
            set => _lastUpdated = value;
        }

        public List<ChangeDisplay> ChangesList
        {
            get => _changesList;
            set => _changesList = value;
        }

        public List<MediaDisplay> MediaList
        {
            get => _mediaList;
            set => _mediaList = value;
        }

        public int ProjectId
        {
            get => _projectId;
        }
    }
}
