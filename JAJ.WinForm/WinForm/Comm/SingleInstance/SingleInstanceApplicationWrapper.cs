using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace JAJ.WinForm.Comm
{
    public class SingleInstanceApplicationWrapper : WindowsFormsApplicationBase
    {
        private readonly Form mainForm;

        public SingleInstanceApplicationWrapper(Form form)
        {
            mainForm = form;
#if DEBUG
            this.IsSingleInstance = true;
#endif
#if RELEASE
            this.IsSingleInstance = true;
#endif
        }

        protected override bool OnStartup(StartupEventArgs e)
        {
            
            Application.Run(mainForm);
            return false;
        }

        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs e)
        {
            // 这里可以把本次使用的参数传给之前的实例，本人在一个WPF 屏幕键盘项目里传送了键盘显示方式（数字、英文、手写）参数
            //e.BringToForeground = true;
            //if (e.CommandLine.Count > 0)
            //{
            //  app.DealArgs(e.CommandLine.ToArray());
            //}
        }
    }
}
