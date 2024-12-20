﻿using System;
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
        //connection
        //private static string _ConnectionString = "Data Source = Sedswbpsql01; Initial Catalog = Mbc5; Persist Security Info =True;Trusted_Connection=True;";
        private static string _ConnectionString = ConfigurationManager.AppSettings["Environment"].ToString() == "DEV" ? "Data Source = sedswjpsql02; Initial Catalog = Mbc5_demo; Persist Security Info =True;Trusted_Connection=True;" : "Data Source = sedswjpsql02; Initial Catalog = Mbc5; Persist Security Info =True;Trusted_Connection=True;";
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
