using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace iTradex.UI.App_Code
{
    public class CommonFunction
    {
        public DataTable GetDatatable(string query)
        {
#pragma warning disable CS0436 // Type conflicts with imported type
            SqlConnection sqlConnect = DatabaseConnection.GetConnection();
#pragma warning restore CS0436 // Type conflicts with imported type
            try
            {
                SqlCommand sqlCmd = new SqlCommand(query, sqlConnect);
                SqlDataAdapter sDAdapter = new SqlDataAdapter(sqlCmd);
                DataTable dTable = new DataTable();
                sDAdapter.Fill(dTable);
                return dTable;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int InsertQuery(string query)
        {
            try
            {
#pragma warning disable CS0436 // Type conflicts with imported type
                SqlConnection sqlConnect = DatabaseConnection.GetConnection();
#pragma warning restore CS0436 // Type conflicts with imported type
                SqlCommand sqlCmd = new SqlCommand(query,sqlConnect);

                int row = sqlCmd.ExecuteNonQuery();
                sqlConnect.Close();
                sqlConnect.Dispose();
                return row;
            }

            catch(SqlException ex)
            {
                throw ex;
            }
        }


        public string[] GetAddress(string address)
        {
            string[] splitAddress = address.Split(',');

            return splitAddress;
        
        }
    }
}