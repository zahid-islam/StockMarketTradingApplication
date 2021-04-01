using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTradex.UI.App_Code;
using System.Data;
using System.Data.SqlClient;
using BOSLCommonClassLib;
using System.Configuration;

namespace iTradex.UI.Pages.Investor
{
    public partial class SystemAdmin : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lblInvestorname.Text = "System Admin";
            ShowBrokerData();
        }

        private void ShowSystemAdminName()
        {
            Label lblBrokerName = this.Master.FindControl("PlaceHolder1").FindControl("lblUserName") as Label;
            lblBrokerName.Text = "System Admin";
        }

        /// <summary>
        /// For showing System Admin Name On Header
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ShowSystemAdminName();
        }

        /// <summary>
        ///  Show Broker Data On DataTable
        /// </summary>
        
        private void ShowBrokerData()
        {
            CommonFunction cmDataTable = new CommonFunction();
            string query = "select MemberID,BrokerName,DSEID,CSEID,CDBLID,ExchangeID from Broker";
            DataTable dtBroker = cmDataTable.GetDatatable(query);
            rptShowBrokerData.DataSource = dtBroker;
            rptShowBrokerData.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
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

            if (prefix == string.Empty && memberID == string.Empty  && boID == string.Empty && brokerName == string.Empty && cdblID == string.Empty && address == string.Empty && telephone == string.Empty && fax == string.Empty && web == string.Empty && email == string.Empty && dseID==string.Empty && cseID==string.Empty)
            {
                return;
            }
        
            else
            {
                try
                {
                    CommonFunction cmSaveData = new CommonFunction();
                    string insertQuery = "insert into Broker(Prefix,MemberID,DSEID,CSEID,BOID,BrokerName,CDBLID,Address,Telephone,Fax,Email,Web,Reference) Values('" + prefix + "','" + memberID + "','" + dseID + "','" + cseID + "','" + boID + "','" + brokerName + "','" + cdblID + "','" + address + "','" + telephone + "','" + fax + "','" + email + "','" + web + "',NEWID())";
                    cmSaveData.InsertQuery(insertQuery);
                    SendPassword ();
                    //ShowBrokerData();
                    ClearField();
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Broker is successfully created');window.location='SystemAdmin.aspx';</script>'");
                }

                catch (Exception ex)
                {
                    Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace)); 
                }
            }
        }

        private void ClearField()
        {
            txtPrefix.Text = "";
            txtMemberID.Text = "";
            //txtExchangeID.Text = "";
            txtBOID.Text = "";
            //txtMigrationDate.Text="";
            //txtReference.Text="";
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

        private void SendPassword()
        {
            Random rnd = new Random();
            string number = rnd.Next(10000000,99999999).ToString();

            RijndaelEncryption encryption = new RijndaelEncryption();

            string memberID = txtMemberID.Text;
            string userId = txtEmail.Text;
            string boID = txtBOID.Text;
            string brokerName = txtBrokerName.Text;
            string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
            string password = encryption.EncryptText(number,encryptionKey);
            string encriptedUserId = encryption.EncryptText(userId,encryptionKey);
            try
            {
                CommonFunction cmSaveData = new CommonFunction();
                string insertQuery = "insert into ApplicationUser(UserId,AccountNumber,BONumber,UserType,Password,IsRegistered,IsActive,IsLogin) Values('" + userId + "','" + memberID + "','" + boID + "','Broker','" + password + "','True','True','False')";
                cmSaveData.InsertQuery(insertQuery);

                BOSLEmailer3 sendEmail = new BOSLEmailer3();

                string siteUrl = ConfigurationManager.AppSettings["SiteUrl"];
                string emailMessage = ConfigurationManager.AppSettings["Message"];
                string message = "Your secret password is "+number+". " + "<a href='" + siteUrl + "Pages/Investor/LoginPage.aspx?" +"'>Please Login</a>" + "";
                //string message = emailMessage + "<a href='http://localhost:2268/Pages/Investor/LoginPage.aspx?E="+encriptedUserId+"&a="+encriptedAccount+"'>Registration Acctivation</a>";
                //string message = emailMessage + "<a href='"+siteUrl +"+"e="+"+encryption.EncryptText(userId, "1")+"' >Registration Acctivation</a>";
                //string message = emailMessage + "<a href=http://localhost:2268/Pages/Investor/LoginPage.aspx?E="+encriptedUserId+"> Registration Acctivation</a>";

                //sendEmail.AttachmentPath=;
                sendEmail.AuthenticationMode = 1;
                sendEmail.Body = message;
                //sendEmail.Cc=;
                sendEmail.From = ConfigurationManager.AppSettings["From"];
                //sendEmail.id=userId;
                sendEmail.IsHtml = Convert.ToBoolean(ConfigurationManager.AppSettings["IsHtml"]);                   //System.Configuration.ConfigurationManager.AppSettings.Get("IsHtml");
                sendEmail.IsUseSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["IsUseSSL"]);
                sendEmail.Password = ConfigurationManager.AppSettings["Password"];
                sendEmail.PortNum = Convert.ToInt32(ConfigurationManager.AppSettings["PortNum"]);
                sendEmail.SendUsing = Convert.ToInt32(ConfigurationManager.AppSettings["SendUsing"]);
                sendEmail.SMTPServer = ConfigurationManager.AppSettings["SMTPServer"];
                sendEmail.Subject = "Registration";
                sendEmail.To = userId;
                sendEmail.UserName = ConfigurationManager.AppSettings["UserName"];
                sendEmail.SendEmail();
            }

            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace)); 
            }
        }
    } 
}