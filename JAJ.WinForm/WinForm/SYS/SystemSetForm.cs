using JAJ.WinForm.PPM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JAJ.WinForm.SYS
{
    public partial class SystemSetForm : Form
    {
        public SystemSetForm()
        {
            InitializeComponent();
        }

        private void SystemSetForm_Load(object sender, EventArgs e)
        {
            UserInfo userInfo = UserInfo.GetInstence();
            this.lblUserCode.Text = userInfo.UserCode + "(" + userInfo.UserName + ")";
           
            using (BugTraceEntities context = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
            {
                List<KeyValuePair<string, string>> kvp = new List<KeyValuePair<string, string>>();
                List<KeyValuePair<string, string>> kvpCommon = new List<KeyValuePair<string, string>>();
                var userRoleList = context.SYS_UserRole.Where(p => p.UserCode == userInfo.UserCode && p.RoleCode == "DeptManager").FirstOrDefault();
                if (userRoleList != null)
                {
                    var query = from c in context.PPM_ProjectInfo
                                orderby c.BeginDate descending
                                select new { c.ProjectCode, c.ProjectName, c.BeginDate };
                    foreach (var item in query)
                    {
                        kvp.Add(new KeyValuePair<string, string>(item.ProjectCode, item.ProjectName));
                        kvpCommon.Add(new KeyValuePair<string, string>(item.ProjectCode, item.ProjectName));
                    }
                }
                else
                {
                    var query = from c in context.PPM_ProjectInfo
                                join d in context.PPM_ProjectTeam
                                on c.ProjectCode equals d.ProjectCode
                                where d.TeamMember == userInfo.UserCode
                                group c by new { ProjectCode = c.ProjectCode, ProjectName = c.ProjectName } into g
                                orderby g.Max(p => p.BeginDate) descending
                                select new { g.Key.ProjectCode, g.Key.ProjectName, BeginDate = g.Max(p => p.BeginDate) };
                    
                    foreach (var item in query)
                    {
                        kvp.Add(new KeyValuePair<string, string>(item.ProjectCode, item.ProjectName));
                        kvpCommon.Add(new KeyValuePair<string, string>(item.ProjectCode, item.ProjectName));
                    }
                }
                this.cbxProjectList.DisplayMember = "value";
                this.cbxProjectList.ValueMember = "key";
                this.cbxProjectList.DataSource = kvpCommon;
                this.cbxProjectList.SelectedIndex = -1;

                this.cbxProject.DisplayMember = "value";
                this.cbxProject.ValueMember = "key";
                this.cbxProject.DataSource = kvp;
                this.cbxProject.SelectedValue = userInfo.DefaultProjectCode == null ? "" : userInfo.DefaultProjectCode;
                var currUser = context.SYS_User.Where(p => p.UserCode == userInfo.UserCode).FirstOrDefault();
                if (currUser != null)
                {
                    this.txtTel.Text = userInfo.Tel;
                    this.txtQQ.Text = userInfo.QQ;                    
                }
                var currUserExt = context.SYS_UserExt.Where(p => p.UserCode == userInfo.UserCode).FirstOrDefault();
                if (currUserExt != null && !string.IsNullOrWhiteSpace(currUserExt.EmailPassword))
                {
                    this.txtEmailPassword.Text = Encrypt.TripleDESDecrypting(currUserExt.EmailPassword);
                }
                var userExt = context.SYS_UserExt.Where(p => p.UserCode == userInfo.UserCode).FirstOrDefault();
                if (userExt != null)
                {
                   if(!string.IsNullOrWhiteSpace(userExt.CommonProject))
                   {
                       var commonProjectList = context.PPM_ProjectInfo.Where(p => userExt.CommonProject.Contains(p.ProjectCode+","));
                       if (commonProjectList != null && commonProjectList.Count() > 0)
                       {
                           lbProjectList.Items.Clear();
                           foreach (var item in commonProjectList)
                           {
                               lbProjectList.Items.Add("("+item.ProjectCode+")"+item.ProjectName);
                           }
                       }
                   }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region 验证
            if (string.IsNullOrWhiteSpace(this.txtTel.Text))
            {
                MessageBox.Show("电话不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtTel.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtQQ.Text))
            {
                MessageBox.Show("QQ不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtQQ.Focus();
                return;
            }
            #endregion
            using (BugTraceEntities context = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
            {
                string strProject = string.Empty;
                if (this.lbProjectList.Items.Count > 0)
                {
                    foreach (var item in this.lbProjectList.Items)
                    {
                        strProject = strProject + item.ToString().Split(')')[0].Replace("(","") + ",";
                    }
                    //strProject = strProject.Substring(0, strProject.Length-1);
                }
               
                string userCode=UserInfo.GetInstence().UserCode;
                var currUserExt = context.SYS_UserExt.Where(p => p.UserCode == userCode).FirstOrDefault();
                if (currUserExt != null)
                {
                    if (!string.IsNullOrWhiteSpace(this.txtEmailPassword.Text))
                    {
                        currUserExt.EmailPassword = Encrypt.TripleDESEncrypting(this.txtEmailPassword.Text);
                        currUserExt.CommonProject = strProject;
                        context.SaveChanges();
                    }                   
                }
                else 
                {
                    currUserExt = new SYS_UserExt();
                    currUserExt.UserCode = userCode;
                    if (!string.IsNullOrWhiteSpace(this.txtEmailPassword.Text))
                    {
                        currUserExt.EmailPassword = Encrypt.TripleDESEncrypting(this.txtEmailPassword.Text);
                    }
                    currUserExt.CommonProject = strProject;
                    context.SYS_UserExt.Add(currUserExt);
                    context.SaveChanges();
                }
                var currUser = context.SYS_User.Where(p => p.UserCode == userCode).FirstOrDefault();
                if (currUser != null && !string.IsNullOrWhiteSpace(this.cbxProject.SelectedValue.ToString()))
                {
                    currUser.DefaultProjectCode = this.cbxProject.SelectedValue.ToString();
                    currUser.QQ = this.txtQQ.Text;
                    currUser.Tel = this.txtTel.Text;
                    context.SaveChanges();
                    UserInfo.GetInstence().DefaultProjectCode = this.cbxProject.SelectedValue.ToString();
                    UserInfo.GetInstence().QQ = this.txtQQ.Text;
                    UserInfo.GetInstence().Tel = this.txtTel.Text;
                    MessageBox.Show("保存成功！");
                    try
                    {
                        bool isExist = FormSingle.IsExist(typeof(ProblemTraceList));
                        if (isExist)
                        {
                            var tempForm = FormSingle.GetForm(typeof(ProblemTraceList));
                            tempForm.Close();
                            tempForm = FormSingle.GetForm(typeof(ProblemTraceList));
                            tempForm.ShowNormal(this.ParentForm);
                        }
                        bool isExistPPL = FormSingle.IsExist(typeof(ProjectPlanList));
                        if (isExistPPL)
                        {
                            var tempForm = FormSingle.GetForm(typeof(ProjectPlanList));
                            tempForm.Close();
                            tempForm = FormSingle.GetForm(typeof(ProjectPlanList));
                            tempForm.ShowNormal(this.ParentForm);
                        }
                        bool isExistIndex = FormSingle.IsExist(typeof(FrmIndex));
                        if (isExistIndex)
                        {
                            var tempForm = FormSingle.GetForm(typeof(FrmIndex)) as FrmIndex;
                            tempForm.Close();
                            tempForm = FormSingle.GetForm(typeof(FrmIndex)) as FrmIndex;
                            tempForm.ShowNormal(this.ParentForm);
                        }
                    }
                    catch (Exception ex)
                    {
                        MyLog.LogError("保存个人设置后刷新各窗口失败！",ex);                        
                    }
                    
                    this.Close();
                }
            }
        }

        private void btnDelProject_Click(object sender, EventArgs e)
        {
            if (this.lbProjectList.SelectedIndex != -1)
            {
                this.lbProjectList.Items.RemoveAt(this.lbProjectList.SelectedIndex);
            }
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.cbxProjectList.Text))
            {
                this.lbProjectList.Items.Add("(" + cbxProjectList.SelectedValue + ")" + cbxProjectList.Text);
            }
        }
    }
}
