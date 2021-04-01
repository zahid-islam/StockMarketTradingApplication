using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.SessionState;
using iTradex.UI.App_Code;

namespace iTradex.Pages.Investor
{
    /// <summary>
    /// Summary description for GetSignature
    /// </summary>
    public class GetSignature : IHttpHandler, IRequiresSessionState
    {
        GetSession session = new GetSession();
        public void ProcessRequest(HttpContext context)
        {
            string DBCon = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
            SqlConnection sqlConnect = new SqlConnection(DBCon);

            string Query = "SELECT Distinct Signature FROM InvestorProfile WHERE AccountNumber='" + session.AccountNumber + "'";
            //cmd.Parameters.AddWithValue("@EntryID", Convert.ToInt32(textBox1.Text));
            SqlCommand sqlCmd = new SqlCommand(Query, sqlConnect);
            try
            {
                sqlConnect.Open();
                SqlDataReader rdr = sqlCmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        try
                        {
                            context.Response.ContentType = "image/jpg";
                            context.Response.BinaryWrite((byte[])rdr["Signature"]);
                        }
                        catch (Exception)
                        {

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


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}