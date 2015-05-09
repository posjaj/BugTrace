using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
    /// <summary> 
    /// MyLog 的摘要说明。 
    /// </summary> 
public class MyLog
{
    private static log4net.ILog log
    {
        get
        {
            log4net.ILog log = log4net.LogManager.GetLogger("WinForm");
            var a = log.Logger.Repository.GetAppenders();
            foreach (var appender in a)
            {
                if (appender.GetType() == typeof(log4net.Appender.AdoNetAppender))
                {
                    log4net.Appender.AdoNetAppender d = (log4net.Appender.AdoNetAppender)appender;
                   // d.ConnectionString = Utility.GetSqlConnectingString();
                    break;
                }
            }
            return log;
        }
    }
    public static void LogError(string ErrorMessage, Exception ex)
    {
        log.Error(ErrorMessage, ex);
    }
    public static void LogMessage(string Message)
    {
        log.Info(Message);
    }
}
