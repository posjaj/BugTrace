using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JAJ.WinForm.PPM
{
    public partial class ProjectPlanForm : Form
    {
        #region 私有属性
        private int _projectPlanID;
        private bool _isCopy = false;
        #endregion        

        public ProjectPlanForm()
        {
            InitializeComponent();
        }

        private void ProjectPlanForm_Load(object sender, EventArgs e)
        {
            string defaultProjectCode = UserInfo.GetInstence().DefaultProjectCode;
            using (BugTraceEntities entiy = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
            {
                var query = (from c in entiy.PPM_ProjectTeam
                             join d in entiy.SYS_User
                             on c.TeamMember equals d.UserCode
                             where c.ProjectCode == defaultProjectCode && c.Status == 1
                             select new
                             {
                                 UserCode = c.TeamMember,
                                 UserName = d.UserName
                             }).ToList();
                List<KeyValuePair<string, string>> kvp = new List<KeyValuePair<string, string>>();
                foreach (var item in query)
                {
                    kvp.Add(new KeyValuePair<string, string>(item.UserCode, item.UserName));
                }
                this.cbxResource.DataSource = kvp;
                this.cbxResource.DisplayMember = "value";
                this.cbxResource.ValueMember = "key";
            }
        }

        #region 激活窗口
        private void ProjectPlanForm_Activated(object sender, EventArgs e)
        {
            ProjectPlanList listForm = FormSingle.GetForm(typeof(ProjectPlanList)) as ProjectPlanList;
            this._projectPlanID = listForm.SelectedID;
            this._isCopy = listForm.IsCopy;
            if (_projectPlanID == -1)
            {
                this.cbxUnit.Text = "";
                this.txtActivity.Text = "";
                this.txtTask.Text = "";
                this.txtBudgetWorkload.Text = "";
                this.dtBudgetBeginDate.Text = "";
                this.dtBudgetEndDate.Text = "";
                this.cbxResource.Text = "";
                this.txtBusinessCode.Text = "";
                this.txtDiffAnalyze.Text = "";
            }
            else
            {
                using (BugTraceEntities context = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
                {
                    var projectPlanList = context.Set<PPM_ProjectPlan>().Where(p => p.ID == _projectPlanID);
                    if (projectPlanList != null && projectPlanList.Count() > 0)
                    {
                        var projectPlan = projectPlanList.FirstOrDefault();
                        this.cbxUnit.Text = projectPlan.Unit ;
                        this.txtActivity.Text = projectPlan.Activity;
                        this.txtTask.Text = projectPlan.Task;
                        this.txtBudgetWorkload.Text = projectPlan.BudgetWorkload.ToString();
                        if (projectPlan.BudgetBeginDate != null)
                        {
                            this.dtBudgetBeginDate.ValueX = projectPlan.BudgetBeginDate;
                        }
                        else
                        {
                            this.dtBudgetBeginDate.ValueX = null;
                        }
                        if (projectPlan.BudgetEndDate != null)
                        {
                            this.dtBudgetEndDate.ValueX = projectPlan.BudgetEndDate;
                        }
                        else
                        {
                            this.dtBudgetEndDate.ValueX = null;
                        }
                        this.cbxResource.Text = projectPlan.ResourceName;
                        this.txtBusinessCode.Text = projectPlan.BusinessCode;
                        this.cbxPlanType.Text = projectPlan.PlanType;
                        this.txtDiffAnalyze.Text = projectPlan.DiffAnalyze;
                        if (projectPlan.HideFlag == 0)
                        {
                            this.rdoDisplay.Checked = true;
                            this.rdoHide.Checked = false;
                        }
                        else
                        {
                            this.rdoDisplay.Checked = false;
                            this.rdoHide.Checked = true;
                        }
                    }
                }
            }
        }
        #endregion

        #region 保存方法
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region 验证
            if (!CheckNumber(this.txtBudgetWorkload.Text))
            {
                MessageBox.Show("预算工作量必须是数值类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtBudgetWorkload.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(cbxPlanType.Text))
            {
                MessageBox.Show("任务类型不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cbxPlanType.Focus();
                return;
            }
            
            #endregion

            using (BugTraceEntities zEntity = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
            {
                PPM_ProjectPlan projectPlan;
                if (this._projectPlanID == -1 || this._isCopy)
                {
                    projectPlan = new PPM_ProjectPlan();
                }
                else
                {
                    projectPlan = zEntity.PPM_ProjectPlan.Where(p => p.ID == this._projectPlanID).FirstOrDefault();
                }
                projectPlan.Unit = this.cbxUnit.Text;
                projectPlan.Activity = this.txtActivity.Text;
                projectPlan.Task = this.txtTask.Text;
                projectPlan.BudgetWorkload = Convert.ToDecimal(this.txtBudgetWorkload.Text);
                if (!string.IsNullOrWhiteSpace(this.dtBudgetBeginDate.Text))
                {
                    projectPlan.BudgetBeginDate = Convert.ToDateTime(this.dtBudgetBeginDate.Text);
                }
                else
                {
                    projectPlan.BudgetBeginDate = null;
                }

                if (!string.IsNullOrWhiteSpace(this.dtBudgetEndDate.Text))
                {
                    projectPlan.BudgetEndDate = Convert.ToDateTime(this.dtBudgetEndDate.Text);
                }
                else
                {
                    projectPlan.BudgetEndDate = null;
                }

                if (!string.IsNullOrWhiteSpace(this.cbxResource.Text))
                {
                    projectPlan.ResourceCode = this.cbxResource.SelectedValue.ToString();
                    projectPlan.ResourceName = this.cbxResource.Text;
                }
                if (this._projectPlanID == -1 || this._isCopy)
                {
                    projectPlan.CreateDate = DateTime.Now;
                    projectPlan.CreatePerson = UserInfo.GetInstence().UserCode;
                    projectPlan.DeleteFlag = 0;
                    projectPlan.Status = "未开始";
                    zEntity.PPM_ProjectPlan.Add(projectPlan);
                }
                else
                {
                    var problemTrace = zEntity.PPM_ProblemTrace.Where(p => p.ProjectPlanID == projectPlan.ID).FirstOrDefault();
                    if (problemTrace != null && problemTrace.Status == "未开始")
                    {
                        problemTrace.Module = projectPlan.Activity;
                        problemTrace.Problem = projectPlan.Task;
                        problemTrace.FindPerson = UserInfo.GetInstence().UserName;
                        problemTrace.FindPersonCode = UserInfo.GetInstence().UserCode;
                        //problemTrace.FindDate = DateTime.Now;
                        problemTrace.DealPerson = projectPlan.ResourceName;
                        problemTrace.DealPersonCode = projectPlan.ResourceCode;
                        problemTrace.UpdateDate = DateTime.Now;
                        problemTrace.UpdatePerson = UserInfo.GetInstence().UserCode;
                        problemTrace.ProblemType = projectPlan.PlanType;
                    }
                }
                projectPlan.UpdateDate = DateTime.Now;
                projectPlan.UpdatePerson = UserInfo.GetInstence().UserCode;
                projectPlan.ProjectCode = UserInfo.GetInstence().DefaultProjectCode;
                projectPlan.BusinessCode = this.txtBusinessCode.Text;
                projectPlan.PlanType = cbxPlanType.Text;
                if (this.rdoDisplay.Checked&&!this.rdoHide.Checked)
                {
                    projectPlan.HideFlag = 0;
                }
                else
                {
                    projectPlan.HideFlag = 1;
                }
                projectPlan.DiffAnalyze = this.txtDiffAnalyze.Text;
                zEntity.SaveChanges();                
            }
            MessageBox.Show("保存成功！");
            this.Close();
            var projectPlanList = FormSingle.GetForm(typeof(ProjectPlanList)) as ProjectPlanList;
            projectPlanList.SearchClick();
        }
        #endregion

        #region 验证数字
        public bool CheckNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return false;
            }
            Regex regex = new Regex(@"^(-)?\d+(\.\d+)?$");
            if (regex.IsMatch(number))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion


    }
}
