using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Entity;
using JAJ.WinForm.Comm;
using System.IO;

namespace JAJ.WinForm.PPM
{
    public partial class ProblemTraceList : Form
    {
        public ProblemTraceList()
        {
            InitializeComponent();
            this.dgvProblemTrace.AutoGenerateColumns = false;
            this.dgvProblemTrace.AllowUserToAddRows = false;
            dgvProblemTrace.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            //dgvProblemTrace.Columns[dgvProblemTrace.ColumnCount - 2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void ProblemTraceList_Load(object sender, EventArgs e)
        {
            using(BugTraceEntities entiy = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
            {
                string defaultProjectCode = UserInfo.GetInstence().DefaultProjectCode;
                var project = entiy.PPM_ProjectInfo.Where(p => p.ProjectCode == defaultProjectCode).FirstOrDefault();
                if (project != null)
                {
                    this.lblTestPublish.Text = project.TestPublishDate == null ? "" : project.TestPublishDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    this.Text = project.ProjectName;
                    if (!string.IsNullOrWhiteSpace(project.UsedCustom))
                    {
                        string projectUse = project.UsedCustom.Replace('，', ',');//实施客户
                        foreach (var item in projectUse.Split(','))
                        {
                            //this.lbProjectUse.Items.Add(item);
                        }
                    }
                }
                else
                {
                    return;
                }
                var query = (from c in entiy.PPM_ProjectTeam
                             join d in entiy.SYS_User 
                             on c.TeamMember equals d.UserCode
                             where c.ProjectCode == defaultProjectCode && c.Status==1
                            select new
                            {
                                UserCode=c.TeamMember,
                                d.UserName 
                            }).ToList();
                List<KeyValuePair<string, string>> kvp = new List<KeyValuePair<string, string>>();
                List<KeyValuePair<string, string>> kvp2 = new List<KeyValuePair<string, string>>();
                foreach (var item in query)
                {
                    kvp.Add(new KeyValuePair<string, string>(item.UserCode, item.UserName));
                    kvp2.Add(new KeyValuePair<string, string>(item.UserCode, item.UserName));
                }
                this.lbFindPerson.DisplayMember = "value";
                this.lbFindPerson.ValueMember = "key";
                this.lbFindPerson.DataSource = kvp;

                this.lbDealPerson.DisplayMember = "value";
                this.lbDealPerson.ValueMember = "key";
                this.lbDealPerson.DataSource = kvp2;
                
            }
            this.lbDealPerson.ClearSelected();
            this.lbFindPerson.ClearSelected();
        }

        #region 公共属性
        /// <summary>
        /// datagridview选中行的ID
        /// </summary>
        //public int ProblemTraceID { get; set; }
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

        #region 列序号
        private void dgvProblemTrace_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            foreach (DataGridViewRow dr in dgvProblemTrace.Rows)
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
                string defaultProjectCode=UserInfo.GetInstence().DefaultProjectCode;
                IQueryable<PPM_ProblemTrace> query = from c in zEntity.PPM_ProblemTrace
                                                     where c.DeleteFlag == 0 && c.ProjectCode == defaultProjectCode
                                                     select c;

                //提出人查询条件
                List<String> strFindPersonCode = new List<string>();
                for (int i = 0; i < this.lbFindPerson.SelectedItems.Count; i++)
                {
                    var drv = (KeyValuePair<string, string>)this.lbFindPerson.SelectedItems[i];
                    strFindPersonCode.Add(drv.Key.ToString());
                }
                if (strFindPersonCode.Count > 0)
                {
                    query = query.Where(p => strFindPersonCode.Contains(p.FindPersonCode));
                }
                //任务号查询条件
                if (!string.IsNullOrWhiteSpace(this.txtTaskID.Text))
                {
                    int taskID=Convert.ToInt32(this.txtTaskID.Text);
                    query = query.Where(p => p.ID == taskID);
                }
                //处理人查询条件
                List<String> strDealPersonCode = new List<string>();
                for (int i = 0; i < this.lbDealPerson.SelectedItems.Count; i++)
                {
                    var drv = (KeyValuePair<string, string>)this.lbDealPerson.SelectedItems[i];
                    strDealPersonCode.Add(drv.Key.ToString());
                }
                if (strDealPersonCode.Count > 0)
                {
                    query = query.Where(p => strDealPersonCode.Contains(p.DealPersonCode));
                }
                //类型查询条件
                List<String> strProblemType = new List<string>();
                for (int i = 0; i < this.lbProblemType.SelectedItems.Count; i++)
                {
                    strProblemType.Add(this.lbProblemType.SelectedItems[i].ToString());
                }
                if (strProblemType.Count > 0)
                {
                    query = query.Where(p => strProblemType.Contains(p.ProblemType));
                }

                //状态查询条件
                List<String> strStatus= new List<string>();               
                for (int i = 0; i < this.lbStatus.SelectedItems.Count; i++)
                {
                    strStatus.Add(this.lbStatus.SelectedItems[i].ToString());
                }
                if (strStatus.Count>0)
                {
                    query = query.Where(p => strStatus.Contains(p.Status));
                }
                //实施客户查询条件
                //List<String> strProject = new List<string>();
                //for (int i = 0; i < this.lbProjectUse.SelectedItems.Count; i++)
                //{
                //    strProject.Add(this.lbProjectUse.SelectedItems[i].ToString());
                //}
                //if (strProject.Count > 0)
                //{
                //    query = query.Where(p => strProject.Contains(p.ProjectUse));
                //}
                
                int pageSize = Int32.Parse(cbxPageSize.Text);
                int pageNum = Int32.Parse(txtPageNum.Text);
                var problemList = query.OrderByDescending(p => p.ID).Skip(pageSize * (pageNum - 1)).Take(pageSize)
                    .Select(p => new
                    {
                        p.ID,
                        p.ProblemType,
                        p.Module,
                        p.Problem,
                        p.FindPerson,
                        FindDate = p.FindDate,
                        p.Solution,
                        p.DealPerson,
                        EndDealDate = p.EndDealDate,
                        p.Status,
                        p.ProjectUse,
                        TestFlag=p.TestFlag==1?"已发":"未发"
                    }).ToList();
                
                this.dgvProblemTrace.DataSource = problemList;
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

        #region 清空查询条件
        private void btnClearStatus_Click(object sender, EventArgs e)
        {
            this.lbStatus.ClearSelected();
        }
                
        private void btnClearFindPerson_Click(object sender, EventArgs e)
        {
            this.lbFindPerson.ClearSelected();
        }
        private void btnClearDealPerson_Click(object sender, EventArgs e)
        {
            this.lbDealPerson.ClearSelected();
        }
        private void btnClearProblemType_Click(object sender, EventArgs e)
        {
            this.lbProblemType.ClearSelected();
        }
        #endregion
        
        #region 新增
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormArgument.ProblemTraceID = -1;//-1表示新增
            ProblemTraceForm tempForm = FormSingle.GetForm(typeof(ProblemTraceForm)) as ProblemTraceForm;
            tempForm.ShowNormal(this.ParentForm);
        }
        #endregion

        #region 修改
        private void btnEdit_Click(object sender, EventArgs e)
        {
            var key = this.dgvProblemTrace.CurrentRow.Cells["ID"].Value;
            if (key == null)
            {
                MessageBox.Show("请先选择一行数据");
            }
            else
            {
                FormArgument.ProblemTraceID = Int32.Parse(key.ToString());
                ProblemTraceForm tempForm = FormSingle.GetForm(typeof(ProblemTraceForm)) as ProblemTraceForm;
                tempForm.ShowNormal(this.ParentForm);
            }
        }
        #endregion

        #region 删除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要删除吗？", "提示：",MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                var key = dgvProblemTrace.CurrentRow.Cells["ID"].Value;
                if (key == null)
                {
                    MessageBox.Show("请先选择一行数据");
                }
                else
                {
                    FormArgument.ProblemTraceID = Int32.Parse(key.ToString());
                    using (BugTraceEntities context = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
                    {
                        var saleOrder = context.PPM_ProblemTrace.Where(p => p.ID == FormArgument.ProblemTraceID).FirstOrDefault();
                        if (saleOrder != null)
                        {
                            saleOrder.DeleteFlag = 1;//删除标识
                            saleOrder.UpdatePerson = UserInfo.GetInstence().UserCode;
                            saleOrder.UpdateDate = DateTime.Now;
                            //context.PPM_ProblemTrace.Remove(saleOrder);
                            context.SaveChanges();
                            MessageBox.Show("删除成功！");
                            btnSearch_Click(null, null);
                        }
                    }
                }
            }
        }
        #endregion

