namespace JAJ.WinForm.PPM
{
    partial class CreateProjectForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtBeginDate = new JAJ.WinForm.Comm.DateTimePickerX();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProjectCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxProjectManager = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbxProjectTeam = new System.Windows.Forms.ListBox();
            this.btnDelProjectTeam = new System.Windows.Forms.Button();
            this.btnAddProjectTeam = new System.Windows.Forms.Button();
            this.cbxProjectLeader = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxProjectTeam = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblSelectProject = new System.Windows.Forms.Label();
            this.cbxSelectProject = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "项目名称：";
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(109, 70);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(296, 21);
            this.txtProjectName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "开始日期：";
            // 
            // dtBeginDate
            // 
            this.dtBeginDate.CustomFormat = " ";
            this.dtBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBeginDate.FormatString = "yyyy年MM月dd日";
            this.dtBeginDate.Location = new System.Drawing.Point(109, 97);
            this.dtBeginDate.Name = "dtBeginDate";
            this.dtBeginDate.OriginalFormat = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBeginDate.Size = new System.Drawing.Size(161, 21);
            this.dtBeginDate.TabIndex = 3;
            this.dtBeginDate.ValueX = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "项目编码：";
            // 
            // txtProjectCode
            // 
            this.txtProjectCode.Location = new System.Drawing.Point(109, 43);
            this.txtProjectCode.Name = "txtProjectCode";
            this.txtProjectCode.Size = new System.Drawing.Size(161, 21);
            this.txtProjectCode.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "项目经理：";
            // 
            // cbxProjectManager
            // 
            this.cbxProjectManager.FormattingEnabled = true;
            this.cbxProjectManager.Location = new System.Drawing.Point(109, 130);
            this.cbxProjectManager.Name = "cbxProjectManager";
            this.cbxProjectManager.Size = new System.Drawing.Size(161, 20);
            this.cbxProjectManager.TabIndex = 7;
            this.cbxProjectManager.SelectedIndexChanged += new System.EventHandler(this.cbxProjectManager_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbxProjectTeam);
            this.groupBox1.Controls.Add(this.btnDelProjectTeam);
            this.groupBox1.Controls.Add(this.btnAddProjectTeam);
            this.groupBox1.Controls.Add(this.cbxProjectLeader);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbxProjectTeam);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(40, 167);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 291);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "项目成员：";
            // 
            // lbxProjectTeam
            // 
            this.lbxProjectTeam.FormattingEnabled = true;
            this.lbxProjectTeam.ItemHeight = 12;
            this.lbxProjectTeam.Location = new System.Drawing.Point(24, 55);
            this.lbxProjectTeam.Name = "lbxProjectTeam";
            this.lbxProjectTeam.Size = new System.Drawing.Size(370, 220);
            this.lbxProjectTeam.TabIndex = 6;
            // 
            // btnDelProjectTeam
            // 
            this.btnDelProjectTeam.Location = new System.Drawing.Point(348, 20);
            this.btnDelProjectTeam.Name = "btnDelProjectTeam";
            this.btnDelProjectTeam.Size = new System.Drawing.Size(46, 20);
            this.btnDelProjectTeam.TabIndex = 5;
            this.btnDelProjectTeam.Text = "移除";
            this.btnDelProjectTeam.UseVisualStyleBackColor = true;
            this.btnDelProjectTeam.Click += new System.EventHandler(this.btnDelProjectTeam_Click);
            // 
            // btnAddProjectTeam
            // 
            this.btnAddProjectTeam.Location = new System.Drawing.Point(293, 20);
            this.btnAddProjectTeam.Name = "btnAddProjectTeam";
            this.btnAddProjectTeam.Size = new System.Drawing.Size(45, 20);
            this.btnAddProjectTeam.TabIndex = 4;
            this.btnAddProjectTeam.Text = "添加";
            this.btnAddProjectTeam.UseVisualStyleBackColor = true;
            this.btnAddProjectTeam.Click += new System.EventHandler(this.btnAddProjectTeam_Click);
            // 
            // cbxProjectLeader
            // 
            this.cbxProjectLeader.FormattingEnabled = true;
            this.cbxProjectLeader.Location = new System.Drawing.Point(204, 20);
            this.cbxProjectLeader.Name = "cbxProjectLeader";
            this.cbxProjectLeader.Size = new System.Drawing.Size(83, 20);
            this.cbxProjectLeader.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(157, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "老师：";
            // 
            // cbxProjectTeam
            // 
            this.cbxProjectTeam.FormattingEnabled = true;
            this.cbxProjectTeam.Location = new System.Drawing.Point(69, 20);
            this.cbxProjectTeam.Name = "cbxProjectTeam";
            this.cbxProjectTeam.Size = new System.Drawing.Size(83, 20);
            this.cbxProjectTeam.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "成员：";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(377, 464);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblSelectProject
            // 
            this.lblSelectProject.AutoSize = true;
            this.lblSelectProject.Location = new System.Drawing.Point(38, 19);
            this.lblSelectProject.Name = "lblSelectProject";
            this.lblSelectProject.Size = new System.Drawing.Size(65, 12);
            this.lblSelectProject.TabIndex = 13;
            this.lblSelectProject.Text = "选择项目：";
            this.lblSelectProject.Visible = false;
            // 
            // cbxSelectProject
            // 
            this.cbxSelectProject.FormattingEnabled = true;
            this.cbxSelectProject.Location = new System.Drawing.Point(109, 15);
            this.cbxSelectProject.Name = "cbxSelectProject";
            this.cbxSelectProject.Size = new System.Drawing.Size(296, 20);
            this.cbxSelectProject.TabIndex = 14;
            this.cbxSelectProject.Visible = false;
            this.cbxSelectProject.SelectedIndexChanged += new System.EventHandler(this.cbxSelectProject_SelectedIndexChanged);
            // 
            // CreateProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 505);
            this.Controls.Add(this.cbxSelectProject);
            this.Controls.Add(this.lblSelectProject);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbxProjectManager);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtProjectCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtBeginDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.label1);
            this.Name = "CreateProjectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateProjectForm";
            this.Load += new System.EventHandler(this.CreateProjectForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label label2;
        private Comm.DateTimePickerX dtBeginDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProjectCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxProjectManager;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxProjectTeam;
        private System.Windows.Forms.ComboBox cbxProjectLeader;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAddProjectTeam;
        private System.Windows.Forms.Button btnDelProjectTeam;
        private System.Windows.Forms.ListBox lbxProjectTeam;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblSelectProject;
        private System.Windows.Forms.ComboBox cbxSelectProject;
    }
}