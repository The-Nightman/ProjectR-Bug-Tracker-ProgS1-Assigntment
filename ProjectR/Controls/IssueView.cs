using Microsoft.EntityFrameworkCore;
using ProjectR.Data;
using ProjectR.Entities;

namespace ProjectR.Controls
{
    public partial class IssueView : UserControl
    {
        private int _issueId;
        private readonly DatabaseContext _context;

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
            Issue issue = await _context
                .Issues.Include(i => i.Media)
                .Include(i => i.Changes)
                .FirstAsync(i => i.Id == _issueId);

            lblIssueTitle.Text = issue.Name;
            lblIssueCreatedDate.Text = $"Created: {issue.CreatedAt:dd/MM/yyyy HH:mm}";
            richTextBoxIssueDesc.Text = issue.Description;
            listBoxMedia.DisplayMember = "Title";
            listBoxMedia.DataSource = issue.Media;
            dataGridViewChanges.DataSource = issue.Changes;

            btnIssueNameEditSave.Location = new Point(
                lblIssueTitle.Location.X + lblIssueTitle.Width + lblIssueTitle.Padding.Right,
                lblIssueTitle.Location.Y
            );

            comboBoxSeverityLevels.SelectedItem = issue.Severity;
            comboBoxStatusLevels.SelectedItem = issue.Status;

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
    }
}
