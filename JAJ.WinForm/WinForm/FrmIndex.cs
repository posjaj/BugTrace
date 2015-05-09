using JAJ.WinForm.Comm;
using JAJ.WinForm.PPM;
using LumiSoft.Net.IMAP;
using LumiSoft.Net.IMAP.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace JAJ.WinForm
{
    public partial class FrmIndex : Form
    {
        private DataTable dtblEmail;
        private int UnReadEmailCount;

        public FrmIndex()
        {
            InitializeComponent();
        }

        private void FrmIndex_Load(object sender, EventArgs e)
        {
            this.Top = 10;
            this.Left = 10;
            using (BugTraceEntities context = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
            {
                #region 加载当前项目信息
                var projectCode = UserInfo.GetInstence().DefaultProjectCode;
                if (!string.IsNullOrWhiteSpace(projectCode))
                {
                    var projectInfo = context.PPM_ProjectInfo.Where(p => p.ProjectCode == projectCode).FirstOrDefault();
                    if (projectInfo != null)
                    {
                        txtCurrProjectName.Text = projectInfo.ProjectName;
                        txtSVN.Text = projectInfo.SVN;
                        txtDevServerInfo.Text = projectInfo.DevServerInfo;
                        txtPubServerInfo.Text = projectInfo.PubServerInfo;
                        txtOtherInfo.Text = projectInfo.OtherInfo;
                        var updatePerson = context.SYS_User.Where(p => p.UserCode == projectInfo.UpdatePerson).FirstOrDefault();
                        if (updatePerson != null)
                        {
                            string updatePersonName = updatePerson.UserName;
                            this.lblUpdateInfo.Text = "（最后一次修改人：" + updatePersonName + "，修改时间：" + (projectInfo.UpdateDate == null ? "未记录" : projectInfo.UpdateDate.Value.ToString("yyyy-MM-dd HH:mm:ss")) + "）";
                        }
                        else
                        {
                            this.lblUpdateInfo.Text = "";
                        }                        
                    }
                }
                #endregion
            }

            #region 开启一个新线程，检测未读邮件信息
            this.dgvEmail.AutoGenerateColumns = false;
            this.dgvEmail.AllowUserToAddRows = false;
            Thread thread = new Thread(new ThreadStart(delegate   ///监听所有客户端连接，并添加到ListBox控件里
            {
                dtblEmail = new DataTable();
                dtblEmail.Columns.Add("Subject", typeof(string));
                dtblEmail.Columns.Add("ReceiveDate", typeof(DateTime));
                dtblEmail.Columns.Add("From", typeof(string));
                while (true)
                {
                    UnReadEmailCount = 0;
                    int netStatus = GetInternetConStatus.GetNetConStatus();
                    if (netStatus == 2 || netStatus == 3)
                    {
                        dtblEmail.Rows.Clear();
                        try
                        {
                            QueryEmailStatus();      
                        }
                        catch (Exception ex)
                        {
                            MyLog.LogError("查询未读邮件异常！",ex);
                        }                                          
                    }
                    Thread.Sleep(1000 * 60*10);//每10分钟查看邮件信息
                }
            }));
            thread.IsBackground = true;
            thread.Start();
            #endregion

            #region 获取外网ip及城市信息，及城市的天气信息
            Thread threadWeather = new Thread(new ThreadStart(delegate   //监听所有客户端连接，并添加到ListBox控件里
            {
                try
                {
                    string hostname;
                    System.Net.IPHostEntry localhost;
                    System.Net.IPAddress[] localaddr;
                    hostname = System.Net.Dns.GetHostName();
                    localhost = System.Net.Dns.GetHostEntry(hostname);
                    localaddr = localhost.AddressList;   //localaddr中就是本机ip地址 

                    foreach (IPAddress ipInfo in localaddr)
                    {
                        if (ipInfo.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            this.Invoke(new MethodInvoker(delegate
                            {
                                lblInnerIP.Text = ipInfo.ToString();
                            }));
                        }
                    }
                    cn.com.webxml.www.WeatherWebService client = new cn.com.webxml.www.WeatherWebService();
                    string[] weaInfo = client.getWeatherbyCityName("青岛");                    
                    this.Invoke(new MethodInvoker(delegate
                    {
                        Label lblDate = new Label();
                        lblDate.Text = weaInfo[13];
                        lblDate.Width = 140;
                        lblDate.Padding = new System.Windows.Forms.Padding(0,7,0,0);
                        Label lblTemperature = new Label();
                        lblTemperature.Text = weaInfo[12];
                        lblTemperature.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
                        Label lblWind = new Label();
                        lblWind.Text = weaInfo[14];
                        lblWind.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
                        PictureBox pbImage = new PictureBox();
                        string strPath = System.Environment.CurrentDirectory + "\\Resource\\weather\\" + weaInfo[15];
                        pbImage.Image = Image.FromFile(strPath);
                        flowWeather1.Controls.Add(lblDate);
                        flowWeather1.Controls.Add(lblTemperature);
                        flowWeather1.Controls.Add(lblWind);
                        flowWeather1.Controls.Add(pbImage);

                        Label lblDate2 = new Label();
                        lblDate2.Text = weaInfo[18];
                        lblDate2.Width = 140;
                        lblDate2.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
                        Label lblTemperature2 = new Label();
                        lblTemperature2.Text = weaInfo[17];
                        lblTemperature2.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
                        Label lblWind2 = new Label();
                        lblWind2.Text = weaInfo[19];
                        lblWind2.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
                        PictureBox pbImage2 = new PictureBox();
                        string strPath2 = System.Environment.CurrentDirectory + "\\Resource\\weather\\" + weaInfo[20];
                        pbImage2.Image = Image.FromFile(strPath2);
                        flowWeather2.Controls.Add(lblDate2);
                        flowWeather2.Controls.Add(lblTemperature2);
                        flowWeather2.Controls.Add(lblWind2);
                        flowWeather2.Controls.Add(pbImage2);

                    }));
                }
                catch (Exception ex)
                {
                    MyLog.LogError("获取IP信息失败！",ex);
                }
                
            }));
            threadWeather.IsBackground = true;
            threadWeather.Start();
            #endregion
        }

        //#region 获取当前外网ip地址
        //private string GetIP()
        //{
        //    string strUrl = "http://www.ip138.com/ip2city.asp"; //获得IP的网址了   
        //    Uri uri = new Uri(strUrl);
        //    WebRequest wr = WebRequest.Create(uri);
        //    Stream s = wr.GetResponse().GetResponseStream();
        //    StreamReader sr = new StreamReader(s, Encoding.Default);
        //    string all = sr.ReadToEnd(); //读取网站的数据   
        //    int i = all.IndexOf("[") + 1;
        //    string tempip = all.Substring(i, 15);
        //    string ip = tempip.Replace("]", "").Replace(" ", "");
        //    return ip;
        //}
        //#endregion
       

        #region 未读邮件信息

        private void QueryEmailStatus()
        {
            IMAP_Client IMAPServer = new IMAP_Client();
            try
            {
                //连接邮件服务器通过传入邮件服务器地址和用于IMAP协议的端口号
                IMAPServer.Connect(@"imap.exmail.sina.com", 143, false);
                string currUserCode = UserInfo.GetInstence().UserCode;
                string emailPassword = string.Empty;
                //登陆邮箱,前者帐号后者密码
                using (var context = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
                {
                    var currUserExt= context.SYS_UserExt.Where(p => p.UserCode == currUserCode).FirstOrDefault();
                    if (currUserExt != null)
                    {
                        emailPassword = Encrypt.TripleDESDecrypting(currUserExt.EmailPassword);
                    }
                }
                if (string.IsNullOrWhiteSpace(emailPassword))
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        this.lblEmailInfo.Text = "邮箱登陆失败！请先在个人设置中设置密码！";
                    }));
                    return;
                }
                IMAPServer.Login(currUserCode + "@ecode.net.cn", emailPassword);
                
                //选中收件箱
                IMAPServer.SelectFolder("INBOX");

                //取出收件箱
                var folder = IMAPServer.SelectedFolder;

                //收件箱邮件总数
                //folder.MessagesCount.ToString();
                //收件箱未读邮件总数
                //folder.RecentMessagesCount.ToString();



                //以下开始取出邮件
                //首先确定取第x到第n封邮件，"1:*"表示第1封到最后一封
                int msgCount=folder.MessagesCount-20;
                if (msgCount <= 0)
                {
                    msgCount = 1;
                }
                var seqSet = LumiSoft.Net.IMAP.IMAP_t_SeqSet.Parse(msgCount.ToString() + ":*");
                //根据数组中的成员决定取出邮件的那些信息
                var imap_t_Fetch_i = new IMAP_t_Fetch_i[]
                       {                    　　
                        new IMAP_t_Fetch_i_Envelope(),//邮件的标题、正文等信息
                        new IMAP_t_Fetch_i_Flags(),//此邮件的标志，应该是已读未读标志
                        new IMAP_t_Fetch_i_InternalDate(),//貌似是收到的日期
                        //new IMAP_t_Fetch_i_Rfc822(),//Rfc822是标准的邮件数据流，可以通过Lumisoft.Net.Mail.Mail_Message对象解析出邮件的所有信息（不确定有没有附件的内容）。
                        new IMAP_t_Fetch_i_Uid()//返回邮件的UID号，UID号是唯一标识邮件的一个号码
                       };
                //创建一个符合lumisoft的回调函数的委托。
                //当调用fetch函数完成时，会自动调用用户自定义的函数，这里是Fetchcallback（我自己起的名字，名字无意义，保证参数是object，LumiSoft . Net . EventArgs<IMAP_r_u> 两个就好
                EventHandler<LumiSoft.Net.EventArgs<IMAP_r_u>> lumisoftHandler = new EventHandler<LumiSoft.Net.EventArgs<IMAP_r_u>>(Fetchcallback);

                //把上边定义好的参数传入fetch函数，就会取出邮件
                //lumisoftHandler指向的函数在每取出一封邮件的时候会被触发一次
                IMAPServer.Fetch(false, seqSet, imap_t_Fetch_i, lumisoftHandler);                
                this.Invoke(new MethodInvoker(delegate
                {
                    this.lblEmailInfo.Text = "";
                    this.linkEmailInfo.Text = "您当前共有" + UnReadEmailCount + "封未读邮件！<<click me>>(只搜索最近20封邮件)";
                    this.linkEmailInfo.Visible = true;
                    this.dgvEmail.DataSource = dtblEmail;
                }));
            }
            catch (Exception ex)
            {
                MyLog.LogError("读取未读邮件失败！",ex);
                if (ex.Message.IndexOf("Invalid login credentials") != -1)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        this.lblEmailInfo.Text = "邮箱登陆失败！请先在个人设置中设置密码！";
                    }));
                }
            }
            finally
            {
                IMAPServer.Disconnect();
            }
        }
        private void linkEmailInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process proc = Process.Start("http://exmail.sina.com.cn/");
        }

        //用来被回调的函数
        public  void Fetchcallback(object sender, LumiSoft.Net.EventArgs<IMAP_r_u> eventArgs)
        {
            try
            {
                if (eventArgs.Value is IMAP_r_u_Fetch)
                {
                    IMAP_r_u_Fetch fetchResp = (IMAP_r_u_Fetch)eventArgs.Value;
                    if (fetchResp.Flags.Flags.Count == 0 && fetchResp.Envelope.From != null)
                    {
                        DataRow dr = dtblEmail.NewRow();
                        dr["Subject"] = fetchResp.Envelope.Subject;
                        dr["ReceiveDate"] = fetchResp.InternalDate.Date;
                        dr["From"] = fetchResp.Envelope.From[0];
                        dtblEmail.Rows.Add(dr);
                        UnReadEmailCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                MyLog.LogError("邮件查询回调函数异常",ex);                
            }            
            
            //var st = x.Rfc822.Stream;
            //st.Position = 0;
            //LumiSoft.Net.Mail.Mail_Message mime = LumiSoft.Net.Mail.Mail_Message.ParseFromStream(st);
            //MessageBox.Show(mime.BodyText);
            //mime里边还有很多对象可以自己挖掘
        }
        
        #endregion

        #region 刷新当前项目信息
        public void RefreshProjectInfo()
        {
            using (BugTraceEntities context = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
            {
                var projectCode = UserInfo.GetInstence().DefaultProjectCode;
                if (!string.IsNullOrWhiteSpace(projectCode))
                {
                    var projectInfo = context.PPM_ProjectInfo.Where(p => p.ProjectCode == projectCode).FirstOrDefault();
                    if (projectInfo != null)
                    {
                        txtCurrProjectName.Text = projectInfo.ProjectName;
                        txtSVN.Text = projectInfo.SVN;
                        txtDevServerInfo.Text = projectInfo.DevServerInfo;
                        txtPubServerInfo.Text = projectInfo.PubServerInfo;
                        txtOtherInfo.Text = projectInfo.OtherInfo;
                    }
                }
            }
        }
        #endregion

        #region 保存项目信息
        private void btnSaveProjectInfo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要更新当前项目信息吗？", "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                using (BugTraceEntities context = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
                {
                    var projectCode = UserInfo.GetInstence().DefaultProjectCode;
                    if (!string.IsNullOrWhiteSpace(projectCode))
                    {
                        var projectInfo = context.PPM_ProjectInfo.Where(p => p.ProjectCode == projectCode).FirstOrDefault();
                        if (projectInfo != null)
                        {
                            projectInfo.ProjectName = txtCurrProjectName.Text;
                            projectInfo.SVN = txtSVN.Text;
                            projectInfo.DevServerInfo = txtDevServerInfo.Text;
                            projectInfo.PubServerInfo = txtPubServerInfo.Text;
                            projectInfo.OtherInfo = txtOtherInfo.Text;
                            projectInfo.UpdateDate = DateTime.Now;
                            projectInfo.UpdatePerson = UserInfo.GetInstence().UserCode;
                            context.SaveChanges();
                            MessageBox.Show("保存项目信息成功！");
                        }
                    }
                }
            }
        }
        #endregion

        
    }
}
