using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTradex.UI.App_Code;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace iTradex.UI
{
    public partial class BrokerInformation : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AccountNumber"] == null)
                {
                    Response.Redirect("../../Default.aspx");
                }
                if (!IsPostBack)
                {
                    ShowBrokerInformation();
                }
            }
            catch (FormatException ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace)); 
            }
        }

        private void ShowBrokerName()
        {
            GetSession session = new GetSession();
            try
            {
                Label lblBrokerName = this.Master.FindControl("PlaceHolder1").FindControl("lblUserName") as Label;
                //string brokerRef = Session["BrokerRef"].ToString();
                CommonFunction cmDataTable = new CommonFunction();

                string query = "select BrokerName from Broker";

                DataTable dtBrokerName = cmDataTable.GetDatatable(query);
                if (dtBrokerName.Rows.Count > 0)
                {
                    lblBrokerName.Text = dtBrokerName.Rows[0]["BrokerName"].ToString();
                }

            }

            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace)); 
            
            }
        }

        /// <summary>
        /// For showing Broker Name On Header
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ShowBrokerName();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetSession session = new GetSession();
            string prefix = txtPrefix.Text;
            string memberID = txtMemberID.Text;
            string boID = txtBOID.Text;
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
                string brokerRef = Session["BrokerRef"].ToString();
                SqlConnection sconUpdate = DatabaseConnection.GetConnection();
                //string updateQuery = "update Broker set Prefix='" + prefix + "',MemberID='" + memberID + "',DSEID='" + dseID + "', CSEID='"+cseID+"',BOID='" + boID + "',BrokerName='" + brokerName + "',CDBLID='" + cdblID + "',Address='" + address + "',Telephone='" + telephone + "',Fax='" + fax + "',Email='" + email + "',Web='" + web + "' where Reference='" + brokerRef + "'";
                string updateQuery = "update Broker set Prefix='" + prefix + "',MemberID='" + memberID + "',DSEID='" + dseID + "', CSEID='" + cseID + "',BOID='" + boID + "',BrokerName='" + brokerName + "',CDBLID='" + cdblID + "',Address='" + address + "',Telephone='" + telephone + "',Fax='" + fax + "',Email='" + email + "',Web='" + web + "' where Email='" + session.UserName + "'";
                SqlCommand cmdUpdate = new SqlCommand(updateQuery, sconUpdate);
                cmdUpdate.ExecuteNonQuery();
                sconUpdate.Close();
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Update Successfully');window.location='BrokerInformation.aspx';</script>'");

            }

            catch (Exception ex)
            {

                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace)); 
            }
        }

        private void ClearField()
        {
            txtPrefix.Text = "";
            txtMemberID.Text = "";
            //txtExchangeID.Text = "";
            txtBOID.Text = "";
            //txtMigrationDate.Text="";
            //txtReference.Text = "";
            txtBrokerName.Text = "";
            txtCDBLID.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtFax.Text = "";
            txtTelephone.Text = "";
            txtWeb.Text = "";
            txtDSEID.Text = "";
            txtCSEID.Text = "";
        }

        private void ShowBrokerInformation()
        {
            GetSession session = new GetSession();
            try
            {
                //string brokerRef = session.BrokerRef;
                CommonFunction cmDataTable = new CommonFunction();
                //string query = "select Prefix,MemberID,ExchangeID,BOID,BrokerName,Web,CDBLID,Address,Telephone,Fax,Email,DSEID,CSEID from Broker where (Reference='" + brokerRef + "')";
                string query = "select Prefix,MemberID,ExchangeID,BOID,BrokerName,Web,CDBLID,Address,Telephone,Fax,Email,DSEID,CSEID from Broker where Email='" + session.UserName + "'";
                DataTable dtBrokerName = cmDataTable.GetDatatable(query);
                foreach (DataRow dr in dtBrokerName.Rows)
                {
                    txtPrefix.Text = dr["Prefix"].ToString();
                    txtMemberID.Text = dr["MemberID"].ToString();
                    //txtExchangeID.Text = dr["ExchangeID"].ToString();
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
                }
            }

            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace)); 
            }
        }

        protected void textBox_TextChanged(object sender, EventArgs e)
        {
            GetSession session = new GetSession();
            RijndaelEncryption encryption = new RijndaelEncryption();
            string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
            string pass = txtOldPassword.Text;
            string oldPassword = encryption.EncryptText(txtOldPassword.Text, encryptionKey);
            try
            {
                CommonFunction cm = new CommonFunction();
                string password = "select Password from ApplicationUser where UserId='" + session.UserName + "' and BONumber='" + session.BoNumber + "' and password='" + oldPassword + "'";

                DataTable dtpassword = cm.GetDatatable(password);

                if (dtpassword.Rows.Count > 0)
                {
                    txtOldPassword.Text = pass;
                    txtNewPassord.ReadOnly = false;
                    txtConfirmPassword.ReadOnly = false;
                    lblMessage.Text = "";
                }

                else
                {
                    
                    txtNewPassord.ReadOnly = true;
                    txtConfirmPassword.ReadOnly = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Password does not match";
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace)); 
            }
        }

        protected void btnPasswordChange_Click(object sender, EventArgs e)
        {
            GetSession session = new GetSession();

                try
                {
                    RijndaelEncryption encryption = new RijndaelEncryption();
                    string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
                    string newPassword = encryption.EncryptText(txtNewPassord.Text, encryptionKey);
                    string oldPassword = encryption.EncryptText(txtOldPassword.Text, encryptionKey);
                    CommonFunction cmSaveData = new CommonFunction();
                    string updatePassword = "update ApplicationUser set Password='" + newPassword + "' where(UserID='" + session.UserName + " ')";
                    cmSaveData.InsertQuery(updatePassword);
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Password change successfully');window.location='BrokerInformation.aspx';</script>'");
                }

                catch (Exception ex)
                {
                    Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace)); 
                }
          
        }
    }
}