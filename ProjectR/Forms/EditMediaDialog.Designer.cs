namespace ProjectR.Forms
{
    partial class EditMediaDialog
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
            groupBoxMediaDetails = new GroupBox();
            lblMediaDesc = new Label();
            lblMediaTitle = new Label();
            textBoxMediaTitle = new TextBox();
            btnSaveMedia = new Button();
            btnCancel = new Button();
            btnDeleteMedia = new Button();
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
            // groupBoxMediaDetails
            // 
            groupBoxMediaDetails.Controls.Add(lblMediaDesc);
            groupBoxMediaDetails.Controls.Add(lblMediaTitle);
            groupBoxMediaDetails.Controls.Add(textBoxMediaTitle);
            groupBoxMediaDetails.Controls.Add(richTextBoxMediaDesc);
            groupBoxMediaDetails.Location = new Point(9, 298);
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
            // btnSaveMedia
            // 
            btnSaveMedia.AccessibleDescription = "Save Media";
            btnSaveMedia.AccessibleName = "";
            btnSaveMedia.BackColor = Color.LawnGreen;
            btnSaveMedia.FlatStyle = FlatStyle.Flat;
            btnSaveMedia.Location = new Point(277, 530);
            btnSaveMedia.Margin = new Padding(0, 0, 8, 0);
            btnSaveMedia.Name = "btnSaveMedia";
            btnSaveMedia.Size = new Size(155, 29);
            btnSaveMedia.TabIndex = 24;
            btnSaveMedia.Text = "Save";
            btnSaveMedia.UseVisualStyleBackColor = false;
            btnSaveMedia.Click += btnSaveMedia_Click;
            // 
            // btnCancel
            // 
            btnCancel.AccessibleDescription = "Cancel New Media";
            btnCancel.BackColor = Color.Red;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(12, 530);
            btnCancel.Margin = new Padding(8, 0, 0, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(155, 29);
            btnCancel.TabIndex = 25;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnDeleteMedia
            // 
            btnDeleteMedia.AccessibleDescription = "Delete Media";
            btnDeleteMedia.BackColor = Color.Red;
            btnDeleteMedia.FlatStyle = FlatStyle.Flat;
            btnDeleteMedia.Location = new Point(277, 260);
            btnDeleteMedia.Margin = new Padding(8, 0, 0, 0);
            btnDeleteMedia.Name = "btnDeleteMedia";
            btnDeleteMedia.Size = new Size(155, 29);
            btnDeleteMedia.TabIndex = 26;
            btnDeleteMedia.Text = "Delete";
            btnDeleteMedia.UseVisualStyleBackColor = false;
            btnDeleteMedia.Click += btnDeleteMedia_Click;
            // 
            // EditMediaDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(441, 567);
            Controls.Add(btnDeleteMedia);
            Controls.Add(btnSaveMedia);
            Controls.Add(btnCancel);
            Controls.Add(groupBoxMediaDetails);
            Controls.Add(pictureBoxDialogMedia);
            Name = "EditMediaDialog";
            Text = "Edit Media";
            Load += EditMediaDialog_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxDialogMedia).EndInit();
            groupBoxMediaDetails.ResumeLayout(false);
            groupBoxMediaDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxDialogMedia;
        private RichTextBox richTextBoxMediaDesc;
        private GroupBox groupBoxMediaDetails;
        private TextBox textBoxMediaTitle;
        private Label lblMediaDesc;
        private Label lblMediaTitle;
        private Button btnSaveMedia;
        private Button btnCancel;
        private Button btnDeleteMedia;
    }
}