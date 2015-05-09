using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JAJ.WinForm.PPM
{
    public partial class CreateProjectForm : Form
    {
        private string _formFlag;

        public CreateProjectForm()
        {
            InitializeComponent();
        }

        private void CreateProjectForm_Load(object sender, EventArgs e)
        {
            if (this.Tag != null && this.Tag.ToString() != null && this.Tag.ToString() == "Add")
            {
                this.Text = "新增项目";
                _formFlag = "Add";
            }
            else
            {
                this.Text = "编辑项目";
                _formFlag = "Edit";
            }
            using (BugTraceEntities context = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
            {
                var query = (from c in context.SYS_User                             
                             select new
                             {
                                 UserCode = c.UserCode,
                                 UserName = c.UserName
                             }).ToList();
                List<KeyValuePair<string, string>> kvp = new List<KeyValuePair<string, string>>();
                List<KeyValuePair<string, string>> kvpTeam = new List<KeyValuePair<string, string>>();
                List<KeyValuePair<string, string>> kvpLeader = new List<KeyValuePair<string, string>>();
                foreach (var item in query)
                {
                    kvp.Add(new KeyValuePair<string, string>(item.UserCode, item.UserName));
                    kvpTeam.Add(new KeyValuePair<string, string>(item.UserCode, item.UserName));
                    kvpLeader.Add(new KeyValuePair<string, string>(item.UserCode, item.UserName));
                }
                this.cbxProjectManager.DataSource = kvp;
                this.cbxProjectManager.DisplayMember = "value";
                this.cbxProjectManager.ValueMember = "key";
                cbxProjectManager.Text = "";
                this.cbxProjectTeam.DataSource = kvpTeam;
                this.cbxProjectTeam.DisplayMember = "value";
                this.cbxProjectTeam.ValueMember = "key";
                cbxProjectTeam.Text = "";
                this.cbxProjectLeader.DataSource = kvpLeader;
                this.cbxProjectLeader.DisplayMember = "value";
                this.cbxProjectLeader.ValueMember = "key";
                cbxProjectLeader.Text = "";

                if (this._formFlag == "Edit")
                {
                    this.lblSelectProject.Visible = true;
                    this.cbxSelectProject.Visible = true;
                    var projectList = from c in context.PPM_ProjectInfo                               
                                group c by new { ProjectCode = c.ProjectCode, ProjectName = c.ProjectName } into g
                                select new { g.Key.ProjectCode, g.Key.ProjectName, BeginDate = g.Max(p => p.BeginDate) };
                    List<KeyValuePair<string, string>> kvpProject = new List<KeyValuePair<string, string>>();
                    foreach (var item in projectList.OrderByDescending(p => p.BeginDate))
                    {
                        kvpProject.Add(new KeyValuePair<string, string>(item.ProjectCode, item.ProjectName));
                    }
                    this.cbxSelectProject.DisplayMember = "value";
                    this.cbxSelectProject.ValueMember = "key";
                    this.cbxSelectProject.DataSource = kvpProject;
                    this.txtProjectCode.Enabled = false;
                    //this.cbxSelectProject.SelectedText = "";
                    //cbxSelectProject.Text = "";
                }
            }
        }

        #region 增加项目成员
        private void btnAddProjectTeam_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.cbxProjectTeam.Text)
                && !string.IsNullOrWhiteSpace(this.cbxProjectLeader.Text))
            {
                this.lbxProjectTeam.Items.Add(cbxProjectTeam.SelectedValue+","+cbxProjectLeader.SelectedValue);
            }
        }
        #endregion

        #region 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (BugTraceEntities context = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
            {
                PPM_ProjectInfo projectInfo;
                if (this._formFlag == "Add")
                {
                    projectInfo = new PPM_ProjectInfo();
                }
                else
                {
                    string projectCode=cbxSelectProject.SelectedValue.ToString();
                    projectInfo = context.PPM_ProjectInfo.Where(p => p.ProjectCode == projectCode).FirstOrDefault();
                }
                projectInfo.ProjectCode = txtProjectCode.Text;
                projectInfo.ProjectName = txtProjectName.Text;
                projectInfo.BeginDate = dtBeginDate.Value;
                projectInfo.ProjectManagerCode = this.cbxProjectManager.SelectedValue.ToString();
                
                if (this._formFlag == "Edit")
                {
                    string projectCode=cbxSelectProject.SelectedValue.ToString();
                    var projectTeamList = context.PPM_ProjectTeam.Where(p => p.ProjectCode == projectCode);
                    context.PPM_ProjectTeam.RemoveRange(projectTeamList);
                }
                PPM_ProjectTeam projectTeam;
                foreach (var item in lbxProjectTeam.Items)
                {
                    string[] strTeam = item.ToString().Split(',');
                    projectTeam = new PPM_ProjectTeam();
                    projectTeam.ProjectCode = projectInfo.ProjectCode;
                    projectTeam.TeamLeader = strTeam[1];
                    projectTeam.TeamMember = strTeam[0];
                    projectTeam.Status = 1;
                    context.PPM_ProjectTeam.Add(projectTeam);
                }
                projectTeam = new PPM_ProjectTeam();
                projectTeam.ProjectCode = projectInfo.ProjectCode;
                projectTeam.TeamMember = projectInfo.ProjectManagerCode;
                projectTeam.TeamLeader = projectInfo.ProjectManagerCode;
                projectTeam.Status = 1;
                context.PPM_ProjectTeam.Add(projectTeam);
                if (this._formFlag == "Add")
                {
                    context.PPM_ProjectInfo.Add(projectInfo);
                }                
                context.SaveChanges();
                MessageBox.Show("保存成功！");
            }
        }
        #endregion

        #region 选择项目经理事件
        private void cbxProjectManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxProjectLeader.SelectedValue = this.cbxProjectManager.SelectedValue;
        }
        #endregion

        #region 编辑项目时，下拉项目改变事件
        private void cbxSelectProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.cbxSelectProject.Text))
            {
                var projectCode = cbxSelectProject.SelectedValue.ToString();
                using (BugTraceEntities context = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
                {
                    var projectInfo = context.PPM_ProjectInfo.Where(p => p.ProjectCode == projectCode).FirstOrDefault();
                    txtProjectCode.Text = projectInfo.ProjectCode;
                    txtProjectName.Text = projectInfo.ProjectName;
                    dtBeginDate.ValueX = projectInfo.BeginDate.Value;
                    cbxProjectManager.SelectedValue = projectInfo.ProjectManagerCode;
                    cbxProjectLeader.SelectedValue = projectInfo.ProjectManagerCode;
                    var projectTeamList = context.PPM_ProjectTeam.Where(p => p.ProjectCode == projectCode);
                    this.lbxProjectTeam.Items.Clear();
                    foreach (var item in projectTeamList)
                    {
                        if (item.TeamLeader == item.TeamMember && item.TeamMember == projectInfo.ProjectManagerCode)
                        {
                            continue;
                        }
                        this.lbxProjectTeam.Items.Add(item.TeamMember + "," + item.TeamLeader);
                    }
                }
            }
            else
            {
                txtProjectCode.Text = "";
                txtProjectName.Text = "";
                dtBeginDate.ValueX = null;
                cbxProjectManager.Text = "";
                cbxProjectLeader.Text = "";                
                this.lbxProjectTeam.Items.Clear();
            }
        }
        #endregion


        private void btnDelProjectTeam_Click(object sender, EventArgs e)
        {
            if (this.lbxProjectTeam.SelectedIndex != -1)
            {
                this.lbxProjectTeam.Items.RemoveAt(this.lbxProjectTeam.SelectedIndex);
            }
        }
    }
}
