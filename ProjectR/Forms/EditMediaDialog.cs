using ProjectR.Classes;
using ProjectR.DTOs;
using ProjectR.Interfaces;

namespace ProjectR.Forms
{
    public partial class EditMediaDialog : Form
    {
        private readonly MediaDisplay _media;
        private readonly IIssuesService _issuesService;

        public EditMediaDialog(
            MediaDisplay media,
            IIssuesService issuesService
        )
        {
            _media = media;
            _issuesService = issuesService;
            InitializeComponent();
        }

        private void EditMediaDialog_Load(object sender, EventArgs e)
        {
            pictureBoxDialogMedia.ImageLocation = _media.Path;
            textBoxMediaTitle.Text = _media.Title;
            richTextBoxMediaDesc.Text = _media.Description;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnDeleteMedia_Click(object sender, EventArgs e)
        {
            try
            {
                await _issuesService.DeleteMediaById(_media.MediaId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An error occurred while deleting the media: {ex.Message}",
                    "Error"
                );
                return;
            }

            Close();
        }

        private async void btnSaveMedia_Click(object sender, EventArgs e)
        {
            try
            {
                await _issuesService.UpdateMedia(
                    new EditMediaDto
                    {
                        Id = _media.MediaId,
                        Title = textBoxMediaTitle.Text,
                        Description = richTextBoxMediaDesc.Text,
                    }
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the media: {ex.Message}", "Error");
                return;
            }

            Close();
        }
    }
}
