using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JAJ.WinServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class MessageService : IMessageService, IDisposable
    {
        public class ClientInfo
        {            
            public string UserCode { get; set; }
            public string ClientHostName { get; set; }
            public string SessionId { get; set; }
            public DateTime NowdateTime { get; set; }
            public ICallback Callback { get; set; }

        }
        public static List<ClientInfo> ClientList = null; //记录客户端列表
        private static readonly object InstObj = new object();//单一实例
        public MessageService()
        {
            ClientList = new List<ClientInfo>();
        }

        public void Login(string id)
        {
            try
            {
                var callback = OperationContext.Current.GetCallbackChannel<ICallback>();
                string sessionId = OperationContext.Current.SessionId;//获取当前机器Sessionid
                string ClientHostName = OperationContext.Current.Channel.RemoteAddress.Uri.Host;//获取当前机器名称
                ClientInfo clientInfo = new ClientInfo();
                clientInfo.UserCode = id;
                clientInfo.SessionId = sessionId;
                clientInfo.ClientHostName = ClientHostName;
                clientInfo.NowdateTime = DateTime.Now;
                clientInfo.Callback = callback;
                OperationContext.Current.Channel.Closing += new EventHandler(Channel_Closing);
                OperationContext.Current.Channel.Faulted += new EventHandler(Channel_Closing);
                lock (InstObj)
                {
                    var hasLogin = ClientList.Where(p => p.UserCode == id);
                    if (hasLogin != null && hasLogin.Count() > 0)
                    {
                        Thread thread = new Thread(ReruenToClient);
                        thread.Start(callback);
                    }
                    else
                    {
                        ClientList.Add(clientInfo);
                    }
                    MyLog.LogMessage(id + "用户登录");
                }
            }
            catch (Exception ex)
            {
                MyLog.LogError("Login方法报错", ex);
            }
            
        }
        /// <summary>
        /// 如果账号已经登录，返回客户端一个提示
        /// </summary>
        /// <param name="client"></param>
        void ReruenToClient(object client)
        {
            try
            {
                ((ICallback)client).SendMessage("该账号已经登录");
            }
            catch (Exception ex)
            {
                MyLog.LogError("ReruenToClient方法报错", ex);
            }
           
        }
        void Channel_Closing(object sender, EventArgs e)
        {
            lock (InstObj)
            {
                if (ClientList != null && ClientList.Count > 0)
                {
                    //ClientList.RemoveAll(p => p.Callback == (ICallback)sender);
                    //MyLog.LogMessage("用户退出了程序");
                    foreach (var item in ClientList)
                    {
                        if (item.Callback == (ICallback)sender)
                        {
                            ClientList.RemoveAll(p => p.UserCode == item.UserCode);
                            //ClientList.Remove(ClientList.Find(p => p.UserCode == item.UserCode));
                            MyLog.LogMessage(item.UserCode + "用户退出系统Closing");
                            break;
                        }
                    }
                }               
            }
        }
        public void Dispose()
        {
            ClientList.Clear();
        }


        public void Update(string id)
        {
            try
            {
                ICallback callback = OperationContext.Current.GetCallbackChannel<ICallback>();
                string sessionId = OperationContext.Current.SessionId;//获取当前机器Sessionid
                string ClientHostName = OperationContext.Current.Channel.RemoteAddress.Uri.Host;//获取当前机器名称
                ClientInfo clientInfo = new ClientInfo();
                clientInfo.UserCode = id;
                clientInfo.SessionId = sessionId;
                clientInfo.ClientHostName = ClientHostName;
                clientInfo.NowdateTime = DateTime.Now;
                clientInfo.Callback = callback;
                OperationContext.Current.Channel.Closing += new EventHandler(Channel_Closing);
                OperationContext.Current.Channel.Faulted += new EventHandler(Channel_Closing);
                lock (InstObj)
                {
                    var hasLogin = ClientList.Where(p => p.UserCode == id);
                    if (hasLogin != null && hasLogin.Count() > 0)
                    {
                        ClientList.RemoveAll(p => p.UserCode == id);
                    }
                    ClientList.Add(clientInfo);
                    //MyLog.LogMessage(id+"用户保持连接");
                }
            }
            catch (Exception ex)
            {
                MyLog.LogError("Update方法报错", ex);
            }
            
        }

        public void Leave(string id)
        {
            var hasLogin = ClientList.Where(p => p.UserCode == id);
            if (hasLogin != null && hasLogin.Count() > 0)
            {
                ClientList.RemoveAll(p => p.UserCode == id);
                MyLog.LogMessage(id + "用户退出系统Leave");
            }  
        }

        static System.Timers.Timer timer1;
        public static void StartListenClients()
        {
            timer1 = new System.Timers.Timer();
            timer1.Interval = 500;
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(time_EventArgs);
            timer1.Start();
        }

        static void time_EventArgs(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock (InstObj)
            {
                foreach (var item in ClientList)
                {
                    if (item.NowdateTime.AddSeconds(5) < DateTime.Now)
                    {
                        ClientList.RemoveAll(p => p.UserCode == item.UserCode);
                        MyLog.LogMessage(item.UserCode+"用户退出系统Timeout");
                        break;
                    }
                }
            }
        }
    }  
}
