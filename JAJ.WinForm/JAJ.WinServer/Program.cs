using JAJ.WinServer.comm;
using JAJ.WinServer.Comm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JAJ.WinServer
{
    static class Program
    {
        //private static Mutex onlyOne;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {            
            SoftHelper.SoftSingle<ServerForm>();

            //onlyOne = new Mutex(true, Process.GetCurrentProcess().ProcessName);
            //if (!onlyOne.WaitOne(0, false))
            //{
            //    MessageBox.Show("应用已经启动！");
            //    return;
            //}
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
           
            //ServerForm serverForm = new ServerForm();
            ////JAJ.WinForm.Frm.FrmUploadFile mainForm = new Frm.FrmUploadFile();
            ////JAJ.WinForm.Frm.FrmDownloadFile mainForm = new Frm.FrmDownloadFile();
            //SingleInstanceApplicationWrapper wrapper = new SingleInstanceApplicationWrapper(serverForm);
            //wrapper.Run(args);
        }
    }
}
