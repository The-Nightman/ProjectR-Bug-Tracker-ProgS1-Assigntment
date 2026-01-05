using Microsoft.EntityFrameworkCore;
using ProjectR.Data;
using ProjectR.Entities;

namespace ProjectR.Forms
{
    public partial class EditMediaDialog : Form
    {
        private readonly Media _media;
        private readonly DatabaseContext _context;

        public EditMediaDialog(Media media, DatabaseContext dbContext)
        {
            _media = media;
            _context = dbContext;
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
                _ = await _context.Media.Where(m => m.Id == _media.Id).ExecuteDeleteAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the media: {ex.Message}", "Error");
                return;
            }

            Close();
        }

        private async void btnSaveMedia_Click(object sender, EventArgs e)
        {
            try
            {
                Media media = await _context.Media.FirstAsync(m => m.Id == _media.Id);

                media.Title = textBoxMediaTitle.Text;
                media.Description = richTextBoxMediaDesc.Text;

                await _context.SaveChangesAsync();
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
