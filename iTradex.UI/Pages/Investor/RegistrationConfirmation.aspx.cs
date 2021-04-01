using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using iTradex.UI.App_Code;
using System.Data;
using System.Configuration;
using BOSLCommonClassLib;

namespace iTradex.UI.Pages.Investor
{
    public partial class RegistrationConfirmation : System.Web.UI.Page
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
                    ShowBrokerData();
                }
            }
            catch (FormatException ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }

        private void ShowBrokerName()
        {
            try
            {
                GetSession session = new GetSession();
                Label lblBrokerName = this.Master.FindControl("PlaceHolder1").FindControl("lblUserName") as Label;
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

        /// <summary>
        /// For Showing Broker Data On DataTable
        /// </summary>
        private void ShowBrokerData()
        {
            try
            {
                GetSession session = new GetSession();
                string brokerRef = session.BrokerRef;
                CommonFunction cmDataTable = new CommonFunction();
                //string query = "select UserID, AccountNumber,BONumber from ApplicationUser where (BrokerRef='"+brokerRef+"' and IsRegistered='true' and IsActive='false')";
                string query = "select UserID, AccountNumber,BONumber,Status from ApplicationUser where Status='Pending'";

                DataTable dtShowBrokerData = cmDataTable.GetDatatable(query);
                rptShowBrokerData.DataSource = dtShowBrokerData;
                rptShowBrokerData.DataBind();
            }

            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }

        }


        /// <summary>
        /// For IsActive True
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnActive_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        GetSession session = new GetSession();
        //        foreach (RepeaterItem rpt in rptShowBrokerData.Items)
        //        {
        //            CheckBox chkAcctive = (CheckBox)rpt.FindControl("chkAcctive");
        //            Label lblUserID = (Label)rpt.FindControl("lblUserID");
        //            Label lblAccountNumber = (Label)rpt.FindControl("lblAccountNumber");
        //            Label lblBONumber = (Label)rpt.FindControl("lblBONumber");
        //            string userId = lblUserID.Text;
        //            string accountNumber = lblAccountNumber.Text;
        //            string boNumber = lblBONumber.Text;
        //            if (chkAcctive.Checked == true)
        //            {
        //                CommonFunction cmActiveInvestor = new CommonFunction();
        //                //SqlConnection sconActiveBrokerData = DatabaseConnection.GetConnection();
        //                string query = "update ApplicationUser set Status='Active' where(IsRegistered='true'"
        //                + "and status='Pending' and UserID='" + userId + "' and AccountNumber='" + accountNumber + "' and BONumber='" + boNumber + "')";

        //                cmActiveInvestor.InsertQuery(query);
        //            }

        //            else
        //                continue;
        //        }
        //        ShowBrokerData();
        //    }

        //    catch (Exception ex)
        //    {
        //        Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace)); 
        //    }
        //}

        //private void ShowBrokerNameOnSuccessModal()
        //{ 

        //     try
        //    {

        //        string brokerRef = Session["BrokerRef"].ToString();
        //        //SqlConnection sconShowBrokerName = DatabaseConnection.GetConnection();
        //        CommonFunction cmDataTable = new CommonFunction();
        //        string query = "select BrokerName from Broker where (Reference='" + brokerRef + "')";
        //        //SqlCommand cmdBrokerName = new SqlCommand(query,sconShowBrokerName);
        //        //SqlDataAdapter sdaShowBrokerName = new SqlDataAdapter(cmdBrokerName);
        //        //sconShowBrokerName.Close();
        //        DataTable dtBrokerName = cmDataTable.GetDatatable(query);
        //        //sdaShowBrokerName.Fill(dtBrokerName);

        //        if (dtBrokerName.Rows.Count > 0)
        //        {

        //            lblInvestorname.Text = dtBrokerName.Rows[0]["BrokerName"].ToString();
        //        }

        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}


        protected void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                GetSession session = new GetSession();
                foreach (RepeaterItem rpt in rptShowBrokerData.Items)
                {
                    CheckBox chkAcctive = (CheckBox)rpt.FindControl("chkAcctive");
                    Label lblUserID = (Label)rpt.FindControl("lblUserID");
                    Label lblAccountNumber = (Label)rpt.FindControl("lblAccountNumber");
                    Label lblBONumber = (Label)rpt.FindControl("lblBONumber");
                    Label lblStatus = (Label)rpt.FindControl("lblStatus");
                    string userId = lblUserID.Text;
                    string accountNumber = lblAccountNumber.Text;
                    string boNumber = lblBONumber.Text;
                    string status = lblStatus.Text;
                    if (chkAcctive.Checked == true)
                    {
                        CommonFunction cmVerifyAccount = new CommonFunction();
                        string verifyAccount = "select BONumber,AccountNumber,Email from InvestorProfile where"
                        + "(BONumber='" + boNumber + "' and AccountNumber='" + accountNumber + "' and Email='" + userId + "' )";


                        DataTable dtCheck = cmVerifyAccount.GetDatatable(verifyAccount);

                        if (dtCheck.Rows.Count > 0)
                        {
                            Registration(userId, accountNumber, boNumber, status);
                            string script = "alert('Verified Completed. An email has sent to the verified investor for activating account.');";
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                        }


                        else
                        {
                            CommonFunction cmRegistration = new CommonFunction();

                            string query = "update ApplicationUser set Status='Rejected' where(IsRegistered='false'"
                              + "and status='Pending' and UserID='" + userId + "' and AccountNumber='" + accountNumber + "' and BONumber='" + boNumber + "')";

                            cmRegistration.InsertQuery(query);
                        }
                    }
                }
                ShowBrokerData();
            }

            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }



        private void Registration(string email, string accNumber, string bo, string status)
        {
            Random rnd = new Random();
            string number = rnd.Next(1000, 9999).ToString();
            CommonFunction cmRegistration = new CommonFunction();

            RijndaelEncryption encryption = new RijndaelEncryption();

            string userId = email;
            string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];

            string accountNumber = accNumber;

            string boNumber = bo;
            string encriptedUserId = encryption.EncryptText(userId, encryptionKey);
            string encriptedAccount = encryption.EncryptText(accountNumber, encryptionKey);
            string pinNumber = encryption.EncryptText(number, encryptionKey);

            try
            {
                string userName = "";
                //string insertQuery = "insert into ApplicationUser(UserID,Password,BrokerRef,BONumber,AccountNumber,"
                //+"SecretQuestion,SecretAnswer,LastLoginTime,IsActive,IsLogin,IsRegistered,UserType,PinNumber)"
                //+"Values('" + userId + "','" + password + "','" + ddlBroker.SelectedValue + "','" + boNumber + "','" + accountNumber + "','" + ddlSecreteQuestion.SelectedItem.Text + "','" + secreteAnswer + "','" + DateTime.Now + "','false','false','false','Investor','" + pinNumber + "')";


                string cmdUserName = "SELECT Distinct Name FROM InvestorProfile where AccountNumber='" + accountNumber + "'";
                DataTable dtUserName = cmRegistration.GetDatatable(cmdUserName);
                if (dtUserName.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtUserName.Rows)
                    {
                        userName = dr["Name"].ToString();
                    }
                }

                BOSLEmailer3 sendEmail = new BOSLEmailer3();

                string siteUrl = ConfigurationManager.AppSettings["SiteUrl"];
                string emailMessage = "Hi " + userName + ",<br/>" + "One more step to activate your account on iTradeX. Just click on the link below:<br/>";

                string message = emailMessage + "<a href='" + siteUrl + "Default.aspx?" + "e=" + encriptedUserId + "&a=" + encriptedAccount + "&n=" + pinNumber + "'>Registration Acctivation</a>" + "<br/> Your secret PIN number for Fund Withdraw Request is " + number + "";

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
                sendEmail.Subject = ConfigurationManager.AppSettings["EmailSubjectForRegistration"];
                sendEmail.To = userId;
                sendEmail.UserName = ConfigurationManager.AppSettings["UserName"];
                sendEmail.SendEmail();

                //sconRegistration.Close();

                //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Your Account Has successfully Registered, Please Check Your Email For Activate Your Account');window.location='RegAndLogin.aspx';</script>'");


                string query = "update ApplicationUser set Status='Verified',PinNumber='" + pinNumber + "' where(IsRegistered='false'"
                  + "and status='Pending' and UserID='" + userId + "' and AccountNumber='" + accountNumber + "' and BONumber='" + boNumber + "')";

                cmRegistration.InsertQuery(query);
                //Response.Redirect("LoginPage.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void textBox_TextChanged(object sender, EventArgs e)
        {
            GetSession session = new GetSession();
            RijndaelEncryption encryption = new RijndaelEncryption();
            string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
            string oldPassword = encryption.EncryptText(txtOldPassword.Text, encryptionKey);
            try
            {
                CommonFunction cm = new CommonFunction();
                string password = "select Password from ApplicationUser where UserId='" + session.UserName + "'  and password='" + oldPassword + "'";

                DataTable dtpassword = cm.GetDatatable(password);

                if (dtpassword.Rows.Count > 0)
                {
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

            try
            {
                GetSession session = new GetSession();
                RijndaelEncryption encryption = new RijndaelEncryption();
                string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
                string newPassword = encryption.EncryptText(txtNewPassord.Text, encryptionKey);
                string oldPassword = encryption.EncryptText(txtOldPassword.Text, encryptionKey);
                CommonFunction cmSaveData = new CommonFunction();
                string updatePassword = "update ApplicationUser set Password='" + newPassword + "' where(UserID='" + session.UserName + " ')";
                cmSaveData.InsertQuery(updatePassword);
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Password change successfully');</script>'");
            }

            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }

        }


        //protected void btnResend_Click(object sender, EventArgs e)
        //{
        //    GetSession session = new GetSession();
        //    try
        //    {

        //        foreach (RepeaterItem rpt in rptShowBrokerData.Items)
        //        {
        //            CheckBox chkChecked = (CheckBox)rpt.FindControl("chkChecked");
        //            if (chkChecked.Checked == true)
        //            {
        //                //string password="";
        //                string userName = "";


        //                Label accountRef = (Label)rpt.FindControl("lblAccountNumber");
        //                string accountNumber = accountRef.Text;

        //                Label userId = (Label)rpt.FindControl("lblUserId");
        //                string UserId = userId.Text;

        //                Random rnd = new Random();
        //                string number = rnd.Next(1000, 9999).ToString();

        //                CommonFunction cmResendEmail = new CommonFunction();


        //                //string cmdPassword="select password from ApplicationUser where AccountNumber='"+accountNumber+"'"
        //                //DataTable dtPassword= cmResendEmail.GetDatatable(cmdPassword);
        //                //if (dtPassword.Rows.Count > 0)
        //                //{
        //                //    foreach (DataRow dr in dtPassword.Rows)
        //                //    {
        //                //       password  = dr["Password"].ToString();
        //                //    }
        //                //}



        //                string cmdUserName = "SELECT Distinct Name FROM InvestorProfile where AccountNumber='" + accountNumber + "'";
        //                DataTable dtUserName = cmResendEmail.GetDatatable(cmdUserName);
        //                if (dtUserName.Rows.Count > 0)
        //                {
        //                    foreach (DataRow dr in dtUserName.Rows)
        //                    {
        //                        userName = dr["Name"].ToString();
        //                    }
        //                }





        //                RijndaelEncryption encryption = new RijndaelEncryption();
        //                string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
        //                string encryptedPinNumber = encryption.EncryptText(number, encryptionKey);
        //                //string encryptedPassword=  encryption.EncryptText(password, encryptionKey);
        //                string encryptedAccountNumber = encryption.EncryptText(accountNumber, encryptionKey);
        //                string encriptedUserId = encryption.EncryptText(UserId, encryptionKey);


        //                CommonFunction cmActiveInvestor = new CommonFunction();
        //                string query = "UPDATE ApplicationUser SET PinNumber ='" + encryptedPinNumber + "' WHERE AccountNumber='" + accountNumber + "'";
        //                cmActiveInvestor.InsertQuery(query);


        //                BOSLEmailer3 sendEmail = new BOSLEmailer3();

        //                string siteUrl = ConfigurationManager.AppSettings["SiteUrl"];
        //                string emailMessage = "Hi " + userName + ",<br/>" + "One more step to verify your email address on iTradeX. Just click on the link below:<br/>";

        //                string message = emailMessage + "<a href='" + siteUrl + "Default.aspx?" + "e=" + encriptedUserId + "&a=" + encryptedAccountNumber + "&n=" + encryptedPinNumber + "'>Registration Acctivation</a>" + "<br/> Your secret PIN number for Fund Withdraw Request is " + number + "";

        //                //sendEmail.AttachmentPath=;
        //                sendEmail.AuthenticationMode = 1;
        //                sendEmail.Body = message;
        //                //sendEmail.Cc=;
        //                sendEmail.From = ConfigurationManager.AppSettings["From"];
        //                //sendEmail.id=userId;
        //                sendEmail.IsHtml = Convert.ToBoolean(ConfigurationManager.AppSettings["IsHtml"]);                   //System.Configuration.ConfigurationManager.AppSettings.Get("IsHtml");
        //                sendEmail.IsUseSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["IsUseSSL"]);
        //                sendEmail.Password = ConfigurationManager.AppSettings["Password"];
        //                sendEmail.PortNum = Convert.ToInt32(ConfigurationManager.AppSettings["PortNum"]);
        //                sendEmail.SendUsing = Convert.ToInt32(ConfigurationManager.AppSettings["SendUsing"]);
        //                sendEmail.SMTPServer = ConfigurationManager.AppSettings["SMTPServer"];
        //                sendEmail.Subject = ConfigurationManager.AppSettings["EmailSubjectForRegistration"];
        //                sendEmail.To = UserId;
        //                sendEmail.UserName = ConfigurationManager.AppSettings["UserName"];
        //                sendEmail.SendEmail();


        //                string script = "alert('An email has sent to the investor.');";
        //                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
        //            }

        //            else
        //                continue;
        //        }

        //        ShowBrokerData();
        //    }

        //    catch (Exception ex)
        //    {
        //        Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
        //    }
        //}


    }
}