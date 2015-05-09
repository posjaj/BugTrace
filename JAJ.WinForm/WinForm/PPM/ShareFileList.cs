using JAJ.WinForm.Comm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace JAJ.WinForm.PPM
{
    public partial class ShareFileList : Form
    {
        public ShareFileList()
        {
            InitializeComponent();
            this.dgvShareFile.AutoGenerateColumns = false;
            this.dgvShareFile.AllowUserToAddRows = false;
            this.dgvShareFile.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            //this.dgvShareFile.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvShareFile.Columns[dgvShareFile.ColumnCount - 2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void ShareFileList_Load(object sender, EventArgs e)
        {
            #region 绑定文件分类
            using (BugTraceEntities entiy = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
            {
                var query = (from c in entiy.SYS_SortDict
                             where c.Type == 1
                             select new
                             {
                                 c.SortCode,
                                 c.SortName
                             }).ToList();
                List<KeyValuePair<string, string>> kvp = new List<KeyValuePair<string, string>>();
                foreach (var item in query)
                {
                    kvp.Add(new KeyValuePair<string, string>(item.SortCode, item.SortName));
                }
                this.cbxSort.DisplayMember = "value";
                this.cbxSort.ValueMember = "key";
                this.cbxSort.DataSource = kvp;
            }
            this.cbxSort.Text = "";
            this.txtFileName.Text = "";   
            #endregion
                     
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.txtPageNum.Text = "1";
            PageDataBind();
        }
        private void txtFileName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PageDataBind();
            }
        }

        #region 分页相关
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void PageDataBind()
        {
            using (BugTraceEntities zEntity = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
            {
                var query = from c in zEntity.PPM_ShareFile
                                                  join d in zEntity.SYS_SortDict
                                                  on c.SortCode equals d.SortCode
                                                  join e in zEntity.SYS_User
                                                  on c.CreateBy equals e.UserCode
                                                  where d.Type == 1
                                                  select new 
                                                  {
                                                      c.ID,
                                                      c.SortCode,
                                                      d.SortName,
                                                      c.FileName,
                                                      c.FilePath,
                                                      c.FileDesc,
                                                      c.CreateBy,
                                                      CreateByName = e.UserName,
                                                      c.CreateDate,
                                                      c.Memo
                                                  };

                //分类查询条件
                if (!string.IsNullOrWhiteSpace(this.cbxSort.Text))
                {
                    string sortCode=this.cbxSort.SelectedValue.ToString();
                    query = query.Where(p => p.SortCode == sortCode);
                }

                //创建人查询条件                
                if (!string.IsNullOrWhiteSpace(this.txtCreateBy.Text))
                {
                    query = query.Where(p => p.CreateByName.Contains(this.txtCreateBy.Text));
                }
                
                 //文件名称查询条件                
                if (!string.IsNullOrWhiteSpace(this.txtFileName.Text))
                {
                    query = query.Where(p => p.FileName.Contains(this.txtFileName.Text));
                }

                int pageSize = Int32.Parse(cbxPageSize.Text);
                int pageNum = Int32.Parse(txtPageNum.Text);
                var shareFileList = query.OrderByDescending(p => new { p.SortCode,p.CreateDate }).Skip(pageSize * (pageNum - 1)).Take(pageSize).ToList();

                this.dgvShareFile.DataSource = shareFileList;
                var totalRecordCount = query.Count();
                this.lblPageInfo.Text = "总共" + totalRecordCount + "条记录，每页";
                this.lblPageTotal.Text = Math.Ceiling(Convert.ToDecimal(totalRecordCount) / pageSize) + "页";
            }
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            txtPageNum.Text = "1";
            PageDataBind();
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (this.txtPageNum.Text == "1")
            {
                return;
            }
            this.txtPageNum.Text = (Convert.ToInt32(this.txtPageNum.Text) - 1).ToString();
            PageDataBind();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            int totalPageCount = Convert.ToInt32(this.lblPageTotal.Text.Substring(0, this.lblPageTotal.Text.Length - 1));
            if (this.txtPageNum.Text == totalPageCount.ToString())
            {
                return;
            }
            this.txtPageNum.Text = (Convert.ToInt32(this.txtPageNum.Text) + 1).ToString();
            PageDataBind();
        }
        /// <summary>
        /// 末页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLastPage_Click(object sender, EventArgs e)
        {
            int totalPageCount = Convert.ToInt32(this.lblPageTotal.Text.Substring(0, this.lblPageTotal.Text.Length - 1));
            this.txtPageNum.Text = totalPageCount.ToString();
            PageDataBind();
        }
        /// <summary>
        /// 跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSkip_Click(object sender, EventArgs e)
        {
            int totalPageCount = Convert.ToInt32(this.lblPageTotal.Text.Substring(0, this.lblPageTotal.Text.Length - 1));
            if (Convert.ToInt32(this.txtPageNum.Text) > totalPageCount)
            {
                this.txtPageNum.Text = totalPageCount.ToString();
            }
            PageDataBind();
        }
        /// <summary>
        /// 回车跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPageNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int totalPageCount = Convert.ToInt32(this.lblPageTotal.Text.Substring(0, this.lblPageTotal.Text.Length - 1));
                if (Convert.ToInt32(this.txtPageNum.Text) > totalPageCount)
                {
                    this.txtPageNum.Text = totalPageCount.ToString();
                }
                PageDataBind();
            }
        }
        #endregion        

        private void txtCreateBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PageDataBind();
            }
        }

        private void dgvShareFile_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            foreach (DataGridViewRow dr in dgvShareFile.Rows)
            {
                dr.Cells["SerialNo"].Value = dr.Index + 1;
            }
        }

        private FrmWait wait;
        private void dgvShareFile_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            var obj = this.dgvShareFile.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (obj != null)
            {
                string buttonText = this.dgvShareFile.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (buttonText == "下载")
                {
                    if (this.folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        wait = new FrmWait("正 在 下 载 请 稍 候");
                        wait.Show();
                        //WaitForm.Show(this, "正 在 下 载 请 稍 候");
                        Thread downloadThread = new Thread(downloadFile);                       
                        downloadThread.IsBackground = true;                       
                        downloadThread.Start(e.RowIndex);
                    }
                }
            }
        }

        private void downloadFile(object rowIndex)
        {
            int BufferLen = 4096;
            string folder = folderBrowserDialog1.SelectedPath;
            string file = this.dgvShareFile.Rows[(int)rowIndex].Cells["FilePath"].Value.ToString();
            string fileName = Path.GetFileName(file);
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
                sourceStream = _client.DowndloadFile(file);
            }
            catch (Exception ex)
            {
                MyLog.LogError("文件下载失败！", ex);
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
            this.Invoke(new MethodInvoker(()=>{
                try
                {
                    wait.Close();
                }
                catch  
                { }
               
                MessageBox.Show("下载成功！");
            }));
        }
    }
}
