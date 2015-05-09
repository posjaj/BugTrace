using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JAJ.WinForm.Comm
{
    public class WcfMessageEventArgs : EventArgs
    {
        public readonly string ServerMessage;
        public WcfMessageEventArgs(string message)
        {
            this.ServerMessage = message;
        }
    }
    public class WCFClient : WcfSvc.IMessageServiceCallback
    {
        public delegate void WcfMessageEventHandler(Object sender, WcfMessageEventArgs e);
        public event WcfMessageEventHandler WcfMessageEvent; 
        public void SendMessage(string message)
        {
            WcfMessageEventArgs e = new WcfMessageEventArgs(message);
            if (WcfMessageEvent != null)
            {
                WcfMessageEvent(this,e);
            }
        }
    }
}
