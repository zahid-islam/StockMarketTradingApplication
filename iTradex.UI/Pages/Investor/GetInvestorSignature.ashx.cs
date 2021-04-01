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
    /// Summary description for GetInvestorSignature
    /// </summary>
    public class GetInvestorSignature : IHttpHandler, IRequiresSessionState
    {
        GetSession session = new GetSession();
        public void ProcessRequest(HttpContext context)
        {
            string AccNo = context.Session["AccountNumber"].ToString();
            //string AccountNo = context.Request.Params["txtAccountNumber"];
            SqlConnection sqlConnect = DatabaseConnection.GetConnection();

            string Query = "SELECT Distinct Signature FROM InvestorProfile WHERE AccountNumber='" + session.AccountNumber + "' ";
            //cmd.Parameters.AddWithValue("@EntryID", Convert.ToInt32(textBox1.Text));
            SqlCommand sqlCmd = new SqlCommand(Query, sqlConnect);
            try
            {
                SqlDataReader rdr = sqlCmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        if (!(rdr.IsDBNull(rdr.GetOrdinal("Signature"))))
                        {
                            context.Response.ContentType = "image/jpg";
                            context.Response.BinaryWrite((byte[])rdr["Signature"]);
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