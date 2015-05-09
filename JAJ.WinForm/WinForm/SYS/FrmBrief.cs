using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JAJ.WinForm.SYS
{
    public partial class FrmBrief : Form
    {
        public FrmBrief()
        {
            InitializeComponent();
        }

        private void FrmBrief_Load(object sender, EventArgs e)
        {
            using (BugTraceEntities context = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
            {
                var versonList = context.SYS_Version.ToList();
                string memo = string.Empty;
                foreach (var item in versonList.OrderByDescending(p=>p.VersionNo))
                {
                    if (!string.IsNullOrWhiteSpace(memo))
                    {
                        memo += "\r\n";
                    }
                    string publishDate = "未发布";
                    if (item.PublishDate!=null)
                    { 
                        publishDate=item.PublishDate.Value.ToString("yyyy-MM-dd");
                    }
                    memo += "版本号：" + item.VersionNo + "  发布日期：" + publishDate+"\r\n";                   
                    foreach (var dtl in item.Memo.Replace('；',';').Split(';'))
                    {
                        memo += "\t"+dtl + "\r\n";
                    }
                }
                this.txtMemo.Text = memo;
            }
        }
    }
}
