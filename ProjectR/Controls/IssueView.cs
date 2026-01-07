using ProjectR.Classes;
using ProjectR.Data;
using ProjectR.DTOs;
using ProjectR.Forms;
using ProjectR.Interfaces;

namespace ProjectR.Controls
{
    public partial class IssueView : UserControl
    {
        private readonly int _issueId;
        private readonly DatabaseContext _context;
        private readonly IIssuesService _issuesService;

        public IssueView(DatabaseContext dbContenxt, int issueId, IIssuesService issuesService)
        {
            _issueId = issueId;
            _context = dbContenxt;
            _issuesService = issuesService;
            InitializeComponent();
        }

        private async void IssueView_Load(object sender, EventArgs e)
        {
            string[] severityLevels = ["Low", "Medium", "Critical"];
            string[] statusLevels = ["Investigating", "In Review", "Fixed"];

            IssueDisplay issue = await _issuesService.GetIssueById(_issueId);

            imageList.Images.Add("editLight", Properties.Resources.editLight);
            imageList.Images.Add("saveLight", Properties.Resources.saveLight);
            btnIssueNameEditSave.ImageKey = "editLight";

            comboBoxSeverityLevels.Items.AddRange(severityLevels);
            comboBoxStatusLevels.Items.AddRange(statusLevels);

            lblIssueTitle.Text = issue.Name;
            lblIssueCreatedDate.Text = $"Created: {issue.CreatedAt:dd/MM/yyyy HH:mm}";
            lblIssueLastUpdated.Text = $"Last Updated: {issue.LastUpdated:dd/MM/yyyy HH:mm}";
            richTextBoxIssueDesc.Text = issue.Description;
            listBoxMedia.DisplayMember = "Title";
            listBoxMedia.DataSource = issue.MediaList;
            dataGridViewChanges.DataSource = issue.ChangesList;

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

            MediaDisplay image = (MediaDisplay)listBoxMedia.SelectedItem;

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

                btnIssueNameEditSave.ImageKey = "saveLight";

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

                btnIssueNameEditSave.ImageKey = "editLight";

                btnIssueNameEditSave.Location = new Point(
                    lblIssueTitle.Location.X + lblIssueTitle.Width + lblIssueTitle.Padding.Right,
                    lblIssueTitle.Location.Y
                );
            }
        }

        private async void btnAddNewMedia_Click(object sender, EventArgs e)
        {
            Form dialog = new AddMediaDialog(_issueId, _issuesService);
            dialog.ShowDialog();

            await ReloadMedia();
        }

        private async void btnEditMedia_Click(object sender, EventArgs e)
        {
            if (listBoxMedia.SelectedItem == null)
                return;

            Form dialog = new EditMediaDialog((MediaDisplay)listBoxMedia.SelectedItem, _issuesService);
            dialog.ShowDialog();

            await ReloadMedia();
        }

        private async void btnAddNewChange_Click(object sender, EventArgs e)
        {
            Form dialog = new AddNewChangeDialog(_issueId, _issuesService);
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
            var newMedia = await _issuesService.GetIssueMedia(_issueId);

            listBoxMedia.DataSource = newMedia;
            listBoxMedia.Refresh();
        }

        private async Task ReloadChanges()
        {
            var refreshIssueQuery = await _issuesService.GetIssueById(_issueId);

            dataGridViewChanges.DataSource = refreshIssueQuery.ChangesList;
            dataGridViewChanges.Refresh();

            lblIssueLastUpdated.Text =
                $"Last Updated: {refreshIssueQuery.LastUpdated:dd/MM/yyyy HH:mm}";
        }

        private async void btnSaveIssueEdits_Click(object sender, EventArgs e)
        {
            if (
                comboBoxSeverityLevels.SelectedItem == null
                || comboBoxStatusLevels.SelectedItem == null
            )
            {
                MessageBox.Show(
                    "Please select both severity and status levels.",
                    "Validation Error"
                );
                return;
            }

            try
            {
                await _issuesService.UpdateIssueDetails(
                    _issueId,
                    new EditIssueDetailsDto
                    {
                        Name = lblIssueTitle.Text,
                        Description = richTextBoxIssueDesc.Text,
                        Severity = comboBoxSeverityLevels.SelectedItem.ToString()!,
                        Status = comboBoxStatusLevels.SelectedItem.ToString()!,
                    }
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the issue: {ex.Message}", "Error");
            }
        }
    }
}
