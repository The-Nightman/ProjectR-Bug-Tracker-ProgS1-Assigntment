using ProjectR.Data;
using ProjectR.Entities;

namespace ProjectR.Forms
{
    public partial class OpenChangeDialog : Form
    {
        private readonly int _changeId;
        private readonly DatabaseContext _context;
        private Change? _change;

        public OpenChangeDialog(int changeId, DatabaseContext dbContext)
        {
            _changeId = changeId;
            _context = dbContext;
            InitializeComponent();
        }

        private async void OpenChangeDialog_Load(object sender, EventArgs e)
        {
            dateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm";

            _change = await _context.Changes.FindAsync(_changeId);

            textBoxChangeHash.Text = _change?.ChangeHash;
            textBoxChangeName.Text = _change?.Name;
            richTextBoxChangeDesc.Text = _change?.Description;
            dateTimePicker.Value = _change?.CreatedAt ?? DateTime.Now;
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
                    _change!.Name = textBoxChangeName.Text;
                    _change.ChangeHash = textBoxChangeHash.Text;
                    _change.Description = richTextBoxChangeDesc.Text;
                    _change.CreatedAt = dateTimePicker.Value;

                    await _context.SaveChangesAsync();
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
