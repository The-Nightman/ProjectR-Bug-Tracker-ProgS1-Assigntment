using ProjectR.Data;
using ProjectR.Entities;

namespace ProjectR.Forms
{
    public partial class AddMediaDialog : Form
    {
        private readonly Issue _issue;
        private readonly DatabaseContext _context;

        public AddMediaDialog(Issue issue, DatabaseContext dbContext)
        {
            _issue = issue;
            _context = dbContext;
            InitializeComponent();
        }

        private void btnOpenFileDialog_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBoxDialogMedia.ImageLocation = openFileDialog1.FileName;

                textBoxFilePath.Text = openFileDialog1.FileName;

                textBoxMediaTitle.Text = Path.GetFileNameWithoutExtension(openFileDialog1.SafeFileName);

                richTextBoxMediaDesc.Text = "";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnSaveNewMedia_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMediaTitle.Text))
            {
                MessageBox.Show("Please enter a title for the media.", "Validation Error");
                return;
            }

            if (string.IsNullOrWhiteSpace(openFileDialog1.FileName))
            {
                MessageBox.Show("Please select a media file to upload.", "Validation Error");
                return;
            }

            if (textBoxFilePath.Text != openFileDialog1.FileName)
            {
                string path = textBoxFilePath.Text;
                string[] permittedTypes = [".jpg", ".jpeg", ".png"];

                if (!File.Exists(path) || !permittedTypes.Contains(Path.GetExtension(path)))
                {
                    MessageBox.Show(
                        "The specified file path is invalid or not a permitted image type (.png .jpeg .jpg).",
                        "Validation Error"
                    );
                    return;
                }
            }

            if (File.Exists($"Data/Media/{openFileDialog1.SafeFileName}"))
            {
                MessageBox.Show(
                    "The filename already exists in the application, please rename the file before uploading.",
                    "Validation Error"
                );
                return;
            }

            try
            {
                if (!Directory.Exists("Data/Media")) // Safety check just incase
                {
                    Directory.CreateDirectory("Data/Media");
                }

                File.Copy(
                    openFileDialog1.FileName,
                    Path.Combine("Data/Media", openFileDialog1.SafeFileName),
                    false
                );

                _ = await _context.Media.AddAsync(
                    new Media
                    {
                        IssueId = _issue.Id,
                        Title = textBoxMediaTitle.Text,
                        Description = richTextBoxMediaDesc.Text,
                        MediaType = "Image",
                        Path = $"Data/Media/{openFileDialog1.SafeFileName}",
                        Issue = _issue,
                    }
                );

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An error occurred while copying the file: {ex.Message}",
                    "File Copy Error"
                );
                return;
            }
            finally
            {
                Close();
            }
        }
    }
}
