using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using iTradex.UI.App_Code;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.Services;

namespace iTradex.UI.Pages.Investor
{
    public partial class Logout : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AccountNumber"] == null)
                {
                    Response.Redirect("../../Default.aspx");
                }
                GetSession session = new GetSession();
                String AccountNumber = session.AccountNumber;
                SqlConnection sqlConnect = DatabaseConnection.GetConnection();
                String Query = "Update ApplicationUser set IsLogin='False' where (AccountNumber='" + AccountNumber + "')";
                SqlCommand sqlCmd = new SqlCommand(Query, sqlConnect);
                sqlCmd.ExecuteNonQuery();

                //Response.Cookies["loginCookies"].Expires = Session.Timeout;
                Response.Cookies.Clear();

                Session.Abandon();
                Session.Clear();
                Response.Redirect("../../Default.aspx");
            }
            catch (FormatException ex)
            {
                throw ex;
            }
        }

    }
}