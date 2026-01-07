using ProjectR.Classes;
using ProjectR.Interfaces;

namespace ProjectR.Controls
{
    public partial class ProjectCard : UserControl
    {
        private readonly ProjectPreview _projData;
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
            _projData = previewData;
            _mainNav = mainNav;
            _projectsService = projectsService;
            _graphService = graphService;
            _issuesService = issuesService;
            InitializeComponent();
        }

        // Accessibility solution taken and adapted from: https://stackoverflow.com/a/3562449

        private void ProjectCard_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.Selectable, true);
            TabStop = true;
            AccessibleName = $"{_projData.ProjectName} ProjectCard";
            AccessibleDescription = $"Click to view project {_projData.ProjectName}";

            lblProjCardTitle.Text = _projData.ProjectName;
            lblProjOpenIssues.Text = $"Open Issues: {_projData.OpenIssues}";
            lblProjCritIssues.Text = $"Critical: {_projData.CriticalIssues}";
            lblProjThisWeek.Text = $"This Week: {_projData.ThisWeekIssues}";
            lblProjLastActive.Text = $"Last Active: {_projData.LastUpdatedToString()}";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Region = new Region(Utils.PaintRoundedCorners(this, 10));

            base.OnPaint(e);

            if (Focused)
            {
                var rc = ClientRectangle;
                rc.Inflate(-2, -2);
                ControlPaint.DrawFocusRectangle(e.Graphics, rc);
            }
        }

        private void ProjectCard_Click(object sender, EventArgs e)
        {
            _mainNav.UseNavigate(
                new ProjectView(
                    _mainNav,
                    _projData.ProjectId,
                    _projectsService,
                    _graphService,
                    _issuesService
                )
            );
        }

        private void ProjectCard_Enter(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void ProjectCard_Leave(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void ProjectCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            _mainNav.UseNavigate(
                new ProjectView(
                    _mainNav,
                    _projData.ProjectId,
                    _projectsService,
                    _graphService,
                    _issuesService
                )
            );
        }
    }
}
