using JAJ.WinForm.Comm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using JAJ.WinForm.FRM;
using JAJ.WinForm.PPM;



namespace JAJ.WinForm
{
    static class Program
    {
        private static Mutex onlyOne;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {            
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                //PPMProjectPlanList form = new PPMProjectPlanList();
                //Application.Run(form);
                //return;

                var process = Process.GetCurrentProcess();                
                onlyOne = new Mutex(true, process.ProcessName);
                if (!onlyOne.WaitOne(0, false))
                {
                    MessageBox.Show("BugTrace已经启动");
                    return;                  
                }
               
                LoginForm loginForm = new LoginForm();                               
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    MainForm mainForm = new MainForm();
                    SingleInstanceApplicationWrapper wrapper = new SingleInstanceApplicationWrapper(mainForm);
                    wrapper.Run(args); 
                }
                else
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统登陆", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }

            #region Toolkit运行单例程序
            //if (!JAJ.Toolkit.Program.AlreadyRuning)
            //{
            //    Application.Run(new Form1());
            //    JAJ.Toolkit.Program.ReleaseMutex();
            //}
            //else
            //{
            //    String msg;
            //    if (!JAJ.Toolkit.Program.ActivateAlreadyRuning(out msg))
            //    {
            //        MessageBox.Show(msg);
            //    }
            //}
            #endregion
        }
    }
}
