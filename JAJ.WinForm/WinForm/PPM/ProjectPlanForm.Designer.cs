namespace JAJ.WinForm.PPM
{
    partial class ProjectPlanForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtActivity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtBudgetEndDate = new JAJ.WinForm.Comm.DateTimePickerX();
            this.label6 = new System.Windows.Forms.Label();
            this.dtBudgetBeginDate = new JAJ.WinForm.Comm.DateTimePickerX();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBudgetWorkload = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbxResource = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbxUnit = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtBusinessCode = new System.Windows.Forms.TextBox();
            this.txtTask = new System.Windows.Forms.RichTextBox();
            this.cbxPlanType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rdoHide = new System.Windows.Forms.RadioButton();
            this.rdoDisplay = new System.Windows.Forms.RadioButton();
            this.txtDiffAnalyze = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "单元：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "活动(功能模块)：";
            // 
            // txtActivity
            // 
            this.txtActivity.Location = new System.Drawing.Point(126, 44);
            this.txtActivity.Name = "txtActivity";
            this.txtActivity.Size = new System.Drawing.Size(350, 21);
            this.txtActivity.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "任务(问题描述)：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtBudgetEndDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtBudgetBeginDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtBudgetWorkload);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(21, 204);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 84);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "预算计划";
            // 
            // dtBudgetEndDate
            // 
            this.dtBudgetEndDate.CustomFormat = " ";
            this.dtBudgetEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBudgetEndDate.FormatString = "yyyy年MM月dd日";
            this.dtBudgetEndDate.Location = new System.Drawing.Point(336, 49);
            this.dtBudgetEndDate.Name = "dtBudgetEndDate";
            this.dtBudgetEndDate.OriginalFormat = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBudgetEndDate.Size = new System.Drawing.Size(119, 21);
            this.dtBudgetEndDate.TabIndex = 5;
            this.dtBudgetEndDate.ValueX = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(256, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "结束日期：";
            // 
            // dtBudgetBeginDate
            // 
            this.dtBudgetBeginDate.CustomFormat = " ";
            this.dtBudgetBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBudgetBeginDate.FormatString = "yyyy年MM月dd日";
            this.dtBudgetBeginDate.Location = new System.Drawing.Point(105, 49);
            this.dtBudgetBeginDate.Name = "dtBudgetBeginDate";
            this.dtBudgetBeginDate.OriginalFormat = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBudgetBeginDate.Size = new System.Drawing.Size(119, 21);
            this.dtBudgetBeginDate.TabIndex = 3;
            this.dtBudgetBeginDate.ValueX = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "开始日期：";
            // 
            // txtBudgetWorkload
            // 
            this.txtBudgetWorkload.Location = new System.Drawing.Point(105, 22);
            this.txtBudgetWorkload.Name = "txtBudgetWorkload";
            this.txtBudgetWorkload.Size = new System.Drawing.Size(119, 21);
            this.txtBudgetWorkload.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "工作量：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(67, 171);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 10;
            this.label11.Text = "负责人：";
            // 
            // cbxResource
            // 
            this.cbxResource.FormattingEnabled = true;
            this.cbxResource.Location = new System.Drawing.Point(126, 168);
            this.cbxResource.Name = "cbxResource";
            this.cbxResource.Size = new System.Drawing.Size(119, 20);
            this.cbxResource.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(401, 368);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbxUnit
            // 
            this.cbxUnit.FormattingEnabled = true;
            this.cbxUnit.Items.AddRange(new object[] {
            "需求调研",
            "功能设计",
            "代码开发",
            "内部测试",
            "实施上线",
            "培训与用户测试",
            "正式使用"});
            this.cbxUnit.Location = new System.Drawing.Point(126, 18);
            this.cbxUnit.Name = "cbxUnit";
            this.cbxUnit.Size = new System.Drawing.Size(119, 20);
            this.cbxUnit.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(55, 144);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 16;
            this.label13.Text = "业务编码：";
            // 
            // txtBusinessCode
            // 
            this.txtBusinessCode.Location = new System.Drawing.Point(126, 141);
            this.txtBusinessCode.Name = "txtBusinessCode";
            this.txtBusinessCode.Size = new System.Drawing.Size(119, 21);
            this.txtBusinessCode.TabIndex = 17;
            // 
            // txtTask
            // 
            this.txtTask.Location = new System.Drawing.Point(126, 71);
            this.txtTask.Name = "txtTask";
            this.txtTask.Size = new System.Drawing.Size(350, 59);
            this.txtTask.TabIndex = 18;
            this.txtTask.Text = "";
            // 
            // cbxPlanType
            // 
            this.cbxPlanType.FormattingEnabled = true;
            this.cbxPlanType.Items.AddRange(new object[] {
            "新功能",
            "现有功能优化",
            "BUG",
            "其它"});
            this.cbxPlanType.Location = new System.Drawing.Point(357, 141);
            this.cbxPlanType.Name = "cbxPlanType";
            this.cbxPlanType.Size = new System.Drawing.Size(119, 20);
            this.cbxPlanType.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(277, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "任务类型：";
            // 
            // rdoHide
            // 
            this.rdoHide.AutoSize = true;
            this.rdoHide.Location = new System.Drawing.Point(259, 371);
            this.rdoHide.Name = "rdoHide";
            this.rdoHide.Size = new System.Drawing.Size(47, 16);
            this.rdoHide.TabIndex = 21;
            this.rdoHide.Text = "隐藏";
            this.rdoHide.UseVisualStyleBackColor = true;
            // 
            // rdoDisplay
            // 
            this.rdoDisplay.AutoSize = true;
            this.rdoDisplay.Checked = true;
            this.rdoDisplay.Location = new System.Drawing.Point(312, 371);
            this.rdoDisplay.Name = "rdoDisplay";
            this.rdoDisplay.Size = new System.Drawing.Size(47, 16);
            this.rdoDisplay.TabIndex = 22;
            this.rdoDisplay.TabStop = true;
            this.rdoDisplay.Text = "显示";
            this.rdoDisplay.UseVisualStyleBackColor = true;
            // 
            // txtDiffAnalyze
            // 
            this.txtDiffAnalyze.Location = new System.Drawing.Point(126, 303);
            this.txtDiffAnalyze.Name = "txtDiffAnalyze";
            this.txtDiffAnalyze.Size = new System.Drawing.Size(350, 59);
            this.txtDiffAnalyze.TabIndex = 24;
            this.txtDiffAnalyze.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 306);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "差异分析：";
            // 
            // ProjectPlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 399);
            this.Controls.Add(this.txtDiffAnalyze);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rdoDisplay);
            this.Controls.Add(this.rdoHide);
            this.Controls.Add(this.cbxPlanType);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTask);
            this.Controls.Add(this.txtBusinessCode);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbxUnit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbxResource);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtActivity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ProjectPlanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "项目计划";
            this.Activated += new System.EventHandler(this.ProjectPlanForm_Activated);
            this.Load += new System.EventHandler(this.ProjectPlanForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtActivity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private Comm.DateTimePickerX dtBudgetBeginDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBudgetWorkload;
        private System.Windows.Forms.Label label4;
        private Comm.DateTimePickerX dtBudgetEndDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbxResource;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbxUnit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtBusinessCode;
        private System.Windows.Forms.RichTextBox txtTask;
        private System.Windows.Forms.ComboBox cbxPlanType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rdoHide;
        private System.Windows.Forms.RadioButton rdoDisplay;
        private System.Windows.Forms.RichTextBox txtDiffAnalyze;
        private System.Windows.Forms.Label label7;
    }
}