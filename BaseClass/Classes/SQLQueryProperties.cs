using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClass.Classes
{
    public class SQLQueryProperties
    {
       
        private static string _ConnectionString = ConfigurationManager.AppSettings["Environment"].ToString() == "PROD" ? "Data Source=10.37.32.49;Initial Catalog=Mbc5;User Id = MbcUser; password = 3l3phant1; Connect Timeout=5" : "Data Source=192.168.1.101; Initial Catalog=Mbc5;User Id=sa;password=Briggitte1; Connect Timeout=5";
        public SQLQueryProperties()
        {
            ConnectionString = _ConnectionString;
            Timeout = 20;
            CommandParameters = new List<SqlParameter>();
            CommandType = CommandType.Text;
            ReturnList = false;
            IdentityColumn = null;
        }

        public string ConnectionString { get; set; }
        public string CommandText { get; set; }
        public int Timeout { get; set; }
        public CommandType CommandType { get; set; }
        public List<SqlParameter> CommandParameters { get; set; }
        public SqlParameter[] CommandParametersCollection { get; set; }
        public bool ReturnList { get; set; }
        public string IdentityColumn { get; set; }
        public bool ReturnSqlIdentityId { get; set; }
        public DataTable BulkCopyDataTable { get; set; }
    }

    public class SQLParam
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public bool isDateTime { get; set; } = true;
    }
}
