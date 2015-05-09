using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JAJ.WinForm.Scm
{
    public partial class SaleOrderForm : Form
    {
        #region 属性
        /// <summary>
        /// 主键
        /// </summary>
        public int SaleOrderID { get; set; }

        #endregion
        public SaleOrderForm()
        {
            InitializeComponent();            
        }

        private void SaleOrderForm_Load(object sender, EventArgs e)
        {

        }

        #region 保存
        private void btnSaveSaleOrder_Click(object sender, EventArgs e)
        {
            SCM_SaleOrder saleOrder;
            BugTraceEntities zEntity = new BugTraceEntities(EntityContextHelper.GetEntityConnString());
            if (this.SaleOrderID == -1)
            {
                saleOrder = new SCM_SaleOrder();
            }
            else
            {
                saleOrder=zEntity.SCM_SaleOrder.Where(p => p.ID == this.SaleOrderID).FirstOrDefault();
            }            
            saleOrder.DeliveryDate=DateTime.Parse(this.dtDeliveryDate.Text);          
            saleOrder.CustomName = this.txtCustomName.Text;
            saleOrder.CustomTel = this.txtCustomTel.Text;
            saleOrder.AgentName = this.txtAgentName.Text;
            saleOrder.CustomAddr = this.txtCustomAddr.Text;
            decimal sumMoney=0;
            if (!decimal.TryParse(this.txtSumMoney.Text,out sumMoney))
            {
                MessageBox.Show("金额必须为数字");
                return;
            }
            saleOrder.SumMoney = sumMoney;
            decimal qty = 0;
            if (!decimal.TryParse(this.txtQty.Text, out qty))
            {
                MessageBox.Show("金额必须为数字");
                return;
            }
            saleOrder.Qty = qty;
            saleOrder.GoodName = this.cbxGoodsName.Text;
            saleOrder.GoodSort = this.txtGoodsSort.Text;
            saleOrder.DeliveryType = this.cbxDeliveryType.Text;
            saleOrder.DeliveryNo = this.txtDeliveryNo.Text;
            saleOrder.PayStatus = this.cbxPayStatus.Text;
            saleOrder.PayType = this.cbxPayType.Text;
            saleOrder.GiftDesc = this.txtGiftDesc.Text;
            saleOrder.Memo = this.txtMemo.Text;
            if (this.SaleOrderID == -1)
            {
                zEntity.SCM_SaleOrder.Add(saleOrder);
            }
            zEntity.SaveChanges();
            MessageBox.Show("保存成功！");            
            this.Close();
            var saleOrderListForm = FormSingle.GetForm(typeof(SaleOrderList)) as SaleOrderList;
            saleOrderListForm.SearchClick();
        }
        #endregion

        #region 窗体激活事件
        private void SaleOrderForm_Activated(object sender, EventArgs e)
        {
            SaleOrderList listForm = FormSingle.GetForm(typeof(SaleOrderList)) as SaleOrderList;
            int rowID = listForm.RowID;
            BugTraceEntities zEntity = new BugTraceEntities(EntityContextHelper.GetEntityConnString());
            var saleOrderList = zEntity.SCM_SaleOrder.Where(p => p.ID == rowID);
            if (saleOrderList != null && saleOrderList.Count() > 0)
            {
                SCM_SaleOrder saleOrder = saleOrderList.FirstOrDefault();
                this.SaleOrderID = saleOrder.ID;
                this.dtDeliveryDate.Text = saleOrder.DeliveryDate.ToString();
                this.txtCustomName.Text = saleOrder.CustomName;
                this.txtCustomTel.Text = saleOrder.CustomTel;
                this.txtAgentName.Text = saleOrder.AgentName;
                this.txtCustomAddr.Text = saleOrder.CustomAddr;
                this.txtSumMoney.Text = saleOrder.SumMoney.ToString();
                this.txtQty.Text = saleOrder.Qty.ToString();
                this.cbxGoodsName.Text = saleOrder.GoodName;
                this.txtGoodsSort.Text = saleOrder.GoodSort;
                this.cbxDeliveryType.Text = saleOrder.DeliveryType;
                this.txtDeliveryNo.Text = saleOrder.DeliveryNo;
                this.cbxPayStatus.Text = saleOrder.PayStatus;
                this.cbxPayType.Text = saleOrder.PayType;
                this.txtGiftDesc.Text = saleOrder.GiftDesc;
                this.txtMemo.Text = saleOrder.Memo;
            }
            else
            {
                this.SaleOrderID = rowID;
                this.dtDeliveryDate.Text = "";
                this.txtCustomName.Text = "";
                this.txtCustomTel.Text = "";
                this.txtAgentName.Text = "";
                this.txtCustomAddr.Text = "";
                this.txtSumMoney.Text = "";
                this.txtQty.Text = "";
                this.cbxGoodsName.Text = "";
                this.txtGoodsSort.Text = "";
                this.cbxDeliveryType.Text = "";
                this.txtDeliveryNo.Text = "";
                this.cbxPayStatus.Text = "";
                this.cbxPayType.Text = "";
                this.txtGiftDesc.Text = "";
                this.txtMemo.Text = "";
            }
        }

        #endregion
       
        
    }
}
