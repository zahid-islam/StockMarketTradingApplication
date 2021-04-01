using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace iTradex.UI.App_Code
{
    public class DatabaseConnection
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
            SqlConnection sqlConn = new SqlConnection(connectionString);
          
            sqlConn.Open();
            return sqlConn;
        }
    }
}