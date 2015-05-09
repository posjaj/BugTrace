namespace JAJ.WinForm.PPM
{
    partial class ProblemTraceList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProblemTraceList));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTaskID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClearProblemType = new System.Windows.Forms.Button();
            this.lbProblemType = new System.Windows.Forms.ListBox();
            this.lblTestPublish = new System.Windows.Forms.Label();
            this.btnTestPublish = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClearFindPerson = new System.Windows.Forms.Button();
            this.lbFindPerson = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClearDealPerson = new System.Windows.Forms.Button();
            this.lbDealPerson = new System.Windows.Forms.ListBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClearStatus = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvProblemTrace = new System.Windows.Forms.DataGridView();
            this.SerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProblemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Module = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Problem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FindPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FindDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Solution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DealPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDealDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectUse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPageTotal = new System.Windows.Forms.Label();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.cbxPageSize = new System.Windows.Forms.ComboBox();
            this.btnSkip = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.txtPageNum = new System.Windows.Forms.TextBox();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProblemTrace)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTaskID);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnClearProblemType);
            this.panel1.Controls.Add(this.lbProblemType);
            this.panel1.Controls.Add(this.lblTestPublish);
            this.panel1.Controls.Add(this.btnTestPublish);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnClearFindPerson);
            this.panel1.Controls.Add(this.lbFindPerson);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnClearDealPerson);
            this.panel1.Controls.Add(this.lbDealPerson);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.btnClearStatus);
            this.panel1.Controls.Add(this.lbStatus);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1127, 100);
            this.panel1.TabIndex = 0;
            // 
            // txtTaskID
            // 
            this.txtTaskID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaskID.Location = new System.Drawing.Point(382, 41);
            this.txtTaskID.Name = "txtTaskID";
            this.txtTaskID.Size = new System.Drawing.Size(67, 21);
            this.txtTaskID.TabIndex = 25;
            this.txtTaskID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTaskID_KeyPress);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(323, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "任务号：";
            // 
            // btnClearProblemType
            // 
            this.btnClearProblemType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearProblemType.Location = new System.Drawing.Point(878, 26);
            this.btnClearProblemType.Name = "btnClearProblemType";
            this.btnClearProblemType.Size = new System.Drawing.Size(30, 48);
            this.btnClearProblemType.TabIndex = 23;
            this.btnClearProblemType.Text = "清除";
            this.btnClearProblemType.UseVisualStyleBackColor = true;
            this.btnClearProblemType.Click += new System.EventHandler(this.btnClearProblemType_Click);
            // 
            // lbProblemType
            // 
            this.lbProblemType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbProblemType.FormattingEnabled = true;
            this.lbProblemType.ItemHeight = 12;
            this.lbProblemType.Items.AddRange(new object[] {
            "新功能",
            "现有功能优化",
            "BUG",
            "其它"});
            this.lbProblemType.Location = new System.Drawing.Point(794, 5);
            this.lbProblemType.Name = "lbProblemType";
            this.lbProblemType.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbProblemType.Size = new System.Drawing.Size(84, 88);
            this.lbProblemType.TabIndex = 22;
            // 
            // lblTestPublish
            // 
            this.lblTestPublish.AutoSize = true;
            this.lblTestPublish.Location = new System.Drawing.Point(171, 8);
            this.lblTestPublish.Name = "lblTestPublish";
            this.lblTestPublish.Size = new System.Drawing.Size(77, 12);
            this.lblTestPublish.TabIndex = 21;
            this.lblTestPublish.Text = "上次发包时间";
            // 
            // btnTestPublish
            // 
            this.btnTestPublish.Location = new System.Drawing.Point(90, 3);
            this.btnTestPublish.Name = "btnTestPublish";
            this.btnTestPublish.Size = new System.Drawing.Size(75, 23);
            this.btnTestPublish.TabIndex = 19;
            this.btnTestPublish.Text = "测试发包";
            this.btnTestPublish.UseVisualStyleBackColor = true;
            this.btnTestPublish.Click += new System.EventHandler(this.btnTestPublish_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(455, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "提出人";
            // 
            // btnClearFindPerson
            // 
            this.btnClearFindPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFindPerson.Location = new System.Drawing.Point(580, 27);
            this.btnClearFindPerson.Name = "btnClearFindPerson";
            this.btnClearFindPerson.Size = new System.Drawing.Size(27, 48);
            this.btnClearFindPerson.TabIndex = 17;
            this.btnClearFindPerson.Text = "清除";
            this.btnClearFindPerson.UseVisualStyleBackColor = true;
            this.btnClearFindPerson.Click += new System.EventHandler(this.btnClearFindPerson_Click);
            // 
            // lbFindPerson
            // 
            this.lbFindPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFindPerson.FormattingEnabled = true;
            this.lbFindPerson.ItemHeight = 12;
            this.lbFindPerson.Location = new System.Drawing.Point(499, 5);
            this.lbFindPerson.Name = "lbFindPerson";
            this.lbFindPerson.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbFindPerson.Size = new System.Drawing.Size(81, 88);
            this.lbFindPerson.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(625, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "处理人";
            // 
            // btnClearDealPerson
            // 
            this.btnClearDealPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearDealPerson.Location = new System.Drawing.Point(750, 27);
            this.btnClearDealPerson.Name = "btnClearDealPerson";
            this.btnClearDealPerson.Size = new System.Drawing.Size(27, 48);
            this.btnClearDealPerson.TabIndex = 14;
            this.btnClearDealPerson.Text = "清除";
            this.btnClearDealPerson.UseVisualStyleBackColor = true;
            this.btnClearDealPerson.Click += new System.EventHandler(this.btnClearDealPerson_Click);
            // 
            // lbDealPerson
            // 
            this.lbDealPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDealPerson.FormattingEnabled = true;
            this.lbDealPerson.ItemHeight = 12;
            this.lbDealPerson.Location = new System.Drawing.Point(669, 5);
            this.lbDealPerson.Name = "lbDealPerson";
            this.lbDealPerson.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbDealPerson.Size = new System.Drawing.Size(81, 88);
            this.lbDealPerson.TabIndex = 13;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(1051, 56);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(59, 23);
            this.btnExport.TabIndex = 12;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Controls.Add(this.btnEdit);
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(84, 100);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(3, 32);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(3, 61);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClearStatus
            // 
            this.btnClearStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearStatus.Location = new System.Drawing.Point(1004, 27);
            this.btnClearStatus.Name = "btnClearStatus";
            this.btnClearStatus.Size = new System.Drawing.Size(30, 48);
            this.btnClearStatus.TabIndex = 8;
            this.btnClearStatus.Text = "清除";
            this.btnClearStatus.UseVisualStyleBackColor = true;
            this.btnClearStatus.Click += new System.EventHandler(this.btnClearStatus_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStatus.FormattingEnabled = true;
            this.lbStatus.ItemHeight = 12;
            this.lbStatus.Items.AddRange(new object[] {
            "未开始",
            "进行中",
            "未通过",
            "已提交未审核",
            "完成",
            "已发现未处理",
            "发版关闭"});
            this.lbStatus.Location = new System.Drawing.Point(920, 6);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbStatus.Size = new System.Drawing.Size(84, 88);
            this.lbStatus.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(1051, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(59, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dgvProblemTrace);
            this.panel2.Location = new System.Drawing.Point(0, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1127, 412);
            this.panel2.TabIndex = 1;
            // 
            // dgvProblemTrace
            // 
            this.dgvProblemTrace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProblemTrace.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SerialNo,
            this.ID,
            this.ProblemType,
            this.Module,
            this.Problem,
            this.FindPerson,
            this.FindDate,
            this.Solution,
            this.DealPerson,
            this.Status,
            this.EndDealDate,
            this.TestFlag,
            this.ProjectUse});
            this.dgvProblemTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProblemTrace.Location = new System.Drawing.Point(0, 0);
            this.dgvProblemTrace.Name = "dgvProblemTrace";
            this.dgvProblemTrace.RowHeadersVisible = false;
            this.dgvProblemTrace.RowTemplate.Height = 23;
            this.dgvProblemTrace.Size = new System.Drawing.Size(1127, 412);
            this.dgvProblemTrace.TabIndex = 0;
            this.dgvProblemTrace.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProblemTrace_CellDoubleClick);
            this.dgvProblemTrace.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvProblemTrace_DataBindingComplete);
            this.dgvProblemTrace.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvProblemTrace_RowPostPaint);
            // 
            // SerialNo
            // 
            this.SerialNo.DataPropertyName = "SerialNo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SerialNo.DefaultCellStyle = dataGridViewCellStyle1;
            this.SerialNo.FillWeight = 52F;
            this.SerialNo.HeaderText = "序号";
            this.SerialNo.Name = "SerialNo";
            this.SerialNo.Width = 52;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.ID.DefaultCellStyle = dataGridViewCellStyle2;
            this.ID.HeaderText = "任务号";
            this.ID.Name = "ID";
            this.ID.Width = 70;
            // 
            // ProblemType
            // 
            this.ProblemType.DataPropertyName = "ProblemType";
            this.ProblemType.HeaderText = "类型";
            this.ProblemType.Name = "ProblemType";
            this.ProblemType.Width = 80;
            // 
            // Module
            // 
            this.Module.DataPropertyName = "Module";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Module.DefaultCellStyle = dataGridViewCellStyle3;
            this.Module.FillWeight = 90F;
            this.Module.HeaderText = "功能模块";
            this.Module.Name = "Module";
            // 
            // Problem
            // 
            this.Problem.DataPropertyName = "Problem";
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Problem.DefaultCellStyle = dataGridViewCellStyle4;
            this.Problem.HeaderText = "问题描述";
            this.Problem.Name = "Problem";
            this.Problem.Width = 230;
            // 
            // FindPerson
            // 
            this.FindPerson.DataPropertyName = "FindPerson";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FindPerson.DefaultCellStyle = dataGridViewCellStyle5;
            this.FindPerson.HeaderText = "提出人";
            this.FindPerson.Name = "FindPerson";
            this.FindPerson.Width = 70;
            // 
            // FindDate
            // 
            this.FindDate.DataPropertyName = "FindDate";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.FindDate.DefaultCellStyle = dataGridViewCellStyle6;
            this.FindDate.HeaderText = "提出日期";
            this.FindDate.Name = "FindDate";
            this.FindDate.Width = 80;
            // 
            // Solution
            // 
            this.Solution.DataPropertyName = "Solution";
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Solution.DefaultCellStyle = dataGridViewCellStyle7;
            this.Solution.HeaderText = "解决方案";
            this.Solution.Name = "Solution";
            this.Solution.Width = 150;
            // 
            // DealPerson
            // 
            this.DealPerson.DataPropertyName = "DealPerson";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DealPerson.DefaultCellStyle = dataGridViewCellStyle8;
            this.DealPerson.HeaderText = "执行人";
            this.DealPerson.Name = "DealPerson";
            this.DealPerson.Width = 70;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "状态";
            this.Status.Name = "Status";
            this.Status.Width = 80;
            // 
            // EndDealDate
            // 
            this.EndDealDate.DataPropertyName = "EndDealDate";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.EndDealDate.DefaultCellStyle = dataGridViewCellStyle9;
            this.EndDealDate.HeaderText = "完成时间";
            this.EndDealDate.Name = "EndDealDate";
            this.EndDealDate.Width = 80;
            // 
            // TestFlag
            // 
            this.TestFlag.DataPropertyName = "TestFlag";
            this.TestFlag.HeaderText = "测试发包";
            this.TestFlag.Name = "TestFlag";
            this.TestFlag.Width = 80;
            // 
            // ProjectUse
            // 
            this.ProjectUse.DataPropertyName = "ProjectUse";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ProjectUse.DefaultCellStyle = dataGridViewCellStyle10;
            this.ProjectUse.HeaderText = "系统";
            this.ProjectUse.Name = "ProjectUse";
            this.ProjectUse.Visible = false;
            this.ProjectUse.Width = 60;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblPageTotal);
            this.panel3.Controls.Add(this.lblPageInfo);
            this.panel3.Controls.Add(this.cbxPageSize);
            this.panel3.Controls.Add(this.btnSkip);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnFirstPage);
            this.panel3.Controls.Add(this.txtPageNum);
            this.panel3.Controls.Add(this.btnPrevPage);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnNextPage);
            this.panel3.Controls.Add(this.btnLastPage);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 509);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1127, 38);
            this.panel3.TabIndex = 2;
            // 
            // lblPageTotal
            // 
            this.lblPageTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageTotal.AutoSize = true;
            this.lblPageTotal.Location = new System.Drawing.Point(669, 13);
            this.lblPageTotal.Name = "lblPageTotal";
            this.lblPageTotal.Size = new System.Drawing.Size(23, 12);
            this.lblPageTotal.TabIndex = 29;
            this.lblPageTotal.Text = "1页";
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Location = new System.Drawing.Point(422, 14);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(107, 12);
            this.lblPageInfo.TabIndex = 26;
            this.lblPageInfo.Text = "总共0条记录，每页";
            // 
            // cbxPageSize
            // 
            this.cbxPageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxPageSize.FormattingEnabled = true;
            this.cbxPageSize.Items.AddRange(new object[] {
            "20",
            "50",
            "100",
            "1000"});
            this.cbxPageSize.Location = new System.Drawing.Point(558, 10);
            this.cbxPageSize.Name = "cbxPageSize";
            this.cbxPageSize.Size = new System.Drawing.Size(54, 20);
            this.cbxPageSize.TabIndex = 27;
            this.cbxPageSize.Text = "20";
            // 
            // btnSkip
            // 
            this.btnSkip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSkip.Location = new System.Drawing.Point(1046, 8);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(50, 23);
            this.btnSkip.TabIndex = 25;
            this.btnSkip.Text = "跳转";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(622, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 28;
            this.label3.Text = "条，共";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1023, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "页";
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFirstPage.Location = new System.Drawing.Point(714, 8);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(52, 23);
            this.btnFirstPage.TabIndex = 20;
            this.btnFirstPage.Text = "首页";
            this.btnFirstPage.UseVisualStyleBackColor = true;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // txtPageNum
            // 
            this.txtPageNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPageNum.Location = new System.Drawing.Point(971, 9);
            this.txtPageNum.Name = "txtPageNum";
            this.txtPageNum.Size = new System.Drawing.Size(46, 21);
            this.txtPageNum.TabIndex = 23;
            this.txtPageNum.Text = "1";
            this.txtPageNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPageNum_KeyDown);
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevPage.Location = new System.Drawing.Point(772, 8);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(51, 23);
            this.btnPrevPage.TabIndex = 18;
            this.btnPrevPage.Text = "上一页";
            this.btnPrevPage.UseVisualStyleBackColor = true;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(948, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "第";
            // 
            // btnNextPage
            // 
            this.btnNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextPage.Location = new System.Drawing.Point(829, 8);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(50, 23);
            this.btnNextPage.TabIndex = 19;
            this.btnNextPage.Text = "下一页";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnLastPage
            // 
            this.btnLastPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLastPage.Location = new System.Drawing.Point(885, 8);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(57, 23);
            this.btnLastPage.TabIndex = 21;
            this.btnLastPage.Text = "末页";
            this.btnLastPage.UseVisualStyleBackColor = true;
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            // 
            // ProblemTraceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 547);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProblemTraceList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "问题跟踪列表";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProblemTraceList_FormClosing);
            this.Load += new System.EventHandler(this.ProblemTraceList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProblemTrace)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblPageTotal;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.ComboBox cbxPageSize;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.TextBox txtPageNum;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.DataGridView dgvProblemTrace;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox lbStatus;
        private System.Windows.Forms.Button btnClearStatus;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnClearDealPerson;
        private System.Windows.Forms.ListBox lbDealPerson;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClearFindPerson;
        private System.Windows.Forms.ListBox lbFindPerson;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTestPublish;
        private System.Windows.Forms.Label lblTestPublish;
        private System.Windows.Forms.Button btnClearProblemType;
        private System.Windows.Forms.ListBox lbProblemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProblemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Module;
        private System.Windows.Forms.DataGridViewTextBoxColumn Problem;
        private System.Windows.Forms.DataGridViewTextBoxColumn FindPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn FindDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Solution;
        private System.Windows.Forms.DataGridViewTextBoxColumn DealPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDealDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectUse;
        private System.Windows.Forms.TextBox txtTaskID;
        private System.Windows.Forms.Label label6;
    }
}