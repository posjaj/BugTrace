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
    public partial class TestFrmDownloadFile : Form
    {
        public TestFrmDownloadFile()
        {
            InitializeComponent();
        }

        private FileTransferSvc.FileServiceClient _client;
        private const int BufferLen = 4096;

        private void FrmDownloadFile_Load(object sender, EventArgs e)
        {
            _client = new FileTransferSvc.FileServiceClient();
        }

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            string file = @"C:\Users\jiaoanjian\Desktop\java文档\ERPV4基础平台调整需求说明书-V0.5.doc";
            
            var downloadFolder = System.Environment.CurrentDirectory + "\\DownloadFile";
            string fileName = Path.GetFileName(file);
            Stream sourceStream = _client.DowndloadFile(file);
            FileStream targetStream = null;
            if (!sourceStream.CanRead)
            {
                throw new Exception("Invalid Stream!");
            }
            if (!Directory.Exists(downloadFolder))
            {
                Directory.CreateDirectory(downloadFolder);
            }
            string filePath = Path.Combine(downloadFolder, fileName);
            using (targetStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {                  
                byte[] buffer = new byte[BufferLen];
                int count = 0;
                
                while ((count = sourceStream.Read(buffer, 0, BufferLen)) > 0)
                {
                    targetStream.Write(buffer, 0, count);
                    //if ((int)sourceStream.Length - (int)targetStream.Length > 100000)
                    //{
                        
                    //}
                }               
                targetStream.Close();
                sourceStream.Close();
            }
        }

       
    }
}
