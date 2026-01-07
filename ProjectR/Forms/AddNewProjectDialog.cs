using ProjectR.DTOs;
using ProjectR.Interfaces;

namespace ProjectR.Forms
{
    public partial class AddNewProjectDialog : Form
    {
        private readonly IProjectsService _projectsService;

        public AddNewProjectDialog(IProjectsService projectsService)
        {
            _projectsService = projectsService;
            InitializeComponent();
        }

        private async void btnSaveNewProject_Click(object sender, EventArgs e)
        {
            try
            {
                await _projectsService.AddNewProject(
                    new NewProjectDto
                    {
                        Name = textBoxNewProjectName.Text,
                        CreatedAt = dateTimePickerNewProjectCreatedAt.Value,
                    }
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An error occurred while adding the new project: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            finally
            {
                Close();
            }
        }
    }
}
