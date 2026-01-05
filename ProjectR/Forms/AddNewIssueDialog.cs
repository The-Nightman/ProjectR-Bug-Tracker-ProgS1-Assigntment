using ProjectR.Data;
using ProjectR.Entities;

namespace ProjectR.Forms
{
    public partial class AddNewIssueDialog : Form
    {
        private readonly Project _project;
        private readonly DatabaseContext _context;

        public AddNewIssueDialog(Project project, DatabaseContext dbContext)
        {
            _project = project;
            _context = dbContext;
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
                _ = await _context.Issues.AddAsync(
                    new Issue
                    {
                        ProjectId = _project.Id,
                        Name = textBoxNewIssueTitle.Text,
                        Description = richTextBoxNewIssueDesc.Text,
                        Severity = comboBoxNewIssueSeverity.SelectedItem.ToString()!,
                        Status = textBoxNewIssueStatus.Text,
                        CreatedAt = dateTimePickerNewIssue.Value,
                        LastUpdated = dateTimePickerNewIssue.Value,
                        Media = [],
                        Changes = [],
                        Project = _project,
                    }
                );

                await _context.SaveChangesAsync();
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

            await _context.SaveChangesAsync();
        }
    }
}
