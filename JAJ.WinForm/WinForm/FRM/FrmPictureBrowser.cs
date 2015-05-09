using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JAJ.WinForm.FRM
{
    public class ImageBroswerInfo
    {
        public int SerialNo{get;set;}
        public string KeyId { get; set; }
        public Image ImageInfo { get; set; }
    }
    public partial class FrmPictureBrowser : Form
    {
        public LinkedList<ImageBroswerInfo> ImageList { get; set; }
        public string currImageKey { get; set; }

        public FrmPictureBrowser()
        {
            InitializeComponent();
        }

        private void FrmPicturebrowser_Load(object sender, EventArgs e)
        {
            Image image =  ImageList.Where(p => p.KeyId == currImageKey).FirstOrDefault().ImageInfo;
            showImage(image);
        }

        #region pictureBox1可拖拽
        Point downPoint; 
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - downPoint.X,
                    this.Location.Y + e.Y - downPoint.Y);
            } 
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            downPoint = new Point(e.X, e.Y);  
        }
        #endregion

        #region 上一张
        private void btnPrev_Click(object sender, EventArgs e)
        {
            int serialNo = ImageList.Where(p => p.KeyId == currImageKey).FirstOrDefault().SerialNo;
            if (serialNo > 1)
            {
                var currentImage = ImageList.Where(p => p.SerialNo == serialNo - 1).FirstOrDefault();
                this.currImageKey = currentImage.KeyId;
                showImage(currentImage.ImageInfo);
            }
            

        }
        #endregion

        #region 下一张
        private void btnNext_Click(object sender, EventArgs e)
        {
            int serialNo = ImageList.Where(p => p.KeyId == currImageKey).FirstOrDefault().SerialNo;
            int count = ImageList.Count();
            if (serialNo < count)
            {
                var currentImage = ImageList.Where(p => p.SerialNo == serialNo + 1).FirstOrDefault();
                this.currImageKey = currentImage.KeyId;
                showImage(currentImage.ImageInfo);
            }
        }
        #endregion

        private void showImage(Image image)
        {
            this.pictureBox1.Image = image;
            this.Width = image.Width;
            this.Height = image.Height + 63;
            this.Top = 5;
            this.Left = 5;
        }
        

        
        
    }
}
