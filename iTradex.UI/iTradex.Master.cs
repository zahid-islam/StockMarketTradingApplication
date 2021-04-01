using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using iTradex.UI.App_Code;
using System.Web.Services;

namespace iTradex.UI
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetUserInformation();
            }
        }
        GetSession session = new GetSession();
        private void GetUserInformation()
        {
            string DBCon = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
            SqlConnection sqlConnect = new SqlConnection(DBCon);

            string Query = "SELECT Name,FirstName,ShortName, AccountNumber FROM InvestorProfile WHERE AccountNumber='"+ session.AccountNumber +"' ";

            SqlCommand sqlCmd = new SqlCommand(Query, sqlConnect);
            try
            {
                sqlConnect.Open();
                SqlDataReader rdr = sqlCmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        lblUserName.Text = rdr["Name"].ToString();
                        
                    }

                    Session["AccountName"] = lblUserName.Text;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnect.Close();
                sqlConnect.Dispose();
            }
        }

        [WebMethod]
        public static void Logout ()
        {
            GetSession.DistroySession();
            //if (Session["AccountNumber"] == null)                                                                               
            //{
            //    Response.Redirect("LoginPage.aspx");
            //}
        }

        
    }
}
