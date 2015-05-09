namespace JAJ.WinForm.Frm
{
    partial class SetIPForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.rbtnAuto = new System.Windows.Forms.RadioButton();
            this.rbtnSet = new System.Windows.Forms.RadioButton();
            this.gboxIPInfo = new System.Windows.Forms.GroupBox();
            this.txtDNS2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDNS1 = new System.Windows.Forms.TextBox();
            this.txtGatway = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gboxIPInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtnAuto
            // 
            this.rbtnAuto.AutoSize = true;
            this.rbtnAuto.Location = new System.Drawing.Point(24, 16);
            this.rbtnAuto.Name = "rbtnAuto";
            this.rbtnAuto.Size = new System.Drawing.Size(107, 16);
            this.rbtnAuto.TabIndex = 0;
            this.rbtnAuto.TabStop = true;
            this.rbtnAuto.Text = "自动获取ip地址";
            this.rbtnAuto.UseVisualStyleBackColor = true;
            this.rbtnAuto.CheckedChanged += new System.EventHandler(this.rbtnAuto_CheckedChanged);
            // 
            // rbtnSet
            // 
            this.rbtnSet.AutoSize = true;
            this.rbtnSet.Location = new System.Drawing.Point(24, 39);
            this.rbtnSet.Name = "rbtnSet";
            this.rbtnSet.Size = new System.Drawing.Size(59, 16);
            this.rbtnSet.TabIndex = 1;
            this.rbtnSet.TabStop = true;
            this.rbtnSet.Text = "设置IP";
            this.rbtnSet.UseVisualStyleBackColor = true;
            this.rbtnSet.CheckedChanged += new System.EventHandler(this.rbtnSet_CheckedChanged);
            // 
            // gboxIPInfo
            // 
            this.gboxIPInfo.Controls.Add(this.txtDNS2);
            this.gboxIPInfo.Controls.Add(this.label4);
            this.gboxIPInfo.Controls.Add(this.txtDNS1);
            this.gboxIPInfo.Controls.Add(this.txtGatway);
            this.gboxIPInfo.Controls.Add(this.txtIP);
            this.gboxIPInfo.Controls.Add(this.label3);
            this.gboxIPInfo.Controls.Add(this.label2);
            this.gboxIPInfo.Controls.Add(this.label1);
            this.gboxIPInfo.Location = new System.Drawing.Point(24, 61);
            this.gboxIPInfo.Name = "gboxIPInfo";
            this.gboxIPInfo.Size = new System.Drawing.Size(323, 205);
            this.gboxIPInfo.TabIndex = 2;
            this.gboxIPInfo.TabStop = false;
            // 
            // txtDNS2
            // 
            this.txtDNS2.Location = new System.Drawing.Point(77, 164);
            this.txtDNS2.Name = "txtDNS2";
            this.txtDNS2.Size = new System.Drawing.Size(199, 21);
            this.txtDNS2.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "DNS2";
            // 
            // txtDNS1
            // 
            this.txtDNS1.Location = new System.Drawing.Point(77, 117);
            this.txtDNS1.Name = "txtDNS1";
            this.txtDNS1.Size = new System.Drawing.Size(199, 21);
            this.txtDNS1.TabIndex = 5;
            // 
            // txtGatway
            // 
            this.txtGatway.Location = new System.Drawing.Point(77, 66);
            this.txtGatway.Name = "txtGatway";
            this.txtGatway.Size = new System.Drawing.Size(199, 21);
            this.txtGatway.TabIndex = 4;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(77, 18);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(199, 21);
            this.txtIP.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "DNS1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "网关";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(225, 295);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "设置";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(101, 295);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SetIPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 343);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gboxIPInfo);
            this.Controls.Add(this.rbtnSet);
            this.Controls.Add(this.rbtnAuto);
            this.Name = "SetIPForm";
            this.Text = "win7设置IP小工具(jaj)";
            this.gboxIPInfo.ResumeLayout(false);
            this.gboxIPInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnAuto;
        private System.Windows.Forms.RadioButton rbtnSet;
        private System.Windows.Forms.GroupBox gboxIPInfo;
        private System.Windows.Forms.TextBox txtDNS2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDNS1;
        private System.Windows.Forms.TextBox txtGatway;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnSave;
    }
}

