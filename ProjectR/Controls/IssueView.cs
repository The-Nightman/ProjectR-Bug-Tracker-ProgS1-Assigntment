using Microsoft.EntityFrameworkCore;
using ProjectR.Data;
using ProjectR.Entities;
using ProjectR.Forms;

namespace ProjectR.Controls
{
    public partial class IssueView : UserControl
    {
        private readonly int _issueId;
        private readonly DatabaseContext _context;
        private Issue? _issue;

        public IssueView(DatabaseContext dbContenxt, int issueId)
        {
            _issueId = issueId;
            _context = dbContenxt;
            InitializeComponent();
        }

        private async void IssueView_Load(object sender, EventArgs e)
        {
            string[] severityLevels = ["Low", "Medium", "Critical"];
            string[] statusLevels = ["Investigating", "In Review", "Fixed"];

            comboBoxSeverityLevels.Items.AddRange(severityLevels);
            comboBoxStatusLevels.Items.AddRange(statusLevels);

            // Loading related entities as a property technically runs multiple queries
            // and this may cause the related entities to not be loaded even with async
            _issue = await _context
                .Issues.Include(i => i.Media)
                .Include(i => i.Changes)
                .FirstAsync(i => i.Id == _issueId);

            lblIssueTitle.Text = _issue.Name;
            lblIssueCreatedDate.Text = $"Created: {_issue.CreatedAt:dd/MM/yyyy HH:mm}";
            lblIssueLastUpdated.Text = $"Last Updated: {_issue.LastUpdated:dd/MM/yyyy HH:mm}";
            richTextBoxIssueDesc.Text = _issue.Description;
            listBoxMedia.DisplayMember = "Title";
            listBoxMedia.DataSource = _issue.Media;
            dataGridViewChanges.DataSource = _issue.Changes.OrderByDescending(c => c.CreatedAt).ToList();

            btnIssueNameEditSave.Location = new Point(
                lblIssueTitle.Location.X + lblIssueTitle.Width + lblIssueTitle.Padding.Right,
                lblIssueTitle.Location.Y
            );

            comboBoxSeverityLevels.SelectedItem = _issue.Severity;
            comboBoxStatusLevels.SelectedItem = _issue.Status;

            toolTip.SetToolTip(pictureBoxIssueMedia, "Click to view fullscreen");
        }

        private void pictureBoxIssueMedia_Click(object sender, EventArgs e)
        {
            Form fullscreenMedia = new()
            {
                FormBorderStyle = FormBorderStyle.None,
                WindowState = FormWindowState.Maximized,
            };

            PictureBox pb = new()
            {
                Image = pictureBoxIssueMedia.Image,
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill,
            };

            fullscreenMedia.Controls.Add(pb);

            fullscreenMedia.KeyPress += (s, args) => fullscreenMedia.Close();
            pb.Click += (s, args) => fullscreenMedia.Close();

            fullscreenMedia.ShowDialog();
        }

        private void listBoxMedia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMedia.SelectedItem == null)
                return;

            Media image = (Media)listBoxMedia.SelectedItem;

            pictureBoxIssueMedia.ImageLocation = Path.Combine(AppContext.BaseDirectory, image.Path);

            richTextBoxMediaDesc.Text = image.Description;
        }

        private void dataGridViewChanges_SelectionChanged(object sender, EventArgs e)
        {
            btnOpenChange.Enabled = dataGridViewChanges.SelectedRows.Count > 0;
        }

        private void btnIssueNameEditSave_Click(object sender, EventArgs e)
        {
            if (lblIssueTitle.Visible) // We can use the controls to monitor state rather than a boolean flag like react
            {
                lblIssueTitle.Visible = false;
                textBoxIssueTitleEdit.Text = lblIssueTitle.Text;
                textBoxIssueTitleEdit.Visible = true;
                btnIssueNameEditSave.AccessibleName = "Save Issue Name";

                btnIssueNameEditSave.ImageIndex = 1;

                btnIssueNameEditSave.Location = new Point(
                    textBoxIssueTitleEdit.Location.X
                        + textBoxIssueTitleEdit.Width
                        + textBoxIssueTitleEdit.Padding.Right,
                    lblIssueTitle.Location.Y
                );
            }
            else
            {
                lblIssueTitle.Visible = true;
                lblIssueTitle.Text = textBoxIssueTitleEdit.Text;
                textBoxIssueTitleEdit.Visible = false;
                btnIssueNameEditSave.AccessibleName = "Edit Issue Name";

                btnIssueNameEditSave.ImageIndex = 0;

                btnIssueNameEditSave.Location = new Point(
                    lblIssueTitle.Location.X + lblIssueTitle.Width + lblIssueTitle.Padding.Right,
                    lblIssueTitle.Location.Y
                );
            }
        }

        private async void btnAddNewMedia_Click(object sender, EventArgs e)
        {
            Form dialog = new AddMediaDialog(_issue!, _context);
            dialog.ShowDialog();

            await ReloadMedia();
        }

        private async void btnEditMedia_Click(object sender, EventArgs e)
        {
            if (listBoxMedia.SelectedItem == null)
                return;

            Form dialog = new EditMediaDialog(
                (Media)listBoxMedia.SelectedItem,
                _context
            );
            dialog.ShowDialog();

            await ReloadMedia();
        }

        private async void btnAddNewChange_Click(object sender, EventArgs e)
        {
            Form dialog = new AddNewChangeDialog(_issue!, _context);
            dialog.ShowDialog();

            await ReloadChanges();
        }

        private async void btnOpenChange_Click(object sender, EventArgs e)
        {
            Form dialog = new OpenChangeDialog(
                (int)dataGridViewChanges.SelectedRows[0].Cells["Id"].Value,
                _context
            );
            dialog.ShowDialog();

            await ReloadChanges(); // The dialog does have functionality to edit the changes so we should still reload
        }

        private async Task ReloadMedia()
        {
            var newMedia = await _context.Media.Where(m => m.IssueId == _issueId).ToListAsync();

            _issue!.Media = newMedia;

            listBoxMedia.DataSource = _issue!.Media;
            listBoxMedia.Refresh();
        }

        private async Task ReloadChanges()
        {
            var newChanges = await _context.Changes.Where(m => m.IssueId == _issueId).ToListAsync();

            _issue!.Changes = newChanges;

            dataGridViewChanges.DataSource = newChanges.OrderByDescending(c => c.CreatedAt).ToList();
            dataGridViewChanges.Refresh();

            var issueToUpdate = await _context.Issues.Where(i => i.Id == _issueId).Select(i => i.LastUpdated).FirstAsync();

            _issue!.LastUpdated = issueToUpdate;

            lblIssueLastUpdated.Text = $"Last Updated: {_issue!.LastUpdated:dd/MM/yyyy HH:mm}";
        }
    }
}
