namespace JAJ.WinForm.PPM
{
    partial class ShareFileList
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCreateBy = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxSort = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvShareFile = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateByName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.下载 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShareFile)).BeginInit();
            this.SuspendLayout();
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
            this.panel3.Location = new System.Drawing.Point(0, 473);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1008, 38);
            this.panel3.TabIndex = 3;
            // 
            // lblPageTotal
            // 
            this.lblPageTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageTotal.AutoSize = true;
            this.lblPageTotal.Location = new System.Drawing.Point(550, 13);
            this.lblPageTotal.Name = "lblPageTotal";
            this.lblPageTotal.Size = new System.Drawing.Size(23, 12);
            this.lblPageTotal.TabIndex = 29;
            this.lblPageTotal.Text = "1页";
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Location = new System.Drawing.Point(303, 14);
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
            this.cbxPageSize.Location = new System.Drawing.Point(439, 10);
            this.cbxPageSize.Name = "cbxPageSize";
            this.cbxPageSize.Size = new System.Drawing.Size(54, 20);
            this.cbxPageSize.TabIndex = 27;
            this.cbxPageSize.Text = "20";
            // 
            // btnSkip
            // 
            this.btnSkip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSkip.Location = new System.Drawing.Point(927, 8);
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
            this.label3.Location = new System.Drawing.Point(503, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 28;
            this.label3.Text = "条，共";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(904, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "页";
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFirstPage.Location = new System.Drawing.Point(595, 8);
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
            this.txtPageNum.Location = new System.Drawing.Point(852, 9);
            this.txtPageNum.Name = "txtPageNum";
            this.txtPageNum.Size = new System.Drawing.Size(46, 21);
            this.txtPageNum.TabIndex = 23;
            this.txtPageNum.Text = "1";
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevPage.Location = new System.Drawing.Point(653, 8);
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
            this.label1.Location = new System.Drawing.Point(829, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "第";
            // 
            // btnNextPage
            // 
            this.btnNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextPage.Location = new System.Drawing.Point(710, 8);
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
            this.btnLastPage.Location = new System.Drawing.Point(766, 8);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(57, 23);
            this.btnLastPage.TabIndex = 21;
            this.btnLastPage.Text = "末页";
            this.btnLastPage.UseVisualStyleBackColor = true;
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtCreateBy);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtFileName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbxSort);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 53);
            this.panel1.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(734, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "排序字段：分类、创建日期";
            // 
            // txtCreateBy
            // 
            this.txtCreateBy.Location = new System.Drawing.Point(234, 15);
            this.txtCreateBy.Name = "txtCreateBy";
            this.txtCreateBy.Size = new System.Drawing.Size(100, 21);
            this.txtCreateBy.TabIndex = 8;
            this.txtCreateBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCreateBy_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(174, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "创建者：";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(430, 15);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(199, 21);
            this.txtFileName.TabIndex = 6;
            this.txtFileName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFileName_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(360, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "文件名称：";
            // 
            // cbxSort
            // 
            this.cbxSort.FormattingEnabled = true;
            this.cbxSort.Location = new System.Drawing.Point(68, 15);
            this.cbxSort.Name = "cbxSort";
            this.cbxSort.Size = new System.Drawing.Size(82, 20);
            this.cbxSort.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "分类：";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(653, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(59, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvShareFile);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 420);
            this.panel2.TabIndex = 5;
            // 
            // dgvShareFile
            // 
            this.dgvShareFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShareFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.FilePath,
            this.SerialNo,
            this.SortName,
            this.FileName,
            this.FileDesc,
            this.CreateByName,
            this.CreateDate,
            this.Memo,
            this.下载});
            this.dgvShareFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShareFile.Location = new System.Drawing.Point(0, 0);
            this.dgvShareFile.Name = "dgvShareFile";
            this.dgvShareFile.RowHeadersVisible = false;
            this.dgvShareFile.RowTemplate.Height = 23;
            this.dgvShareFile.Size = new System.Drawing.Size(1008, 420);
            this.dgvShareFile.TabIndex = 0;
            this.dgvShareFile.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShareFile_CellClick);
            this.dgvShareFile.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvShareFile_RowPostPaint);
            // 
            // ID
            // 
            this.ID.HeaderText = "主键";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            this.ID.Width = 80;
            // 
            // FilePath
            // 
            this.FilePath.DataPropertyName = "FilePath";
            this.FilePath.HeaderText = "文件路径";
            this.FilePath.Name = "FilePath";
            this.FilePath.Visible = false;
            // 
            // SerialNo
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SerialNo.DefaultCellStyle = dataGridViewCellStyle1;
            this.SerialNo.HeaderText = "序号";
            this.SerialNo.Name = "SerialNo";
            this.SerialNo.Width = 60;
            // 
            // SortName
            // 
            this.SortName.DataPropertyName = "SortName";
            this.SortName.HeaderText = "分类";
            this.SortName.Name = "SortName";
            this.SortName.Width = 80;
            // 
            // FileName
            // 
            this.FileName.DataPropertyName = "FileName";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FileName.DefaultCellStyle = dataGridViewCellStyle2;
            this.FileName.HeaderText = "文件名称";
            this.FileName.Name = "FileName";
            this.FileName.Width = 200;
            // 
            // FileDesc
            // 
            this.FileDesc.DataPropertyName = "FileDesc";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FileDesc.DefaultCellStyle = dataGridViewCellStyle3;
            this.FileDesc.HeaderText = "文件描述";
            this.FileDesc.Name = "FileDesc";
            this.FileDesc.Width = 200;
            // 
            // CreateByName
            // 
            this.CreateByName.DataPropertyName = "CreateByName";
            this.CreateByName.HeaderText = "创建者";
            this.CreateByName.Name = "CreateByName";
            this.CreateByName.Width = 80;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.CreateDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.CreateDate.HeaderText = "创建日期";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.Width = 80;
            // 
            // Memo
            // 
            this.Memo.DataPropertyName = "Memo";
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Memo.DefaultCellStyle = dataGridViewCellStyle5;
            this.Memo.HeaderText = "备注";
            this.Memo.Name = "Memo";
            this.Memo.Width = 200;
            // 
            // 下载
            // 
            this.下载.DataPropertyName = "下载";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.下载.DefaultCellStyle = dataGridViewCellStyle6;
            this.下载.HeaderText = "下载";
            this.下载.Name = "下载";
            this.下载.Text = "下载";
            this.下载.ToolTipText = "下载";
            this.下载.UseColumnTextForButtonValue = true;
            this.下载.Width = 60;
            // 
            // ShareFileList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 511);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "ShareFileList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "共享文件列表";
            this.Load += new System.EventHandler(this.ShareFileList_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShareFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvShareFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxSort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCreateBy;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SortName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateByName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Memo;
        private System.Windows.Forms.DataGridViewButtonColumn 下载;
        private System.Windows.Forms.Label label7;
    }
}