using JAJ.WinForm.Comm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JAJ.WinForm.PPM
{
    public partial class ProjectPlanList : Form
    {
        #region 公共属性
        /// <summary>
        /// datagridview选中行的ID
        /// </summary>
        public int SelectedID { get; set; }
        /// <summary>
        /// 是否点击复制按钮
        /// </summary>
        public bool IsCopy { get; set; }
        #endregion

        private int _currIndex;
        private bool _loacateIndex=true;//是否定位到选择行

        #region 公共方法
        public void SearchClick()
        {
            this.DataBind();
        }
        #endregion

        public ProjectPlanList()
        {
            InitializeComponent();
            this.dataGridViewExt1.EnableHeadersVisualStyles = false;
            foreach (DataGridViewColumn col in this.dataGridViewExt1.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                if (col.DataPropertyName!="BusinessCode")
                {
                    col.ReadOnly = true;
                }
                else
                {
                    var style= new DataGridViewCellStyle();
                    style.BackColor = Color.Orange;
                    col.DefaultCellStyle =style;
                }
            }
            this.dataGridViewExt1.AutoGenerateColumns = false;
            this.dataGridViewExt1.AllowUserToAddRows = false;
            this.dataGridViewExt1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

            this.dataGridViewExt1.ColumnHeadersHeight = 40;
            this.dataGridViewExt1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewExt1.AddSpanHeader(5, 3, "预算");
            this.dataGridViewExt1.AddSpanHeader(8, 4, "实际");
            this.dataGridViewExt1.MergeColumnNames.Add("Column1");
            this.dataGridViewExt1.MergeColumnNames.Add("Column2"); 
        }

        private void PPMProjectPlanList_Load(object sender, EventArgs e)
        {
            this.cbxDispatchStatus.SelectedIndex = 0;
            using (BugTraceEntities entiy = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
            {
                UserInfo userInfo=UserInfo.GetInstence();
                string defaultProjectCode = userInfo.DefaultProjectCode;
                string defaultProjectName=string.Empty;
                var project = entiy.PPM_ProjectInfo.Where(p => p.ProjectCode == defaultProjectCode).FirstOrDefault();
                if (project != null)
                {
                    defaultProjectName = project.ProjectName;
                    this.Text = project.ProjectName+"--项目计划";
                }
                #region 绑定项目列表查询条件
                List<KeyValuePair<string, string>> kvp = new List<KeyValuePair<string, string>>();
                bool hasDeafaultPro = false;//常用项目是否包含当前项目
                var userExt = entiy.SYS_UserExt.Where(p => p.UserCode == userInfo.UserCode).FirstOrDefault();
                if (userExt != null)
                {
                    if (!string.IsNullOrWhiteSpace(userExt.CommonProject))
                    {
                        var commonProjectList = entiy.PPM_ProjectInfo.Where(p => userExt.CommonProject.Contains(p.ProjectCode + ","));
                        if (commonProjectList != null && commonProjectList.Count() > 0)
                        {
                            foreach (var item in commonProjectList.OrderByDescending(p => p.BeginDate))
                            {
                                if (item.ProjectCode == defaultProjectCode)
                                {
                                    hasDeafaultPro = true;
                                }
                                kvp.Add(new KeyValuePair<string, string>(item.ProjectCode, item.ProjectName));
                            }                            
                        }
                    }
                }
                if (!hasDeafaultPro)
                {
                    kvp.Add(new KeyValuePair<string, string>(defaultProjectCode, defaultProjectName));
                }
                this.cbxCommonProject.DisplayMember = "value";
                this.cbxCommonProject.ValueMember = "key";
                this.cbxCommonProject.DataSource = kvp;
                if (!string.IsNullOrWhiteSpace(defaultProjectCode))
                {
                    this.cbxCommonProject.SelectedValue = defaultProjectCode;
                }
                #endregion
                
            }      
        }
      
        #region 查询
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _loacateIndex = false;
            DataBind();
        }
        private void DataBind()
        {
            string selProject = cbxCommonProject.Text;
            if (string.IsNullOrWhiteSpace(selProject))
            {
                return;
            }
            bool displayAllTask = this.chkDisplayAllTask.Checked;
            string defaultProjectCode = cbxCommonProject.SelectedValue.ToString();
            using (BugTraceEntities context = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
            {
                IQueryable<V_ProjectPlan> query;
                if (displayAllTask)
                {
                    query = context.V_ProjectPlan.Where(p => p.DeleteFlag == 0 && p.ProjectCode == defaultProjectCode);
                }
                else
                {
                    query = context.V_ProjectPlan.Where(p => p.DeleteFlag == 0 && p.HideFlag == 0 && p.ProjectCode == defaultProjectCode);
                }
                if (this.cbxDispatchStatus.Text != "全部")
                {
                    query = query.Where(p => p.DispatchStatus == this.cbxDispatchStatus.Text);
                }
                var projectPlanList = query.OrderBy(p => p.BusinessCode).ToList();
                foreach (var item in projectPlanList)
                {
                    if (item.RealEndDate != null && item.RealBeginDate != null)
                    {
                        decimal workload = (item.RealEndDate.Value.Date - item.RealBeginDate.Value.Date).Days + 1;
                        //if (item.RealBeginDate.Value.Hour >= 12)
                        //{
                        //    workload = workload - Convert.ToDecimal(0.5);
                        //}
                        //if (item.RealEndDate.Value.Hour < 12)
                        //{
                        //    workload = workload - Convert.ToDecimal(0.5);
                        //}
                        item.RealWorkload = workload;
                    }
                }
                this.dataGridViewExt1.DataSource = projectPlanList;
                if (_currIndex > 0 && _loacateIndex)
                {
                    dataGridViewExt1.Rows[_currIndex].Selected = true;
                    dataGridViewExt1.FirstDisplayedScrollingRowIndex = _currIndex;
                    dataGridViewExt1.CurrentCell = this.dataGridViewExt1.Rows[_currIndex].Cells[4];
                }
            }
        }
        #endregion

        #region 新增
        private void btnAddPlan_Click(object sender, EventArgs e)
        {
            this.SelectedID = -1;
            this.IsCopy = false;
            FormSingle.GetForm(typeof(ProjectPlanForm)).ShowNormal(this.ParentForm);
            _loacateIndex = false;
        }
        #endregion

        #region 复制
        private void btnCopy_Click(object sender, EventArgs e)
        {
            var key = this.dataGridViewExt1.CurrentRow.Cells["ID"].Value;
            if (key == null)
            {
                MessageBox.Show("请先选择一行数据");
            }
            else
            {
                this.SelectedID = Int32.Parse(key.ToString());
                this.IsCopy = true;
                ProjectPlanForm tempForm = FormSingle.GetForm(typeof(ProjectPlanForm)) as ProjectPlanForm;
                tempForm.ShowNormal(this.ParentForm);
                _loacateIndex = true;
            }
        }
        #endregion

        #region 双击
        private void dataGridViewExt1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0||e.ColumnIndex==3)
            {
                return;
            }
            
            var key = dataGridViewExt1.Rows[e.RowIndex].Cells["ID"].Value;
            if (key == null)
            {
                MessageBox.Show("请先查询");
            }
            else
            {
                this.SelectedID = Int32.Parse(key.ToString());
                this.IsCopy = false;
                ProjectPlanForm tempForm = FormSingle.GetForm(typeof(ProjectPlanForm)) as ProjectPlanForm;
                tempForm.ShowNormal(this.ParentForm);
                _loacateIndex = true;
            }
        }
        #endregion

        #region 修改
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewExt1.CurrentRow == null)
            {
                MessageBox.Show("请先选择一行数据");
                return;
            }
            var key = this.dataGridViewExt1.CurrentRow.Cells["ID"].Value;
            if (key == null)
            {
                MessageBox.Show("请先选择一行数据");
            }
            else
            {
                this.SelectedID = Int32.Parse(key.ToString());
                this.IsCopy = false;
                ProjectPlanForm tempForm = FormSingle.GetForm(typeof(ProjectPlanForm)) as ProjectPlanForm;
                tempForm.ShowNormal(this.ParentForm);
                _loacateIndex = true;
            }
        }
        #endregion

        #region 删除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要删除吗？", "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                var key = dataGridViewExt1.CurrentRow.Cells["ID"].Value;
                if (key == null)
                {
                    MessageBox.Show("请先选择一行数据");
                }
                else
                {
                    this.SelectedID = Int32.Parse(key.ToString());                 
                    using (BugTraceEntities context = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
                    {
                        //var problemTraceList = context.PPM_ProblemTrace.Where(p => p.ProjectPlanID == this.SelectedID);
                        //if (problemTraceList != null && problemTraceList.Count() > 0)
                        //{
                        //    MessageBox.Show("任务已经下发，不能删除");
                        //    return;
                        //}
                        var projectPlan = context.PPM_ProjectPlan.Where(p => p.ID == this.SelectedID).FirstOrDefault();
                        if (projectPlan != null)
                        {
                            projectPlan.DeleteFlag = 1;//删除标识
                            projectPlan.UpdatePerson = UserInfo.GetInstence().UserCode;
                            projectPlan.UpdateDate = DateTime.Now;
                            var problemTraceList = context.PPM_ProblemTrace.Where(p => p.ProjectPlanID == this.SelectedID);
                            foreach (var problemTrace in problemTraceList)
                            {
                                problemTrace.DeleteFlag = 1;//删除标识
                                problemTrace.UpdatePerson = UserInfo.GetInstence().UserCode;
                                problemTrace.UpdateDate = DateTime.Now;
                            }
                            context.SaveChanges();
                            MessageBox.Show("删除成功！");
                            _loacateIndex = false;
                            this.DataBind();
                        }
                    }
                }
            }
        }
        #endregion

        #region 保存业务编码
        private void btnSaveBusinessCode_Click(object sender, EventArgs e)
        {
            using (BugTraceEntities context = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
            {
                foreach (DataGridViewRow row in this.dataGridViewExt1.Rows)
                {
                    if (row.Tag == null || row.Tag.ToString() != "Changed")
                    {
                        continue;
                    }
                    int id = Convert.ToInt32(row.Cells["ID"].Value);
                    string bCode = row.Cells["BusinessCode"].Value.ToString();
                    var projectPlan = context.PPM_ProjectPlan.Where(p => p.ID == id).FirstOrDefault();
                    projectPlan.BusinessCode = bCode;
                }
                context.SaveChanges();
            }
            MessageBox.Show("保存业务编码成功！");
            _loacateIndex = true;
            this.DataBind();            
        }
        #endregion

        #region 单元格编辑结束事件
        private void dataGridViewExt1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewExt1.Rows[e.RowIndex].Tag = "Changed";//编辑过
        }
        #endregion

        #region 任务下发
        private void btnTurnToProblemTrace_Click(object sender, EventArgs e)
        {
            var key = this.dataGridViewExt1.CurrentRow.Cells["ID"].Value;           
            if (key == null)
            {
                MessageBox.Show("请先选择一行数据");
            }
            else
            {
                var dealPerson = this.dataGridViewExt1.CurrentRow.Cells["DealPerson"].Value;
                if (dealPerson==null||string.IsNullOrWhiteSpace(dealPerson.ToString()))
                {
                    MessageBox.Show("当前任务没有负责人，不能下发");
                    return;
                }

                if (MessageBox.Show("您确定要下发任务吗？", "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    int id = Convert.ToInt32(key);
                    using (BugTraceEntities context = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
                    {
                        #region 验证是否已经下发任务
                        var problemTraceList = context.PPM_ProblemTrace.Where(p => p.ProjectPlanID == id);
                        if (problemTraceList != null && problemTraceList.Count() > 0)
                        {
                            MessageBox.Show("任务已经下发！");
                            return;
                        }
                        #endregion
                        var projectPlan = context.PPM_ProjectPlan.Where(p => p.ID == id).FirstOrDefault();
                        var problemTrace = new PPM_ProblemTrace()
                        {
                            ProjectCode = projectPlan.ProjectCode,
                            Module = projectPlan.Activity,
                            Problem = projectPlan.Task,
                            FindPerson = UserInfo.GetInstence().UserName,
                            FindPersonCode = UserInfo.GetInstence().UserCode,
                            FindDate = DateTime.Now,
                            DealPerson = projectPlan.ResourceName,
                            DealPersonCode = projectPlan.ResourceCode,
                            Status = projectPlan.Status,
                            DeleteFlag = 0,
                            CreateDate = DateTime.Now,
                            CreatePerson = UserInfo.GetInstence().UserCode,
                            UpdateDate = DateTime.Now,
                            UpdatePerson = UserInfo.GetInstence().UserCode,
                            ProblemType = projectPlan.PlanType,
                            ProjectPlanID = projectPlan.ID,
                            IsRepeat="否"
                        };
                        context.PPM_ProblemTrace.Add(problemTrace);
                        context.SaveChanges();
                        MessageBox.Show("任务下发成功！");
                        _loacateIndex = true;
                        this.DataBind();
                    }
                }
            }
        }
        #endregion

        #region 转到问题跟踪
        private void btnOpenProblemTrace_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewExt1.CurrentRow == null)
            {
                MessageBox.Show("请先选择一行数据");
                return;
            }
            var key = this.dataGridViewExt1.CurrentRow.Cells["ID"].Value;
            if (key == null)
            {
                MessageBox.Show("请先选择一行数据");
            }
            else
            {
                var probID = this.dataGridViewExt1.CurrentRow.Cells["ProblemTraceID"].Value;
                if (probID == null || string.IsNullOrWhiteSpace(probID.ToString()))
                {
                    MessageBox.Show("该计划没有下发任务！");
                }
                else
                {
                    _loacateIndex = true;
                    FormArgument.ProblemTraceID = Convert.ToInt32(probID);
                    ProblemTraceForm tempForm2 = FormSingle.GetForm(typeof(ProblemTraceForm)) as ProblemTraceForm;
                    tempForm2.ShowNormal(this.ParentForm);
                }
            }            
        }        
        #endregion

        #region 改变行背景色
        private void dataGridViewExt1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < this.dataGridViewExt1.Rows.Count; i++)
            {
                var status=this.dataGridViewExt1.Rows[i].Cells["Status"].Value.ToString();
                if (status == "发版关闭" || status == "完成")
                {
                    this.dataGridViewExt1.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;
                    this.dataGridViewExt1.Rows[i].Cells["BusinessCode"].Style.BackColor = Color.Orange;
                    this.dataGridViewExt1.Rows[i].Cells["Column1"].Style.BackColor = Color.White;
                    this.dataGridViewExt1.Rows[i].Cells["Column2"].Style.BackColor = Color.White;
                }
                else if (status == "已提交未审核")
                {
                    this.dataGridViewExt1.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    this.dataGridViewExt1.Rows[i].Cells["BusinessCode"].Style.BackColor = Color.Orange;
                    this.dataGridViewExt1.Rows[i].Cells["Column1"].Style.BackColor = Color.White;
                    this.dataGridViewExt1.Rows[i].Cells["Column2"].Style.BackColor = Color.White;
                }

            }
        }
        #endregion

        #region 显示所有任务
        private void chkDisplayAllTask_CheckedChanged(object sender, EventArgs e)
        {
            _loacateIndex = false;
            DataBind();
        }
        #endregion

        #region 导出excel
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strFolder = folderBrowserDialog1.SelectedPath;
                using (BugTraceEntities context = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
                {
                    string selProject = cbxCommonProject.Text;
                    if (string.IsNullOrWhiteSpace(selProject))
                    {
                        return;
                    }
                    string defaultProjectCode = cbxCommonProject.SelectedValue.ToString();
                    //string defaultProjectCode = UserInfo.GetInstence().DefaultProjectCode;
                    SqlParameter[] sqlparams = new SqlParameter[1];
                    sqlparams[0] = new SqlParameter("@DefaultProjectCode", SqlDbType.VarChar, 50);
                    sqlparams[0].Value = string.IsNullOrWhiteSpace(defaultProjectCode) ? "" : defaultProjectCode;

                    string sql = @" SELECT a.Unit,a.Activity,a.Task,a.BudgetWorkload,CONVERT(varchar(100), a.BudgetBeginDate, 23),
                                    CONVERT(varchar(100), a.BudgetEndDate, 23),a.RealWorkload,
                                    CONVERT(varchar(100), a.RealBeginDate, 23),CONVERT(varchar(100), a.RealEndDate, 23),
                                    CONVERT(varchar(100), a.TestPassDate, 23),a.DispatchStatus,a.Status,a.DealPerson,a.TestPerson ,a.DiffAnalyze
                                    FROM  dbo.V_ProjectPlan a WHERE a.ProjectCode=@DefaultProjectCode ORDER BY a.BusinessCode";
                    DataTable dtbl = context.Database.SqlQueryForDataTatable(sql, sqlparams);

                    using (OpenXmlHelper ox = new OpenXmlHelper())
                    {
                        ox.RowIndex = new int[] { 4 };
                        var fileTemplatePath = System.Environment.CurrentDirectory + "\\Template\\ProjectPlanTemplate.xlsx";
                        var filePath = strFolder + "\\ProjectPlan.xlsx";
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

        #region 设置当前的行index
        private void dataGridViewExt1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _currIndex = this.dataGridViewExt1.CurrentRow.Index;
        }
        #endregion
        

    }
}
