namespace JIRAReport
{
    partial class Form1
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridSprints = new System.Windows.Forms.DataGridView();
            this.gridSprintID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSprintName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSprintState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSprintStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSprintCompleteDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStories = new System.Windows.Forms.DataGridView();
            this.gridStoryEpic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStoryKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStorySummary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStoryPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStoryAssigneeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridStoryStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtRapidViewID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chkChaos = new System.Windows.Forms.CheckBox();
            this.btnGenerateWord = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtScrumTeamName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtScrumMaster = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProductOwner = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSprintDuration = new System.Windows.Forms.TextBox();
            this.gridResources = new System.Windows.Forms.DataGridView();
            this.gridResourceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridResourceAvailability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridResourceIDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridResourcePoints = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSprints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStories)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridResources)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(955, 20);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(101, 35);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Log In";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(123, 24);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(171, 26);
            this.txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(407, 24);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(169, 26);
            this.txtPassword.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "User Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(6, 61);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridSprints);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridStories);
            this.splitContainer1.Size = new System.Drawing.Size(1220, 577);
            this.splitContainer1.SplitterDistance = 212;
            this.splitContainer1.TabIndex = 3;
            // 
            // gridSprints
            // 
            this.gridSprints.AllowUserToAddRows = false;
            this.gridSprints.AllowUserToDeleteRows = false;
            this.gridSprints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSprints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridSprintID,
            this.gridSprintName,
            this.gridSprintState,
            this.gridSprintStartDate,
            this.gridSprintCompleteDate});
            this.gridSprints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSprints.Location = new System.Drawing.Point(0, 0);
            this.gridSprints.Name = "gridSprints";
            this.gridSprints.ReadOnly = true;
            this.gridSprints.RowTemplate.Height = 28;
            this.gridSprints.Size = new System.Drawing.Size(1220, 212);
            this.gridSprints.TabIndex = 0;
            this.gridSprints.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSprints_CellDoubleClick);
            // 
            // gridSprintID
            // 
            this.gridSprintID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gridSprintID.HeaderText = "Sprint ID";
            this.gridSprintID.Name = "gridSprintID";
            this.gridSprintID.ReadOnly = true;
            this.gridSprintID.Width = 108;
            // 
            // gridSprintName
            // 
            this.gridSprintName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gridSprintName.HeaderText = "Name";
            this.gridSprintName.Name = "gridSprintName";
            this.gridSprintName.ReadOnly = true;
            this.gridSprintName.Width = 87;
            // 
            // gridSprintState
            // 
            this.gridSprintState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gridSprintState.HeaderText = "State";
            this.gridSprintState.Name = "gridSprintState";
            this.gridSprintState.ReadOnly = true;
            this.gridSprintState.Width = 84;
            // 
            // gridSprintStartDate
            // 
            this.gridSprintStartDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gridSprintStartDate.HeaderText = "Start Date";
            this.gridSprintStartDate.Name = "gridSprintStartDate";
            this.gridSprintStartDate.ReadOnly = true;
            this.gridSprintStartDate.Width = 119;
            // 
            // gridSprintCompleteDate
            // 
            this.gridSprintCompleteDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gridSprintCompleteDate.HeaderText = "Complete Date";
            this.gridSprintCompleteDate.Name = "gridSprintCompleteDate";
            this.gridSprintCompleteDate.ReadOnly = true;
            this.gridSprintCompleteDate.Width = 152;
            // 
            // gridStories
            // 
            this.gridStories.AllowUserToAddRows = false;
            this.gridStories.AllowUserToDeleteRows = false;
            this.gridStories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridStoryEpic,
            this.gridStoryKey,
            this.gridStorySummary,
            this.gridStoryPoint,
            this.gridStoryAssigneeName,
            this.gridStoryStatus});
            this.gridStories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStories.Location = new System.Drawing.Point(0, 0);
            this.gridStories.Name = "gridStories";
            this.gridStories.ReadOnly = true;
            this.gridStories.RowTemplate.Height = 28;
            this.gridStories.Size = new System.Drawing.Size(1220, 361);
            this.gridStories.TabIndex = 0;
            // 
            // gridStoryEpic
            // 
            this.gridStoryEpic.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gridStoryEpic.HeaderText = "Epic";
            this.gridStoryEpic.Name = "gridStoryEpic";
            this.gridStoryEpic.ReadOnly = true;
            this.gridStoryEpic.Width = 76;
            // 
            // gridStoryKey
            // 
            this.gridStoryKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gridStoryKey.HeaderText = "Story Key";
            this.gridStoryKey.Name = "gridStoryKey";
            this.gridStoryKey.ReadOnly = true;
            this.gridStoryKey.Width = 112;
            // 
            // gridStorySummary
            // 
            this.gridStorySummary.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gridStorySummary.HeaderText = "Summary";
            this.gridStorySummary.Name = "gridStorySummary";
            this.gridStorySummary.ReadOnly = true;
            this.gridStorySummary.Width = 112;
            // 
            // gridStoryPoint
            // 
            this.gridStoryPoint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gridStoryPoint.HeaderText = "Point";
            this.gridStoryPoint.Name = "gridStoryPoint";
            this.gridStoryPoint.ReadOnly = true;
            this.gridStoryPoint.Width = 81;
            // 
            // gridStoryAssigneeName
            // 
            this.gridStoryAssigneeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gridStoryAssigneeName.HeaderText = "Assignee";
            this.gridStoryAssigneeName.Name = "gridStoryAssigneeName";
            this.gridStoryAssigneeName.ReadOnly = true;
            this.gridStoryAssigneeName.Width = 111;
            // 
            // gridStoryStatus
            // 
            this.gridStoryStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gridStoryStatus.HeaderText = "Status";
            this.gridStoryStatus.Name = "gridStoryStatus";
            this.gridStoryStatus.ReadOnly = true;
            this.gridStoryStatus.Width = 92;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1240, 692);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnLogin);
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Controls.Add(this.txtUsername);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtRapidViewID);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtPassword);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1232, 659);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sprints";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtRapidViewID
            // 
            this.txtRapidViewID.Location = new System.Drawing.Point(742, 24);
            this.txtRapidViewID.Name = "txtRapidViewID";
            this.txtRapidViewID.Size = new System.Drawing.Size(169, 26);
            this.txtRapidViewID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(602, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rapid View ID:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gridResources);
            this.tabPage2.Controls.Add(this.txtProductOwner);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtSprintDuration);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txtScrumMaster);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtScrumTeamName);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1232, 659);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Basic Info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chkChaos);
            this.tabPage3.Controls.Add(this.btnGenerateWord);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1232, 659);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Actions";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chkChaos
            // 
            this.chkChaos.AutoSize = true;
            this.chkChaos.Location = new System.Drawing.Point(507, 151);
            this.chkChaos.Name = "chkChaos";
            this.chkChaos.Size = new System.Drawing.Size(138, 24);
            this.chkChaos.TabIndex = 1;
            this.chkChaos.Text = "Chaos in Day1";
            this.chkChaos.UseVisualStyleBackColor = true;
            // 
            // btnGenerateWord
            // 
            this.btnGenerateWord.Location = new System.Drawing.Point(507, 203);
            this.btnGenerateWord.Name = "btnGenerateWord";
            this.btnGenerateWord.Size = new System.Drawing.Size(161, 159);
            this.btnGenerateWord.TabIndex = 0;
            this.btnGenerateWord.Text = "Generate Word";
            this.btnGenerateWord.UseVisualStyleBackColor = true;
            this.btnGenerateWord.Click += new System.EventHandler(this.btnGenerateWord_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 670);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1240, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Scrum Team Name: ";
            // 
            // txtScrumTeamName
            // 
            this.txtScrumTeamName.Location = new System.Drawing.Point(204, 16);
            this.txtScrumTeamName.Name = "txtScrumTeamName";
            this.txtScrumTeamName.Size = new System.Drawing.Size(302, 26);
            this.txtScrumTeamName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Scrum Master: ";
            // 
            // txtScrumMaster
            // 
            this.txtScrumMaster.Location = new System.Drawing.Point(204, 66);
            this.txtScrumMaster.Name = "txtScrumMaster";
            this.txtScrumMaster.Size = new System.Drawing.Size(302, 26);
            this.txtScrumMaster.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(585, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Product Owner: ";
            // 
            // txtProductOwner
            // 
            this.txtProductOwner.Location = new System.Drawing.Point(745, 17);
            this.txtProductOwner.Name = "txtProductOwner";
            this.txtProductOwner.Size = new System.Drawing.Size(296, 26);
            this.txtProductOwner.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(585, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Sprint (Duration): ";
            // 
            // txtSprintDuration
            // 
            this.txtSprintDuration.Location = new System.Drawing.Point(745, 66);
            this.txtSprintDuration.Name = "txtSprintDuration";
            this.txtSprintDuration.Size = new System.Drawing.Size(296, 26);
            this.txtSprintDuration.TabIndex = 1;
            // 
            // gridResources
            // 
            this.gridResources.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridResources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridResources.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridResourceName,
            this.gridResourceAvailability,
            this.gridResourceIDD,
            this.gridResourcePoints});
            this.gridResources.Location = new System.Drawing.Point(48, 130);
            this.gridResources.Name = "gridResources";
            this.gridResources.RowTemplate.Height = 28;
            this.gridResources.Size = new System.Drawing.Size(1132, 418);
            this.gridResources.TabIndex = 2;
            // 
            // gridResourceName
            // 
            this.gridResourceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gridResourceName.HeaderText = "Team Member Name";
            this.gridResourceName.Name = "gridResourceName";
            this.gridResourceName.Width = 177;
            // 
            // gridResourceAvailability
            // 
            this.gridResourceAvailability.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gridResourceAvailability.HeaderText = "% Availability";
            this.gridResourceAvailability.Name = "gridResourceAvailability";
            this.gridResourceAvailability.Width = 125;
            // 
            // gridResourceIDD
            // 
            this.gridResourceIDD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gridResourceIDD.HeaderText = "Hrs Availability Ideal developer day (IDD) - 6 hrs work)";
            this.gridResourceIDD.Name = "gridResourceIDD";
            this.gridResourceIDD.Width = 265;
            // 
            // gridResourcePoints
            // 
            this.gridResourcePoints.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gridResourcePoints.HeaderText = "Points";
            this.gridResourcePoints.Name = "gridResourcePoints";
            this.gridResourcePoints.Width = 89;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 692);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Jira Report";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSprints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStories)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridResources)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtRapidViewID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridSprints;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSprintID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSprintName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSprintState;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSprintStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridSprintCompleteDate;
        private System.Windows.Forms.DataGridView gridStories;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStoryEpic;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStoryKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStorySummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStoryPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStoryAssigneeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStoryStatus;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox chkChaos;
        private System.Windows.Forms.Button btnGenerateWord;
        private System.Windows.Forms.TextBox txtScrumMaster;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtScrumTeamName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProductOwner;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSprintDuration;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView gridResources;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridResourceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridResourceAvailability;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridResourceIDD;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridResourcePoints;
    }
}

