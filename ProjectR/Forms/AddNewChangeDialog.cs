using ProjectR.DTOs;
using ProjectR.Interfaces;

namespace ProjectR.Forms
{
    public partial class AddNewChangeDialog : Form
    {
        private readonly int _issueId;
        private readonly IIssuesService _issuesService;

        public AddNewChangeDialog(int issueId, IIssuesService issueService)
        {
            _issueId = issueId;
            _issuesService = issueService;
            InitializeComponent();
        }

        private void AddNewChangeDialog_Load(object sender, EventArgs e)
        {
            dateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePicker.Value = DateTime.Now;
        }

        private async void btnSaveNewChange_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxChangeHash.Text))
            {
                MessageBox.Show("Please enter the git change hash.", "Validation Error");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxChangeName.Text))
            {
                MessageBox.Show("Please enter the change name.", "Validation Error");
                return;
            }

            if (string.IsNullOrWhiteSpace(richTextBoxChangeDesc.Text))
            {
                MessageBox.Show("Please enter the change description.", "Validation Error");
                return;
            }

            try
            {
                await _issuesService.AddNewChange(
                    _issueId,
                    new NewChangeDto
                    {
                        ChangeHash = textBoxChangeHash.Text,
                        Name = textBoxChangeName.Text,
                        Description = richTextBoxChangeDesc.Text,
                        CreatedAt = dateTimePicker.Value
                    }
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An error occurred while adding the change: {ex.Message}",
                    "Save Failed"
                );
                return;
            }
            finally
            {
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
