using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JAJ.WinForm.Comm;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace JAJ.WinForm.FRM
{
    public partial class FrmImportExcel : Form
    {
        private FrmWait wait;

        public FrmImportExcel()
        {
            InitializeComponent();
        }

        private void FrmImportExcel_Load(object sender, EventArgs e)
        {
            using (BugTraceEntities context = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
            {
                string currUser = UserInfo.GetInstence().UserCode;
                var userExt = context.SYS_UserExt.Where(p => p.UserCode == currUser).FirstOrDefault();
                if (userExt != null)
                {
                    this.txtHOST.Text = userExt.Host;
                    this.txtPORT.Text = userExt.Port;
                    this.txtSERVICENAME.Text = userExt.ServiceName;
                    this.txtUsername.Text = userExt.Username;
                    this.txtPassword.Text = userExt.Password;
                    this.txtTableName.Text = userExt.TempTableName;
                }
            }
        }

        #region 测试数据库连接
        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            bool IsCanConnectioned = ConnectionTest();
            if (!IsCanConnectioned)
            {
                MessageBox.Show(this, "连接数据库失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("连接数据库成功！");
            }
        }
        #endregion

        #region 保存配置
        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            using (BugTraceEntities context = new BugTraceEntities(EntityContextHelper.GetEntityConnString()))
            {
                string currUser=UserInfo.GetInstence().UserCode;
                var userExt = context.SYS_UserExt.Where(p => p.UserCode == currUser).FirstOrDefault();
                if (userExt == null)
                {
                    userExt = new SYS_UserExt();
                    userExt.UserCode = currUser;
                    userExt.Host = this.txtHOST.Text.Trim();
                    userExt.Port = this.txtPORT.Text.Trim();
                    userExt.ServiceName = this.txtSERVICENAME.Text.Trim();
                    userExt.Username = this.txtUsername.Text.Trim();
                    userExt.Password = this.txtPassword.Text.Trim();
                    userExt.TempTableName = this.txtTableName.Text.Trim();
                    context.SYS_UserExt.Add(userExt);
                    context.SaveChanges();
                }
                else 
                {                   
                    userExt.Host = this.txtHOST.Text.Trim();
                    userExt.Port = this.txtPORT.Text.Trim();
                    userExt.ServiceName = this.txtSERVICENAME.Text.Trim();
                    userExt.Username = this.txtUsername.Text.Trim();
                    userExt.Password = this.txtPassword.Text.Trim();
                    userExt.TempTableName = this.txtTableName.Text.Trim();
                    context.SaveChanges();
                }
                MessageBox.Show("保存配置成功！");
            }
        }
        #endregion

        #region 选择excel文件
        private void btnSelectExcel_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtExcelPath.Text = openFileDialog1.FileName;
            }
        }
        #endregion
        
        #region 导入按钮
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            #region 验证
            if (string.IsNullOrWhiteSpace(this.txtExcelPath.Text))
            {
                MessageBox.Show(this, "请选择Excel", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTableName.Text))
            {
                MessageBox.Show(this, "表名不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!CheckParameter(txtTableName.Text))
            {
                MessageBox.Show(this, "表命名不合法！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool IsCanConnectioned = ConnectionTest();
            if (!IsCanConnectioned)
            {
                MessageBox.Show(this, "连接数据库失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; ;
            }            
            #endregion

            Thread thread = new Thread(ImportExcel);
            thread.IsBackground = true;
            List<KeyValuePair<string, object>> kv = new List<KeyValuePair<string, object>>();
            kv.Add(new KeyValuePair<string, object>("excelPath", this.txtExcelPath.Text));
            kv.Add(new KeyValuePair<string, object>("oraConn", GetConnectionString()));
            kv.Add(new KeyValuePair<string, object>("tableName", this.txtTableName.Text));
            kv.Add(new KeyValuePair<string, object>("isClearData", false));
            wait = new FrmWait("正 在 导 入 请 稍 候");
            wait.Show();
            thread.Start(kv);
        }


        #endregion

        #region 导入方法（新线程）
        private void ImportExcel(object obj)
        {
            List<KeyValuePair<string, object>> kv = obj as List<KeyValuePair<string, object>>;
            string excelPath = kv.Where(p => p.Key == "excelPath").FirstOrDefault().Value.ToString();
            string connectionString = kv.Where(p => p.Key == "oraConn").FirstOrDefault().Value.ToString();
            string tableName = kv.Where(p => p.Key == "tableName").FirstOrDefault().Value.ToString();
            bool isClearData = Convert.ToBoolean(kv.Where(p => p.Key == "isClearData").FirstOrDefault().Value);
            //1从excel中读取数据至DataTable
            DataTable dtbl = GetDataFromExcel(excelPath);
            if (dtbl == null || dtbl.Rows.Count == 0)
            {                
                MessageBoxInvoker("Excel表格数据为空！");
                return;
            }
            //2处理table
            UpdateDataTable(ref dtbl);
            //3检查表是否存在，不存在就创建
            #region 创建表(如果已经存在，则不创建)
            bool isExist = CheckTableIsExist(connectionString, tableName);
            if (!isExist)
            {
                try
                {
                    //验证字段名命名是否合法
                    if (dtbl != null && dtbl.Rows.Count > 0)
                    {
                        DataRow dr = dtbl.Rows[0];
                        for (int i = 0; i < dtbl.Columns.Count; i++)
                        {
                            if (string.IsNullOrWhiteSpace(dr[i].ToString()))
                            {
                                MessageBoxInvoker("excel中第一行的表字段命名不能为空！");
                                return;
                            }
                            if (!CheckParameter(dr[i].ToString().Trim()))
                            {
                                MessageBoxInvoker("excel中第一行的表字段命名不符合规范！");
                                return;
                            }
                        }
                        //创建表
                        CreateTable(connectionString, dr, dtbl.Rows[1], dtbl.Columns.Count, tableName);
                    }
                    else
                    {
                        MessageBoxInvoker("excel为空！");
                        return;
                    } 
                }
                catch (Exception ex)
                {
                    MessageBoxInvoker(ex.Message);
                    return;
                }
            }
            #endregion

            //4将读取出来数据插入到创建的表中    
            #region 插入表中
            string cmdText = " SELECT t.COLUMN_NAME from User_Tab_Columns t WHERE t.TABLE_NAME=UPPER(:tableName) ";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    try
                    {
                        if (conn.State != ConnectionState.Open)
                        { conn.Open(); }
                        var trans = conn.BeginTransaction();
                        cmd.Connection = conn;
                        cmd.CommandText = cmdText;
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new OracleParameter(":tableName", OracleDbType.NVarchar2, 200));
                        cmd.Parameters[0].Value = tableName;
                        DataTable dtblColumns = new DataTable();
                        OracleDataAdapter oda = new OracleDataAdapter(cmd);
                        oda.Fill(dtblColumns);
                        cmd.Parameters.Clear();
                        if (dtblColumns.Rows.Count > 0)
                        {
                            StringBuilder sbInsert = new StringBuilder();
                            sbInsert.AppendFormat(" INSERT INTO {0} ( ", tableName);
                            foreach (DataRow item in dtblColumns.Rows)
                            {
                                sbInsert.AppendFormat(" {0},", item[0]);
                            }
                            sbInsert.Remove(sbInsert.Length - 1, 1);
                            sbInsert.AppendFormat(" ) VALUES  ( ");
                            foreach (DataRow item in dtblColumns.Rows)
                            {
                                sbInsert.AppendFormat(" :{0},", item[0]);
                            }
                            sbInsert.Remove(sbInsert.Length - 1, 1);
                            sbInsert.AppendFormat(" ) ");
                            //是否需要清除表中数据
                            if (isClearData)
                            {
                                string cmdDel = " delete from " + tableName;
                                cmd.CommandText = cmdDel;
                                cmd.ExecuteNonQuery();
                            }
                            cmd.CommandText = sbInsert.ToString();
                            cmd.Parameters.Clear();
                            for (int i = 2; i < dtbl.Rows.Count; i++)
                            {

                                int j = 0;
                                foreach (DataRow item in dtblColumns.Rows)
                                {
                                    cmd.Parameters.Add(new OracleParameter(":" + item[0], OracleDbType.NVarchar2, 200));
                                    cmd.Parameters[cmd.Parameters.Count - 1].Value = dtbl.Rows[i][j].ToString();
                                    j++;
                                }
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                            }
                        }
                        trans.Commit();
                        MessageBoxInvoker("导入成功！");
                    }
                    catch (Exception ex)
                    {
                        MyLog.LogError("导入Excel数据报错", ex);
                        MessageBoxInvoker(ex.Message);
                    }
                }
            }
            #endregion
            
        }
        #endregion

        #region 线程中执行提示
        private void MessageBoxInvoker(string message)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                MessageBox.Show(message);
                try
                {
                    wait.Close();
                }
                catch
                {
                }
            }));
        }
        #endregion

        #region 获取Excel中的数据，返回DataTable
        private DataTable GetDataFromExcel(string excelPath)
        {
            if (string.IsNullOrWhiteSpace(excelPath))
            {
                return null;
            }
            if (!File.Exists(excelPath))
            {
                return null;
            }
            using (OpenXmlHelper ox = new OpenXmlHelper())
            {
                ox.RowIndex = new int[] { 1 };//excel从第几行开始读取数据，从1开始计数,不是从0开始
                DataSet ds = ox.ExcelToDataSet(excelPath);
                return ds.Tables[0];
            }
        }
        #endregion

        #region 测试连接是否有效
        private bool ConnectionTest()
        {
            bool IsCanConnectioned;
            OracleConnection oracon = new OracleConnection(GetConnectionString());
            try
            {
                oracon.Open();
                IsCanConnectioned = true;
            }
            catch
            {
                IsCanConnectioned = false;
            }
            finally
            {
                oracon.Close();
            }
            return IsCanConnectioned;
        }
        #endregion

        #region 获取连接字符串
        private string GetConnectionString()
        {
            var connectionString = @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)
                    (HOST="+this.txtHOST.Text.Trim()+@") (PORT="+this.txtPORT.Text.Trim()+@")))
                    (CONNECT_DATA=(SERVICE_NAME= "+this.txtSERVICENAME.Text.Trim()+@")));
                    User Id="+this.txtUsername.Text.Trim()+"; Password="+this.txtPassword.Text.Trim();            
            return connectionString;
        }
        #endregion

        #region 检查命名是否合法
        private bool CheckParameter(string input)
        {
            if (input.ToLower().IndexOf("delete ") != -1 || input.ToLower().IndexOf("drop ") != -1 || input.ToLower().IndexOf("truncate ") != -1)
            {
                return false;
            }
            return Regex.IsMatch(input, @"^[a-zA-Z_][A-Za-z0-9_]*$");
        }
        #endregion

        #region 处理table，规则以第一行第一列为主，他们的内容不为空的行列范围的数据
        private void UpdateDataTable(ref DataTable dtbl)
        {
            if (dtbl == null || dtbl.Rows.Count == 0)
            {
                return;
            }
            //取有效列数
            int cellCount = 0;
            DataRow dr = dtbl.Rows[0];
            for (int i = 0; i < dtbl.Columns.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(dr[i].ToString()))
                {
                    break;
                }
                cellCount = i + 1;
            }
            //取有效行数
            int rowsCount = 0;
            for (int i = 0; i < dtbl.Rows.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(dtbl.Rows[i][0].ToString()))
                {
                    break;
                }
                rowsCount = i + 1;
            }
            //删除多余列
            while (dtbl.Columns.Count > cellCount)
            {
                dtbl.Columns.RemoveAt(cellCount);
            }
            //删除多余行
            while (dtbl.Rows.Count > rowsCount)
            {
                dtbl.Rows.RemoveAt(rowsCount);
            }
        }
        #endregion

        #region 检查表是否存在
        private bool CheckTableIsExist(string oraConn, string TableName)
        {
            string cmdText = "SELECT * from User_Tables t WHERE t.TABLE_NAME=UPPER(:tableName)";
            using (OracleConnection conn = new OracleConnection(oraConn))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    if (conn.State != ConnectionState.Open)
                    { conn.Open(); }
                    cmd.Connection = conn;
                    cmd.CommandText = cmdText;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new OracleParameter(":tableName", OracleDbType.NVarchar2, 500));
                    cmd.Parameters[0].Value = TableName;
                    OracleDataAdapter oda = new OracleDataAdapter(cmd);
                    DataTable dtbl = new DataTable();
                    oda.Fill(dtbl);
                    cmd.Parameters.Clear();
                    if (dtbl != null && dtbl.Rows.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    } 
                }
            }
        }
        #endregion

        #region 创建表
        private void CreateTable(string strConn, DataRow dr, DataRow drMemo, int columnCount, string tableName)
        {
            StringBuilder cmdText = new StringBuilder();
           
            List<string> memoList = new List<string>();
            cmdText.AppendFormat(" CREATE TABLE {0}( ", tableName);
            for (int i = 0; i < columnCount - 1; i++)
            {
                cmdText.AppendFormat("{0} nvarchar2(200) NULL,", dr[i]);               
                memoList.Add(" comment on column " + tableName + "." + dr[i] + "  is '" + drMemo[i] + "' ");
            }
            cmdText.AppendFormat("{0} nvarchar2(200) NULL", dr[columnCount - 1]);
            cmdText.AppendFormat(" ) ");
            memoList.Add(" comment on column " + tableName + "." + dr[columnCount - 1] + "  is '" + drMemo[columnCount - 1] + "' ");
           
            using (OracleConnection oraCon = new OracleConnection(strConn))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    if (oraCon.State != ConnectionState.Open)
                    { oraCon.Open(); }
                    cmd.Connection = oraCon;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = cmdText.ToString();
                    //创建表
                    cmd.ExecuteNonQuery();
                    //添加备注
                    foreach (var item in memoList)
                    {
                        cmd.CommandText = item;
                        cmd.ExecuteNonQuery(); 
                    }                   
                }
            }
        }
        #endregion

        
        
    }
}
