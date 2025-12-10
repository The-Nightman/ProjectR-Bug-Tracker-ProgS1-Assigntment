using ProjectR.Data;

namespace ProjectR
{
    public partial class App : Form
    {
        private DatabaseContext? dbContext;

        private string currentView = "DASHBOARD";

        public App()
        {
            InitializeComponent();
        }

        private async void App_Load(object sender, EventArgs e)
        {
            dbContext = new DatabaseContext();

            await SeedData.SeedDatabase(dbContext);

            panelMainView.Controls.Add(new Controls.Dashboard(dbContext));
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
            NavigateTo(new Controls.Dashboard(dbContext!));
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
            NavigateTo(new Controls.ProjectView(dbContext!));
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

        private void NavigateTo(UserControl screen)
        {
            panelMainView.Controls.Clear();
            panelMainView.Controls.Add(screen);
        }

        private void App_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbContext?.Dispose();

            dbContext = null;
        }
    }
}
