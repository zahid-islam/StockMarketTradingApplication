using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using iTradex.UI.App_Code;
using System.Web.SessionState;

namespace iTradex.UI.Pages.Investor
{
    /// <summary>
    /// Summary description for GetInvestorPhoto
    /// </summary>
    public class GetInvestorPhoto : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        GetSession session = new GetSession();
        public void ProcessRequest(HttpContext context)
        {
            SqlConnection sqlConnect = DatabaseConnection.GetConnection();

            string Query = "SELECT Distinct Photo FROM InvestorProfile WHERE AccountNumber= '" + session.AccountNumber + "' ";
            //cmd.Parameters.AddWithValue("@EntryID", Convert.ToInt32(textBox1.Text));
            SqlCommand sqlCmd = new SqlCommand(Query, sqlConnect);
            try
            {
                SqlDataReader rdr = sqlCmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        if (!(rdr.IsDBNull(rdr.GetOrdinal("Photo"))))
                        {
                            context.Response.ContentType = "image/jpg";
                            context.Response.BinaryWrite((byte[])rdr["Photo"]);
                        }
                        else
                        {
                            context.Response.ContentType = "image/png";
                            context.Response.WriteFile("../../img/UserAvater.png");
                        }
                    }
                }

                if (rdr != null)
                    rdr.Close();
            }
            finally
            {
                if (sqlConnect != null)
                    sqlConnect.Close();
            }
        }

        
    }
}