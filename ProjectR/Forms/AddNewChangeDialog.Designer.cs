namespace ProjectR.Forms
{
    partial class AddNewChangeDialog
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
            lblChangeHash = new Label();
            lblChangeName = new Label();
            lblChangeDesc = new Label();
            lblChangeCreatedAt = new Label();
            textBoxChangeHash = new TextBox();
            textBoxChangeName = new TextBox();
            richTextBoxChangeDesc = new RichTextBox();
            dateTimePicker = new DateTimePicker();
            btnSaveNewChange = new Button();
            btnCancel = new Button();
            groupBoxNewChangeDetails = new GroupBox();
            groupBoxNewChangeDetails.SuspendLayout();
            SuspendLayout();
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
            // lblChangeCreatedAt
            // 
            lblChangeCreatedAt.AutoSize = true;
            lblChangeCreatedAt.Location = new Point(6, 299);
            lblChangeCreatedAt.Name = "lblChangeCreatedAt";
            lblChangeCreatedAt.Size = new Size(78, 20);
            lblChangeCreatedAt.TabIndex = 3;
            lblChangeCreatedAt.Text = "Created at";
            // 
            // textBoxChangeHash
            // 
            textBoxChangeHash.AccessibleDescription = "Add the git commit hash for the change (requried)";
            textBoxChangeHash.Location = new Point(6, 55);
            textBoxChangeHash.Margin = new Padding(3, 3, 3, 8);
            textBoxChangeHash.Name = "textBoxChangeHash";
            textBoxChangeHash.Size = new Size(389, 27);
            textBoxChangeHash.TabIndex = 4;
            // 
            // textBoxChangeName
            // 
            textBoxChangeName.AccessibleDescription = "Edit the name for the change (required)";
            textBoxChangeName.Location = new Point(6, 113);
            textBoxChangeName.Margin = new Padding(3, 3, 3, 8);
            textBoxChangeName.Name = "textBoxChangeName";
            textBoxChangeName.Size = new Size(389, 27);
            textBoxChangeName.TabIndex = 5;
            // 
            // richTextBoxChangeDesc
            // 
            richTextBoxChangeDesc.AccessibleDescription = "Edit the description for the change (required)";
            richTextBoxChangeDesc.Location = new Point(6, 171);
            richTextBoxChangeDesc.Margin = new Padding(3, 3, 3, 8);
            richTextBoxChangeDesc.Name = "richTextBoxChangeDesc";
            richTextBoxChangeDesc.Size = new Size(389, 120);
            richTextBoxChangeDesc.TabIndex = 6;
            richTextBoxChangeDesc.Text = "";
            // 
            // dateTimePicker
            // 
            dateTimePicker.AccessibleDescription = "Add the datetime of the change, default to current date and time";
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.Location = new Point(6, 322);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(389, 27);
            dateTimePicker.TabIndex = 7;
            // 
            // btnSaveNewChange
            // 
            btnSaveNewChange.AccessibleDescription = "Save Change";
            btnSaveNewChange.AccessibleName = "";
            btnSaveNewChange.BackColor = Color.LawnGreen;
            btnSaveNewChange.FlatStyle = FlatStyle.Flat;
            btnSaveNewChange.Location = new Point(256, 388);
            btnSaveNewChange.Margin = new Padding(0, 0, 8, 0);
            btnSaveNewChange.Name = "btnSaveNewChange";
            btnSaveNewChange.Size = new Size(155, 29);
            btnSaveNewChange.TabIndex = 26;
            btnSaveNewChange.Text = "Save";
            btnSaveNewChange.UseVisualStyleBackColor = false;
            btnSaveNewChange.Click += btnSaveNewChange_Click;
            // 
            // btnCancel
            // 
            btnCancel.AccessibleDescription = "Cancel New Change";
            btnCancel.BackColor = Color.Red;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(9, 388);
            btnCancel.Margin = new Padding(8, 0, 0, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(155, 29);
            btnCancel.TabIndex = 27;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
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
            groupBoxNewChangeDetails.TabIndex = 28;
            groupBoxNewChangeDetails.TabStop = false;
            groupBoxNewChangeDetails.Text = "New Change Details";
            // 
            // AddNewChangeDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 426);
            Controls.Add(groupBoxNewChangeDetails);
            Controls.Add(btnSaveNewChange);
            Controls.Add(btnCancel);
            Name = "AddNewChangeDialog";
            Text = "AddNewChange";
            Load += AddNewChangeDialog_Load;
            groupBoxNewChangeDetails.ResumeLayout(false);
            groupBoxNewChangeDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblChangeHash;
        private Label lblChangeName;
        private Label lblChangeDesc;
        private Label lblChangeCreatedAt;
        private TextBox textBoxChangeHash;
        private TextBox textBoxChangeName;
        private RichTextBox richTextBoxChangeDesc;
        private DateTimePicker dateTimePicker;
        private Button btnSaveNewChange;
        private Button btnCancel;
        private GroupBox groupBoxNewChangeDetails;
    }
}