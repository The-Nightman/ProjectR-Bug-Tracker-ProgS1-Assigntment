using ProjectR.Classes;
using ProjectR.DTOs;
using ProjectR.Interfaces;

namespace ProjectR.Forms
{
    public partial class OpenChangeDialog : Form
    {
        private readonly int _changeId;
        private readonly IIssuesService _issuesService;

        public OpenChangeDialog(
            int changeId,
            IIssuesService issuesService
        )
        {
            _changeId = changeId;
            _issuesService = issuesService;
            InitializeComponent();
        }

        private async void OpenChangeDialog_Load(object sender, EventArgs e)
        {
            dateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm";

            ChangeDisplay change = await _issuesService.GetChangeById(_changeId);

            textBoxChangeHash.Text = change.ChangeHash;
            textBoxChangeName.Text = change.Name;
            richTextBoxChangeDesc.Text = change.Description;
            dateTimePicker.Value = change.CreatedAt;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnSaveEditChange_Click(object sender, EventArgs e)
        {
            if (textBoxChangeName.ReadOnly == true)
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to continue? Think about if this is necessary and what details need to be changed",
                    "Are you sure?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.No)
                {
                    return;
                }

                textBoxChangeName.ReadOnly = false;
                textBoxChangeHash.ReadOnly = false;
                richTextBoxChangeDesc.ReadOnly = false;
                dateTimePicker.Enabled = true;
                btnSaveEditChange.Text = "Save";
                btnSaveEditChange.AccessibleDescription = "Save Change Details";
                btnSaveEditChange.BackColor = Color.LawnGreen;
            }
            else
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to continue? These changes will be irreversible",
                    "Are you sure?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.No)
                {
                    return;
                }

                try
                {
                    await _issuesService.UpdateChange(
                        new EditChangeDto
                        {
                            Id = _changeId,
                            ChangeHash = textBoxChangeHash.Text,
                            Name = textBoxChangeName.Text,
                            Description = richTextBoxChangeDesc.Text,
                            CreatedAt = dateTimePicker.Value,
                        }
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"An error occurred while saving the change: {ex.Message}",
                        "Save Failed"
                    );
                    return;
                }

                textBoxChangeName.ReadOnly = true;
                textBoxChangeHash.ReadOnly = true;
                richTextBoxChangeDesc.ReadOnly = true;
                dateTimePicker.Enabled = false;
                btnSaveEditChange.Text = "Edit";
                btnSaveEditChange.AccessibleDescription = "Edit Change Details";
                btnSaveEditChange.BackColor = Color.DodgerBlue;
            }
        }
    }
}
