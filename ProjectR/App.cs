using ProjectR.Classes;
using ProjectR.Controls;
using ProjectR.Data;
using ProjectR.Data.Repositories;
using ProjectR.Interfaces;
using ProjectR.Services;

namespace ProjectR
{
    public partial class App : Form
    {
        private Navigation? mainNav;
        private DatabaseContext? dbContext;
        private IProjectsRepository? projectsRepository;
        private IProjectsService? projectsService;
        private IGraphDataRepository? graphRepository;
        private IGraphDataService? graphService;
        private IIssuesRepository? issuesRepository;
        private IIssuesService? issuesService;

        private string currentView = "DASHBOARD";

        public App()
        {
            InitializeComponent();
        }

        private async void App_Load(object sender, EventArgs e)
        {
            mainNav = new(panelMainView);
            dbContext = new DatabaseContext();
            projectsRepository = new ProjectsRepository(dbContext);
            projectsService = new ProjectsService(projectsRepository);
            graphRepository = new GraphDataRepository(dbContext);
            graphService = new GraphDataService(graphRepository);
            issuesRepository = new IssuesRepository(dbContext);
            issuesService = new IssuesService(issuesRepository);

            await SeedData.SeedDatabase(dbContext);

            mainNav!.UseNavigate(new Dashboard(mainNav, projectsService, graphService, issuesService));
            imageListNavbarIconsControl.Images.Add(
                "dashboardDarkActive",
                Properties.Resources.dashboardIconStateActiveDark
            );
            imageListNavbarIconsControl.Images.Add(
                "dashboardDarkInactive",
                Properties.Resources.dashboardIconStateInactiveDark
            );
            imageListNavbarIconsControl.Images.Add(
                "projectsDarkActive",
                Properties.Resources.projectsIconStateActiveDark
            );
            imageListNavbarIconsControl.Images.Add(
                "projectsDarkInactive",
                Properties.Resources.projectsIconStateInactiveDark
            );
            btnNavbarDashboard.ForeColor = ColorTranslator.FromHtml("#DEB660");
            btnNavbarDashboard.ImageKey = "dashboardDarkActive";
            btnNavbarProjects.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnNavbarProjects.ImageKey = "projectsDarkInactive";
        }

        private void btnNavbarDashboard_Click(object sender, EventArgs e)
        {
            if (currentView == "DASHBOARD")
                return;

            currentView = "DASHBOARD";
            mainNav!.UseNavigate(new Dashboard(mainNav, projectsService!, graphService!, issuesService));
            btnNavbarDashboard.ForeColor = ColorTranslator.FromHtml("#DEB660");
            btnNavbarDashboard.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml(
                "#33DEB660"
            );
            btnNavbarDashboard.ImageKey = "dashboardDarkActive";
            btnNavbarProjects.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnNavbarProjects.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml(
                "#575757"
            );
            btnNavbarProjects.ImageKey = "projectsDarkInactive";
        }

        private void btnNavbarProjects_Click(object sender, EventArgs e)
        {
            if (currentView == "PROJECTS")
                return;

            currentView = "PROJECTS";
            //mainNav!.UseNavigate(new Controls.ProjectView(dbContext!, mainNav, ));
            btnNavbarDashboard.ForeColor = ColorTranslator.FromHtml("#ffffff");
            btnNavbarDashboard.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml(
                "#575757"
            );
            btnNavbarDashboard.ImageKey = "dashboardDarkInactive";
            btnNavbarProjects.ForeColor = ColorTranslator.FromHtml("#DEB660");
            btnNavbarProjects.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml(
                "#33DEB660"
            );
            btnNavbarProjects.ImageKey = "projectsDarkActive";
        }

        private void App_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbContext?.Dispose();

            dbContext = null;
        }
    }
}
