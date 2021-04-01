using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTradex.UI.App_Code;
using System.Data;
using System.Data.SqlClient;

namespace iTradex.UI.Pages.Investor
{
    public partial class PopUpAddForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string memberID = Request.QueryString["ID"].ToString();
                    CommonFunction cmDataTable = new CommonFunction();
                    string query = "select Prefix,MemberID,BOID,BrokerName,Web,CDBLID,Address,Telephone,Fax,Email,Reference,DSEID,CSEID from Broker where (MemberID='" + memberID + "')";
                    DataTable dtBrokerName = cmDataTable.GetDatatable(query);
                    foreach (DataRow dr in dtBrokerName.Rows)
                    {
                        txtPrefix.Text = dr["Prefix"].ToString();
                        txtMemberID.Text = dr["MemberID"].ToString();
                        txtDSEID.Text = dr["DSEID"].ToString();
                        txtCSEID.Text = dr["CSEID"].ToString();
                        txtBOID.Text = dr["BOID"].ToString();
                        txtBrokerName.Text = dr["BrokerName"].ToString();
                        txtWeb.Text = dr["Web"].ToString();
                        txtCDBLID.Text = dr["CDBLID"].ToString();
                        txtAddress.Text = dr["Address"].ToString();
                        txtTelephone.Text = dr["Telephone"].ToString();
                        txtFax.Text = dr["Fax"].ToString();
                        txtEmail.Text = dr["Email"].ToString();
                        Session["Ref"] = dr["Reference"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace)); 
            
            }
          
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string reference = HttpContext.Current.Session["Ref"].ToString();
            string prefix = txtPrefix.Text;
            string memberID = txtMemberID.Text;
            //string exchangeID = txtExchangeID.Text;
            string boID = txtBOID.Text;
            //string migrationDate = txtMigrationDate.Text;
            //string reference = txtReference.Text;
            string brokerName = txtBrokerName.Text;
            string cdblID = txtCDBLID.Text;
            string address = txtAddress.Text;
            string telephone = txtTelephone.Text;
            string fax = txtFax.Text;
            string email = txtEmail.Text;
            string web = txtWeb.Text;
            string dseID = txtDSEID.Text;
            string cseID = txtCSEID.Text;


            try
            {
                SqlConnection sconUpdate = DatabaseConnection.GetConnection();
                string updateQuery = "update Broker set Prefix='" + prefix + "',MemberID='" + memberID + "',DSEID='" + dseID + "',CSEID='" + cseID + "',BOID='" + boID + "',BrokerName='" + brokerName + "',CDBLID='" + cdblID + "',Address='" + address + "',Telephone='" + telephone + "',Fax='" + fax + "',Email='" + email + "',Web='" + web + "' where Reference='" + reference + "'";
                SqlCommand cmdUpdate = new SqlCommand(updateQuery, sconUpdate);
                cmdUpdate.ExecuteNonQuery();
                sconUpdate.Close();
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Update Successfully');</script>'");
                //ScriptManager.RegisterClientScriptBlock(Page, GetType(), "close", "window.close();", true);
                ClientScript.RegisterStartupScript(GetType(), "CLOSE", "<script language='javascript'> opener.location.href = 'SystemAdmin.aspx'; window.close(); </script>");
                //ClientScript.RegisterStartupScript(GetType(), "CLOSE", "<script language='javascript'> opener.location.href = 'http://istockbroking.com/itradex/Pages/Investor/SystemAdmin.aspx'; window.close(); </script>");
            }

            catch (Exception ex)
            {

                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace)); 
            }

        }


    }


}
