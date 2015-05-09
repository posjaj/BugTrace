using JAJ.WinForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace JAJ.WinForm.Scm
{
    public partial class SaleOrderList : Form
    {
        public SaleOrderList()
        {
            InitializeComponent();
            this.dgvSaleOrder.AutoGenerateColumns = false;
            this.dgvSaleOrder.AllowUserToAddRows = false;

        }
        #region 公共属性
        public int RowID
        {
            get;
            set;
        }

        #endregion

        #region 公共方法
        public void SearchClick()
        {
            this.btnSearch_Click(null, null);
        }
        #endregion



        #region 查询
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.txtPageNum.Text = "1";
            PageDataBind();
        }
        #endregion



        #region 新增销售订单
        private void btnAddSaleOrder_Click(object sender, EventArgs e)
        {
            RowID = -1;
            FormSingle.GetForm(typeof(SaleOrderForm)).ShowNormal(this); 
        }
        #endregion

        #region 双击事件
        private void dgvSaleOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var key = dgvSaleOrder.Rows[e.RowIndex].Cells["ID"].Value;
            if (key == null)
            {
                MessageBox.Show("请先查询");
            }
            else
            {
                RowID = Int32.Parse(key.ToString());
                SaleOrderForm tempForm = FormSingle.GetForm(typeof(SaleOrderForm)) as SaleOrderForm;
                tempForm.ShowNormal(this.ParentForm);
            }
        }

        #endregion

        #region 修改销售单
        private void btnUpdateSaleOrder_Click(object sender, EventArgs e)
        {
            var key = dgvSaleOrder.CurrentRow.Cells["ID"].Value;
            if (key == null)
            {
                MessageBox.Show("请先选择一行数据");
            }
            else
            {
                RowID = Int32.Parse(key.ToString());
                SaleOrderForm tempForm = FormSingle.GetForm(typeof(SaleOrderForm)) as SaleOrderForm;
                tempForm.ShowNormal(this.ParentForm);
            }
        }
        #endregion

        #region 删除销售单
        private void btnDeleteSaleOrder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要删除吗？", "提示：", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                var key = dgvSaleOrder.CurrentRow.Cells["ID"].Value;
                if (key == null)
                {
                    MessageBox.Show("请先选择一行数据");
                }
                else
                {
                    RowID = Int32.Parse(key.ToString());
                    using (BugTraceEntities context = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
                    {
                        var saleOrder = context.SCM_SaleOrder.Where(p => p.ID == RowID).FirstOrDefault();
                        if (saleOrder != null)
                        {
                            context.SCM_SaleOrder.Remove(saleOrder);
                            context.SaveChanges();
                            MessageBox.Show("删除成功！");
                            btnSearch_Click(null, null);
                        }
                    }
                }
            }
        }
        #endregion

        #region 列序号
        private void dgvSaleOrder_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            foreach (DataGridViewRow dr in dgvSaleOrder.Rows)
            {
                dr.Cells["SerialNo"].Value = dr.Index + 1;
            }
        }
        #endregion


        #region 分页相关
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void PageDataBind()
        {
            using (BugTraceEntities zEntity = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
            {
                IQueryable<SCM_SaleOrder> query = from c in zEntity.SCM_SaleOrder
                                                      select c;
                if (!string.IsNullOrWhiteSpace(this.txtCustomName.Text))
                {
                    query = query.Where(p => p.CustomName.Contains(this.txtCustomName.Text));
                }
                if(!string.IsNullOrWhiteSpace(this.cbxPayStatus.Text))
                {
                    query = query.Where(p => p.PayStatus == this.cbxPayStatus.Text);
                }
                int pageSize = Int32.Parse(cbxPageSize.Text);
                int pageNum = Int32.Parse(txtPageNum.Text);
                var saleOrderList = query.OrderBy(p => p.ID).Skip(pageSize * (pageNum - 1)).Take(pageSize).ToList();
                this.dgvSaleOrder.DataSource = saleOrderList;
                var totalRecordCount = query.Count();
                this.lblPageInfo.Text = "总共" + totalRecordCount + "条记录，每页";
                this.lblPageTotal.Text = Math.Ceiling(Convert.ToDecimal(totalRecordCount) / pageSize) + "页";
            }
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            txtPageNum.Text = "1";
            PageDataBind();
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (this.txtPageNum.Text == "1")
            {
                return;
            }
            this.txtPageNum.Text = (Convert.ToInt32(this.txtPageNum.Text) - 1).ToString();
            PageDataBind();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            int totalPageCount = Convert.ToInt32(this.lblPageTotal.Text.Substring(0, this.lblPageTotal.Text.Length - 1));
            if (this.txtPageNum.Text == totalPageCount.ToString())
            {
                return;
            }
            this.txtPageNum.Text = (Convert.ToInt32(this.txtPageNum.Text) + 1).ToString();
            PageDataBind();
        }
        /// <summary>
        /// 末页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLastPage_Click(object sender, EventArgs e)
        {
            int totalPageCount = Convert.ToInt32(this.lblPageTotal.Text.Substring(0, this.lblPageTotal.Text.Length - 1));
            this.txtPageNum.Text = totalPageCount.ToString();
            PageDataBind();
        }
        /// <summary>
        /// 跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSkip_Click(object sender, EventArgs e)
        {
            int totalPageCount = Convert.ToInt32(this.lblPageTotal.Text.Substring(0, this.lblPageTotal.Text.Length - 1));
            if (Convert.ToInt32(this.txtPageNum.Text) > totalPageCount)
            {
                this.txtPageNum.Text = totalPageCount.ToString();
            }
            PageDataBind();
        }
        /// <summary>
        /// 回车跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPageNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int totalPageCount = Convert.ToInt32(this.lblPageTotal.Text.Substring(0, this.lblPageTotal.Text.Length - 1));
                if (Convert.ToInt32(this.txtPageNum.Text) > totalPageCount)
                {
                    this.txtPageNum.Text = totalPageCount.ToString();
                }
                PageDataBind();
            }
        }
        #endregion


    }
}
