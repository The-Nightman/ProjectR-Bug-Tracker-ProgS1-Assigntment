namespace ProjectR.Controls
{
    partial class ProjectView
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
            lblProjectsProjectTitle = new Label();
            lblProjectActivityHeatmapTitle = new Label();
            formPlotProjectActivityHeatmap = new ScottPlot.WinForms.FormsPlot();
            separator = new Label();
            lblProjectTrackedIssuesTitle = new Label();
            formPlotCurrentOpenBugs = new ScottPlot.WinForms.FormsPlot();
            lblProjectCurrentOpenBugs = new Label();
            panelHeatmap = new Panel();
            panel1 = new Panel();
            issueListItemBindingSource = new BindingSource(components);
            dataGridViewIssues = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            titleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            changesCountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            severityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            createdAtDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lastUpdatedDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            btnAddNewIssue = new Button();
            btnOpenIssue = new Button();
            panelHeatmap.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)issueListItemBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewIssues).BeginInit();
            SuspendLayout();
            // 
            // lblProjectsProjectTitle
            // 
            lblProjectsProjectTitle.AutoSize = true;
            lblProjectsProjectTitle.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProjectsProjectTitle.ForeColor = SystemColors.ControlText;
            lblProjectsProjectTitle.Location = new Point(16, 16);
            lblProjectsProjectTitle.Margin = new Padding(0, 0, 0, 16);
            lblProjectsProjectTitle.Name = "lblProjectsProjectTitle";
            lblProjectsProjectTitle.Size = new Size(189, 32);
            lblProjectsProjectTitle.TabIndex = 3;
            lblProjectsProjectTitle.Text = "ProjectName";
            // 
            // lblProjectActivityHeatmapTitle
            // 
            lblProjectActivityHeatmapTitle.AutoSize = true;
            lblProjectActivityHeatmapTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProjectActivityHeatmapTitle.ForeColor = SystemColors.ControlLightLight;
            lblProjectActivityHeatmapTitle.Location = new Point(16, 16);
            lblProjectActivityHeatmapTitle.Margin = new Padding(0);
            lblProjectActivityHeatmapTitle.Name = "lblProjectActivityHeatmapTitle";
            lblProjectActivityHeatmapTitle.Size = new Size(167, 31);
            lblProjectActivityHeatmapTitle.TabIndex = 15;
            lblProjectActivityHeatmapTitle.Text = "Project Activity";
            // 
            // formPlotProjectActivityHeatmap
            // 
            formPlotProjectActivityHeatmap.DisplayScale = 1.25F;
            formPlotProjectActivityHeatmap.Location = new Point(16, 49);
            formPlotProjectActivityHeatmap.Margin = new Padding(0);
            formPlotProjectActivityHeatmap.Name = "formPlotProjectActivityHeatmap";
            formPlotProjectActivityHeatmap.Size = new Size(604, 233);
            formPlotProjectActivityHeatmap.TabIndex = 13;
            // 
            // separator
            // 
            separator.BackColor = SystemColors.ControlDark;
            separator.BorderStyle = BorderStyle.FixedSingle;
            separator.Location = new Point(16, 386);
            separator.Margin = new Padding(0, 16, 0, 16);
            separator.Name = "separator";
            separator.Size = new Size(1101, 2);
            separator.TabIndex = 11;
            // 
            // lblProjectTrackedIssuesTitle
            // 
            lblProjectTrackedIssuesTitle.AutoSize = true;
            lblProjectTrackedIssuesTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProjectTrackedIssuesTitle.ForeColor = SystemColors.ControlText;
            lblProjectTrackedIssuesTitle.Location = new Point(19, 64);
            lblProjectTrackedIssuesTitle.Name = "lblProjectTrackedIssuesTitle";
            lblProjectTrackedIssuesTitle.Size = new Size(159, 31);
            lblProjectTrackedIssuesTitle.TabIndex = 19;
            lblProjectTrackedIssuesTitle.Text = "Tracked Issues";
            // 
            // formPlotCurrentOpenBugs
            // 
            formPlotCurrentOpenBugs.DisplayScale = 1.25F;
            formPlotCurrentOpenBugs.Location = new Point(16, 47);
            formPlotCurrentOpenBugs.Margin = new Padding(0);
            formPlotCurrentOpenBugs.Name = "formPlotCurrentOpenBugs";
            formPlotCurrentOpenBugs.Size = new Size(419, 233);
            formPlotCurrentOpenBugs.TabIndex = 20;
            // 
            // lblProjectCurrentOpenBugs
            // 
            lblProjectCurrentOpenBugs.AutoSize = true;
            lblProjectCurrentOpenBugs.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProjectCurrentOpenBugs.ForeColor = SystemColors.ControlLightLight;
            lblProjectCurrentOpenBugs.Location = new Point(16, 16);
            lblProjectCurrentOpenBugs.Margin = new Padding(0);
            lblProjectCurrentOpenBugs.Name = "lblProjectCurrentOpenBugs";
            lblProjectCurrentOpenBugs.Size = new Size(208, 31);
            lblProjectCurrentOpenBugs.TabIndex = 21;
            lblProjectCurrentOpenBugs.Text = "Current Open Bugs";
            // 
            // panelHeatmap
            // 
            panelHeatmap.BackColor = Color.FromArgb(57, 57, 57);
            panelHeatmap.Controls.Add(lblProjectActivityHeatmapTitle);
            panelHeatmap.Controls.Add(formPlotProjectActivityHeatmap);
            panelHeatmap.Location = new Point(16, 406);
            panelHeatmap.Margin = new Padding(0);
            panelHeatmap.Name = "panelHeatmap";
            panelHeatmap.Padding = new Padding(16);
            panelHeatmap.Size = new Size(639, 296);
            panelHeatmap.TabIndex = 22;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(57, 57, 57);
            panel1.Controls.Add(lblProjectCurrentOpenBugs);
            panel1.Controls.Add(formPlotCurrentOpenBugs);
            panel1.Location = new Point(666, 406);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(16);
            panel1.Size = new Size(451, 296);
            panel1.TabIndex = 23;
            // 
            // issueListItemBindingSource
            // 
            issueListItemBindingSource.DataSource = typeof(Classes.IssueListItem);
            // 
            // dataGridViewIssues
            // 
            dataGridViewIssues.AllowUserToAddRows = false;
            dataGridViewIssues.AllowUserToDeleteRows = false;
            dataGridViewIssues.AllowUserToResizeRows = false;
            dataGridViewIssues.AutoGenerateColumns = false;
            dataGridViewIssues.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewIssues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewIssues.Columns.AddRange(new DataGridViewColumn[] { Id, titleDataGridViewTextBoxColumn, changesCountDataGridViewTextBoxColumn, statusDataGridViewTextBoxColumn, severityDataGridViewTextBoxColumn, createdAtDataGridViewTextBoxColumn, lastUpdatedDataGridViewTextBoxColumn });
            dataGridViewIssues.DataSource = issueListItemBindingSource;
            dataGridViewIssues.Location = new Point(16, 95);
            dataGridViewIssues.Margin = new Padding(0);
            dataGridViewIssues.MultiSelect = false;
            dataGridViewIssues.Name = "dataGridViewIssues";
            dataGridViewIssues.ReadOnly = true;
            dataGridViewIssues.RowHeadersVisible = false;
            dataGridViewIssues.RowHeadersWidth = 51;
            dataGridViewIssues.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewIssues.Size = new Size(1101, 275);
            dataGridViewIssues.TabIndex = 25;
            dataGridViewIssues.DataBindingComplete += dataGridViewIssues_DataBindingComplete;
            dataGridViewIssues.SelectionChanged += dataGridViewIssues_SelectionChanged;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            titleDataGridViewTextBoxColumn.FillWeight = 82F;
            titleDataGridViewTextBoxColumn.HeaderText = "Title";
            titleDataGridViewTextBoxColumn.MinimumWidth = 6;
            titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // changesCountDataGridViewTextBoxColumn
            // 
            changesCountDataGridViewTextBoxColumn.DataPropertyName = "ChangesCount";
            changesCountDataGridViewTextBoxColumn.FillWeight = 15F;
            changesCountDataGridViewTextBoxColumn.HeaderText = "Changes";
            changesCountDataGridViewTextBoxColumn.MinimumWidth = 6;
            changesCountDataGridViewTextBoxColumn.Name = "changesCountDataGridViewTextBoxColumn";
            changesCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            statusDataGridViewTextBoxColumn.FillWeight = 20F;
            statusDataGridViewTextBoxColumn.HeaderText = "Status";
            statusDataGridViewTextBoxColumn.MinimumWidth = 6;
            statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // severityDataGridViewTextBoxColumn
            // 
            severityDataGridViewTextBoxColumn.DataPropertyName = "Severity";
            severityDataGridViewTextBoxColumn.FillWeight = 18F;
            severityDataGridViewTextBoxColumn.HeaderText = "Severity";
            severityDataGridViewTextBoxColumn.MinimumWidth = 6;
            severityDataGridViewTextBoxColumn.Name = "severityDataGridViewTextBoxColumn";
            severityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createdAtDataGridViewTextBoxColumn
            // 
            createdAtDataGridViewTextBoxColumn.DataPropertyName = "FormattedCreatedAt";
            createdAtDataGridViewTextBoxColumn.FillWeight = 24F;
            createdAtDataGridViewTextBoxColumn.HeaderText = "Created at";
            createdAtDataGridViewTextBoxColumn.MinimumWidth = 6;
            createdAtDataGridViewTextBoxColumn.Name = "createdAtDataGridViewTextBoxColumn";
            createdAtDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastUpdatedDataGridViewTextBoxColumn
            // 
            lastUpdatedDataGridViewTextBoxColumn.DataPropertyName = "FormattedLastUpdated";
            lastUpdatedDataGridViewTextBoxColumn.FillWeight = 24F;
            lastUpdatedDataGridViewTextBoxColumn.HeaderText = "Last updated";
            lastUpdatedDataGridViewTextBoxColumn.MinimumWidth = 6;
            lastUpdatedDataGridViewTextBoxColumn.Name = "lastUpdatedDataGridViewTextBoxColumn";
            lastUpdatedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // btnAddNewIssue
            // 
            btnAddNewIssue.BackColor = Color.LawnGreen;
            btnAddNewIssue.FlatStyle = FlatStyle.Popup;
            btnAddNewIssue.Location = new Point(845, 61);
            btnAddNewIssue.Margin = new Padding(0, 0, 8, 0);
            btnAddNewIssue.Name = "btnAddNewIssue";
            btnAddNewIssue.Size = new Size(128, 30);
            btnAddNewIssue.TabIndex = 26;
            btnAddNewIssue.Text = "Track New Issue";
            btnAddNewIssue.UseVisualStyleBackColor = false;
            btnAddNewIssue.Click += btnAddNewIssue_Click;
            // 
            // btnOpenIssue
            // 
            btnOpenIssue.BackColor = Color.DodgerBlue;
            btnOpenIssue.Enabled = false;
            btnOpenIssue.FlatStyle = FlatStyle.Flat;
            btnOpenIssue.Location = new Point(989, 61);
            btnOpenIssue.Margin = new Padding(8, 0, 0, 0);
            btnOpenIssue.Name = "btnOpenIssue";
            btnOpenIssue.Size = new Size(128, 30);
            btnOpenIssue.TabIndex = 27;
            btnOpenIssue.Text = "Open Issue";
            btnOpenIssue.UseVisualStyleBackColor = false;
            btnOpenIssue.Click += btnOpenIssue_Click;
            // 
            // ProjectView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(btnOpenIssue);
            Controls.Add(btnAddNewIssue);
            Controls.Add(dataGridViewIssues);
            Controls.Add(panel1);
            Controls.Add(panelHeatmap);
            Controls.Add(lblProjectTrackedIssuesTitle);
            Controls.Add(separator);
            Controls.Add(lblProjectsProjectTitle);
            Margin = new Padding(0);
            Name = "ProjectView";
            Padding = new Padding(16);
            Size = new Size(1133, 718);
            Load += ProjectView_Load;
            panelHeatmap.ResumeLayout(false);
            panelHeatmap.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)issueListItemBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewIssues).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProjectsProjectTitle;
        private Label lblProjectActivityHeatmapTitle;
        private ScottPlot.WinForms.FormsPlot formPlotProjectActivityHeatmap;
        private Label separator;
        private Label lblProjectTrackedIssuesTitle;
        private ScottPlot.WinForms.FormsPlot formPlotCurrentOpenBugs;
        private Label lblProjectCurrentOpenBugs;
        private Panel panelHeatmap;
        private Panel panel1;
        private BindingSource issueListItemBindingSource;
        private DataGridView dataGridViewIssues;
        private Button btnAddNewIssue;
        private Button btnOpenIssue;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn changesCountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn severityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn createdAtDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastUpdatedDataGridViewTextBoxColumn;
    }
}
