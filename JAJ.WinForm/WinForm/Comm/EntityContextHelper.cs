using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAJ.WinForm
{
    public partial class BugTraceEntities : DbContext
    {
        public BugTraceEntities(string connectionString)
            : base(connectionString)
        {
        }
    }

    public class EntityContextHelper
    {        
        public static string GetEntityConnString()
        {//192.168.100.9,49589
            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
            //Metadata属性的值，是从向导生成的Config粘贴过来的
            entityBuilder.Metadata = "res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl";
            entityBuilder.ProviderConnectionString = @"data source=192.168.100.9,49589;initial catalog=BugTrace;persist security info=True;user id=sa;password=ec0801;MultipleActiveResultSets=True;App=EntityFramework";
            entityBuilder.Provider = "System.Data.SqlClient";
            return entityBuilder.ToString();
        }

    }
   
}