        #region 双击事件
        private void dgvProblemTrace_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            var key = dgvProblemTrace.Rows[e.RowIndex].Cells["ID"].Value;
            if (key == null)
            {
                MessageBox.Show("请先查询");
            }
            else
            {
                FormArgument.ProblemTraceID = Int32.Parse(key.ToString());
                ProblemTraceForm tempForm = FormSingle.GetForm(typeof(ProblemTraceForm)) as ProblemTraceForm;
                tempForm.ShowNormal(this.ParentForm);
            }
        }
        #endregion       

        #region 导出excel
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strFolder = folderBrowserDialog1.SelectedPath;
                using (BugTraceEntities context = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
                {
                    string defaultProjectCode = UserInfo.GetInstence().DefaultProjectCode;
                    SqlParameter[] sqlparams = new SqlParameter[1];
                    sqlparams[0] = new SqlParameter("@DefaultProjectCode", SqlDbType.VarChar,50);
                    sqlparams[0].Value = string.IsNullOrWhiteSpace(defaultProjectCode) ? "" : defaultProjectCode;
                   
                    DataTable dtbl = context.Database.SqlQueryForDataTatable(
                        " SELECT a.Module,a.ProblemType,a.Problem,a.FindPerson,CONVERT(varchar(100), a.FindDate, 23),a.Solution,a.DealPerson,CONVERT(varchar(100), a.EndDealDate, 23),a.Status,a.ProjectUse "
                        +" FROM dbo.PPM_ProblemTrace a WHERE a.DeleteFlag=0 and a.ProjectCode=@DefaultProjectCode ", sqlparams);

                    using (OpenXmlHelper ox = new OpenXmlHelper())
                    {
                        ox.RowIndex = new int[] { 3 };
                        var fileTemplatePath = System.Environment.CurrentDirectory + "\\Template\\ProblemTraceTemplate.xlsx";
                        var filePath = strFolder + "\\ProblemTrace.xlsx";
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                        DataSet ds = new DataSet();
                        ds.Tables.Add(dtbl);
                        ox.ExcelExport(ds, filePath, fileTemplatePath);
                    }
                    MessageBox.Show("导出excel成功！");
                }
            }
        }
        #endregion

        #region 测试发版
        private void btnTestPublish_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定已经测试发版了吗？", "提示：", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                using (BugTraceEntities context = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
                {
                    var problem = context.PPM_ProblemTrace.Where(p => p.Status == "已提交未审核" || p.Status == "完成" || p.Status == "发版关闭");
                    foreach (var item in problem)
                    {
                        item.TestFlag = 1;
                    }
                    string defaultProjectCode = UserInfo.GetInstence().DefaultProjectCode;
                    var project = context.PPM_ProjectInfo.Where(p => p.ProjectCode == defaultProjectCode).FirstOrDefault();
                    if (project != null)
                    {
                        project.TestPublishDate = DateTime.Now;
                    }
                    context.SaveChanges();
                    this.lblTestPublish.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") ;
                    MessageBox.Show("保存成功！");
                    this.SearchClick();
                }
            }
        }
        #endregion

        #region 窗口关闭事件
        private void ProblemTraceList_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool isExist = FormSingle.IsExist(typeof(ProblemTraceForm));
            if (isExist)
            {
                var tempForm = FormSingle.GetForm(typeof(ProblemTraceForm));
                tempForm.Close();               
            }
        }
        #endregion 

        #region 更改行背景色
        private void dgvProblemTrace_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < this.dgvProblemTrace.Rows.Count; i++)
            {
                var status = this.dgvProblemTrace.Rows[i].Cells["Status"].Value.ToString();
                if (status == "发版关闭" || status == "完成")
                {
                    this.dgvProblemTrace.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;
                }
            }
        }
        #endregion

        private void txtTaskID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }  
        }
    }
}
