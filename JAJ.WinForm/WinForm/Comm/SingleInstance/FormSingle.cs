using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Runtime.InteropServices;

public static class FormSingle
{
    

    private static Dictionary<string,Form> formList= new Dictionary<string,Form>();
    private static object obj = new object();
    public static Form GetForm(Type type)
    {
        string fullName = type.Namespace + "." + type.Name;
        var formInfo = formList.Where(p => p.Key == fullName);
        if (formInfo == null || formInfo.Count() == 0)
        {
            lock (obj)
            {
                return CreateNewForm(type);
            }
        }
        else 
        {
            return formInfo.FirstOrDefault().Value;
        }       
    }
    public static bool IsExist(Type type)
    {
        string fullName = type.Namespace + "." + type.Name;
        var formInfo = formList.Where(p => p.Key == fullName);
        if (formInfo != null && formInfo.Count()>0)
        {
            return true;
        }
        return false;
    }
    /// <summary>释放对象
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="args"></param>
    private static void Display(object obj, FormClosedEventArgs args)
    {
        string fullName = obj.GetType().Namespace + "." + obj.GetType().Name;
        formList.Remove(fullName);       
    }
    /// <summary>创建新窗体
    /// </summary>
    private static Form CreateNewForm(Type type)
    {
        //form = new T();
        var form = Activator.CreateInstance(type) as Form;
        form.FormClosed += new FormClosedEventHandler(Display);//订阅窗体的关闭事件，释放对象
        string fullName = type.Namespace + "." + type.Name;
        formList.Add(fullName, form);
        return form;
    }
}


public static class FromHelper
{
    [DllImport("user32")]
    public static extern int SetParent(int hWndChild, int hWndNewParent);

    public static void ShowNormal(this Form form)
    {
        form.ShowInTaskbar = false;
        form.WindowState = FormWindowState.Normal;
        form.Show();
        form.Activate();
    }
    public static void ShowNormal(this Form form, Form mdiForm,string args=null)
    {
        form.MdiParent = mdiForm;
        //form.ShowInTaskbar = false;
        form.WindowState = FormWindowState.Normal;
        form.Tag = args;
        form.Show();
        form.Activate();        
        //SetParent((int)form.Handle, (int)mdiForm.Handle);       
        //form.BringToFront();
    }
}
