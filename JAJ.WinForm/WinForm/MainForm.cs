using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JAJ.WinForm;
using JAJ.WinForm.FRM;
using JAJ.WinForm.Scm;
using JAJ.WinForm.PPM;
using System.ServiceModel;
using JAJ.WinForm.Comm;
using System.Configuration;
using System.Timers;
using System.Runtime.InteropServices;
using JAJ.WinForm.SYS;
using System.ServiceModel.Description;
using System.Reflection;

namespace JAJ.WinForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            using (BugTraceEntities context = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
            {
                #region 动态创建菜单
                var menuList = context.SYS_Menu.ToList();
                var firstMenu = menuList.Where(p => p.SortGrade == 1);
                foreach (var item in firstMenu.OrderBy(p => p.OrderCode))
                {
                    if (item.HasNext == 0)
                    {
                        ToolStripMenuItem menu = new ToolStripMenuItem();
                        menu.Text = item.MenuName;
                        menu.Tag = item.FormModule + "." + item.FormName;
                        menu.Click += menu_Click;
                        this.menuStrip1.Items.Add(menu);
                    }
                    else
                    {
                        ToolStripMenuItem menu2 = new ToolStripMenuItem();
                        menu2.Text = item.MenuName;
                        var secMenu = menuList.Where(p => p.ParentCode == item.MenuCode);
                        foreach (var itemChild in secMenu)
                        {
                            ToolStripMenuItem menu = new ToolStripMenuItem();
                            menu.Text = itemChild.MenuName;
                            menu.Tag = itemChild.FormModule + "." + itemChild.FormName;
                            menu.Click += menu_Click;
                            menu2.DropDownItems.Add(menu);
                        }
                        this.menuStrip1.Items.Add(menu2);
                    }
                }
                ToolStripMenuItem menuHelp = new ToolStripMenuItem();
                menuHelp.Text = "帮助(&H)";
                ToolStripMenuItem menuBrief = new ToolStripMenuItem();
                menuBrief.Text = "简要说明";
                menuBrief.Click += menuBrief_Click;
                menuHelp.DropDownItems.Add(menuBrief);
                ToolStripMenuItem menuAbout = new ToolStripMenuItem();
                menuAbout.Text = "关于";
                menuAbout.Click += menuAbout_Click;
                menuHelp.DropDownItems.Add(menuAbout);
                this.menuStrip1.Items.Add(menuHelp);
                #endregion

            }

            this.lblCurrentUser.Text = "当前用户："+UserInfo.GetInstence().UserName;

            //打开问题跟踪
            //openMenu("PPM", "ProjectPlanList");
            //打开首页
            openMenu(null, "FrmIndex");

            
        }

        #region 菜单
        /// <summary>
        /// 打开菜单
        /// </summary>
        /// <param name="formModule"></param>
        /// <param name="formName"></param>
        void openMenu(string formModule, string formName, string args=null)
        {
            string fullName = string.Empty;
            if (string.IsNullOrWhiteSpace(formModule))
            {
                fullName = "JAJ.WinForm." + formName;
            }
            else
            {
                fullName = "JAJ.WinForm." + formModule + "." + formName;
            }
            var type = Type.GetType(fullName);
            FormSingle.GetForm(type).ShowNormal(this, args);
        }
        /// <summary>
        /// 动态菜单点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void menu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = sender as ToolStripMenuItem;
            string fullName = "JAJ.WinForm." + menu.Tag;
            //Assembly assembly = Assembly.GetExecutingAssembly();
            var type = Type.GetType(fullName);
            FormSingle.GetForm(type).ShowNormal(this);
        }
        /// <summary>
        /// 简要说明
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuBrief_Click(object sender, EventArgs e)
        {
            FormSingle.GetForm(typeof(FrmBrief)).ShowNormal(this);
        }
        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAbout_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();           
            sb.Append("BugTrace(专注软件开发流程规范化管理)\r\n");
            sb.Append("版本 " + ConfigurationManager.AppSettings["Version"]+"\r\n");
            sb.Append("Copyright 2014 - 2016\r\n");
            sb.Append("");
            MessageBox.Show(sb.ToString(), "关于", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }        
        #endregion

        #region 快捷键设置
        private void MainForm_Activated(object sender, EventArgs e)
        {
            //注册热键Shift+I，Id号为100。HotKey.KeyModifiers.Shift也可以直接使用数字4来表示。
            HotKey.RegisterHotKey(Handle, 100, HotKey.KeyModifiers.Alt, Keys.I);
            HotKey.RegisterHotKey(Handle, 101, HotKey.KeyModifiers.Alt, Keys.O);
        }

        private void MainForm_Leave(object sender, EventArgs e)
        {
            //注销Id号为100的热键设定
            HotKey.UnregisterHotKey(Handle, 100);
            HotKey.UnregisterHotKey(Handle, 101);
        }
        /// <summary>
        /// 重载FromA中的WndProc函数，监视Windows消息，重载WndProc方法，用于实现热键响应
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            //按快捷键 
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 100:    //按下的是Shift+I
                            openMenu("PPM", "CreateProjectForm","Add");  
                            break;
                        case 101:
                            openMenu("PPM", "CreateProjectForm","Edit");  
                            //此处填写快捷键响应代码
                            break;                        
                    }
                    break;
            }
            base.WndProc(ref m);
        }


        #endregion

        #region 是否退出
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("您确定要退出吗？", "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
               
            }
            else
            {
                e.Cancel = true;
            }
        }
        #endregion

    }
}
