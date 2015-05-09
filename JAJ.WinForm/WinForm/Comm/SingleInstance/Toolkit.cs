using System;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace JAJ.WinForm.Comm
{
    /// <summary>
    /// 指示当前应用程序(激活当前应用程序)
    /// </summary>
    public class Program
    {
        #region 
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        #endregion

        private static Mutex _mutex = null;
        /// <summary>
        /// 指示程序是否已经开始运行
        /// </summary>
        public static Boolean AlreadyRuning
        {
            get
            {
                if (_mutex == null)
                {
                    lock (typeof(Program))
                    {
                        if (_mutex == null)
                        {
                            // ReSharper disable PossibleMultipleWriteAccessInDoubleCheckLocking
                            _mutex = new Mutex(false, Assembly.GetEntryAssembly().FullName);
                            // ReSharper restore PossibleMultipleWriteAccessInDoubleCheckLocking
                        }
                    }
                }
                var r = !_mutex.WaitOne(0, false);
                if (!r)
                {
                    //如果是第一次运行
                    var cf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    var id = Process.GetCurrentProcess().Id.ToString();
                    if (cf.AppSettings.Settings["RunningApp"] == null)
                    {
                        cf.AppSettings.Settings.Add("RunningApp", id);
                    }
                    else
                    {
                        cf.AppSettings.Settings["RunningApp"].Value = id;
                    }
                    cf.Save();
                }
                return r;
            }
        }
        /// <summary>
        /// 释放互斥锁
        /// </summary>
        public static void ReleaseMutex()
        {
            if (_mutex != null)
            {
                _mutex.Close();
            }
        }
        /// <summary>
        /// 激活已经运行的App
        /// </summary>
        public static Boolean ActivateAlreadyRuning(out String message)
        {
            //RunningApp
            var idStr = ConfigurationManager.AppSettings["RunningApp"];
            Int32 id;
            if (Int32.TryParse(idStr, out id))
            {
                try
                {
                    var p = Process.GetProcessById(id);
                    ShowWindowAsync(p.MainWindowHandle, 1);
                    SetForegroundWindow(p.MainWindowHandle);
                }
                catch (Exception exception)
                {
                    message = exception.Message;
                    return false;
                }
            }
            message = null;
            return true;
        }
    }
}
