using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTradex.UI.App_Code;

namespace iTradex.UI.Pages.Investor
{
    public partial class LoginErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string ex = Request.QueryString["ex"];
                string st = Request.QueryString["st"];

                
                CommonFunction cmSaveData = new CommonFunction();
                string insertQuery = "insert into ErrorLog (DateTime,Details) Values('" + DateTime.Now + "','" + st + "')";
                cmSaveData.InsertQuery(insertQuery);

                lblMsg.Text = ex;
                lblst.Text = st;
        
               }

            catch (Exception ex)
            {
                string eex = Request.QueryString["ex"];
                string st = Request.QueryString["st"];
                lblMsg.Text = ex.Message;
                lblst.Text = st;
            }

            }

           

          
        }
    }