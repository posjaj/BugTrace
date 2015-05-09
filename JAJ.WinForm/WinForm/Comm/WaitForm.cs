using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace JAJ.WinForm.Comm
{
    public delegate void ExecutedInvokeHeandle();

    /// <summary>
    /// 等待窗口
    /// </summary>
    public class WaitForm
    {
        /// <summary>
        /// 等待窗口对象
        /// </summary>
        static FrmWait mWait;
        /// <summary>
        /// 事件状态通知
        /// </summary>
        static AutoResetEvent mEvents;
        /// <summary>
        /// 显示状态
        /// </summary>
        static bool mShowing = false;
        /// <summary>
        /// 等待状态
        /// </summary>
        static bool mWaiting = false;
        static WaitForm()
        {
            //全局等待信号
            mEvents = new AutoResetEvent(false);
        }
        /// <summary>
        /// 窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void WaitForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (mWaiting || !(sender is FrmWait))
            {
                //信号等待中被异常关闭,或主窗口被关闭时自动通知信号复位
                mEvents.Set();
                return;
            }
            mShowing = false;
            //回收等待窗口
            try
            {
                mWait.Dispose();
            }
            finally
            {
                mWait = null;
            }
        }
        /// <summary>
        /// 显示等待窗口
        /// </summary>
        /// <param name="pComponet">调用对象,可为控件或窗口</param>
        public static void Show(Control pComponet,string message)
        {
            //已显示则返回
            if (mShowing)
                return;
            //创建等待窗口
            mWait = new JAJ.WinForm.FrmWait(message);
            //设置窗口关闭事件
            mWait.FormClosed += new FormClosedEventHandler(WaitForm_FormClosed);
            //启动显示线程
            Thread tmpThread = new Thread(show);
            tmpThread.Start(pComponet);
        }
        /// <summary>
        /// 关闭等待窗口
        /// </summary>
        public static void Close()
        {

            if (mShowing)
                //如果显示中则设置关闭信号
                mEvents.Set();
            //修改等待状态
            mWaiting = false;
        }
        /// <summary>
        /// 显示窗口过程
        /// </summary>
        /// <param name="pComponet"></param>
        static void show(object pComponet)
        {
            if (pComponet != null &&
                pComponet is Control)
            {
                //设置显示状态
                mShowing = true;
                //当调用对象为Win控件时
                (pComponet as Control).BeginInvoke(new ExecutedInvokeHeandle(delegate()
                {
                    //进行异步调用
                    if (pComponet != null &&
                        pComponet is Control)
                    {
                        //显示等待窗口
                        mWait.Show((pComponet as Control).FindForm());
                        //设置父级窗口关闭事件
                        (pComponet as Control).FindForm().FormClosed += new FormClosedEventHandler(WaitForm_FormClosed);
                        //激活父级窗口,
                        (pComponet as Control).FindForm().Activate();
                    }
                    else
                    {
                        //如查询不到父级窗口设置顶层显示,此处可用GetDesktop的API来获取桌面窗口,并设置为父级窗口
                        mWait.TopMost = true;
                        //显示等待窗口
                        mWait.Show();
                    }
                }));
                //设置等待信号
                mWaiting = true;
                mEvents.WaitOne();
                //等待结束
                mWaiting = false;
                (pComponet as Control).BeginInvoke(new ExecutedInvokeHeandle(delegate()
                {
                    //关闭窗口
                    mWait.Close();
                }));

            }
        }
    }
}
