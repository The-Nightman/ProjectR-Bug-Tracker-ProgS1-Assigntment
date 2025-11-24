using ProjectR.Classes;
using System.Windows.Forms;

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

        private void ProjectCard_Click(object sender, System.EventArgs e)
        {
            DialogResult notyetimplemented = MessageBox.Show("NOT YET IMPLEMENTED", "ProjectR", MessageBoxButtons.OK);
        }
    }
}
