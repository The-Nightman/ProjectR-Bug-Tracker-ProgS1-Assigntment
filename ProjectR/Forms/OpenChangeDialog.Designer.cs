namespace ProjectR.Forms
{
    partial class OpenChangeDialog
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
            groupBoxNewChangeDetails = new GroupBox();
            lblChangeHash = new Label();
            lblChangeName = new Label();
            lblChangeDesc = new Label();
            dateTimePicker = new DateTimePicker();
            lblChangeCreatedAt = new Label();
            richTextBoxChangeDesc = new RichTextBox();
            textBoxChangeHash = new TextBox();
            textBoxChangeName = new TextBox();
            btnSaveEditChange = new Button();
            btnClose = new Button();
            groupBoxNewChangeDetails.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxNewChangeDetails
            // 
            groupBoxNewChangeDetails.Controls.Add(lblChangeHash);
            groupBoxNewChangeDetails.Controls.Add(lblChangeName);
            groupBoxNewChangeDetails.Controls.Add(lblChangeDesc);
            groupBoxNewChangeDetails.Controls.Add(dateTimePicker);
            groupBoxNewChangeDetails.Controls.Add(lblChangeCreatedAt);
            groupBoxNewChangeDetails.Controls.Add(richTextBoxChangeDesc);
            groupBoxNewChangeDetails.Controls.Add(textBoxChangeHash);
            groupBoxNewChangeDetails.Controls.Add(textBoxChangeName);
            groupBoxNewChangeDetails.Location = new Point(9, 9);
            groupBoxNewChangeDetails.Margin = new Padding(0);
            groupBoxNewChangeDetails.Name = "groupBoxNewChangeDetails";
            groupBoxNewChangeDetails.Size = new Size(402, 362);
            groupBoxNewChangeDetails.TabIndex = 31;
            groupBoxNewChangeDetails.TabStop = false;
            groupBoxNewChangeDetails.Text = "Change Details";
            // 
            // lblChangeHash
            // 
            lblChangeHash.AutoSize = true;
            lblChangeHash.Location = new Point(6, 32);
            lblChangeHash.Name = "lblChangeHash";
            lblChangeHash.Size = new Size(96, 20);
            lblChangeHash.TabIndex = 0;
            lblChangeHash.Text = "Change Hash";
            // 
            // lblChangeName
            // 
            lblChangeName.AutoSize = true;
            lblChangeName.Location = new Point(6, 90);
            lblChangeName.Name = "lblChangeName";
            lblChangeName.Size = new Size(49, 20);
            lblChangeName.TabIndex = 1;
            lblChangeName.Text = "Name";
            // 
            // lblChangeDesc
            // 
            lblChangeDesc.AutoSize = true;
            lblChangeDesc.Location = new Point(6, 148);
            lblChangeDesc.Name = "lblChangeDesc";
            lblChangeDesc.Size = new Size(85, 20);
            lblChangeDesc.TabIndex = 2;
            lblChangeDesc.Text = "Description";
            // 
            // dateTimePicker
            // 
            dateTimePicker.AccessibleDescription = "";
            dateTimePicker.Enabled = false;
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.Location = new Point(6, 322);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(389, 27);
            dateTimePicker.TabIndex = 7;
            // 
            // lblChangeCreatedAt
            // 
            lblChangeCreatedAt.AutoSize = true;
            lblChangeCreatedAt.Location = new Point(6, 299);
            lblChangeCreatedAt.Name = "lblChangeCreatedAt";
            lblChangeCreatedAt.Size = new Size(78, 20);
            lblChangeCreatedAt.TabIndex = 3;
            lblChangeCreatedAt.Text = "Created at";
            // 
            // richTextBoxChangeDesc
            // 
            richTextBoxChangeDesc.AccessibleDescription = "Change description";
            richTextBoxChangeDesc.Location = new Point(6, 171);
            richTextBoxChangeDesc.Margin = new Padding(3, 3, 3, 8);
            richTextBoxChangeDesc.Name = "richTextBoxChangeDesc";
            richTextBoxChangeDesc.ReadOnly = true;
            richTextBoxChangeDesc.Size = new Size(389, 120);
            richTextBoxChangeDesc.TabIndex = 6;
            richTextBoxChangeDesc.Text = "";
            // 
            // textBoxChangeHash
            // 
            textBoxChangeHash.AccessibleDescription = "";
            textBoxChangeHash.AccessibleName = "Change hash";
            textBoxChangeHash.Location = new Point(6, 55);
            textBoxChangeHash.Margin = new Padding(3, 3, 3, 8);
            textBoxChangeHash.Name = "textBoxChangeHash";
            textBoxChangeHash.ReadOnly = true;
            textBoxChangeHash.Size = new Size(389, 27);
            textBoxChangeHash.TabIndex = 4;
            // 
            // textBoxChangeName
            // 
            textBoxChangeName.AccessibleDescription = "";
            textBoxChangeName.AccessibleName = "Name";
            textBoxChangeName.Location = new Point(6, 113);
            textBoxChangeName.Margin = new Padding(3, 3, 3, 8);
            textBoxChangeName.Name = "textBoxChangeName";
            textBoxChangeName.ReadOnly = true;
            textBoxChangeName.Size = new Size(389, 27);
            textBoxChangeName.TabIndex = 5;
            // 
            // btnSaveEditChange
            // 
            btnSaveEditChange.AccessibleDescription = "Edit Change Details";
            btnSaveEditChange.AccessibleName = "";
            btnSaveEditChange.BackColor = Color.DodgerBlue;
            btnSaveEditChange.FlatStyle = FlatStyle.Flat;
            btnSaveEditChange.Location = new Point(256, 388);
            btnSaveEditChange.Margin = new Padding(0, 0, 8, 0);
            btnSaveEditChange.Name = "btnSaveEditChange";
            btnSaveEditChange.Size = new Size(155, 29);
            btnSaveEditChange.TabIndex = 29;
            btnSaveEditChange.Text = "Edit";
            btnSaveEditChange.UseVisualStyleBackColor = false;
            btnSaveEditChange.Click += btnSaveEditChange_Click;
            // 
            // btnClose
            // 
            btnClose.AccessibleDescription = "Close the dialog";
            btnClose.BackColor = SystemColors.Control;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Location = new Point(9, 388);
            btnClose.Margin = new Padding(8, 0, 0, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(155, 29);
            btnClose.TabIndex = 30;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // OpenChangeDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 425);
            Controls.Add(groupBoxNewChangeDetails);
            Controls.Add(btnSaveEditChange);
            Controls.Add(btnClose);
            Name = "OpenChangeDialog";
            Text = "View Change";
            Load += OpenChangeDialog_Load;
            groupBoxNewChangeDetails.ResumeLayout(false);
            groupBoxNewChangeDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxNewChangeDetails;
        private Label lblChangeHash;
        private Label lblChangeName;
        private Label lblChangeDesc;
        private DateTimePicker dateTimePicker;
        private Label lblChangeCreatedAt;
        private RichTextBox richTextBoxChangeDesc;
        private TextBox textBoxChangeHash;
        private TextBox textBoxChangeName;
        private Button btnSaveEditChange;
        private Button btnClose;
    }
}