using JAJ.WinForm.Comm;
using JAJ.WinForm.FRM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace JAJ.WinForm.PPM
{
    public partial class ProblemTraceForm : Form
    {
        #region 私有属性
        private int _problemTraceID;
        private string _attachmentUniqueID;
        private bool _attachmentFlag = false;
        private string _oldFileName;
        private FrmWait wait = null;
        #endregion

        public ProblemTraceForm()
        {
            InitializeComponent();
        }

        private void ProblemTraceForm_Load(object sender, EventArgs e)
        {
            string defaultProjectCode = UserInfo.GetInstence().DefaultProjectCode;
            using (BugTraceEntities entiy = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
            {
                //var project = entiy.PPM_ProjectInfo.Where(p => p.ProjectCode == defaultProjectCode).FirstOrDefault();
                //if (project != null)
                //{
                //    if (!string.IsNullOrWhiteSpace(project.UsedCustom))
                //    {
                //        string projectUse = project.UsedCustom.Replace("，", ",");//实施客户
                //        foreach (var item in projectUse.Split(','))
                //        {
                //            this.cbxProjectUse.Items.Add(item);
                //        }
                //    }                    
                //}
                var query = (from c in entiy.PPM_ProjectTeam
                             join d in entiy.SYS_User
                             on c.TeamMember equals d.UserCode
                             where c.ProjectCode == defaultProjectCode && c.Status == 1
                             select new
                             {
                                 UserCode=c.TeamMember,
                                 UserName=d.UserName
                             }).ToList();
                List<KeyValuePair<string, string>> kvp = new List<KeyValuePair<string, string>>();
                List<KeyValuePair<string, string>> kvp2 = new List<KeyValuePair<string, string>>();
                foreach (var item in query)
                {
                    kvp.Add(new KeyValuePair<string, string>(item.UserCode, item.UserName));
                    kvp2.Add(new KeyValuePair<string, string>(item.UserCode, item.UserName));
                }
                this.cbxFindPerson.DataSource = kvp;
                this.cbxFindPerson.DisplayMember = "value";
                this.cbxFindPerson.ValueMember = "key";                

                this.cbxDealPerson.DisplayMember = "value";
                this.cbxDealPerson.ValueMember = "key";
                this.cbxDealPerson.DataSource = kvp2;
            }
        }

        #region 窗口激活
        private void ProblemTraceForm_Activated(object sender, EventArgs e)
        {
            int rowID = FormArgument.ProblemTraceID;
            if (rowID != -1)
            {
                using (BugTraceEntities zEntity = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
                {
                    //var problemList = zEntity.PPM_ProblemTrace.Where(p => p.ID == rowID);
                    var problemList = (from c in zEntity.PPM_ProblemTrace
                                       join d in zEntity.SYS_User
                                       on c.AttachmentCreateBy equals d.UserCode
                                       into g
                                       where c.ID == rowID
                                       from item in g.DefaultIfEmpty()
                                       select new
                                       {
                                           c.ID,
                                           c.Module,
                                           c.ProjectUse,
                                           c.FindPersonCode,
                                           c.Problem,
                                           c.DealPersonCode,
                                           c.BeginDealDate,
                                           c.EndDealDate,
                                           c.Solution,
                                           c.Status,
                                           c.ProblemType,
                                           c.AttachmentUniqueID,
                                           c.AttachmentName,
                                           c.AttachmentCreateBy,
                                           c.PPM_ProblemTraceImage,
                                           c.AttachmentCreateDate,
                                           AttachmentCreateByName = item.UserName,
                                           c.IsRepeat
                                       }).DefaultIfEmpty();
                    var problemTrace = problemList.FirstOrDefault();
                    this._problemTraceID = problemTrace.ID;
                    this.txtModule.Text = problemTrace.Module;
                    //this.cbxProjectUse.Text = problemTrace.ProjectUse;
                    if (problemTrace.BeginDealDate != null)
                    {
                        this.dtBeginDealDate.ValueX = problemTrace.BeginDealDate;
                    }
                    else
                    {
                        this.dtBeginDealDate.ValueX = null;
                    }
                    this.cbxFindPerson.SelectedValue = problemTrace.FindPersonCode;
                    this.txtProblem.Text = problemTrace.Problem;
                    this.cbxDealPerson.SelectedValue = problemTrace.DealPersonCode;
                    //this.dtEndDealDate.Text = problemTrace.EndDealDate.ToString();
                    if (problemTrace.EndDealDate != null)
                    {
                        this.dtEndDealDate.ValueX = problemTrace.EndDealDate;
                    }
                    else
                    {
                        this.dtEndDealDate.ValueX = null;
                    }
                    this.txtSolution.Text = problemTrace.Solution;
                    this.cbxStatus.Text = problemTrace.Status;
                    this.cbxProblemType.Text = problemTrace.ProblemType;
                    this._attachmentUniqueID = problemTrace.AttachmentUniqueID;
                    this._oldFileName = problemTrace.AttachmentUniqueID + problemTrace.AttachmentName;
                    this.linkAttachment.Text = problemTrace.AttachmentName;
                    if (!string.IsNullOrWhiteSpace(problemTrace.AttachmentCreateByName))
                    {
                        this.lblAttachmentCreateBy.Text = "（上传人：" + problemTrace.AttachmentCreateByName + "，上传时间：" + (problemTrace.AttachmentCreateDate==null?"未记录":problemTrace.AttachmentCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss")) + "）";
                    }
                    else
                    {
                        this.lblAttachmentCreateBy.Text = "";
                    }
                    this.cbxIsRepeat.Text = problemTrace.IsRepeat;
                    flowLayoutPanel1.Controls.Clear();
                    foreach (var item in problemTrace.PPM_ProblemTraceImage.OrderBy(p => p.SerialNo))
                    {
                        genarateImageList(item.ID, ByteToImage(item.ImageFile));
                    }
                    
                }
            }
            else
            {
                UserInfo userInfo = UserInfo.GetInstence();
                this._problemTraceID = rowID;
                this.txtModule.Text = "";
                this.cbxFindPerson.SelectedValue = userInfo.UserCode;
                //this.cbxProjectUse.Text = "";
                this.dtBeginDealDate.Text = "";
                this.txtProblem.Text = "";
                this.cbxDealPerson.Text = "";
                this.dtEndDealDate.Text = "";
                this.txtSolution.Text = "";
                this.cbxStatus.Text = "未开始";
                this._attachmentUniqueID = "";
                this._oldFileName = "";
                this.linkAttachment.Text = "";
                this.lblAttachmentCreateBy.Text = "";
                this.cbxIsRepeat.Text = "";
                flowLayoutPanel1.Controls.Clear();
            }
        }
        #endregion

        #region 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region 验证
            if (string.IsNullOrWhiteSpace(this.txtModule.Text))
            {
                MessageBox.Show("功能模块不能为空","提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtModule.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(this.cbxProblemType.Text))
            {
                MessageBox.Show("类型不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cbxProblemType.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(this.cbxFindPerson.Text))
            {
                MessageBox.Show("提出人不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cbxFindPerson.Focus();
                return;
            }
            //if (string.IsNullOrWhiteSpace(this.cbxProjectUse.Text))
            //{
            //    //MessageBox.Show("实施客户不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //this.cbxProjectUse.Focus();
            //    //return;
            //}
            if (string.IsNullOrWhiteSpace(this.txtProblem.Text))
            {
                MessageBox.Show("问题描述不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtProblem.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(this.cbxDealPerson.Text))
            {
                MessageBox.Show("执行人不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cbxDealPerson.Focus();
                return;
            }
            if (this.cbxStatus.Text == "已提交未审核" || this.cbxStatus.Text == "完成" || this.cbxStatus.Text == "发版关闭")
            {
                if (string.IsNullOrWhiteSpace(this.dtEndDealDate.Text))
                {
                    MessageBox.Show("完成日期不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.dtEndDealDate.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(this.txtSolution.Text))
                {
                    MessageBox.Show("解决方案不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtSolution.Focus();
                    return;
                }
            }
            if (string.IsNullOrWhiteSpace(this.cbxStatus.Text))
            {
                MessageBox.Show("状态不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cbxStatus.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(this.cbxIsRepeat.Text))
            {
                MessageBox.Show("是否重复问题不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cbxIsRepeat.Focus();
                return;
            }
            
            #endregion

            if (this._attachmentFlag)
            {
                UploadAttachment();//上传附件结束后调用SaveProblemTrace
            }
            else
            {
                SaveProblemTrace(false);
            }
            
        }
        private void UploadAttachment()
        {
            string fileServiceUrl = string.Empty;
            using (BugTraceEntities zentity = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
            {
                var currVersion = zentity.SYS_Version.Where(p => p.IsDefault == 1).FirstOrDefault();
                fileServiceUrl = currVersion.FileServiceUrlPort;
            }           
            try
            {                
                string filepath = this.txtAttachment.Text;
                EndpointAddress address = new EndpointAddress("http://" + fileServiceUrl + "/JAJ.WinServer/FileService");
                FileTransferSvc.FileServiceClient _client = new FileTransferSvc.FileServiceClient("BasicHttpBinding_IFileService", address);
                FileTransferSvc.TransferFileData uploadData = new FileTransferSvc.TransferFileData();
                uploadData.FileName = Path.GetFileName(filepath);
                uploadData.FileData = File.OpenRead(filepath);
                uploadData.FileSize = (int)uploadData.FileData.Length;
                uploadData.FileUniqueID = this._attachmentUniqueID;
                uploadData.FileType = "PPM_ProblemTrace";
                uploadData.oldFileName = this._oldFileName;
                wait = new FrmWait("正 在 上 传 请 稍 候");               
                wait.Show();
                _client.UploadFileAsync(uploadData.FileName, uploadData.FileSize, uploadData.FileType, 
                    uploadData.FileUniqueID, uploadData.oldFileName, uploadData.FileData);
                _client.UploadFileCompleted += _client_UploadFileCompleted;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("文件上传失败！");
                MyLog.LogError("保存问题跟踪时文件上传失败！", ex);
                return;
            }
        }

        void _client_UploadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                MyLog.LogError("问题列表上传文件错误",e.Error);                
                return;
            }
            try
            {
                wait.Close();
            }
            catch 
            {  }
            SaveProblemTrace(true);
        }
        private void SaveProblemTrace(bool hasUpload)
        {
            PPM_ProblemTrace problemTrace;
            using (BugTraceEntities zEntity = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
            {
                UserInfo currUser = UserInfo.GetInstence();
                if (this._problemTraceID == -1)
                {
                    problemTrace = new PPM_ProblemTrace();
                }
                else
                {
                    problemTrace = zEntity.PPM_ProblemTrace.Where(p => p.ID == this._problemTraceID).FirstOrDefault();
                }
                problemTrace.ProjectCode = currUser.DefaultProjectCode;
                problemTrace.Module = this.txtModule.Text;
                problemTrace.FindPersonCode = this.cbxFindPerson.SelectedValue.ToString();
                problemTrace.FindPerson = this.cbxFindPerson.Text;
                problemTrace.Problem = this.txtProblem.Text;
                problemTrace.DealPersonCode = this.cbxDealPerson.SelectedValue.ToString();
                problemTrace.DealPerson = this.cbxDealPerson.Text;
                //problemTrace.ProjectUse = this.cbxProjectUse.Text;
                if (!string.IsNullOrWhiteSpace(this.dtBeginDealDate.Text))
                {
                    problemTrace.BeginDealDate = Convert.ToDateTime(this.dtBeginDealDate.Text);
                }
                else
                {
                    problemTrace.BeginDealDate = null;
                }
                if (!string.IsNullOrWhiteSpace(this.dtEndDealDate.Text))
                {
                    problemTrace.EndDealDate = Convert.ToDateTime(this.dtEndDealDate.Text);
                }
                problemTrace.Solution = this.txtSolution.Text;
                problemTrace.Status = this.cbxStatus.Text;
                problemTrace.ProblemType = this.cbxProblemType.Text;
                if (problemTrace.Status == "未通过")
                {
                    problemTrace.TestFlag = 0;
                }
                problemTrace.UpdateDate = DateTime.Now;
                problemTrace.UpdatePerson = currUser.UserCode;
                problemTrace.IsRepeat = this.cbxIsRepeat.Text;
                if (problemTrace.Status == "未开始" || problemTrace.Status == "进行中" || problemTrace.Status == "未通过")
                {
                    problemTrace.EndDealDate = null;
                }
                if (problemTrace.Status == "发版关闭")
                {
                    problemTrace.TestPersonCode = UserInfo.GetInstence().UserCode;
                    problemTrace.TestPerson = UserInfo.GetInstence().UserName;
                    problemTrace.TestPassDate = DateTime.Now;
                }
                if (this._problemTraceID == -1)
                {
                    problemTrace.FindDate = DateTime.Now;
                    problemTrace.CreateDate = DateTime.Now;
                    problemTrace.CreatePerson = currUser.UserCode;
                    problemTrace.DeleteFlag = 0;
                    zEntity.PPM_ProblemTrace.Add(problemTrace);
                }
                if (hasUpload)//有上传附件
                {
                    problemTrace.AttachmentName = Path.GetFileName(this.txtAttachment.Text);
                    problemTrace.AttachmentUniqueID = this._attachmentUniqueID;
                    problemTrace.AttachmentCreateBy = UserInfo.GetInstence().UserCode;
                    problemTrace.AttachmentCreateDate = DateTime.Now;
                }
                if (problemTrace.Status == "进行中")
                {
                    problemTrace.BeginDealDate = DateTime.Now;
                }
                #region 保存图片
                if (this._problemTraceID != -1)
                {//删除以前的图片
                    var delImage = zEntity.PPM_ProblemTraceImage.Where(p => p.ProblemTraceID == this._problemTraceID);
                    zEntity.PPM_ProblemTraceImage.RemoveRange(delImage);
                }
                int i = 1;
                foreach (Control item in flowLayoutPanel1.Controls)
                {
                    PictureBox pictureBox = item as PictureBox;
                    if (pictureBox != null)
                    {
                        PPM_ProblemTraceImage image = new PPM_ProblemTraceImage()
                        {
                            ID = pictureBox.Tag.ToString(),
                            StorageType = 1,
                            SerialNo = i++,
                            ImageFile = ImageToBytes(pictureBox.Image),
                        };
                        problemTrace.PPM_ProblemTraceImage.Add(image);
                    }
                }
                #endregion
                zEntity.SaveChanges();
            }
            MessageBox.Show("保存成功！");
            this.Close();
            try
            {
                var problemTraceList = FormSingle.GetForm(typeof(ProblemTraceList)) as ProblemTraceList;
                problemTraceList.SearchClick();
                bool isExist = FormSingle.IsExist(typeof(ProjectPlanList));
                if (isExist)
                {
                    var tempForm = FormSingle.GetForm(typeof(ProjectPlanList)) as ProjectPlanList;
                    tempForm.SearchClick();
                }
            }
            catch (Exception ex)
            {
                MyLog.LogError("保存问题跟踪后刷新列表页面失败！",ex);
            }

        }
        #endregion

        #region 图片二进制相互转换
        private Image ByteToImage(byte[] mybyte)
        {
            Image image;
            MemoryStream mymemorystream = new MemoryStream(mybyte, 0, mybyte.Length);
            image = Image.FromStream(mymemorystream);
            return image;
        }

        private byte[] ImageToBytes(Image img)
        {
            byte[] bt = null;
            if (!img.Equals(null))
            {
                using (MemoryStream mostream = new MemoryStream())
                {
                    Bitmap bmp = new Bitmap(img);
                    bmp.Save(mostream, System.Drawing.Imaging.ImageFormat.Jpeg);//将图像以指定的格式存入缓存内存流
                    bt = new byte[mostream.Length];
                    mostream.Position = 0;//设置留的初始位置
                    mostream.Read(bt, 0, Convert.ToInt32(bt.Length));
                }
            }           
            return bt;
        }
        #endregion

        #region 附件选择按钮
        private void btnAttachment_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.txtAttachment.Text = openFileDialog1.FileName;

                    FileStream ftream = File.OpenRead(this.txtAttachment.Text);
                    long fileSize = ftream.Length;
                    if (fileSize > 30 * 1024 * 1024)
                    {
                        MessageBox.Show("文件不能超过30M", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtAttachment.Text = "";
                    }
                    else
                    {
                        this._attachmentFlag = true;//允许上传
                        this._attachmentUniqueID = Guid.NewGuid().ToString();//附件的UniqueID
                    }
                }
            }
            catch (Exception ex)
            {
                this.txtAttachment.Text = "";
                MessageBox.Show(ex.Message+"\r\n[[--请先关闭文件再选择上传--]]");
            }
            
        }
        #endregion

        #region 下载附件
        private void linkAttachment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.linkAttachment.Text))
            {
                return;
            }
            if (this.folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                wait = new FrmWait("正 在 下 载 请 稍 候");
                wait.Show();
                Thread downloadThread = new Thread(downloadFile);
                downloadThread.IsBackground = true;
                List<KeyValuePair<string, string>> map = new List<KeyValuePair<string, string>>();
                map.Add(new KeyValuePair<string, string>("folder", folderBrowserDialog1.SelectedPath));
                map.Add(new KeyValuePair<string, string>("fileName", this.linkAttachment.Text));
                map.Add(new KeyValuePair<string, string>("uniqueID", this._attachmentUniqueID));
                downloadThread.Start(map);
            }
        }
        private void downloadFile(object obj)
        {
            List<KeyValuePair<string, string>> map =obj as List<KeyValuePair<string, string>>;
            int BufferLen = 4096;
            string folder = map.Where(p => p.Key == "folder").FirstOrDefault().Value;
            string fileName = map.Where(p => p.Key == "fileName").FirstOrDefault().Value;
            string uniqueID = map.Where(p => p.Key == "uniqueID").FirstOrDefault().Value;

            string serverFilePath = "\\UploadFile\\PPM_ProblemTrace\\" + uniqueID + fileName;
            string fileServiceUrl = string.Empty;
            using (BugTraceEntities zentity = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
            {
                var currVersion = zentity.SYS_Version.Where(p => p.IsDefault == 1).FirstOrDefault();
                fileServiceUrl = currVersion.FileServiceUrlPort;
            }
            Stream sourceStream = null;
            try
            {
                EndpointAddress address = new EndpointAddress("http://" + fileServiceUrl + "/JAJ.WinServer/FileService");
                FileTransferSvc.FileServiceClient _client = new FileTransferSvc.FileServiceClient("BasicHttpBinding_IFileService", address);
                sourceStream = _client.DowndloadFile(serverFilePath);
            }
            catch (Exception ex)
            {
                MyLog.LogError("文件下载失败！", ex);
                this.Invoke(new MethodInvoker(() =>
                {
                    try
                    {
                        wait.Close();
                    }
                    catch
                    { }

                    MessageBox.Show("文件下载失败！");
                }));
                return;
            }
            
            FileStream targetStream = null;
            if (!sourceStream.CanRead)
            {
                MyLog.LogError("下载异常", new Exception("Invalid Stream!"));
                throw new Exception("Invalid Stream!");
            }

            string filePath = Path.Combine(folder, fileName);
            using (targetStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                byte[] buffer = new byte[BufferLen];
                int count = 0;
                while ((count = sourceStream.Read(buffer, 0, BufferLen)) > 0)
                {
                    targetStream.Write(buffer, 0, count);
                }
                targetStream.Close();
                sourceStream.Close();

            }
            this.Invoke(new MethodInvoker(() =>
            {
                try
                {
                    wait.Close();
                }
                catch
                { }

                MessageBox.Show("下载成功！");
            }));
        }
        #endregion

        #region 右键黏贴
        private void menuCopyPicture_Click(object sender, EventArgs e)
        {
            copyImageFromClipboard();
        }
        #endregion

        #region 粘贴图片RichTextBox内容改变事件
        private void txtPicture_TextChanged(object sender, EventArgs e)
        {
            copyImageFromClipboard();
            this.txtPicture.Clear();
        }
        #endregion

        #region 粘贴图片(查看大图、删除)
        private void copyImageFromClipboard()
        {
            Image image = null;
            if (Clipboard.ContainsData(DataFormats.FileDrop))
            {
                var obj = Clipboard.GetDataObject();
                var file = obj.GetData(DataFormats.FileDrop);
                string filePath = ((string[])(file))[0];
                string extType = Path.GetExtension(filePath);
                if (extType == ".jpg" || extType == ".bmp" || extType == ".png" || extType == ".gif")
                {
                    image = Image.FromFile(filePath);                    
                }
            }
            else if (Clipboard.ContainsData(DataFormats.Bitmap))
            {
                image = Clipboard.GetImage();
            }
            if (image != null)
            {
                string letter = UserInfo.GetInstence().UserName + "  " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                ImageHelper.LetterWatermark(image, 12, letter, Color.Red, "RB");
                string groupId = Guid.NewGuid().ToString();
                genarateImageList(groupId,image);
            }
        }

        private void genarateImageList(string groupId,Image image)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Name = "pictureBox" + groupId;
            pictureBox.Width = 150;
            pictureBox.Tag = groupId;
            pictureBox.Height = 100;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = image;
            flowLayoutPanel1.Controls.Add(pictureBox);
            Button button = new Button();
            button.Name = "btnDeletePic" + groupId;
            button.Text = "删除";
            button.Tag = groupId;
            button.Width = 65;
            button.Click += btnDeletePic_Click;
            flowLayoutPanel1.Controls.Add(button);
            Button buttonB = new Button();
            buttonB.Name = "btnBigPic" + groupId;
            buttonB.Text = "查看大图";
            buttonB.Click += buttonBigPic_Click;
            buttonB.Tag = groupId;
            buttonB.Width = 65;
            flowLayoutPanel1.Controls.Add(buttonB);
        }
        
        void buttonBigPic_Click(object sender, EventArgs e)
        {           
           Button btn = sender as Button;
           if (btn.Text == "查看大图")
           {
               string groupId = btn.Tag.ToString();               
               Control[] controls= flowLayoutPanel1.Controls.Find("pictureBox" + groupId,false);
               PictureBox picbox = controls[0] as PictureBox;
               FrmPictureBrowser picb = new FrmPictureBrowser();
               picb.currImageKey = picbox.Name;
               LinkedList<ImageBroswerInfo> dicPicture = new LinkedList<ImageBroswerInfo>();
               int i=1;
               foreach (Control item in flowLayoutPanel1.Controls)
               {
                   PictureBox pictureBox = item as PictureBox;
                   if (pictureBox != null)
                   {
                       ImageBroswerInfo ibi = new ImageBroswerInfo()
                       {
                           SerialNo = i++,
                           KeyId = pictureBox.Name,
                           ImageInfo = pictureBox.Image
                       };
                       dicPicture.AddLast(ibi);
                   }
               }
               picb.ImageList = dicPicture;
               picb.ShowDialog();
           }
        }

        void btnDeletePic_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Text == "删除")
            {
                if (MessageBox.Show("您确定要删除吗？", "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    string groupId = btn.Tag.ToString();
                    flowLayoutPanel1.Controls.RemoveByKey("pictureBox" + groupId);
                    flowLayoutPanel1.Controls.RemoveByKey("btnDeletePic" + groupId);
                    flowLayoutPanel1.Controls.RemoveByKey("btnBigPic" + groupId);
                }
            }            
        }

        #endregion

    }
}
