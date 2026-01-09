using ProjectR.DTOs;
using ProjectR.Interfaces;

namespace ProjectR.Forms
{
    public partial class AddNewIssueDialog : Form
    {
        private readonly int _projectId;
        private readonly IIssuesService _issuesService;

        public AddNewIssueDialog(int projectId, IIssuesService issuesService)
        {
            _projectId = projectId;
            _issuesService = issuesService;
            InitializeComponent();
        }

        private void AddNewIssueDialog_Load(object sender, EventArgs e)
        {
            string[] severityLevels = ["Low", "Medium", "Critical"];
            string[] statusLevels = ["Investigating", "In Review", "Fixed"];

            comboBoxNewIssueSeverity.DataSource = severityLevels;
            // Default to first item as the textbox is readonly and we dont want new issues with any other status than investigating
            textBoxNewIssueStatus.Text = statusLevels[0];
            dateTimePickerNewIssue.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePickerNewIssue.Value = DateTime.Now;
        }

        private async void btnSaveNewIssue_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNewIssueTitle.Text))
            {
                MessageBox.Show("Please enter the issue title.", "Validation Error");
                return;
            }

            if (string.IsNullOrWhiteSpace(richTextBoxNewIssueDesc.Text))
            {
                MessageBox.Show("Please enter the issue description.", "Validation Error");
                return;
            }

            if (comboBoxNewIssueSeverity.SelectedItem == null)
            {
                MessageBox.Show("Please select the issue severity.", "Validation Error");
                return;
            }

            try
            {
                AddNewIssueDto newIssueDto = new()
                {
                    ProjectId = _projectId,
                    Name = textBoxNewIssueTitle.Text.Trim(),
                    Description = richTextBoxNewIssueDesc.Text.Trim(),
                    Severity = comboBoxNewIssueSeverity.SelectedItem.ToString()!,
                    Status = textBoxNewIssueStatus.Text.Trim(),
                    CreatedAt = dateTimePickerNewIssue.Value,
                };

                await _issuesService.AddNewIssue(_projectId, newIssueDto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An error occurred while adding the issue: {ex.Message}",
                    "Save Failed"
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
