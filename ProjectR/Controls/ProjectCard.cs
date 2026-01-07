using ProjectR.Classes;
using ProjectR.Interfaces;

namespace ProjectR.Controls
{
    public partial class ProjectCard : UserControl
    {
        private readonly int _projId;
        private readonly Navigation _mainNav;
        private readonly IProjectsService _projectsService;
        private readonly IGraphDataService _graphService;
        private readonly IIssuesService _issuesService;

        public ProjectCard(
            ProjectPreview previewData,
            Navigation mainNav,
            IProjectsService projectsService,
            IGraphDataService graphService,
            IIssuesService issuesService
            )
        {
            _projId = previewData.ProjectId;
            _mainNav = mainNav;
            _projectsService = projectsService;
            _graphService = graphService;
            _issuesService = issuesService;
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
            _mainNav.UseNavigate(new ProjectView(_mainNav, _projId, _projectsService, _graphService, _issuesService));
        }
    }
}
