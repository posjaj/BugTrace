/*----------------------------------------------------------------  
 *  Copyright (C) 2014-2016 
 *  All rights reserved
 *  创建人：posjaj 
 *  创建时间：2015-05-09  
 * ----------------------------------------------------------------*/
using JAJ.WinForm.Comm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace JAJ.WinForm
{
    public partial class LoginForm : Form
    {

        private static Thread _thread;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            string userCode = ConfigurationManager.AppSettings["ID"];
            string versionNo = ConfigurationManager.AppSettings["Version"];
            
            //int netStatus= GetInternetConStatus.GetNetConStatus();//判断网络状态
            int netStatus = 2;
            if (netStatus == 2 || netStatus == 3)
            {
                if (!string.IsNullOrWhiteSpace(userCode))
                {
                    this.txtUserCode.Text = userCode;
                    btnLogin_Click(null, null);
                }
            }
            else 
            {
                MessageBox.Show("没有连上网络");
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }


        #region 退出
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region 显示密码
        private void chkDisplayPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkDisplayPassword.Checked)
                this.txtPassword.PasswordChar = '*';
            else
                this.txtPassword.PasswordChar = (char)0;
        }
        #endregion

        #region 登录按钮事件
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            WaitForm.Show(this, "正 在 登 录 请 稍 候");
            Thread fThread = new Thread(ThreadLogin);
            fThread.IsBackground = true;
            fThread.Start(this.txtUserCode.Text);
        }
        #endregion
        

        private void ThreadLogin(object obj)
        {
            string userCode = obj.ToString();
            bool isCorrectVersion = true;
            bool isLogin = login(userCode, ref isCorrectVersion);            
            this.Invoke(new MethodInvoker(() =>
            {
                WaitForm.Close();
                this.Enabled = true;
                if (isLogin)
                {
                    if(this.chkRememberUserCode.Checked&&this.chkRememberPassword.Checked)
                    {
                        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        config.AppSettings.Settings["ID"].Value = userCode;
                        config.Save();
                    }                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    if (!isCorrectVersion)
                    {
                        if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            string folder = folderBrowserDialog1.SelectedPath;
                            Thread downloadThread = new Thread(downloadFile);
                            downloadThread.Start(folder);
                            WaitForm.Show(this, "正 在 下 载 请 稍 候");
                        }
                    }
                }   
            }));
        }

        #region 下载最先版本

        #endregion
        private void downloadFile(object objFolder)
        {
            int BufferLen = 4096;
            string folder = objFolder.ToString();
            string file = string.Empty;
            string fileServiceUrl = string.Empty;
            using (BugTraceEntities zentity = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
            {
                var currVersion=zentity.SYS_Version.Where(p => p.IsDefault == 1).FirstOrDefault();
                file = currVersion.FilePath;
                fileServiceUrl = currVersion.FileServiceUrlPort;                
            }
            string fileName = Path.GetFileName(file);
            Stream sourceStream =null;
            try
            {
                EndpointAddress address = new EndpointAddress("http://" + fileServiceUrl + "/JAJ.WinServer/FileService");
                FileTransferSvc.FileServiceClient _client = new FileTransferSvc.FileServiceClient("BasicHttpBinding_IFileService", address);
                sourceStream = _client.DowndloadFile(file);
            }
            catch (Exception ex)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    WaitForm.Close();
                    MessageBox.Show("下载客户端失败！");
                }));
                MyLog.LogError("下载客户端失败！",ex);
                return;
            }
           
            FileStream targetStream = null;
            if (!sourceStream.CanRead)
            {
                MyLog.LogError("下载异常", new Exception("Invalid Stream!"));
                throw new Exception("Invalid Stream!");
            }
            string filePath = Path.Combine(folder, fileName);
            using (targetStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                byte[] buffer = new byte[BufferLen];
                int count = 0;
                while ((count = sourceStream.Read(buffer, 0, BufferLen)) > 0)
                {
                    targetStream.Write(buffer, 0, count);
                }
                targetStream.Close();
                sourceStream.Close();
            }
            this.Invoke(new MethodInvoker(() =>
            {
                WaitForm.Close();
                MessageBox.Show("下载成功，请使用最新下载的客户端，谢谢！");
                this.Close();
            }));
        }


        private bool login(string userCode, ref bool correctVersion)
        {
            string versionNo = ConfigurationManager.AppSettings["Version"];
            string messageUrlPort = string.Empty;
            using (BugTraceEntities zentity = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
            {
                var currVersion = zentity.SYS_Version.Where(p => p.IsDefault == 1).FirstOrDefault();
                if (currVersion == null)
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        MessageBox.Show("数据库中系统版本不存，在请系统联系管理员！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }));
                    return false;
                }
                if (versionNo != currVersion.VersionNo)
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        MessageBox.Show("版本已经升级，请点击确定后下载最新版客户端！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }));
                    correctVersion = false;
                    return false;
                }
                var user = zentity.SYS_User.Where(p => p.UserCode == userCode).FirstOrDefault();
                if (user == null)
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        MessageBox.Show("当前用户不存在，请联系管理员！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }));
                    return false;
                }
                else
                {
                    UserInfo userInfo = UserInfo.GetInstence();
                    userInfo.UserCode = user.UserCode;
                    userInfo.UserName = user.UserName;
                    userInfo.Tel = user.Tel;
                    userInfo.QQ = user.QQ;
                    userInfo.LoginTime = DateTime.Now;
                    userInfo.DefaultProjectCode = user.DefaultProjectCode;
                    messageUrlPort = user.UrlPort;
                }
            }
            try
            {
                //urlPort = "localhost:9119";
                var client = new WCFClient();
                client.WcfMessageEvent += client_WcfMessage;
                var ctx = new InstanceContext(client);
                EndpointAddress address = new EndpointAddress("net.tcp://" + messageUrlPort + "/JAJ.WinServer");
                System.ServiceModel.Channels.Binding binding = new NetTcpBinding("netTcpExpenseService_ForSupplier");
                var proxy = new WcfSvc.MessageServiceClient(ctx, binding, address);
                proxy.Login(userCode);               
            }
            catch (Exception ex)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    MessageBox.Show("消息服务启动失败！\r\n问题跟踪功能可正常使用，请点击确定后继续使用系统");
                }));
                MyLog.LogError("消息服务启动失败", ex);
            }
            finally
            {
                #region 开启新的线程保持连接
                List<KeyValuePair<string, string>> kList = new List<KeyValuePair<string, string>>();
                kList.Add(new KeyValuePair<string, string>("UserCode",userCode));
                kList.Add(new KeyValuePair<string, string>("UrlPort", messageUrlPort));
                _thread = new Thread(KeepAlive);
                _thread.IsBackground = true;
                _thread.Start(kList);
                #endregion
            }
            return true;
        }
        void client_WcfMessage(object sender, WcfMessageEventArgs e)
        {
            MessageBox.Show(e.ServerMessage);
        }

        #region 心跳函数保持连接KeepAlive
        private void KeepAlive(object obj)
        {
            List<KeyValuePair<string, string>> kList = obj as List<KeyValuePair<string, string>>;
            string userCode = kList.Where(p => p.Key == "UserCode").FirstOrDefault().Value;
            string urlPort = kList.Where(p => p.Key == "UrlPort").FirstOrDefault().Value;            
            var client = new WCFClient();
            client.WcfMessageEvent += client_WcfMessage;
            var ctx = new InstanceContext(client);
            EndpointAddress address = new EndpointAddress("net.tcp://" + urlPort + "/JAJ.WinServer");
            System.ServiceModel.Channels.Binding binding = new NetTcpBinding("netTcpExpenseService_ForSupplier");
            var proxy = new WcfSvc.MessageServiceClient(ctx, binding, address);

            while (true)
            {
                Thread.Sleep(3000);
                try
                {
                    proxy.Update(userCode);
                }
                catch
                {
                    try
                    {
                        client = new WCFClient();
                        client.WcfMessageEvent += client_WcfMessage;
                        ctx = new InstanceContext(client);
                        proxy = new WcfSvc.MessageServiceClient(ctx, binding, address);
                        proxy.Login(userCode);
                    }
                    catch (Exception ex)
                    {
                        MyLog.LogError("重连异常", ex);
                    }
                }
            }
        }
        #endregion

        private void txtUserCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnLogin_Click(null,null);
            }
        }

        

    }
}
