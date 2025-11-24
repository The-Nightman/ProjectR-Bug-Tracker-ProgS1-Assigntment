using System;

namespace ProjectR.Classes
{
    public class ProjectPreview
    {
        private string _projectName;
        private int _openIssues;
        private int _criticalIssues;
        private int _thisWeekIssues;
        private DateTime _lastUpdated;

        public ProjectPreview(string projectName, int openIssues, int criticalIssues, int thisWeekIssues, DateTime lastUpdated)
        {
            _projectName = projectName;
            _openIssues = openIssues;
            _criticalIssues = criticalIssues;
            _thisWeekIssues = thisWeekIssues;
            _lastUpdated = lastUpdated;
        }

        public string ProjectName
        {
            get => _projectName;
            set => _projectName = value;
        }

        public int OpenIssues
        {
            get => _openIssues;
            set => _openIssues = value;
        }

        public int CriticalIssues
        {
            get => _criticalIssues;
            set => _criticalIssues = value;
        }

        public int ThisWeekIssues
        {
            get => _thisWeekIssues;
            set => _thisWeekIssues = value;
        }

        public DateTime LastUpdated
        {
            get => _lastUpdated;
            set => _lastUpdated = value;
        }

        public string LastUpdatedToString()
        {
            if (_lastUpdated == DateTime.Now)
            {
                return "Today";
            }
            else if (_lastUpdated == DateTime.Now.AddDays(-1))
            {
                return "Yesterday";
            }
            else
            {
                return _lastUpdated.ToString("dd/MM/yyyy");
            }
        }
    }
}
