using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JAJ.WinForm.FRM
{
    public partial class FrmChangeMoney : Form
    {
        public FrmChangeMoney()
        {
            InitializeComponent();
        }

        private void txtSmallMoney_TextChanged(object sender, EventArgs e)
        {
            string bmoney = txtSmallMoney.Text;
            decimal money = 0;
            decimal.TryParse(bmoney, out money);
            lblBigMoney.Text = RMBToChinese.getChinese(money);
        }
    }
}
