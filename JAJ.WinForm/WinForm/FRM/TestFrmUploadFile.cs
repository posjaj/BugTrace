using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace JAJ.WinForm.FRM
{
    public partial class TestFrmUploadFile : Form
    {
        public TestFrmUploadFile()
        {
            InitializeComponent();
        }
        private FileTransferSvc.FileServiceClient _client;
        private Thread _uploadWatchThread;
        private bool _uploadCompleted;
        private Action<int, int> _updateLabel;
        private Action<int> _updateProcessBar;

        private void FrmUploadFile_Load(object sender, EventArgs e)
        {
            _client = new FileTransferSvc.FileServiceClient();
            _uploadCompleted = false;
            _updateLabel = (curr, total) =>
            {
                lblInfo.Text = string.Format("{0}KB/{1}KB", curr / 1000, total / 1000);
            };
            _updateProcessBar = (process) => { progressBar1.Value = process; };  
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            var filepath = textBox1.Text;
            if (string.IsNullOrEmpty(filepath) || !File.Exists(filepath))
                return;
            _uploadCompleted = false;
            FileTransferSvc.TransferFileData uploadData = new FileTransferSvc.TransferFileData();
            uploadData.FileName = Path.GetFileName(filepath);
            uploadData.FileData = File.OpenRead(filepath);
            uploadData.FileSize = uploadData.FileData.Length;
            uploadData.FileUniqueID = Guid.NewGuid().ToString();
            uploadData.FileType = "test";
            uploadData.oldFileName = "";
            _client.UploadFileAsync(uploadData.FileName, uploadData.FileSize, uploadData.FileType, uploadData.FileUniqueID, uploadData.oldFileName, uploadData.FileData);
            _client.UploadFileCompleted += _client_UploadFileCompleted;
            _uploadWatchThread = new Thread(UpdateFileUploadInfo);
            _uploadWatchThread.Start(uploadData);
            btnBrowser.Enabled = false;
            btnUpload.Enabled = false; 
        }

        void UpdateFileUploadInfo(object obj)
        {
            var uploadData = obj as FileTransferSvc.TransferFileData;
            var uploadSize = _client.GetUploadFileInfo(uploadData.FileUniqueID);
            var totalSize = uploadData.FileSize;
            while (uploadSize < totalSize)
            {
                double process = ((double)uploadSize / (double)uploadData.FileSize) * 100;
                progressBar1.Invoke(_updateProcessBar, (int)process);
                lblInfo.Invoke(_updateLabel, uploadSize, totalSize);
                Thread.Sleep(500);
                if (_uploadCompleted)
                {
                    progressBar1.Invoke(_updateProcessBar, progressBar1.Maximum);
                    lblInfo.Invoke(_updateLabel, totalSize, totalSize);
                    break;
                }
                else
                {
                    uploadSize = _client.GetUploadFileInfo(uploadData.FileUniqueID);
                }
            }
        } 

        void _client_UploadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            _uploadCompleted = true;
            btnBrowser.Enabled = true;
            btnUpload.Enabled = true; 
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                textBox1.Text = openFileDialog1.FileName; 
        }

        private void FrmUploadFile_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_uploadWatchThread.Join(500))
            {
                try
                {
                    _uploadWatchThread.Abort();
                }
                catch
                { }
            }
        }

        

        

       
    }
}
