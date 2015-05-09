namespace JAJ.WinForm.Scm
{
    partial class SaleOrderList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSaleOrder = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AgentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SumMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoodSort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeliveryType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeliveryNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiftDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiftQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AgentTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAddSaleOrder = new System.Windows.Forms.Button();
            this.btnUpdateSaleOrder = new System.Windows.Forms.Button();
            this.btnDeleteSaleOrder = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
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
            this.lblPageTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxPayStatus = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleOrder)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSaleOrder
            // 
            this.dgvSaleOrder.AllowUserToAddRows = false;
            this.dgvSaleOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSaleOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaleOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.SerialNo,
            this.DeliveryDate,
            this.CustomName,
            this.CustomTel,
            this.AgentName,
            this.CustomAddr,
            this.SumMoney,
            this.Qty,
            this.GoodName,
            this.GoodSort,
            this.DeliveryType,
            this.DeliveryNo,
            this.PayStatus,
            this.PayType,
            this.GiftDesc,
            this.GiftQty,
            this.BookDate,
            this.AgentTel,
            this.Memo,
            this.Price});
            this.dgvSaleOrder.Location = new System.Drawing.Point(12, 0);
            this.dgvSaleOrder.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.dgvSaleOrder.Name = "dgvSaleOrder";
            this.dgvSaleOrder.RowTemplate.Height = 23;
            this.dgvSaleOrder.Size = new System.Drawing.Size(922, 358);
            this.dgvSaleOrder.TabIndex = 0;
            this.dgvSaleOrder.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSaleOrder_CellDoubleClick);
            this.dgvSaleOrder.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvSaleOrder_RowPostPaint);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ID.DefaultCellStyle = dataGridViewCellStyle5;
            this.ID.Frozen = true;
            this.ID.HeaderText = "主键";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // SerialNo
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SerialNo.DefaultCellStyle = dataGridViewCellStyle6;
            this.SerialNo.FillWeight = 55F;
            this.SerialNo.Frozen = true;
            this.SerialNo.HeaderText = "序号";
            this.SerialNo.Name = "SerialNo";
            this.SerialNo.ReadOnly = true;
            this.SerialNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SerialNo.Width = 55;
            // 
            // DeliveryDate
            // 
            this.DeliveryDate.DataPropertyName = "DeliveryDate";
            this.DeliveryDate.FillWeight = 70F;
            this.DeliveryDate.HeaderText = "日期";
            this.DeliveryDate.Name = "DeliveryDate";
            this.DeliveryDate.Width = 70;
            // 
            // CustomName
            // 
            this.CustomName.DataPropertyName = "CustomName";
            this.CustomName.FillWeight = 80F;
            this.CustomName.HeaderText = "顾客姓名";
            this.CustomName.Name = "CustomName";
            this.CustomName.Width = 80;
            // 
            // CustomTel
            // 
            this.CustomTel.DataPropertyName = "CustomTel";
            this.CustomTel.HeaderText = "顾客电话";
            this.CustomTel.Name = "CustomTel";
            this.CustomTel.Width = 80;
            // 
            // AgentName
            // 
            this.AgentName.DataPropertyName = "AgentName";
            this.AgentName.FillWeight = 80F;
            this.AgentName.HeaderText = "客户来源";
            this.AgentName.Name = "AgentName";
            this.AgentName.Width = 80;
            // 
            // CustomAddr
            // 
            this.CustomAddr.DataPropertyName = "CustomAddr";
            this.CustomAddr.FillWeight = 250F;
            this.CustomAddr.HeaderText = "收货地址";
            this.CustomAddr.Name = "CustomAddr";
            this.CustomAddr.Width = 250;
            // 
            // SumMoney
            // 
            this.SumMoney.DataPropertyName = "SumMoney";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SumMoney.DefaultCellStyle = dataGridViewCellStyle7;
            this.SumMoney.FillWeight = 60F;
            this.SumMoney.HeaderText = "金额";
            this.SumMoney.Name = "SumMoney";
            this.SumMoney.Width = 60;
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "Qty";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = null;
            this.Qty.DefaultCellStyle = dataGridViewCellStyle8;
            this.Qty.FillWeight = 40F;
            this.Qty.HeaderText = "数量";
            this.Qty.Name = "Qty";
            this.Qty.Width = 40;
            // 
            // GoodName
            // 
            this.GoodName.DataPropertyName = "GoodName";
            this.GoodName.FillWeight = 80F;
            this.GoodName.HeaderText = "产品种类";
            this.GoodName.Name = "GoodName";
            this.GoodName.Width = 80;
            // 
            // GoodSort
            // 
            this.GoodSort.DataPropertyName = "GoodSort";
            this.GoodSort.FillWeight = 60F;
            this.GoodSort.HeaderText = "品种";
            this.GoodSort.Name = "GoodSort";
            this.GoodSort.Width = 60;
            // 
            // DeliveryType
            // 
            this.DeliveryType.DataPropertyName = "DeliveryType";
            this.DeliveryType.FillWeight = 80F;
            this.DeliveryType.HeaderText = "发货方式";
            this.DeliveryType.Name = "DeliveryType";
            this.DeliveryType.Width = 80;
            // 
            // DeliveryNo
            // 
            this.DeliveryNo.DataPropertyName = "DeliveryNo";
            this.DeliveryNo.HeaderText = "快递单号";
            this.DeliveryNo.Name = "DeliveryNo";
            // 
            // PayStatus
            // 
            this.PayStatus.DataPropertyName = "PayStatus";
            this.PayStatus.HeaderText = "付款状态";
            this.PayStatus.Name = "PayStatus";
            this.PayStatus.Width = 80;
            // 
            // PayType
            // 
            this.PayType.DataPropertyName = "PayType";
            this.PayType.HeaderText = "付款方式";
            this.PayType.Name = "PayType";
            this.PayType.Width = 80;
            // 
            // GiftDesc
            // 
            this.GiftDesc.DataPropertyName = "GiftDesc";
            this.GiftDesc.HeaderText = "赠品";
            this.GiftDesc.Name = "GiftDesc";
            // 
            // GiftQty
            // 
            this.GiftQty.DataPropertyName = "GiftQty";
            this.GiftQty.HeaderText = "赠品数量";
            this.GiftQty.Name = "GiftQty";
            this.GiftQty.Visible = false;
            // 
            // BookDate
            // 
            this.BookDate.DataPropertyName = "BookDate";
            this.BookDate.HeaderText = "登记日期";
            this.BookDate.Name = "BookDate";
            this.BookDate.Visible = false;
            // 
            // AgentTel
            // 
            this.AgentTel.DataPropertyName = "AgentTel";
            this.AgentTel.HeaderText = "代理人电话";
            this.AgentTel.Name = "AgentTel";
            this.AgentTel.Visible = false;
            // 
            // Memo
            // 
            this.Memo.DataPropertyName = "Memo";
            this.Memo.HeaderText = "备注";
            this.Memo.Name = "Memo";
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "单价";
            this.Price.Name = "Price";
            this.Price.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(681, 79);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAddSaleOrder
            // 
            this.btnAddSaleOrder.Location = new System.Drawing.Point(23, 14);
            this.btnAddSaleOrder.Name = "btnAddSaleOrder";
            this.btnAddSaleOrder.Size = new System.Drawing.Size(75, 23);
            this.btnAddSaleOrder.TabIndex = 2;
            this.btnAddSaleOrder.Text = "新增销售单";
            this.btnAddSaleOrder.UseVisualStyleBackColor = true;
            this.btnAddSaleOrder.Click += new System.EventHandler(this.btnAddSaleOrder_Click);
            // 
            // btnUpdateSaleOrder
            // 
            this.btnUpdateSaleOrder.Location = new System.Drawing.Point(125, 14);
            this.btnUpdateSaleOrder.Name = "btnUpdateSaleOrder";
            this.btnUpdateSaleOrder.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateSaleOrder.TabIndex = 3;
            this.btnUpdateSaleOrder.Text = "修改销售单";
            this.btnUpdateSaleOrder.UseVisualStyleBackColor = true;
            this.btnUpdateSaleOrder.Click += new System.EventHandler(this.btnUpdateSaleOrder_Click);
            // 
            // btnDeleteSaleOrder
            // 
            this.btnDeleteSaleOrder.Location = new System.Drawing.Point(225, 14);
            this.btnDeleteSaleOrder.Name = "btnDeleteSaleOrder";
            this.btnDeleteSaleOrder.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteSaleOrder.TabIndex = 4;
            this.btnDeleteSaleOrder.Text = "删除销售单";
            this.btnDeleteSaleOrder.UseVisualStyleBackColor = true;
            this.btnDeleteSaleOrder.Click += new System.EventHandler(this.btnDeleteSaleOrder_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbxPayStatus);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtCustomName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnAddSaleOrder);
            this.panel1.Controls.Add(this.btnUpdateSaleOrder);
            this.panel1.Controls.Add(this.btnDeleteSaleOrder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(946, 133);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvSaleOrder);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 133);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(946, 408);
            this.panel2.TabIndex = 19;
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
            this.panel3.Location = new System.Drawing.Point(0, 494);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(946, 47);
            this.panel3.TabIndex = 20;
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Location = new System.Drawing.Point(29, 14);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(107, 12);
            this.lblPageInfo.TabIndex = 14;
            this.lblPageInfo.Text = "总共0条记录，每页";
            // 
            // cbxPageSize
            // 
            this.cbxPageSize.FormattingEnabled = true;
            this.cbxPageSize.Items.AddRange(new object[] {
            "20",
            "50",
            "100",
            "1000"});
            this.cbxPageSize.Location = new System.Drawing.Point(142, 10);
            this.cbxPageSize.Name = "cbxPageSize";
            this.cbxPageSize.Size = new System.Drawing.Size(47, 20);
            this.cbxPageSize.TabIndex = 15;
            this.cbxPageSize.Text = "20";
            // 
            // btnSkip
            // 
            this.btnSkip.Location = new System.Drawing.Point(619, 8);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(50, 23);
            this.btnSkip.TabIndex = 13;
            this.btnSkip.Text = "跳转";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "条，共";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(596, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "页";
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Location = new System.Drawing.Point(287, 8);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(52, 23);
            this.btnFirstPage.TabIndex = 8;
            this.btnFirstPage.Text = "首页";
            this.btnFirstPage.UseVisualStyleBackColor = true;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // txtPageNum
            // 
            this.txtPageNum.Location = new System.Drawing.Point(544, 9);
            this.txtPageNum.Name = "txtPageNum";
            this.txtPageNum.Size = new System.Drawing.Size(46, 21);
            this.txtPageNum.TabIndex = 11;
            this.txtPageNum.Text = "1";
            this.txtPageNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPageNum_KeyDown);
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Location = new System.Drawing.Point(345, 8);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(51, 23);
            this.btnPrevPage.TabIndex = 6;
            this.btnPrevPage.Text = "上一页";
            this.btnPrevPage.UseVisualStyleBackColor = true;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(521, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "第";
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(402, 8);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(50, 23);
            this.btnNextPage.TabIndex = 7;
            this.btnNextPage.Text = "下一页";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnLastPage
            // 
            this.btnLastPage.Location = new System.Drawing.Point(458, 8);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(57, 23);
            this.btnLastPage.TabIndex = 9;
            this.btnLastPage.Text = "末页";
            this.btnLastPage.UseVisualStyleBackColor = true;
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            // 
            // lblPageTotal
            // 
            this.lblPageTotal.AutoSize = true;
            this.lblPageTotal.Location = new System.Drawing.Point(242, 13);
            this.lblPageTotal.Name = "lblPageTotal";
            this.lblPageTotal.Size = new System.Drawing.Size(23, 12);
            this.lblPageTotal.TabIndex = 17;
            this.lblPageTotal.Text = "1页";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "顾客姓名：";
            // 
            // txtCustomName
            // 
            this.txtCustomName.Location = new System.Drawing.Point(89, 79);
            this.txtCustomName.Name = "txtCustomName";
            this.txtCustomName.Size = new System.Drawing.Size(100, 21);
            this.txtCustomName.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(206, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "支付状态：";
            // 
            // cbxPayStatus
            // 
            this.cbxPayStatus.FormattingEnabled = true;
            this.cbxPayStatus.Items.AddRange(new object[] {
            "未付款",
            "已付款"});
            this.cbxPayStatus.Location = new System.Drawing.Point(278, 79);
            this.cbxPayStatus.Name = "cbxPayStatus";
            this.cbxPayStatus.Size = new System.Drawing.Size(121, 20);
            this.cbxPayStatus.TabIndex = 8;
            // 
            // SaleOrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 541);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SaleOrderList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "真真记账";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleOrder)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSaleOrder;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddSaleOrder;
        private System.Windows.Forms.Button btnUpdateSaleOrder;
        private System.Windows.Forms.Button btnDeleteSaleOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn AgentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn SumMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoodSort;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeliveryType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeliveryNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayType;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiftDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiftQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AgentTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Memo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.TextBox txtPageNum;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.ComboBox cbxPageSize;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Label lblPageTotal;
        private System.Windows.Forms.ComboBox cbxPayStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCustomName;
        private System.Windows.Forms.Label label4;
    }
}

