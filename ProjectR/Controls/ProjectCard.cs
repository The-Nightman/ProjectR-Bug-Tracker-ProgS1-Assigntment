using ProjectR.Classes;
using ProjectR.Data;

namespace ProjectR.Controls
{
    public partial class ProjectCard : UserControl
    {
        private readonly int _projId;
        private readonly Navigation _mainNav;
        private readonly DatabaseContext _context;

        public ProjectCard(
            ProjectPreview previewData,
            DatabaseContext dbContext,
            Navigation mainNav
        )
        {
            _projId = previewData.ProjectId;
            _mainNav = mainNav;
            _context = dbContext;
            InitializeComponent();

            lblProjCardTitle.Text = previewData.ProjectName;
            lblProjOpenIssues.Text = $"Open Issues: {previewData.OpenIssues}";
            lblProjCritIssues.Text = $"Critical: {previewData.CriticalIssues}";
            lblProjThisWeek.Text = $"This Week: {previewData.ThisWeekIssues}";
            lblProjLastActive.Text = $"Last Active: {previewData.LastUpdatedToString()}";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Region = new Region(Utils.PaintRoundedCorners(this, 10));

            base.OnPaint(e);
        }

        private void ProjectCard_Click(object sender, EventArgs e)
        {
            _mainNav.UseNavigate(new ProjectView(_context, _mainNav, _projId));
        }
    }
}
