using Microsoft.EntityFrameworkCore;
using ProjectR.Data;
using ProjectR.Entities;

namespace ProjectR.Forms
{
    public partial class AddNewChangeDialog : Form
    {
        private readonly Issue _issue;
        private readonly DatabaseContext _context;

        public AddNewChangeDialog(Issue issue, DatabaseContext dbContext)
        {
            _issue = issue;
            _context = dbContext;
            InitializeComponent();
        }

        private void AddNewChangeDialog_Load(object sender, EventArgs e)
        {
            dateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePicker.Value = DateTime.Now;
        }

        private async void btnSaveNewMedia_Click(object sender, EventArgs e)
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
                _ = await _context.Changes.AddAsync(
                    new Change
                    {
                        IssueId = _issue.Id,
                        ChangeHash = textBoxChangeHash.Text,
                        Name = textBoxChangeName.Text,
                        Description = richTextBoxChangeDesc.Text,
                        CreatedAt = dateTimePicker.Value,
                        Issue = _issue,
                    }
                );

                Issue issueToUpdate = await _context.Issues.Where(i => i.Id == _issue.Id).FirstAsync();

                issueToUpdate.LastUpdated = dateTimePicker.Value;

                await _context.SaveChangesAsync();
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

            await _context.SaveChangesAsync();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
