namespace JAJ.WinForm.PPM
{
    partial class ProblemTraceForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProblemTraceForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxProblemType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxFindPerson = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProblem = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtModule = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxIsRepeat = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dtEndDealDate = new JAJ.WinForm.Comm.DateTimePickerX();
            this.cbxDealPerson = new System.Windows.Forms.ComboBox();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSolution = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.linkAttachment = new System.Windows.Forms.LinkLabel();
            this.lblAttachmentCreateBy = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnAttachment = new System.Windows.Forms.Button();
            this.txtAttachment = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtPicture = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuCopyPicture = new System.Windows.Forms.ToolStripMenuItem();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dtBeginDealDate = new JAJ.WinForm.Comm.DateTimePickerX();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtBeginDealDate);
            this.groupBox1.Controls.Add(this.cbxProblemType);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbxFindPerson);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtProblem);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtModule);
            this.groupBox1.Location = new System.Drawing.Point(8, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(706, 183);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "问题跟踪";
            // 
            // cbxProblemType
            // 
            this.cbxProblemType.FormattingEnabled = true;
            this.cbxProblemType.Items.AddRange(new object[] {
            "新功能",
            "现有功能优化",
            "BUG",
            "其它"});
            this.cbxProblemType.Location = new System.Drawing.Point(397, 22);
            this.cbxProblemType.Name = "cbxProblemType";
            this.cbxProblemType.Size = new System.Drawing.Size(94, 20);
            this.cbxProblemType.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(353, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "类型：";
            // 
            // cbxFindPerson
            // 
            this.cbxFindPerson.FormattingEnabled = true;
            this.cbxFindPerson.Location = new System.Drawing.Point(274, 22);
            this.cbxFindPerson.Name = "cbxFindPerson";
            this.cbxFindPerson.Size = new System.Drawing.Size(73, 20);
            this.cbxFindPerson.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(497, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "开始日期：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "提出人：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "问题描述：";
            // 
            // txtProblem
            // 
            this.txtProblem.Location = new System.Drawing.Point(82, 49);
            this.txtProblem.Name = "txtProblem";
            this.txtProblem.Size = new System.Drawing.Size(616, 112);
            this.txtProblem.TabIndex = 2;
            this.txtProblem.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "功能模块：";
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(82, 22);
            this.txtModule.Name = "txtModule";
            this.txtModule.Size = new System.Drawing.Size(125, 21);
            this.txtModule.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxIsRepeat);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.dtEndDealDate);
            this.groupBox2.Controls.Add(this.cbxDealPerson);
            this.groupBox2.Controls.Add(this.cbxStatus);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtSolution);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(9, 201);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(705, 175);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "处理跟踪";
            // 
            // cbxIsRepeat
            // 
            this.cbxIsRepeat.FormattingEnabled = true;
            this.cbxIsRepeat.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cbxIsRepeat.Location = new System.Drawing.Point(653, 18);
            this.cbxIsRepeat.Name = "cbxIsRepeat";
            this.cbxIsRepeat.Size = new System.Drawing.Size(41, 20);
            this.cbxIsRepeat.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(558, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 12);
            this.label15.TabIndex = 14;
            this.label15.Text = "是否重复问题：";
            // 
            // dtEndDealDate
            // 
            this.dtEndDealDate.CustomFormat = " ";
            this.dtEndDealDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndDealDate.FormatString = "yyyy年MM月dd日";
            this.dtEndDealDate.Location = new System.Drawing.Point(242, 17);
            this.dtEndDealDate.Name = "dtEndDealDate";
            this.dtEndDealDate.OriginalFormat = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndDealDate.Size = new System.Drawing.Size(130, 21);
            this.dtEndDealDate.TabIndex = 13;
            this.dtEndDealDate.ValueX = null;
            // 
            // cbxDealPerson
            // 
            this.cbxDealPerson.FormattingEnabled = true;
            this.cbxDealPerson.Location = new System.Drawing.Point(82, 18);
            this.cbxDealPerson.Name = "cbxDealPerson";
            this.cbxDealPerson.Size = new System.Drawing.Size(83, 20);
            this.cbxDealPerson.TabIndex = 12;
            // 
            // cbxStatus
            // 
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Items.AddRange(new object[] {
            "未开始",
            "进行中",
            "已发现未处理",
            "已提交未审核",
            "完成",
            "未通过",
            "发版关闭"});
            this.cbxStatus.Location = new System.Drawing.Point(432, 17);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(115, 20);
            this.cbxStatus.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(385, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "状态：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(171, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "完成日期：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "解决方案：";
            // 
            // txtSolution
            // 
            this.txtSolution.Location = new System.Drawing.Point(81, 45);
            this.txtSolution.Name = "txtSolution";
            this.txtSolution.Size = new System.Drawing.Size(616, 112);
            this.txtSolution.TabIndex = 4;
            this.txtSolution.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "执行人：";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(768, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 31);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.flowLayoutPanel2);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.btnAttachment);
            this.groupBox3.Controls.Add(this.txtAttachment);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(9, 383);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(705, 94);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "附件";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.linkAttachment);
            this.flowLayoutPanel2.Controls.Add(this.lblAttachmentCreateBy);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(78, 70);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(614, 20);
            this.flowLayoutPanel2.TabIndex = 7;
            // 
            // linkAttachment
            // 
            this.linkAttachment.AutoSize = true;
            this.linkAttachment.Location = new System.Drawing.Point(3, 0);
            this.linkAttachment.Name = "linkAttachment";
            this.linkAttachment.Size = new System.Drawing.Size(53, 12);
            this.linkAttachment.TabIndex = 5;
            this.linkAttachment.TabStop = true;
            this.linkAttachment.Text = "附件名称";
            this.linkAttachment.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAttachment_LinkClicked);
            // 
            // lblAttachmentCreateBy
            // 
            this.lblAttachmentCreateBy.AutoSize = true;
            this.lblAttachmentCreateBy.Location = new System.Drawing.Point(62, 0);
            this.lblAttachmentCreateBy.Name = "lblAttachmentCreateBy";
            this.lblAttachmentCreateBy.Size = new System.Drawing.Size(65, 12);
            this.lblAttachmentCreateBy.TabIndex = 6;
            this.lblAttachmentCreateBy.Text = "附件创建人";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 6;
            this.label12.Text = "附    件：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(80, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(605, 12);
            this.label11.TabIndex = 3;
            this.label11.Text = "仅支持一个附件，如有多个，请压缩后再上传，最大30M（上传附件前需先关闭已打开的文件，如excel、word等）";
            // 
            // btnAttachment
            // 
            this.btnAttachment.Location = new System.Drawing.Point(633, 16);
            this.btnAttachment.Name = "btnAttachment";
            this.btnAttachment.Size = new System.Drawing.Size(64, 23);
            this.btnAttachment.TabIndex = 2;
            this.btnAttachment.Text = "选择文件";
            this.btnAttachment.UseVisualStyleBackColor = true;
            this.btnAttachment.Click += new System.EventHandler(this.btnAttachment_Click);
            // 
            // txtAttachment
            // 
            this.txtAttachment.Enabled = false;
            this.txtAttachment.Location = new System.Drawing.Point(82, 17);
            this.txtAttachment.Name = "txtAttachment";
            this.txtAttachment.Size = new System.Drawing.Size(545, 21);
            this.txtAttachment.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "本地路径：";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(720, 136);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(172, 341);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // txtPicture
            // 
            this.txtPicture.ContextMenuStrip = this.contextMenuStrip1;
            this.txtPicture.Location = new System.Drawing.Point(720, 103);
            this.txtPicture.Name = "txtPicture";
            this.txtPicture.Size = new System.Drawing.Size(172, 27);
            this.txtPicture.TabIndex = 5;
            this.txtPicture.Text = "";
            this.txtPicture.TextChanged += new System.EventHandler(this.txtPicture_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCopyPicture});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(148, 26);
            // 
            // menuCopyPicture
            // 
            this.menuCopyPicture.Name = "menuCopyPicture";
            this.menuCopyPicture.Size = new System.Drawing.Size(147, 22);
            this.menuCopyPicture.Text = "粘贴 (Ctrl+V)";
            this.menuCopyPicture.Click += new System.EventHandler(this.menuCopyPicture_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(718, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(179, 12);
            this.label13.TabIndex = 6;
            this.label13.Text = "保存图片(QQ截图,直接复制图片)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(719, 85);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(173, 12);
            this.label14.TabIndex = 7;
            this.label14.Text = "请将图片拷贝到下边的文本框中";
            // 
            // dtBeginDealDate
            // 
            this.dtBeginDealDate.CustomFormat = " ";
            this.dtBeginDealDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBeginDealDate.FormatString = "yyyy年MM月dd日";
            this.dtBeginDealDate.Location = new System.Drawing.Point(566, 22);
            this.dtBeginDealDate.Name = "dtBeginDealDate";
            this.dtBeginDealDate.OriginalFormat = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBeginDealDate.Size = new System.Drawing.Size(130, 21);
            this.dtBeginDealDate.TabIndex = 14;
            this.dtBeginDealDate.ValueX = null;
            // 
            // ProblemTraceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 490);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtPicture);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProblemTraceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "问题跟踪";
            this.Activated += new System.EventHandler(this.ProblemTraceForm_Activated);
            this.Load += new System.EventHandler(this.ProblemTraceForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtProblem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox txtSolution;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbxFindPerson;
        private System.Windows.Forms.ComboBox cbxDealPerson;
        private Comm.DateTimePickerX dtEndDealDate;
        private System.Windows.Forms.ComboBox cbxProblemType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAttachment;
        private System.Windows.Forms.TextBox txtAttachment;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.LinkLabel linkAttachment;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RichTextBox txtPicture;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuCopyPicture;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblAttachmentCreateBy;
        private System.Windows.Forms.ComboBox cbxIsRepeat;
        private System.Windows.Forms.Label label15;
        private Comm.DateTimePickerX dtBeginDealDate;
    }
}