using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

/// <summary>
/// SqlHelper 为 SQL Server 数据库的基本访问类    
/// </summary>
public abstract class SqlHelper
{
    /// <summary>
    /// 执行方法，适用于不返回数据的SQL语句，通过链接字符串创建的Connection
    /// </summary>
    /// <param name="connectionString">数据库链接字符串</param>        
    /// <param name="cmdType">Command类型</param>
    /// <param name="cmdText">SQL脚本</param>
    /// <param name="commandParameters">SQL参数集合</param>
    /// <returns>返回影响的行数</returns>
    public static int ExecuteNonQuery(String connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }
    }

    /// <summary>
    /// 执行方法，适用于不返回数据的SQL语句，通过给定的数据库链接Connection
    /// </summary>
    /// <param name="conn">数据库链接</param>        
    /// <param name="cmdType">Command类型</param>
    /// <param name="cmdText">SQL脚本</param>
    /// <param name="commandParameters">SQL参数集合</param>
    /// <returns>返回影响的行数</returns>
    public static int ExecuteNonQuery(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {

        SqlCommand cmd = new SqlCommand();

        PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
        int val = cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        return val;
    }

    /// <summary>
    /// 执行方法，适用于不返回数据的SQL语句，通过给定的数据库事务
    /// </summary>
    /// <param name="conn">数据库事务</param>        
    /// <param name="cmdType">Command类型</param>
    /// <param name="cmdText">SQL脚本</param>
    /// <param name="commandParameters">SQL参数集合</param>
    /// <returns>返回影响的行数</returns>
    public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();
        PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
        int val = cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        return val;
    }

    /// <summary>
    /// 查询方法，适用于返回只读数据的SQL语句，通过链接字符串创建的Connection
    /// </summary>
    /// <param name="cmdType">Command类型</param>
    /// <param name="cmdText">SQL脚本</param>
    /// <param name="commandParameters">SQL参数集合</param>
    /// <returns>返回SqlDataReader数据集</returns>
    public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection(connectionString);
        PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
        SqlDataReader rdr = cmd.ExecuteReader();
        cmd.Parameters.Clear();
        return rdr;

    }

    /// <summary>
    /// 查询方法，适用于返回DataSet数据的SQL语句，通过链接字符串创建的Connection
    /// </summary>
    /// <param name="cmdType">Command类型</param>
    /// <param name="cmdText">SQL脚本</param>
    /// <param name="commandParameters">SQL参数集合</param>
    /// <returns>返回DataSet数据集</returns>
    public static DataSet FillDataSet(String connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();
        DataSet dataSet = new DataSet();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dataSet);
            cmd.Parameters.Clear();
            return dataSet;
        }
    }

    /// <summary>
    /// 执行方法，适用于不返回数据的SQL语句，通过给定的数据库链接Connection
    /// </summary>
    /// <param name="conn">数据库链接</param>        
    /// <param name="cmdType">Command类型</param>
    /// <param name="cmdText">SQL脚本</param>
    /// <param name="commandParameters">SQL参数集合</param>
    /// <returns>返回DataSet数据集</returns>
    public static DataSet FillDataSet(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();
        DataSet dataSet = new DataSet();

        PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
        dataAdapter.Fill(dataSet);
        cmd.Parameters.Clear();
        return dataSet;
    }

    /// <summary>
    /// 执行方法，适用于不返回数据的SQL语句，通过给定的数据库事务
    /// </summary>
    /// <param name="conn">数据库事务</param>        
    /// <param name="cmdType">Command类型</param>
    /// <param name="cmdText">SQL脚本</param>
    /// <param name="commandParameters">SQL参数集合</param>
    /// <returns>返回影响的行数</returns>
    public static DataSet FillDataSet(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();
        DataSet dataSet = new DataSet();

        PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
        dataAdapter.Fill(dataSet);
        cmd.Parameters.Clear();
        return dataSet;
    }

    /// <summary>
    /// 执行方法，适用于具有一个返回值的SQL语句，通过链接字符串创建的Connection
    /// </summary>
    /// <param name="connectionString">数据库链接字符串</param>
    /// <param name="cmdType">Command类型</param>
    /// <param name="cmdText">SQL脚本</param>
    /// <param name="commandParameters">SQL参数集合</param>
    /// <returns>返回对象</returns>
    public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }
    }

    /// <summary>
    /// 执行方法，适用于具有一个返回值的SQL语句，通过给定的数据库链接Connection
    /// </summary>
    /// <param name="conn">数据库链接</param>
    /// <param name="cmdType">Command类型</param>
    /// <param name="cmdText">SQL脚本</param>
    /// <param name="commandParameters">SQL参数集合</param>
    /// <returns>返回对象</returns>
    public static object ExecuteScalar(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {

        SqlCommand cmd = new SqlCommand();

        PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
        object val = cmd.ExecuteScalar();
        cmd.Parameters.Clear();
        return val;
    }

    /// <summary>
    /// 执行方法，适用于具有一个返回值的SQL语句，通过给定的数据库事务
    /// </summary>
    /// <param name="conn">数据库事务</param>        
    /// <param name="cmdType">Command类型</param>
    /// <param name="cmdText">SQL脚本</param>
    /// <param name="commandParameters">SQL参数集合</param>
    /// <returns>返回对象</returns>
    public static object ExecuteScalar(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
    {
        SqlCommand cmd = new SqlCommand();
        PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
        object val = cmd.ExecuteScalar();
        cmd.Parameters.Clear();
        return val;
    }

    /// <summary>
    /// 初始化SqlCommand
    /// </summary>
    /// <param name="cmd">SqlCommand命令组件</param>
    /// <param name="conn">SqlConnection链接组件</param>
    /// <param name="trans">SqlTransaction事务组件</param>
    /// <param name="cmdType">CommandType类型</param>
    /// <param name="cmdText">SQL脚本</param>
    /// <param name="cmdParms">SQL参数集合</param>
    private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
    {

        if (conn.State != ConnectionState.Open)
            conn.Open();

        cmd.Connection = conn;
        cmd.CommandText = cmdText;
        cmd.CommandTimeout = 6000;

        if (trans != null)
            cmd.Transaction = trans;

        cmd.CommandType = cmdType;

        if (cmdParms != null)
        {
            foreach (SqlParameter parm in cmdParms)
                cmd.Parameters.Add(parm);
        }
    }

    /// <summary>
    /// 定义批量执行多条SQL语句的方法
    /// </summary>
    /// <param name="connectionString">数据库链接字符串</param>
    /// <param name="strSql">命令数组</param>
    /// <returns>执行结果</returns>
    public static bool ExecuteTransaction(string connectionString, string[] strSql, SqlParameter[] cmdParms)
    {
        bool flag = false;
        SqlConnection con = new SqlConnection(connectionString);
        if (con.State != ConnectionState.Open)
            con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;//命令对象
        SqlTransaction myTransaction;　//声明一个SQL事物类型
        myTransaction = con.BeginTransaction();//基于一个连接初始化事物

        try
        {

            for (int i = 0; i < strSql.Length; i++)
            {
                cmd.Transaction = myTransaction;//指定SQL命令语句　的事物
                cmd.CommandText = strSql[i];//给定命令语句
                if (i == 1)
                {
                    foreach (SqlParameter parm in cmdParms)
                        cmd.Parameters.Add(parm);
                }
                cmd.ExecuteNonQuery();//执行SQL语句
            }
            myTransaction.Commit();
            flag = true;
        }
        catch //(Exception e)
        {
            myTransaction.Rollback();
            flag = false;
        }

        finally
        {
            con.Close();
            cmd.Dispose();
        }
        return flag;
    }
}

public static class CommJAJ
{
    public static string GetConnectionString()
    {
        string strServer = ConfigurationManager.AppSettings["server"];
        string strUid = ConfigurationManager.AppSettings["uid"];
        string strPwd = ConfigurationManager.AppSettings["pwd"];
        string strDb = ConfigurationManager.AppSettings["db"];
        string strcon = string.Format("Initial Catalog={0};Server={1};User ID={2};Password={3};Integrated Security=false;",
                                strDb, strServer, strUid, strPwd);
        return strcon;
    }
}
