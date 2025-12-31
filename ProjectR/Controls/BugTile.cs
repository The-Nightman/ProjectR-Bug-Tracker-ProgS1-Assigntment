using ProjectR.Classes;
using ProjectR.Data;

namespace ProjectR.Controls
{
    public partial class BugTile : UserControl
    {
        private IssueListItem _issueData;
        private readonly Navigation _mainNav;
        private readonly DatabaseContext _context;

        public BugTile(DatabaseContext dbContext, Navigation mainNav, IssueListItem issueData)
        {
            _issueData = issueData;
            _mainNav = mainNav;
            _context = dbContext;
            InitializeComponent();
        }

        private void BugTile_Load(object sender, EventArgs e)
        {
            lblBugTitle.Text = _issueData.Title;
            lblBugChanges.Text = $"Changes: {_issueData.ChangesCount}";
            lblBugStatus.Text = _issueData.Status;
            lblBugSeverityTitle.Text = $"Severity: {_issueData.Severity}";
            lblBugLastUpdatedAt.Text = $"Last Update: {_issueData.LastUpdatedToString()}";
            lblBugCreatedAt.Text = $"Created: {_issueData.CreatedAtToString()}";
        }
    }
}
