namespace ProjectR.Classes
{
    public class MediaDisplay(
        int mediaId,
        string title,
        string description,
        string path,
        int issueId
    )
    {
        private readonly int _mediaId = mediaId;
        private string _title = title;
        private string _description = description;
        private string _path = path;
        private readonly int _issueId = issueId;

        public int MediaId
        {
            get => _mediaId;
        }

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public string Path
        {
            get => _path;
            set => _path = value;
        }

        public int IssueId
        {
            get => _issueId;
        }
    }
}
