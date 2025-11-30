using ProjectR.Classes;

namespace ProjectR.Controls
{
    public partial class ProjectCard : UserControl
    {
        public ProjectCard(ProjectPreview previewData)
        {
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
            _ = MessageBox.Show("NOT YET IMPLEMENTED", "ProjectR", MessageBoxButtons.OK);
        }
    }
}
