namespace JAJ.WinForm
{
    partial class FrmIndex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIndex));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUpdateInfo = new System.Windows.Forms.Label();
            this.btnSaveProjectInfo = new System.Windows.Forms.Button();
            this.txtOtherInfo = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPubServerInfo = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDevServerInfo = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSVN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCurrProjectName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvEmail = new System.Windows.Forms.DataGridView();
            this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiveDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.From = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblEmailInfo = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.linkEmailInfo = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblInnerIP = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowWeather2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowWeather1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmail)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblUpdateInfo);
            this.panel1.Controls.Add(this.btnSaveProjectInfo);
            this.panel1.Controls.Add(this.txtOtherInfo);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtPubServerInfo);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtDevServerInfo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtSVN);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCurrProjectName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(7, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 564);
            this.panel1.TabIndex = 4;
            // 
            // lblUpdateInfo
            // 
            this.lblUpdateInfo.AutoSize = true;
            this.lblUpdateInfo.Location = new System.Drawing.Point(180, 535);
            this.lblUpdateInfo.Name = "lblUpdateInfo";
            this.lblUpdateInfo.Size = new System.Drawing.Size(137, 12);
            this.lblUpdateInfo.TabIndex = 26;
            this.lblUpdateInfo.Text = "最后修改人：修改时间：";
            // 
            // btnSaveProjectInfo
            // 
            this.btnSaveProjectInfo.Location = new System.Drawing.Point(99, 530);
            this.btnSaveProjectInfo.Name = "btnSaveProjectInfo";
            this.btnSaveProjectInfo.Size = new System.Drawing.Size(75, 23);
            this.btnSaveProjectInfo.TabIndex = 24;
            this.btnSaveProjectInfo.Text = "保存";
            this.btnSaveProjectInfo.UseVisualStyleBackColor = true;
            this.btnSaveProjectInfo.Click += new System.EventHandler(this.btnSaveProjectInfo_Click);
            // 
            // txtOtherInfo
            // 
            this.txtOtherInfo.Location = new System.Drawing.Point(100, 386);
            this.txtOtherInfo.Name = "txtOtherInfo";
            this.txtOtherInfo.Size = new System.Drawing.Size(477, 129);
            this.txtOtherInfo.TabIndex = 19;
            this.txtOtherInfo.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 386);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "其他信息：";
            // 
            // txtPubServerInfo
            // 
            this.txtPubServerInfo.Location = new System.Drawing.Point(100, 220);
            this.txtPubServerInfo.Name = "txtPubServerInfo";
            this.txtPubServerInfo.Size = new System.Drawing.Size(477, 160);
            this.txtPubServerInfo.TabIndex = 17;
            this.txtPubServerInfo.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 220);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "正式服务器：";
            // 
            // txtDevServerInfo
            // 
            this.txtDevServerInfo.Location = new System.Drawing.Point(100, 66);
            this.txtDevServerInfo.Name = "txtDevServerInfo";
            this.txtDevServerInfo.Size = new System.Drawing.Size(477, 148);
            this.txtDevServerInfo.TabIndex = 5;
            this.txtDevServerInfo.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "开发服务器：";
            // 
            // txtSVN
            // 
            this.txtSVN.Location = new System.Drawing.Point(100, 36);
            this.txtSVN.Name = "txtSVN";
            this.txtSVN.Size = new System.Drawing.Size(477, 21);
            this.txtSVN.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "SVN地址：";
            // 
            // txtCurrProjectName
            // 
            this.txtCurrProjectName.Location = new System.Drawing.Point(100, 9);
            this.txtCurrProjectName.Name = "txtCurrProjectName";
            this.txtCurrProjectName.Size = new System.Drawing.Size(477, 21);
            this.txtCurrProjectName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前项目名称：";
            // 
            // dgvEmail
            // 
            this.dgvEmail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Subject,
            this.ReceiveDate,
            this.From});
            this.dgvEmail.Location = new System.Drawing.Point(612, 47);
            this.dgvEmail.Name = "dgvEmail";
            this.dgvEmail.RowHeadersVisible = false;
            this.dgvEmail.RowTemplate.Height = 23;
            this.dgvEmail.Size = new System.Drawing.Size(477, 150);
            this.dgvEmail.TabIndex = 5;
            // 
            // Subject
            // 
            this.Subject.DataPropertyName = "Subject";
            this.Subject.HeaderText = "主题";
            this.Subject.Name = "Subject";
            this.Subject.Width = 200;
            // 
            // ReceiveDate
            // 
            this.ReceiveDate.DataPropertyName = "ReceiveDate";
            dataGridViewCellStyle1.Format = "G";
            dataGridViewCellStyle1.NullValue = null;
            this.ReceiveDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.ReceiveDate.HeaderText = "收件日期";
            this.ReceiveDate.Name = "ReceiveDate";
            this.ReceiveDate.Width = 120;
            // 
            // From
            // 
            this.From.DataPropertyName = "From";
            this.From.HeaderText = "发件人";
            this.From.Name = "From";
            this.From.Width = 150;
            // 
            // lblEmailInfo
            // 
            this.lblEmailInfo.AutoSize = true;
            this.lblEmailInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEmailInfo.Location = new System.Drawing.Point(3, 0);
            this.lblEmailInfo.Name = "lblEmailInfo";
            this.lblEmailInfo.Size = new System.Drawing.Size(195, 16);
            this.lblEmailInfo.TabIndex = 6;
            this.lblEmailInfo.Text = "正在获取未读邮件。。。";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblEmailInfo);
            this.flowLayoutPanel1.Controls.Add(this.linkEmailInfo);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(612, 18);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(477, 25);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // linkEmailInfo
            // 
            this.linkEmailInfo.AutoSize = true;
            this.linkEmailInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkEmailInfo.Location = new System.Drawing.Point(204, 0);
            this.linkEmailInfo.Name = "linkEmailInfo";
            this.linkEmailInfo.Size = new System.Drawing.Size(176, 16);
            this.linkEmailInfo.TabIndex = 7;
            this.linkEmailInfo.TabStop = true;
            this.linkEmailInfo.Text = "您目前共有0封未读邮件";
            this.linkEmailInfo.Visible = false;
            this.linkEmailInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEmailInfo_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(272, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "内网IP：";
            // 
            // lblInnerIP
            // 
            this.lblInnerIP.AutoSize = true;
            this.lblInnerIP.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.lblInnerIP.Location = new System.Drawing.Point(340, 14);
            this.lblInnerIP.Name = "lblInnerIP";
            this.lblInnerIP.Size = new System.Drawing.Size(83, 14);
            this.lblInnerIP.TabIndex = 10;
            this.lblInnerIP.Text = "内网ip地址";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14F);
            this.label5.Location = new System.Drawing.Point(194, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "青岛";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.flowWeather2);
            this.panel2.Controls.Add(this.flowWeather1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lblInnerIP);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(612, 203);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(477, 120);
            this.panel2.TabIndex = 12;
            // 
            // flowWeather2
            // 
            this.flowWeather2.Location = new System.Drawing.Point(2, 76);
            this.flowWeather2.Name = "flowWeather2";
            this.flowWeather2.Size = new System.Drawing.Size(472, 34);
            this.flowWeather2.TabIndex = 14;
            // 
            // flowWeather1
            // 
            this.flowWeather1.Location = new System.Drawing.Point(2, 43);
            this.flowWeather1.Name = "flowWeather1";
            this.flowWeather1.Size = new System.Drawing.Size(475, 34);
            this.flowWeather1.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(185, 33);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // FrmIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 587);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.dgvEmail);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmIndex";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FrmIndex";
            this.Load += new System.EventHandler(this.FrmIndex_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmail)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSaveProjectInfo;
        private System.Windows.Forms.RichTextBox txtOtherInfo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox txtPubServerInfo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox txtDevServerInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSVN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCurrProjectName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUpdateInfo;
        private System.Windows.Forms.DataGridView dgvEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiveDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn From;
        private System.Windows.Forms.Label lblEmailInfo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel linkEmailInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblInnerIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowWeather2;
        private System.Windows.Forms.FlowLayoutPanel flowWeather1;


    }
}