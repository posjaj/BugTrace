using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace JAJ.WinServer
{
    public partial class ServerForm : Form
    {
        private static string connectString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        private SqlDependency dep;
        private static int clientCount=0;
        private static DataTable dtblUserList;
        
        private static readonly object InstObj = new object();
        private ServiceHost _hostMessage = null;
        private ServiceHost _hostFile = null; 
        public ServerForm()
        {
            InitializeComponent();
        }
        private void ServerForm_FormLoad(object sender, EventArgs e)
        {
            try
            {
                _hostFile = new ServiceHost(typeof(JAJ.WinServer.FileService));
                _hostFile.Open();
                this.lblWCFStatus.Text = "文件服务正常启动\r\n\r\n";
            }
            catch (Exception ex)
            {
                MyLog.LogError("文件服务启动失败！", ex);
                this.lblWCFStatus.Text = "文件服务启动失败！！！\r\n\r\n";
            }

            try
            {
                _hostMessage = new ServiceHost(typeof(JAJ.WinServer.MessageService));
                _hostMessage.Open();
                this.lblWCFStatus.Text += "消息服务正常启动\r\n";
            }
            catch (Exception ex)
            {
                MyLog.LogError("文件服务启动失败！", ex);
                throw ex;
            }
            //客户端心跳监听
            MessageService.StartListenClients();

            //启动一个与Sql Server进行通信的客户端进程
            SqlDependency.Start(connectString);
            SqlDenpendencyLisener();

            #region 客户端列表展示
            string cmdText = "SELECT * from sys_user  ";
            dtblUserList = SqlHelper.FillDataSet(connectString, CommandType.Text, cmdText).Tables[0];
            Thread thread = new Thread(new ThreadStart(delegate   ///监听所有客户端连接，并添加到ListBox控件里
            {
                while (true)
                {
                    if (MessageService.ClientList != null || MessageService.ClientList.Count > 0)
                    {
                        this.Invoke(new MethodInvoker(delegate { this.lbClient.Items.Clear(); }));
                        foreach (var c in MessageService.ClientList.OrderBy(p => p.UserCode))
                        {
                            this.Invoke(new MethodInvoker(delegate
                            {
                                var userInfo = dtblUserList.AsEnumerable().Where(p => p.Field<string>("UserCode") == c.UserCode).FirstOrDefault();
                                if (userInfo != null)
                                {
                                    this.lbClient.Items.Add(c.UserCode + "(" + userInfo.Field<string>("UserName") + ")");
                                }
                                else
                                {
                                    this.lbClient.Items.Add(c.UserCode);
                                }
                            }));
                        }
                    }
                    if (MessageService.ClientList != null && MessageService.ClientList.Count != clientCount)
                    {//有客户端登陆，则发送消息
                        SendMessageToClient();
                        clientCount = MessageService.ClientList.Count;
                    }
                    Thread.Sleep(1000 * 1);
                }
            }));
            thread.IsBackground = true;
            thread.Start();
            #endregion

        }
        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_hostFile != null)
                {
                    _hostFile.Close();
                    IDisposable host = _hostFile as IDisposable;
                    host.Dispose();
                }
                if (_hostMessage != null)
                {
                    _hostMessage.Close();
                    IDisposable host = _hostMessage as IDisposable;
                    host.Dispose();
                }
                //终止与Sql Server通信
                SqlDependency.Stop(connectString);
            }
            catch (Exception ex)
            {
                MyLog.LogError("FormClosing", ex);               
            }
        }

        #region SqlDenpendency监听
        private void SqlDenpendencyLisener()
        {
            try
            {
                string sql = "SELECT a.ID,a.MessageTo,a.MsgContent FROM dbo.PPM_MessageRecord a WHERE a.NotifyFlag=0";
                DataTable dt = new DataTable();
                using (SqlConnection cn = new SqlConnection(connectString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        cn.Open();
                        //SqlCommand对象包含一个Notification属性，可以将SqlCommand对象传递给SqlDependency对象的构造函数，以设置该属性。
                        dep = new SqlDependency(cmd);
                        //当有DML操作时，onChange事件会接收来自Sql Server通过sq_DispatcherProc存储过程发送给应用程序的消息。
                        dep.OnChange += new OnChangeEventHandler(dep_OnChange);
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            dt.Load(rdr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MyLog.LogError("SqlDenpendencyLisener方法报错", ex);
            }
            
        }
        #endregion

        #region SqlDependency的onChange事件处理

        void dep_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info == SqlNotificationInfo.Invalid)
            {
                MessageBox.Show("Invalid Statement");
                return;
            }
            SqlDenpendencyLisener();

            //MessageBox.Show(e.ToString());
            SendMessageToClient();
        }
        void SendMessageToClient()
        {
            String cmdText = "SELECT a.ID,a.MessageTo,a.MsgContent FROM dbo.PPM_MessageRecord a WHERE a.NotifyFlag=0";
            DataSet ds = null;
            try
            {
                ds = SqlHelper.FillDataSet(connectString, CommandType.Text, cmdText);
            }
            catch (Exception ex)
            {
                MyLog.LogError("SendMessageToClient查询消息队列失败！", ex);
                return;
            }
            
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    SqlTransaction sqltran=null;
                    try
                    {
                        conn.Open();
                        sqltran = conn.BeginTransaction();
                        SqlParameter param;
                        cmdText = "UPDATE dbo.PPM_MessageRecord SET NotifyFlag=1 WHERE ID=@ID";
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {                            
                            string messageTo = item["MessageTo"].ToString();
                            string msgContent = item["MsgContent"].ToString();
                            var clientList = JAJ.WinServer.MessageService.ClientList;
                            var client = clientList.Where(p => p.UserCode == messageTo);
                            if (client != null && client.Count() > 0)
                            {
                                client.FirstOrDefault().Callback.SendMessage(msgContent);
                                param = new SqlParameter("@ID", SqlDbType.Int, 4);
                                param.Value = Convert.ToInt32(item["ID"]);
                                SqlHelper.ExecuteNonQuery(sqltran, CommandType.Text, cmdText, param);                               
                            }
                        }
                        sqltran.Commit();
                    }
                    catch (Exception ex)
                    {
                        sqltran.Rollback();
                        MyLog.LogError("SendMessageToClient消息发送失败！", ex);
                    }
                    finally
                    {
                        sqltran.Dispose();
                        conn.Close();
                    }
                }
            }
        }
        #endregion

        #region 服务端广播消息
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            var clientList = JAJ.WinServer.MessageService.ClientList;
            if (clientList == null || clientList.Count == 0)
            {
                return;
            }
            lock (InstObj)
            {
                if (this.lbClient.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < this.lbClient.SelectedItems.Count; i++)
                    {
                        var userId = this.lbClient.SelectedItems[i].ToString();
                        var cleint = clientList.Where(p => p.UserCode == userId);
                        if (cleint != null && cleint.Count() > 0)
                        {
                            foreach (var item in cleint)
                            {
                                item.Callback.SendMessage(this.txtMessage.Text);
                            }
                        }
                    }
                }
                else
                {
                    foreach (var item in clientList)
                    {
                        item.Callback.SendMessage(this.txtMessage.Text);
                    }
                }
            }
        }
        #endregion
    }
}
