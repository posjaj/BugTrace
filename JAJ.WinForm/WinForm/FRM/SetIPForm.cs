using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IPProvider;
using System.Configuration;

namespace JAJ.WinForm.Frm
{
    public partial class SetIPForm : Form
    {
        public SetIPForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.txtIP.Text = ConfigurationManager.AppSettings["ip"];
            this.txtGatway.Text = ConfigurationManager.AppSettings["gatway"];
            this.txtDNS1.Text = ConfigurationManager.AppSettings["dns1"];
            this.txtDNS2.Text = ConfigurationManager.AppSettings["dns2"];
            //<add key="ip" value="192.168.0.151" />
            //<add key="gatway" value="192.168.0.3" />
            //<add key="dns1" value="202.102.134.68" />
            //<add key="dns2" value="202.102.128.68" />
        }

        private void rbtnAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnAuto.Checked)
            {
                gboxIPInfo.Enabled = false;
            }
        }

        private void rbtnSet_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnSet.Checked)
            {
                gboxIPInfo.Enabled = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rbtnAuto.Checked)
            {//设置自动获取ip地址
                WMIForIPSet.EnableDHCP();
            }
            else
            {
                string[] ip = { txtIP.Text };
                string[] submask = { "255.255.255.0" };
                string[] gatway = { txtGatway.Text };
                string[] dns = { txtDNS1.Text, txtDNS2.Text };
                WMIForIPSet.SetIPAddress(ip, submask, gatway, dns);
            }
            MessageBox.Show("设置成功！");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["ip"].Value = txtIP.Text;
            config.AppSettings.Settings["gatway"].Value = txtGatway.Text;
            config.AppSettings.Settings["dns1"].Value = txtDNS1.Text;
            config.AppSettings.Settings["dns2"].Value = txtDNS2.Text;
            config.Save();
            MessageBox.Show("保存成功！");
        }
    }
}
