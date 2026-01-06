using ProjectR.Classes;
using ProjectR.Data;
using ProjectR.Interfaces;

namespace ProjectR.Controls
{
    public partial class ProjectCard : UserControl
    {
        private readonly int _projId;
        private readonly Navigation _mainNav;
        private readonly DatabaseContext _context;
        private readonly IProjectsService _projectsService;
        private readonly IGraphDataService _graphService;

        public ProjectCard(
            ProjectPreview previewData,
            DatabaseContext dbContext,
            Navigation mainNav,
            IProjectsService projectsService,
            IGraphDataService graphService
        )
        {
            _projId = previewData.ProjectId;
            _mainNav = mainNav;
            _context = dbContext;
            _projectsService = projectsService;
            _graphService = graphService;
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
            _mainNav.UseNavigate(new ProjectView(_context, _mainNav, _projId, _projectsService, _graphService));
        }
    }
}
