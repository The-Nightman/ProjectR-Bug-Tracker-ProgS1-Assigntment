namespace ProjectR.Classes
{
    public class ChangeDisplay(
        int changeId,
        string changeHash,
        string name,
        string description,
        DateTime createdAt,
        int issueId
    )
    {
        private readonly int _changeId = changeId;
        private string _changeHash = changeHash;
        private string _name = name;
        private string _description = description;
        private DateTime _createdAt = createdAt;
        private readonly int _issueId = issueId;

        public int ChangeId
        {
            get => _changeId;
        }

        public string ChangeHash
        {
            get => _changeHash;
            set => _changeHash = value;
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

        public DateTime CreatedAt
        {
            get => _createdAt;
            set => _createdAt = value;
        }

        public int IssueId
        {
            get => _issueId;
        }
    }
}
