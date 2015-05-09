namespace JAJ.WinForm.PPM
{
    partial class ProjectPlanList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectPlanList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxCommonProject = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxDispatchStatus = new System.Windows.Forms.ComboBox();
            this.chkDisplayAllTask = new System.Windows.Forms.CheckBox();
            this.btnOpenProblemTrace = new System.Windows.Forms.Button();
            this.btnTurnToProblemTrace = new System.Windows.Forms.Button();
            this.btnAddPlan = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSaveBusinessCode = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewExt1 = new JAJ.WinForm.Comm.DataGridViewExt();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BusinessCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RealTestEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiffAnalyze = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DispatchStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DealPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestResourceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProblemTraceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExt1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbxCommonProject);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnExportExcel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbxDispatchStatus);
            this.panel1.Controls.Add(this.chkDisplayAllTask);
            this.panel1.Controls.Add(this.btnOpenProblemTrace);
            this.panel1.Controls.Add(this.btnTurnToProblemTrace);
            this.panel1.Controls.Add(this.btnAddPlan);
            this.panel1.Controls.Add(this.btnCopy);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnSaveBusinessCode);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1330, 104);
            this.panel1.TabIndex = 0;
            // 
            // cbxCommonProject
            // 
            this.cbxCommonProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxCommonProject.FormattingEnabled = true;
            this.cbxCommonProject.Location = new System.Drawing.Point(982, 52);
            this.cbxCommonProject.Name = "cbxCommonProject";
            this.cbxCommonProject.Size = new System.Drawing.Size(198, 20);
            this.cbxCommonProject.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(913, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "常用项目：";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Location = new System.Drawing.Point(1228, 55);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(90, 23);
            this.btnExportExcel.TabIndex = 10;
            this.btnExportExcel.Text = "导出excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(911, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "分配状态：";
            // 
            // cbxDispatchStatus
            // 
            this.cbxDispatchStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxDispatchStatus.DisplayMember = "全部";
            this.cbxDispatchStatus.FormattingEnabled = true;
            this.cbxDispatchStatus.Items.AddRange(new object[] {
            "全部",
            "已分配",
            "未分配"});
            this.cbxDispatchStatus.Location = new System.Drawing.Point(982, 13);
            this.cbxDispatchStatus.Name = "cbxDispatchStatus";
            this.cbxDispatchStatus.Size = new System.Drawing.Size(84, 20);
            this.cbxDispatchStatus.TabIndex = 8;
            this.cbxDispatchStatus.ValueMember = "全部";
            // 
            // chkDisplayAllTask
            // 
            this.chkDisplayAllTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDisplayAllTask.AutoSize = true;
            this.chkDisplayAllTask.Location = new System.Drawing.Point(1092, 16);
            this.chkDisplayAllTask.Name = "chkDisplayAllTask";
            this.chkDisplayAllTask.Size = new System.Drawing.Size(96, 16);
            this.chkDisplayAllTask.TabIndex = 7;
            this.chkDisplayAllTask.Text = "显示所有任务";
            this.chkDisplayAllTask.UseVisualStyleBackColor = true;
            this.chkDisplayAllTask.CheckedChanged += new System.EventHandler(this.chkDisplayAllTask_CheckedChanged);
            // 
            // btnOpenProblemTrace
            // 
            this.btnOpenProblemTrace.Location = new System.Drawing.Point(196, 12);
            this.btnOpenProblemTrace.Name = "btnOpenProblemTrace";
            this.btnOpenProblemTrace.Size = new System.Drawing.Size(95, 23);
            this.btnOpenProblemTrace.TabIndex = 6;
            this.btnOpenProblemTrace.Text = "转到问题跟踪";
            this.btnOpenProblemTrace.UseVisualStyleBackColor = true;
            this.btnOpenProblemTrace.Click += new System.EventHandler(this.btnOpenProblemTrace_Click);
            // 
            // btnTurnToProblemTrace
            // 
            this.btnTurnToProblemTrace.Location = new System.Drawing.Point(104, 70);
            this.btnTurnToProblemTrace.Name = "btnTurnToProblemTrace";
            this.btnTurnToProblemTrace.Size = new System.Drawing.Size(86, 23);
            this.btnTurnToProblemTrace.TabIndex = 5;
            this.btnTurnToProblemTrace.Text = "任务下发";
            this.btnTurnToProblemTrace.UseVisualStyleBackColor = true;
            this.btnTurnToProblemTrace.Click += new System.EventHandler(this.btnTurnToProblemTrace_Click);
            // 
            // btnAddPlan
            // 
            this.btnAddPlan.Location = new System.Drawing.Point(12, 12);
            this.btnAddPlan.Name = "btnAddPlan";
            this.btnAddPlan.Size = new System.Drawing.Size(86, 23);
            this.btnAddPlan.TabIndex = 0;
            this.btnAddPlan.Text = "新增";
            this.btnAddPlan.UseVisualStyleBackColor = true;
            this.btnAddPlan.Click += new System.EventHandler(this.btnAddPlan_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(104, 12);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(86, 23);
            this.btnCopy.TabIndex = 4;
            this.btnCopy.Text = "复制";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(1228, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(12, 41);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(86, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSaveBusinessCode
            // 
            this.btnSaveBusinessCode.Location = new System.Drawing.Point(104, 41);
            this.btnSaveBusinessCode.Name = "btnSaveBusinessCode";
            this.btnSaveBusinessCode.Size = new System.Drawing.Size(86, 23);
            this.btnSaveBusinessCode.TabIndex = 4;
            this.btnSaveBusinessCode.Text = "保存业务编码";
            this.btnSaveBusinessCode.UseVisualStyleBackColor = true;
            this.btnSaveBusinessCode.Click += new System.EventHandler(this.btnSaveBusinessCode_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 70);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewExt1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 104);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1330, 520);
            this.panel2.TabIndex = 1;
            // 
            // dataGridViewExt1
            // 
            this.dataGridViewExt1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExt1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Column1,
            this.Column2,
            this.BusinessCode,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.RealTestEndDate,
            this.DiffAnalyze,
            this.DispatchStatus,
            this.Status,
            this.DealPerson,
            this.TestResourceName,
            this.ProblemTraceID});
            this.dataGridViewExt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewExt1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewExt1.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dataGridViewExt1.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dataGridViewExt1.MergeColumnNames")));
            this.dataGridViewExt1.Name = "dataGridViewExt1";
            this.dataGridViewExt1.RowHeadersVisible = false;
            this.dataGridViewExt1.RowTemplate.Height = 23;
            this.dataGridViewExt1.Size = new System.Drawing.Size(1330, 520);
            this.dataGridViewExt1.TabIndex = 0;
            this.dataGridViewExt1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewExt1_CellClick);
            this.dataGridViewExt1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewExt1_CellDoubleClick);
            this.dataGridViewExt1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewExt1_CellEndEdit);
            this.dataGridViewExt1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewExt1_DataBindingComplete);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            this.ID.Width = 76;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Unit";
            this.Column1.HeaderText = "单元";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Activity";
            this.Column2.HeaderText = "活动(功能模块)";
            this.Column2.Name = "Column2";
            this.Column2.Width = 140;
            // 
            // BusinessCode
            // 
            this.BusinessCode.DataPropertyName = "BusinessCode";
            this.BusinessCode.HeaderText = "业务编码";
            this.BusinessCode.Name = "BusinessCode";
            this.BusinessCode.Width = 77;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Task";
            this.Column3.HeaderText = "任务（问题描述）";
            this.Column3.Name = "Column3";
            this.Column3.Width = 240;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "BudgetWorkload";
            this.Column4.HeaderText = "工作量";
            this.Column4.Name = "Column4";
            this.Column4.Width = 45;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "BudgetBeginDate";
            this.Column5.HeaderText = "开始日期";
            this.Column5.Name = "Column5";
            this.Column5.Width = 60;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "BudgetEndDate";
            this.Column6.HeaderText = "结束日期";
            this.Column6.Name = "Column6";
            this.Column6.Width = 60;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "RealWorkload";
            this.Column7.HeaderText = "工作量";
            this.Column7.Name = "Column7";
            this.Column7.Width = 45;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "RealBeginDate";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.Column8.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column8.HeaderText = "开始日期";
            this.Column8.Name = "Column8";
            this.Column8.Width = 60;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "RealEndDate";
            this.Column9.HeaderText = "开发结束日期";
            this.Column9.Name = "Column9";
            this.Column9.Width = 80;
            // 
            // RealTestEndDate
            // 
            this.RealTestEndDate.DataPropertyName = "TestPassDate";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.RealTestEndDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.RealTestEndDate.HeaderText = "测试结束日期";
            this.RealTestEndDate.Name = "RealTestEndDate";
            this.RealTestEndDate.Width = 85;
            // 
            // DiffAnalyze
            // 
            this.DiffAnalyze.DataPropertyName = "DiffAnalyze";
            this.DiffAnalyze.FillWeight = 150F;
            this.DiffAnalyze.HeaderText = "差异分析";
            this.DiffAnalyze.Name = "DiffAnalyze";
            this.DiffAnalyze.Width = 200;
            // 
            // DispatchStatus
            // 
            this.DispatchStatus.DataPropertyName = "DispatchStatus";
            this.DispatchStatus.HeaderText = "分配状态";
            this.DispatchStatus.Name = "DispatchStatus";
            this.DispatchStatus.Width = 65;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "状态";
            this.Status.Name = "Status";
            this.Status.Width = 80;
            // 
            // DealPerson
            // 
            this.DealPerson.DataPropertyName = "DealPerson";
            this.DealPerson.HeaderText = "负责人";
            this.DealPerson.Name = "DealPerson";
            this.DealPerson.Width = 65;
            // 
            // TestResourceName
            // 
            this.TestResourceName.DataPropertyName = "TestPerson";
            this.TestResourceName.HeaderText = "检查人员";
            this.TestResourceName.Name = "TestResourceName";
            this.TestResourceName.Width = 65;
            // 
            // ProblemTraceID
            // 
            this.ProblemTraceID.DataPropertyName = "ProblemTraceID";
            this.ProblemTraceID.HeaderText = "问题跟踪主键";
            this.ProblemTraceID.Name = "ProblemTraceID";
            this.ProblemTraceID.Visible = false;
            // 
            // ProjectPlanList
            // 
            this.ClientSize = new System.Drawing.Size(1330, 624);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ProjectPlanList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "项目计划";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PPMProjectPlanList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExt1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Comm.DataGridViewExt dataGridViewExt1;
        private System.Windows.Forms.Button btnAddPlan;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnSaveBusinessCode;
        private System.Windows.Forms.Button btnTurnToProblemTrace;
        private System.Windows.Forms.Button btnOpenProblemTrace;
        private System.Windows.Forms.CheckBox chkDisplayAllTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn BusinessCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn RealTestEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiffAnalyze;
        private System.Windows.Forms.DataGridViewTextBoxColumn DispatchStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestResourceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProblemTraceID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxDispatchStatus;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DealPerson;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxCommonProject;



    }
}