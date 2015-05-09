namespace JAJ.WinForm.FRM
{
    partial class FrmImportExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImportExcel));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtExcelPath = new System.Windows.Forms.TextBox();
            this.btnSelectExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHOST = new System.Windows.Forms.TextBox();
            this.lblPORT = new System.Windows.Forms.Label();
            this.txtPORT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.btnSaveSetting = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSERVICENAME = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xlsx";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Excel文件|*.xlsx";
            // 
            // txtExcelPath
            // 
            this.txtExcelPath.Enabled = false;
            this.txtExcelPath.Location = new System.Drawing.Point(80, 132);
            this.txtExcelPath.Name = "txtExcelPath";
            this.txtExcelPath.Size = new System.Drawing.Size(396, 21);
            this.txtExcelPath.TabIndex = 0;
            // 
            // btnSelectExcel
            // 
            this.btnSelectExcel.BackColor = System.Drawing.Color.Yellow;
            this.btnSelectExcel.Location = new System.Drawing.Point(482, 131);
            this.btnSelectExcel.Name = "btnSelectExcel";
            this.btnSelectExcel.Size = new System.Drawing.Size(106, 23);
            this.btnSelectExcel.TabIndex = 1;
            this.btnSelectExcel.Text = "选择文件";
            this.btnSelectExcel.UseVisualStyleBackColor = false;
            this.btnSelectExcel.Click += new System.EventHandler(this.btnSelectExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(20, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Excel：";
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnImportExcel.Location = new System.Drawing.Point(529, 361);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(65, 23);
            this.btnImportExcel.TabIndex = 3;
            this.btnImportExcel.Text = "导入";
            this.btnImportExcel.UseVisualStyleBackColor = false;
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(103, 82);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(122, 21);
            this.txtTableName.TabIndex = 4;
            this.txtTableName.Text = "aaa_test";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "表名：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(80, 257);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(514, 95);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(20, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "说明：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(20, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "例如：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "HOST：";
            // 
            // txtHOST
            // 
            this.txtHOST.Location = new System.Drawing.Point(103, 19);
            this.txtHOST.Name = "txtHOST";
            this.txtHOST.Size = new System.Drawing.Size(291, 21);
            this.txtHOST.TabIndex = 11;
            // 
            // lblPORT
            // 
            this.lblPORT.AutoSize = true;
            this.lblPORT.Location = new System.Drawing.Point(423, 23);
            this.lblPORT.Name = "lblPORT";
            this.lblPORT.Size = new System.Drawing.Size(41, 12);
            this.lblPORT.TabIndex = 12;
            this.lblPORT.Text = "PORT：";
            // 
            // txtPORT
            // 
            this.txtPORT.Location = new System.Drawing.Point(470, 19);
            this.txtPORT.Name = "txtPORT";
            this.txtPORT.Size = new System.Drawing.Size(106, 21);
            this.txtPORT.TabIndex = 13;
            this.txtPORT.Text = "1521";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "SERVICE_NAME：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTestConnection);
            this.groupBox1.Controls.Add(this.btnSaveSetting);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtSERVICENAME);
            this.groupBox1.Controls.Add(this.txtHOST);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPORT);
            this.groupBox1.Controls.Add(this.lblPORT);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTableName);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(582, 113);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(294, 80);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(100, 23);
            this.btnTestConnection.TabIndex = 21;
            this.btnTestConnection.Text = "测试连接";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Location = new System.Drawing.Point(470, 80);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(106, 23);
            this.btnSaveSetting.TabIndex = 20;
            this.btnSaveSetting.Text = "保存配置";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(470, 50);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(106, 21);
            this.txtPassword.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(399, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "Password：";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(294, 50);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 21);
            this.txtUsername.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(231, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "Username：";
            // 
            // txtSERVICENAME
            // 
            this.txtSERVICENAME.Location = new System.Drawing.Point(103, 50);
            this.txtSERVICENAME.Name = "txtSERVICENAME";
            this.txtSERVICENAME.Size = new System.Drawing.Size(122, 21);
            this.txtSERVICENAME.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(78, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(520, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "1、表存在时，从第三行开始读取数据(前两行不能为空)，顺序必须与数据库字段顺序一致";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(78, 186);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(268, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "2、表不存在时根据excel创建表，规则如下：";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(80, 208);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(508, 38);
            this.richTextBox1.TabIndex = 18;
            this.richTextBox1.Text = "Excel要求：第一行为数据库字段名，全部为nvarchar2(200)，第二行为标题行（字段注释），第三行往后为数据行，第一列数据不能为空，如果为空后边的数据则" +
    "不会读取";
            // 
            // FrmImportExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 395);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnImportExcel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelectExcel);
            this.Controls.Add(this.txtExcelPath);
            this.Name = "FrmImportExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel导入数据库工具(仅支持2007及其以上版本)";
            this.Load += new System.EventHandler(this.FrmImportExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtExcelPath;
        private System.Windows.Forms.Button btnSelectExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImportExcel;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHOST;
        private System.Windows.Forms.Label lblPORT;
        private System.Windows.Forms.TextBox txtPORT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSERVICENAME;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Button btnSaveSetting;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}