namespace ProjectR.Classes
{
    public class IssueListItem(int id, string title, int changesCount, string status, string severity, DateTime createdAt, DateTime lastUpdated)
    {
        private readonly int _id = id;
        private string _title = title;
        private int _changesCount = changesCount;
        private string _status = status;
        private string _severity = severity;
        private DateTime _createdAt = createdAt;
        private DateTime _lastUpdated = lastUpdated;

        public int Id
        {
            get => _id;
        }

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public int ChangesCount
        {
            get => _changesCount;
            set => _changesCount = value;
        }

        public string Status
        {
            get => _status;
            set => _status = value;
        }

        public string Severity
        {
            get => _severity;
            set => _severity = value;
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

        public string CreatedAtToString()
        {
            if (_createdAt.Date == DateTime.Now.Date)
            {
                return $"Today";
            }
            else if (_createdAt.Date == DateTime.Now.AddDays(-1))
            {
                return "Yesterday";
            }
            else
            {
                return _createdAt.ToString("dd/MM/yyyy");
            }
        }

        public string LastUpdatedToString()
        {
            if (_lastUpdated.Date == DateTime.Now.Date)
            {
                return $"Today";
            }
            else if (_lastUpdated.Date == DateTime.Now.AddDays(-1))
            {
                return $"Yesterday";
            }
            else
            {
                return _lastUpdated.ToString("dd/MM/yyyy");
            }
        }
    }
}
