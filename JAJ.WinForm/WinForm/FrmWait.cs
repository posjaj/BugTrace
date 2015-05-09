using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JAJ.WinForm
{
    public delegate void ExecutedInvokeHeandle();

    public partial class FrmWait : Form
    {
        public FrmWait(string message)
        {            
            InitializeComponent();
            this.lblInfo.Text = message;
        }
    }
}
