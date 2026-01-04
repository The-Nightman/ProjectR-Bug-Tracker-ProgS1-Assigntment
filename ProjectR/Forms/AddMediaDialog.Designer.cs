namespace ProjectR.Forms
{
    partial class AddMediaDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBoxDialogMedia = new PictureBox();
            richTextBoxMediaDesc = new RichTextBox();
            btnOpenFileDialog = new Button();
            textBoxFilePath = new TextBox();
            groupBoxMediaDetails = new GroupBox();
            lblMediaDesc = new Label();
            lblMediaTitle = new Label();
            textBoxMediaTitle = new TextBox();
            btnSaveNewMedia = new Button();
            btnCancel = new Button();
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDialogMedia).BeginInit();
            groupBoxMediaDetails.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxDialogMedia
            // 
            pictureBoxDialogMedia.Location = new Point(9, 9);
            pictureBoxDialogMedia.Margin = new Padding(0);
            pictureBoxDialogMedia.Name = "pictureBoxDialogMedia";
            pictureBoxDialogMedia.Size = new Size(426, 240);
            pictureBoxDialogMedia.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxDialogMedia.TabIndex = 9;
            pictureBoxDialogMedia.TabStop = false;
            // 
            // richTextBoxMediaDesc
            // 
            richTextBoxMediaDesc.AccessibleDescription = "Enter the description for the media file";
            richTextBoxMediaDesc.AccessibleName = "Media Description";
            richTextBoxMediaDesc.Location = new Point(3, 124);
            richTextBoxMediaDesc.Margin = new Padding(0);
            richTextBoxMediaDesc.Name = "richTextBoxMediaDesc";
            richTextBoxMediaDesc.Size = new Size(420, 95);
            richTextBoxMediaDesc.TabIndex = 10;
            richTextBoxMediaDesc.Text = "";
            // 
            // btnOpenFileDialog
            // 
            btnOpenFileDialog.Location = new Point(341, 252);
            btnOpenFileDialog.Name = "btnOpenFileDialog";
            btnOpenFileDialog.Size = new Size(94, 29);
            btnOpenFileDialog.TabIndex = 11;
            btnOpenFileDialog.Text = "Open File";
            btnOpenFileDialog.UseVisualStyleBackColor = true;
            btnOpenFileDialog.Click += btnOpenFileDialog_Click;
            // 
            // textBoxFilePath
            // 
            textBoxFilePath.AccessibleDescription = "Enter the filepath or use the open file button to select a media file";
            textBoxFilePath.AccessibleName = "File Path";
            textBoxFilePath.Location = new Point(12, 254);
            textBoxFilePath.Name = "textBoxFilePath";
            textBoxFilePath.Size = new Size(323, 27);
            textBoxFilePath.TabIndex = 12;
            // 
            // groupBoxMediaDetails
            // 
            groupBoxMediaDetails.Controls.Add(lblMediaDesc);
            groupBoxMediaDetails.Controls.Add(lblMediaTitle);
            groupBoxMediaDetails.Controls.Add(textBoxMediaTitle);
            groupBoxMediaDetails.Controls.Add(richTextBoxMediaDesc);
            groupBoxMediaDetails.Location = new Point(9, 284);
            groupBoxMediaDetails.Margin = new Padding(0);
            groupBoxMediaDetails.Name = "groupBoxMediaDetails";
            groupBoxMediaDetails.Size = new Size(426, 222);
            groupBoxMediaDetails.TabIndex = 13;
            groupBoxMediaDetails.TabStop = false;
            groupBoxMediaDetails.Text = "Media Details";
            // 
            // lblMediaDesc
            // 
            lblMediaDesc.AutoSize = true;
            lblMediaDesc.Location = new Point(6, 101);
            lblMediaDesc.Name = "lblMediaDesc";
            lblMediaDesc.Size = new Size(131, 20);
            lblMediaDesc.TabIndex = 13;
            lblMediaDesc.Text = "Media Description";
            // 
            // lblMediaTitle
            // 
            lblMediaTitle.AutoSize = true;
            lblMediaTitle.Location = new Point(6, 29);
            lblMediaTitle.Name = "lblMediaTitle";
            lblMediaTitle.Size = new Size(84, 20);
            lblMediaTitle.TabIndex = 12;
            lblMediaTitle.Text = "Media Title";
            // 
            // textBoxMediaTitle
            // 
            textBoxMediaTitle.AccessibleDescription = "Enter the name for the media file";
            textBoxMediaTitle.AccessibleName = "Media Title";
            textBoxMediaTitle.Location = new Point(3, 52);
            textBoxMediaTitle.Margin = new Padding(0, 3, 0, 3);
            textBoxMediaTitle.Name = "textBoxMediaTitle";
            textBoxMediaTitle.Size = new Size(420, 27);
            textBoxMediaTitle.TabIndex = 11;
            // 
            // btnSaveNewMedia
            // 
            btnSaveNewMedia.AccessibleDescription = "Save Media";
            btnSaveNewMedia.AccessibleName = "";
            btnSaveNewMedia.BackColor = Color.LawnGreen;
            btnSaveNewMedia.FlatStyle = FlatStyle.Flat;
            btnSaveNewMedia.Location = new Point(277, 511);
            btnSaveNewMedia.Margin = new Padding(0, 0, 8, 0);
            btnSaveNewMedia.Name = "btnSaveNewMedia";
            btnSaveNewMedia.Size = new Size(155, 29);
            btnSaveNewMedia.TabIndex = 24;
            btnSaveNewMedia.Text = "Save";
            btnSaveNewMedia.UseVisualStyleBackColor = false;
            btnSaveNewMedia.Click += btnSaveNewMedia_Click;
            // 
            // btnCancel
            // 
            btnCancel.AccessibleDescription = "Cancel New Media";
            btnCancel.BackColor = Color.Red;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(12, 511);
            btnCancel.Margin = new Padding(8, 0, 0, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(155, 29);
            btnCancel.TabIndex = 25;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog";
            openFileDialog1.Filter = "Image Files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";
            // 
            // AddMediaDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(441, 549);
            Controls.Add(btnSaveNewMedia);
            Controls.Add(btnCancel);
            Controls.Add(groupBoxMediaDetails);
            Controls.Add(textBoxFilePath);
            Controls.Add(btnOpenFileDialog);
            Controls.Add(pictureBoxDialogMedia);
            Name = "AddMediaDialog";
            Text = "Add New Media";
            ((System.ComponentModel.ISupportInitialize)pictureBoxDialogMedia).EndInit();
            groupBoxMediaDetails.ResumeLayout(false);
            groupBoxMediaDetails.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxDialogMedia;
        private RichTextBox richTextBoxMediaDesc;
        private Button btnOpenFileDialog;
        private TextBox textBoxFilePath;
        private GroupBox groupBoxMediaDetails;
        private TextBox textBoxMediaTitle;
        private Label lblMediaDesc;
        private Label lblMediaTitle;
        private Button btnSaveNewMedia;
        private Button btnCancel;
        private OpenFileDialog openFileDialog1;
    }
}