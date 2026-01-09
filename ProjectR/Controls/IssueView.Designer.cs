namespace ProjectR.Controls
{
    partial class IssueView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblIssueTitle = new Label();
            richTextBoxIssueDesc = new RichTextBox();
            pictureBoxIssueMedia = new PictureBox();
            listBoxMedia = new ListBox();
            toolTip = new ToolTip(components);
            richTextBoxMediaDesc = new RichTextBox();
            lblIssueChangesTitle = new Label();
            dataGridViewChanges = new DataGridView();
            changeBindingSource = new BindingSource(components);
            btnAddNewMedia = new Button();
            btnEditMedia = new Button();
            btnOpenChange = new Button();
            btnAddNewChange = new Button();
            lblIssueSeverityTitle = new Label();
            lblIssueStatusTitle = new Label();
            comboBoxSeverityLevels = new ComboBox();
            comboBoxStatusLevels = new ComboBox();
            groupBoxIssueDetails = new GroupBox();
            lblIssueLastUpdated = new Label();
            lblIssueCreatedDate = new Label();
            groupBoxIssueMedia = new GroupBox();
            btnIssueNameEditSave = new Button();
            imageList = new ImageList(components);
            textBoxIssueTitleEdit = new TextBox();
            btnSaveIssueEdits = new Button();
            changeDisplayBindingSource = new BindingSource(components);
            Id = new DataGridViewTextBoxColumn();
            changeHash = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            description = new DataGridViewTextBoxColumn();
            createdAt = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIssueMedia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewChanges).BeginInit();
            ((System.ComponentModel.ISupportInitialize)changeBindingSource).BeginInit();
            groupBoxIssueDetails.SuspendLayout();
            groupBoxIssueMedia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)changeDisplayBindingSource).BeginInit();
            SuspendLayout();
            // 
            // lblIssueTitle
            // 
            lblIssueTitle.AutoSize = true;
            lblIssueTitle.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIssueTitle.ForeColor = SystemColors.ControlText;
            lblIssueTitle.Location = new Point(16, 16);
            lblIssueTitle.Margin = new Padding(0, 0, 4, 16);
            lblIssueTitle.Name = "lblIssueTitle";
            lblIssueTitle.Size = new Size(165, 32);
            lblIssueTitle.TabIndex = 4;
            lblIssueTitle.Text = "IssueName";
            // 
            // richTextBoxIssueDesc
            // 
            richTextBoxIssueDesc.AccessibleName = "Issue Description";
            richTextBoxIssueDesc.Location = new Point(1, 99);
            richTextBoxIssueDesc.Margin = new Padding(0, 0, 8, 0);
            richTextBoxIssueDesc.Name = "richTextBoxIssueDesc";
            richTextBoxIssueDesc.Size = new Size(655, 160);
            richTextBoxIssueDesc.TabIndex = 5;
            richTextBoxIssueDesc.Text = "";
            // 
            // pictureBoxIssueMedia
            // 
            pictureBoxIssueMedia.Location = new Point(1, 22);
            pictureBoxIssueMedia.Margin = new Padding(0);
            pictureBoxIssueMedia.Name = "pictureBoxIssueMedia";
            pictureBoxIssueMedia.Size = new Size(426, 240);
            pictureBoxIssueMedia.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxIssueMedia.TabIndex = 6;
            pictureBoxIssueMedia.TabStop = false;
            pictureBoxIssueMedia.Click += pictureBoxIssueMedia_Click;
            // 
            // listBoxMedia
            // 
            listBoxMedia.FormattingEnabled = true;
            listBoxMedia.Location = new Point(1, 485);
            listBoxMedia.Margin = new Padding(0);
            listBoxMedia.Name = "listBoxMedia";
            listBoxMedia.Size = new Size(426, 104);
            listBoxMedia.TabIndex = 7;
            listBoxMedia.SelectedIndexChanged += listBoxMedia_SelectedIndexChanged;
            // 
            // richTextBoxMediaDesc
            // 
            richTextBoxMediaDesc.Location = new Point(1, 360);
            richTextBoxMediaDesc.Margin = new Padding(0, 0, 0, 8);
            richTextBoxMediaDesc.Name = "richTextBoxMediaDesc";
            richTextBoxMediaDesc.ReadOnly = true;
            richTextBoxMediaDesc.Size = new Size(426, 117);
            richTextBoxMediaDesc.TabIndex = 8;
            richTextBoxMediaDesc.Text = "";
            // 
            // lblIssueChangesTitle
            // 
            lblIssueChangesTitle.AutoSize = true;
            lblIssueChangesTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIssueChangesTitle.ForeColor = SystemColors.ControlText;
            lblIssueChangesTitle.Location = new Point(16, 333);
            lblIssueChangesTitle.Margin = new Padding(0);
            lblIssueChangesTitle.Name = "lblIssueChangesTitle";
            lblIssueChangesTitle.Size = new Size(102, 31);
            lblIssueChangesTitle.TabIndex = 20;
            lblIssueChangesTitle.Text = "Changes";
            // 
            // dataGridViewChanges
            // 
            dataGridViewChanges.AllowUserToResizeColumns = false;
            dataGridViewChanges.AllowUserToResizeRows = false;
            dataGridViewChanges.AutoGenerateColumns = false;
            dataGridViewChanges.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewChanges.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewChanges.Columns.AddRange(new DataGridViewColumn[] { Id, changeHash, name, description, createdAt });
            dataGridViewChanges.DataSource = changeDisplayBindingSource;
            dataGridViewChanges.Location = new Point(16, 367);
            dataGridViewChanges.Margin = new Padding(0);
            dataGridViewChanges.MultiSelect = false;
            dataGridViewChanges.Name = "dataGridViewChanges";
            dataGridViewChanges.ReadOnly = true;
            dataGridViewChanges.RowHeadersVisible = false;
            dataGridViewChanges.RowHeadersWidth = 51;
            dataGridViewChanges.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewChanges.Size = new Size(657, 335);
            dataGridViewChanges.TabIndex = 21;
            dataGridViewChanges.SelectionChanged += dataGridViewChanges_SelectionChanged;
            // 
            // changeBindingSource
            // 
            changeBindingSource.DataSource = typeof(Entities.Change);
            // 
            // btnAddNewMedia
            // 
            btnAddNewMedia.AccessibleDescription = "Add New Media";
            btnAddNewMedia.AccessibleName = "";
            btnAddNewMedia.BackColor = Color.LawnGreen;
            btnAddNewMedia.FlatStyle = FlatStyle.Flat;
            btnAddNewMedia.Location = new Point(223, 268);
            btnAddNewMedia.Margin = new Padding(0, 0, 8, 0);
            btnAddNewMedia.Name = "btnAddNewMedia";
            btnAddNewMedia.Size = new Size(94, 29);
            btnAddNewMedia.TabIndex = 22;
            btnAddNewMedia.Text = "Add New";
            btnAddNewMedia.UseVisualStyleBackColor = false;
            btnAddNewMedia.Click += btnAddNewMedia_Click;
            // 
            // btnEditMedia
            // 
            btnEditMedia.BackColor = Color.DodgerBlue;
            btnEditMedia.FlatStyle = FlatStyle.Flat;
            btnEditMedia.Location = new Point(333, 268);
            btnEditMedia.Margin = new Padding(8, 0, 0, 0);
            btnEditMedia.Name = "btnEditMedia";
            btnEditMedia.Size = new Size(94, 29);
            btnEditMedia.TabIndex = 23;
            btnEditMedia.Text = "Edit Media";
            btnEditMedia.UseVisualStyleBackColor = false;
            btnEditMedia.Click += btnEditMedia_Click;
            // 
            // btnOpenChange
            // 
            btnOpenChange.BackColor = Color.DodgerBlue;
            btnOpenChange.Enabled = false;
            btnOpenChange.FlatStyle = FlatStyle.Flat;
            btnOpenChange.Location = new Point(564, 332);
            btnOpenChange.Margin = new Padding(8, 0, 0, 0);
            btnOpenChange.Name = "btnOpenChange";
            btnOpenChange.Size = new Size(109, 29);
            btnOpenChange.TabIndex = 25;
            btnOpenChange.Text = "Open Change";
            btnOpenChange.UseVisualStyleBackColor = false;
            btnOpenChange.Click += btnOpenChange_Click;
            // 
            // btnAddNewChange
            // 
            btnAddNewChange.AccessibleDescription = "Add New Change";
            btnAddNewChange.AccessibleName = "";
            btnAddNewChange.BackColor = Color.LawnGreen;
            btnAddNewChange.FlatStyle = FlatStyle.Flat;
            btnAddNewChange.Location = new Point(439, 332);
            btnAddNewChange.Margin = new Padding(0, 0, 8, 0);
            btnAddNewChange.Name = "btnAddNewChange";
            btnAddNewChange.Size = new Size(109, 29);
            btnAddNewChange.TabIndex = 24;
            btnAddNewChange.Text = "Add New";
            btnAddNewChange.UseVisualStyleBackColor = false;
            btnAddNewChange.Click += btnAddNewChange_Click;
            // 
            // lblIssueSeverityTitle
            // 
            lblIssueSeverityTitle.AutoSize = true;
            lblIssueSeverityTitle.Font = new Font("Segoe UI", 10.8F);
            lblIssueSeverityTitle.ForeColor = SystemColors.ControlText;
            lblIssueSeverityTitle.Location = new Point(1, 57);
            lblIssueSeverityTitle.Margin = new Padding(0);
            lblIssueSeverityTitle.Name = "lblIssueSeverityTitle";
            lblIssueSeverityTitle.Size = new Size(74, 25);
            lblIssueSeverityTitle.TabIndex = 27;
            lblIssueSeverityTitle.Text = "Severity";
            // 
            // lblIssueStatusTitle
            // 
            lblIssueStatusTitle.AutoSize = true;
            lblIssueStatusTitle.Font = new Font("Segoe UI", 10.8F);
            lblIssueStatusTitle.ForeColor = SystemColors.ControlText;
            lblIssueStatusTitle.Location = new Point(341, 57);
            lblIssueStatusTitle.Margin = new Padding(0);
            lblIssueStatusTitle.Name = "lblIssueStatusTitle";
            lblIssueStatusTitle.Size = new Size(60, 25);
            lblIssueStatusTitle.TabIndex = 28;
            lblIssueStatusTitle.Text = "Status";
            // 
            // comboBoxSeverityLevels
            // 
            comboBoxSeverityLevels.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSeverityLevels.FormattingEnabled = true;
            comboBoxSeverityLevels.Location = new Point(77, 59);
            comboBoxSeverityLevels.Margin = new Padding(0);
            comboBoxSeverityLevels.Name = "comboBoxSeverityLevels";
            comboBoxSeverityLevels.Size = new Size(247, 28);
            comboBoxSeverityLevels.TabIndex = 29;
            // 
            // comboBoxStatusLevels
            // 
            comboBoxStatusLevels.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatusLevels.FormattingEnabled = true;
            comboBoxStatusLevels.Location = new Point(403, 59);
            comboBoxStatusLevels.Margin = new Padding(0);
            comboBoxStatusLevels.Name = "comboBoxStatusLevels";
            comboBoxStatusLevels.Size = new Size(247, 28);
            comboBoxStatusLevels.TabIndex = 30;
            // 
            // groupBoxIssueDetails
            // 
            groupBoxIssueDetails.AccessibleName = "Issue Details";
            groupBoxIssueDetails.Controls.Add(lblIssueLastUpdated);
            groupBoxIssueDetails.Controls.Add(lblIssueCreatedDate);
            groupBoxIssueDetails.Controls.Add(lblIssueStatusTitle);
            groupBoxIssueDetails.Controls.Add(comboBoxStatusLevels);
            groupBoxIssueDetails.Controls.Add(lblIssueSeverityTitle);
            groupBoxIssueDetails.Controls.Add(comboBoxSeverityLevels);
            groupBoxIssueDetails.Controls.Add(richTextBoxIssueDesc);
            groupBoxIssueDetails.Location = new Point(16, 64);
            groupBoxIssueDetails.Margin = new Padding(0);
            groupBoxIssueDetails.Name = "groupBoxIssueDetails";
            groupBoxIssueDetails.Padding = new Padding(1);
            groupBoxIssueDetails.Size = new Size(657, 261);
            groupBoxIssueDetails.TabIndex = 31;
            groupBoxIssueDetails.TabStop = false;
            groupBoxIssueDetails.Text = "Details";
            // 
            // lblIssueLastUpdated
            // 
            lblIssueLastUpdated.AutoSize = true;
            lblIssueLastUpdated.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIssueLastUpdated.Location = new Point(359, 27);
            lblIssueLastUpdated.Margin = new Padding(0);
            lblIssueLastUpdated.Name = "lblIssueLastUpdated";
            lblIssueLastUpdated.Size = new Size(291, 25);
            lblIssueLastUpdated.TabIndex = 32;
            lblIssueLastUpdated.Text = "Last Updated: dd/mm/yyyy hh:mm";
            // 
            // lblIssueCreatedDate
            // 
            lblIssueCreatedDate.AutoSize = true;
            lblIssueCreatedDate.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblIssueCreatedDate.Location = new Point(1, 27);
            lblIssueCreatedDate.Margin = new Padding(0);
            lblIssueCreatedDate.Name = "lblIssueCreatedDate";
            lblIssueCreatedDate.Size = new Size(247, 25);
            lblIssueCreatedDate.TabIndex = 31;
            lblIssueCreatedDate.Text = "Created: dd/mm/yyyy hh:mm";
            // 
            // groupBoxIssueMedia
            // 
            groupBoxIssueMedia.AccessibleName = "Issue Media";
            groupBoxIssueMedia.Controls.Add(pictureBoxIssueMedia);
            groupBoxIssueMedia.Controls.Add(listBoxMedia);
            groupBoxIssueMedia.Controls.Add(richTextBoxMediaDesc);
            groupBoxIssueMedia.Controls.Add(btnAddNewMedia);
            groupBoxIssueMedia.Controls.Add(btnEditMedia);
            groupBoxIssueMedia.Location = new Point(689, 64);
            groupBoxIssueMedia.Margin = new Padding(0);
            groupBoxIssueMedia.Name = "groupBoxIssueMedia";
            groupBoxIssueMedia.Padding = new Padding(1);
            groupBoxIssueMedia.Size = new Size(428, 635);
            groupBoxIssueMedia.TabIndex = 32;
            groupBoxIssueMedia.TabStop = false;
            groupBoxIssueMedia.Text = "Issue Media";
            // 
            // btnIssueNameEditSave
            // 
            btnIssueNameEditSave.AccessibleName = "Edit Issue Name";
            btnIssueNameEditSave.BackColor = Color.Transparent;
            btnIssueNameEditSave.FlatAppearance.BorderSize = 0;
            btnIssueNameEditSave.FlatStyle = FlatStyle.Flat;
            btnIssueNameEditSave.ImageList = imageList;
            btnIssueNameEditSave.Location = new Point(185, 16);
            btnIssueNameEditSave.Margin = new Padding(0);
            btnIssueNameEditSave.Name = "btnIssueNameEditSave";
            btnIssueNameEditSave.Size = new Size(32, 32);
            btnIssueNameEditSave.TabIndex = 33;
            btnIssueNameEditSave.UseVisualStyleBackColor = false;
            btnIssueNameEditSave.Click += btnIssueNameEditSave_Click;
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            imageList.ImageSize = new Size(32, 32);
            imageList.TransparentColor = Color.Transparent;
            // 
            // textBoxIssueTitleEdit
            // 
            textBoxIssueTitleEdit.AccessibleDescription = "Enter the issue name here";
            textBoxIssueTitleEdit.AccessibleName = "Edit Issue Name";
            textBoxIssueTitleEdit.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxIssueTitleEdit.Location = new Point(16, 9);
            textBoxIssueTitleEdit.Margin = new Padding(0, 0, 4, 0);
            textBoxIssueTitleEdit.Name = "textBoxIssueTitleEdit";
            textBoxIssueTitleEdit.Size = new Size(532, 43);
            textBoxIssueTitleEdit.TabIndex = 34;
            textBoxIssueTitleEdit.Visible = false;
            // 
            // btnSaveIssueEdits
            // 
            btnSaveIssueEdits.AccessibleDescription = "Save changes to issue details";
            btnSaveIssueEdits.AccessibleName = "";
            btnSaveIssueEdits.BackColor = Color.LawnGreen;
            btnSaveIssueEdits.FlatStyle = FlatStyle.Flat;
            btnSaveIssueEdits.Location = new Point(1007, 16);
            btnSaveIssueEdits.Margin = new Padding(0, 0, 8, 0);
            btnSaveIssueEdits.Name = "btnSaveIssueEdits";
            btnSaveIssueEdits.Size = new Size(109, 29);
            btnSaveIssueEdits.TabIndex = 35;
            btnSaveIssueEdits.Text = "Save";
            btnSaveIssueEdits.UseVisualStyleBackColor = false;
            btnSaveIssueEdits.Click += btnSaveIssueEdits_Click;
            // 
            // changeDisplayBindingSource
            // 
            changeDisplayBindingSource.DataSource = typeof(Classes.ChangeDisplay);
            // 
            // Id
            // 
            Id.DataPropertyName = "ChangeId";
            Id.HeaderText = "ChangeId";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            // 
            // changeHash
            // 
            changeHash.DataPropertyName = "ChangeHash";
            changeHash.HeaderText = "ChangeHash";
            changeHash.MinimumWidth = 6;
            changeHash.Name = "changeHash";
            changeHash.ReadOnly = true;
            // 
            // name
            // 
            name.DataPropertyName = "Name";
            name.HeaderText = "Name";
            name.MinimumWidth = 6;
            name.Name = "name";
            name.ReadOnly = true;
            // 
            // description
            // 
            description.DataPropertyName = "Description";
            description.HeaderText = "Description";
            description.MinimumWidth = 6;
            description.Name = "description";
            description.ReadOnly = true;
            // 
            // createdAt
            // 
            createdAt.DataPropertyName = "CreatedAt";
            createdAt.HeaderText = "CreatedAt";
            createdAt.MinimumWidth = 6;
            createdAt.Name = "createdAt";
            createdAt.ReadOnly = true;
            // 
            // IssueView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(btnSaveIssueEdits);
            Controls.Add(textBoxIssueTitleEdit);
            Controls.Add(btnIssueNameEditSave);
            Controls.Add(groupBoxIssueMedia);
            Controls.Add(groupBoxIssueDetails);
            Controls.Add(btnOpenChange);
            Controls.Add(btnAddNewChange);
            Controls.Add(dataGridViewChanges);
            Controls.Add(lblIssueChangesTitle);
            Controls.Add(lblIssueTitle);
            Margin = new Padding(0);
            Name = "IssueView";
            Padding = new Padding(16);
            Size = new Size(1133, 718);
            Load += IssueView_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxIssueMedia).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewChanges).EndInit();
            ((System.ComponentModel.ISupportInitialize)changeBindingSource).EndInit();
            groupBoxIssueDetails.ResumeLayout(false);
            groupBoxIssueDetails.PerformLayout();
            groupBoxIssueMedia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)changeDisplayBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIssueTitle;
        private RichTextBox richTextBoxIssueDesc;
        private PictureBox pictureBoxIssueMedia;
        private ListBox listBoxMedia;
        private ToolTip toolTip;
        private RichTextBox richTextBoxMediaDesc;
        private Label lblIssueChangesTitle;
        private DataGridView dataGridViewChanges;
        private Button btnAddNewMedia;
        private Button btnEditMedia;
        private Button btnOpenChange;
        private Button btnAddNewChange;
        private BindingSource changeBindingSource;
        private Label lblIssueSeverityTitle;
        private Label lblIssueStatusTitle;
        private ComboBox comboBoxSeverityLevels;
        private ComboBox comboBoxStatusLevels;
        private GroupBox groupBoxIssueDetails;
        private GroupBox groupBoxIssueMedia;
        private Label lblIssueCreatedDate;
        private Button btnIssueNameEditSave;
        private ImageList imageList;
        private TextBox textBoxIssueTitleEdit;
        private Label lblIssueLastUpdated;
        private Button btnSaveIssueEdits;
        private BindingSource changeDisplayBindingSource;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn changeHash;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn description;
        private DataGridViewTextBoxColumn createdAt;
    }
}
