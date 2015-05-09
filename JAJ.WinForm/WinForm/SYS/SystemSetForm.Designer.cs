namespace JAJ.WinForm.SYS
{
    partial class SystemSetForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUserCode = new System.Windows.Forms.Label();
            this.cbxProject = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtQQ = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmailPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbProjectList = new System.Windows.Forms.ListBox();
            this.btnDelProject = new System.Windows.Forms.Button();
            this.btnAddProject = new System.Windows.Forms.Button();
            this.cbxProjectList = new System.Windows.Forms.ComboBox();
            this.lable11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(264, 419);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "当前用户：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "当前项目：";
            // 
            // lblUserCode
            // 
            this.lblUserCode.AutoSize = true;
            this.lblUserCode.Location = new System.Drawing.Point(106, 24);
            this.lblUserCode.Name = "lblUserCode";
            this.lblUserCode.Size = new System.Drawing.Size(53, 12);
            this.lblUserCode.TabIndex = 3;
            this.lblUserCode.Text = "UserCode";
            // 
            // cbxProject
            // 
            this.cbxProject.FormattingEnabled = true;
            this.cbxProject.Location = new System.Drawing.Point(108, 63);
            this.cbxProject.Name = "cbxProject";
            this.cbxProject.Size = new System.Drawing.Size(258, 20);
            this.cbxProject.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(363, 419);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "电    话：";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(108, 89);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(258, 21);
            this.txtTel.TabIndex = 7;
            // 
            // txtQQ
            // 
            this.txtQQ.Location = new System.Drawing.Point(108, 116);
            this.txtQQ.Name = "txtQQ";
            this.txtQQ.Size = new System.Drawing.Size(258, 21);
            this.txtQQ.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "QQ：";
            // 
            // txtEmailPassword
            // 
            this.txtEmailPassword.Location = new System.Drawing.Point(108, 143);
            this.txtEmailPassword.Name = "txtEmailPassword";
            this.txtEmailPassword.PasswordChar = '*';
            this.txtEmailPassword.Size = new System.Drawing.Size(258, 21);
            this.txtEmailPassword.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "公司邮箱密码：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(378, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "密码经过特殊加密";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbProjectList);
            this.groupBox1.Controls.Add(this.btnDelProject);
            this.groupBox1.Controls.Add(this.btnAddProject);
            this.groupBox1.Controls.Add(this.cbxProjectList);
            this.groupBox1.Controls.Add(this.lable11);
            this.groupBox1.Location = new System.Drawing.Point(26, 182);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 231);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "常用项目";
            // 
            // lbProjectList
            // 
            this.lbProjectList.FormattingEnabled = true;
            this.lbProjectList.ItemHeight = 12;
            this.lbProjectList.Location = new System.Drawing.Point(24, 45);
            this.lbProjectList.Name = "lbProjectList";
            this.lbProjectList.Size = new System.Drawing.Size(376, 172);
            this.lbProjectList.TabIndex = 8;
            // 
            // btnDelProject
            // 
            this.btnDelProject.Location = new System.Drawing.Point(354, 18);
            this.btnDelProject.Name = "btnDelProject";
            this.btnDelProject.Size = new System.Drawing.Size(46, 20);
            this.btnDelProject.TabIndex = 7;
            this.btnDelProject.Text = "移除";
            this.btnDelProject.UseVisualStyleBackColor = true;
            this.btnDelProject.Click += new System.EventHandler(this.btnDelProject_Click);
            // 
            // btnAddProject
            // 
            this.btnAddProject.Location = new System.Drawing.Point(299, 18);
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.Size = new System.Drawing.Size(45, 20);
            this.btnAddProject.TabIndex = 6;
            this.btnAddProject.Text = "添加";
            this.btnAddProject.UseVisualStyleBackColor = true;
            this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click);
            // 
            // cbxProjectList
            // 
            this.cbxProjectList.FormattingEnabled = true;
            this.cbxProjectList.Location = new System.Drawing.Point(93, 18);
            this.cbxProjectList.Name = "cbxProjectList";
            this.cbxProjectList.Size = new System.Drawing.Size(192, 20);
            this.cbxProjectList.TabIndex = 1;
            // 
            // lable11
            // 
            this.lable11.AutoSize = true;
            this.lable11.Location = new System.Drawing.Point(22, 21);
            this.lable11.Name = "lable11";
            this.lable11.Size = new System.Drawing.Size(65, 12);
            this.lable11.TabIndex = 0;
            this.lable11.Text = "项目列表：";
            // 
            // SystemSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEmailPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtQQ);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbxProject);
            this.Controls.Add(this.lblUserCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnSave);
            this.Name = "SystemSetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "个人设置";
            this.Load += new System.EventHandler(this.SystemSetForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUserCode;
        private System.Windows.Forms.ComboBox cbxProject;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtQQ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmailPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxProjectList;
        private System.Windows.Forms.Label lable11;
        private System.Windows.Forms.Button btnDelProject;
        private System.Windows.Forms.Button btnAddProject;
        private System.Windows.Forms.ListBox lbProjectList;
    }
}