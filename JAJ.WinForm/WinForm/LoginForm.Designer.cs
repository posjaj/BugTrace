namespace JAJ.WinForm
{
    partial class LoginForm
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
            this.txtUserCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkDisplayPassword = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.chkRememberUserCode = new System.Windows.Forms.CheckBox();
            this.chkRememberPassword = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // txtUserCode
            // 
            this.txtUserCode.Location = new System.Drawing.Point(105, 59);
            this.txtUserCode.Name = "txtUserCode";
            this.txtUserCode.Size = new System.Drawing.Size(172, 21);
            this.txtUserCode.TabIndex = 1;
            this.txtUserCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserCode_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密  码：";
            this.label2.Visible = false;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(105, 97);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(172, 21);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Visible = false;
            // 
            // chkDisplayPassword
            // 
            this.chkDisplayPassword.AutoSize = true;
            this.chkDisplayPassword.Location = new System.Drawing.Point(289, 100);
            this.chkDisplayPassword.Name = "chkDisplayPassword";
            this.chkDisplayPassword.Size = new System.Drawing.Size(72, 16);
            this.chkDisplayPassword.TabIndex = 4;
            this.chkDisplayPassword.Text = "显示密码";
            this.chkDisplayPassword.UseVisualStyleBackColor = true;
            this.chkDisplayPassword.Visible = false;
            this.chkDisplayPassword.CheckedChanged += new System.EventHandler(this.chkDisplayPassword_CheckedChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(105, 179);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "登陆";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(201, 179);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 6;
            this.btnQuit.Text = "退出";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(287, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "请输入姓名全拼";
            // 
            // chkRememberUserCode
            // 
            this.chkRememberUserCode.AutoSize = true;
            this.chkRememberUserCode.Checked = true;
            this.chkRememberUserCode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRememberUserCode.Location = new System.Drawing.Point(105, 143);
            this.chkRememberUserCode.Name = "chkRememberUserCode";
            this.chkRememberUserCode.Size = new System.Drawing.Size(84, 16);
            this.chkRememberUserCode.TabIndex = 8;
            this.chkRememberUserCode.Text = "记住用户名";
            this.chkRememberUserCode.UseVisualStyleBackColor = true;
            // 
            // chkRememberPassword
            // 
            this.chkRememberPassword.AutoSize = true;
            this.chkRememberPassword.Checked = true;
            this.chkRememberPassword.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRememberPassword.Location = new System.Drawing.Point(202, 143);
            this.chkRememberPassword.Name = "chkRememberPassword";
            this.chkRememberPassword.Size = new System.Drawing.Size(72, 16);
            this.chkRememberPassword.TabIndex = 9;
            this.chkRememberPassword.Text = "记住密码";
            this.chkRememberPassword.UseVisualStyleBackColor = true;
            this.chkRememberPassword.Visible = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(391, 261);
            this.ControlBox = false;
            this.Controls.Add(this.chkRememberPassword);
            this.Controls.Add(this.chkRememberUserCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.chkDisplayPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUserCode);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登陆";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkDisplayPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkRememberUserCode;
        private System.Windows.Forms.CheckBox chkRememberPassword;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}