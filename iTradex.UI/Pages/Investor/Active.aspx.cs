using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using iTradex.UI.App_Code;
using BOSLCommonClassLib;
using System.Configuration;

namespace iTradex.UI.Pages.Investor
{
    public partial class Active : System.Web.UI.Page
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
                    btnAcctive.Visible = false;
                    btnSuspend.Visible = false;
                    btnResetPin.Visible = false;
                    btnResendEmail.Visible = false;

                }



            }
            catch (FormatException ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }

        private void ShowData(string status)
        {
            GetSession session = new GetSession();
            try
            {
                //string brokerRef = Session["BrokerRef"].ToString();
                CommonFunction cmDataTable = new CommonFunction();
                //string query = "select UserID,AccountNumber,BONumber,LastLoginTime from ApplicationUser where (BrokerRef='" + brokerRef + "' and IsRegistered='true' and IsActive='true' and IsLogin='true' and UserType='Investor')";
                string query = "select UserID, AccountNumber, BONumber,Status from ApplicationUser where (status='" + status + "' and UserType='Investor')";

                DataTable dtShowBrokerData = cmDataTable.GetDatatable(query);
                rptShowBrokerData.DataSource = dtShowBrokerData;
                rptShowBrokerData.DataBind();
            }
            catch (Exception ex)
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
                string brokerRef = Session["BrokerRef"].ToString();
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
        //protected void checkAll_click(object sender, EventArgs e)
        //{
        //    foreach (RepeaterItem rpt in rptShowBrokerData.Items)
        //    {
        //        CheckBox chkAll = (CheckBox)rpt.FindControl("chkAll");
        //        CheckBox chkChecked = (CheckBox)rpt.FindControl("chkChecked");
        //        if (chkAll.Checked == true)
        //        {
        //            chkChecked.Checked = true;
        //        }
        //        else if (chkAll.Checked == false)
        //        {
        //            chkChecked.Checked = false;
        //        }

        //    }
        //}
        /// <summary>
        /// Reset Pin Number and send Email
        /// </summary>
        protected void Resetpin_click(object sender, EventArgs e)
        {
            GetSession session = new GetSession();
            string finalString = "";
            string AccountNumber = "";
            string UserId = "";
            try
            {
                foreach (RepeaterItem rpt in rptShowBrokerData.Items)
                {
                    CheckBox chkAll = (CheckBox)rpt.FindControl("chkAll");
                    CheckBox chkChecked = (CheckBox)rpt.FindControl("chkChecked");

                    if (chkChecked.Checked == true)
                    {
                        //Random rnd = new Random();
                        //string rndPin = rnd.Next(1000, 9999).ToString();
                        var chars = "0123456ABCDEFG6789HIJKLMNOPQR456STUVWXYZa234bcdefghijklmno789pqrstuvwxyz";
                        var stringChars = new char[4];
                        var random = new Random();

                        for (int i = 0; i < stringChars.Length; i++)
                        {
                            stringChars[i] = chars[random.Next(chars.Length)];
                        }
                        finalString = new String(stringChars);
                        RijndaelEncryption encryption = new RijndaelEncryption();
                        string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
                        string pinNumberEnc = encryption.EncryptText(finalString, encryptionKey);

                        Label accountNumber = (Label)rpt.FindControl("lblAccountNumber");
                        Label userId = (Label)rpt.FindControl("lblUserId");
                        UserId = userId.Text;
                        AccountNumber = accountNumber.Text.ToString();

                        CommonFunction cmActiveInvestor = new CommonFunction();
                        string query = "UPDATE ApplicationUser SET PinNumber ='" + pinNumberEnc + "' WHERE AccountNumber='" + AccountNumber + "'";
                        cmActiveInvestor.InsertQuery(query);

                        SendMailWithPin(finalString, AccountNumber, UserId);
                        
                    }
                    else
                        continue;
                }
            }

            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }

        /// <summary> 
        /// genarate digit random number as password and send user mail
        /// </summary>
      
        protected void Resetpassword_click(object sender, EventArgs e)
        {

            GetSession session = new GetSession();
            //string finalString = "";
            string AccountNumber = "";
            string UserId = "";
            try
            {
                foreach (RepeaterItem rpt in rptShowBrokerData.Items)
                {
                    CheckBox chkAll = (CheckBox)rpt.FindControl("chkAll");
                    CheckBox chkChecked = (CheckBox)rpt.FindControl("chkChecked");

                    if (chkChecked.Checked == true)
                    {
                        //Random rnd = new Random();
                        //string rndPin = rnd.Next(1000, 9999).ToString();
                        //string rndPassword = rnd.Next(10000000, 99990000).ToString();
                        var chars = "0123456ABCDEFG6789HIJKLMNOPQR456STUVWXYZa234bcdefghijklmno789pqrstuvwxyz";
                        var stringChars = new char[8];
                        var random = new Random();

                        for (int i = 0; i < stringChars.Length; i++)
                        {
                            stringChars[i] = chars[random.Next(chars.Length)];
                        }

                        var rndPassword = new String(stringChars);

                        RijndaelEncryption decreption = new RijndaelEncryption();
                        string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
                        string encriptedPassword = decreption.EncryptText(rndPassword, encryptionKey);

                        //string Email = decreption.DecryptText((Request.QueryString["e"].ToString()), encryptionKey);
                        //string accountNumber = decreption.DecryptText((Request.QueryString["a"].ToString()), encryptionKey);

                        Label accountNumber = (Label)rpt.FindControl("lblAccountNumber");
                        Label userId = (Label)rpt.FindControl("lblUserId");
                        UserId = userId.Text;
                        AccountNumber = accountNumber.Text.ToString();

                        //string Email = Request.Form["Email"].ToString();
                        //string accountNumber = Request.Form["AccountNumber"];


                        //if (string.IsNullOrEmpty(Email))
                        ////    return;
                        //if (UserId != null)
                        //{
                        //    SendMailWithPassword(rndPassword,accountNumber,UserId);

                        //}
                        CommonFunction cmAcctivation = new CommonFunction();
                        string acctivationQuery = "update ApplicationUser set Password='" + encriptedPassword + "' where(UserID='" + UserId + " ' and AccountNumber='" + AccountNumber + "' )";

                        cmAcctivation.InsertQuery(acctivationQuery);

                        SendMailWithPassword(rndPassword, AccountNumber, UserId);
                    }
                    else
                        continue;
                }
            }

            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }

        protected void btnDeletUser_click(object sender, EventArgs e)
        {
            GetSession session = new GetSession();
            //string finalString = "";
            string AccountNumber = "";
            string UserId = "";
            try
            {
                foreach (RepeaterItem rpt in rptShowBrokerData.Items)
                {
                    CheckBox chkAll = (CheckBox)rpt.FindControl("chkAll");
                    CheckBox chkChecked = (CheckBox)rpt.FindControl("chkChecked");

                    if (chkChecked.Checked == true)
                    {
                        Label accountNumber = (Label)rpt.FindControl("lblAccountNumber");
                        Label userId = (Label)rpt.FindControl("lblUserId");
                        UserId = userId.Text;
                        AccountNumber = accountNumber.Text.ToString();

                        CommonFunction cmAcctivation = new CommonFunction();
                        string acctivationQuery = "DELETE FROM ApplicationUser WHERE UserID = '" + UserId + " ' AND AccountNumber = '" + AccountNumber + "'";

                        cmAcctivation.InsertQuery(acctivationQuery);

                        string script = "alert('The selected user has been deleted from iTradex.');";
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                    }
                    else
                        continue;
                }
            }

            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }

        /// <summary>
        /// send email
        /// </summary>
        private void SendMailWithPassword(string passwordNumber, string AccountNumber, string Email)
        {
            GetSession session = new GetSession();
            try
            {

                string userName = "";
                CommonFunction cmUser = new CommonFunction();
                string cmdUserName = "SELECT Distinct Name FROM InvestorProfile where AccountNumber='" + AccountNumber + "'";
                DataTable dtUserName = cmUser.GetDatatable(cmdUserName);
                if (dtUserName.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtUserName.Rows)
                    {
                        userName = dr["Name"].ToString();
                    }
                }
                BOSLEmailer3 sendEmail = new BOSLEmailer3();

                string emailMessage = "Dear " + userName + ",<br/><br/>" + "Your new password is:<br/>";

                string message = emailMessage + "<br/> " + passwordNumber + ".<br/><br/><br/> If you have not requested this change, please call your stock broker immediately.";

                //sendEmail.AttachmentPath=;
                sendEmail.AuthenticationMode = Convert.ToInt32(ConfigurationManager.AppSettings["Authentication"]);//1;
                sendEmail.Body = message;
                //sendEmail.Cc=;
                sendEmail.From = ConfigurationManager.AppSettings["From"];
                //sendEmail.id=userId;
                sendEmail.IsHtml = true;//Convert.ToBoolean(ConfigurationManager.AppSettings["IsHtml"]);
                sendEmail.IsUseSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["IsUseSSL"]);
                sendEmail.Password = ConfigurationManager.AppSettings["Password"];
                sendEmail.PortNum = Convert.ToInt32(ConfigurationManager.AppSettings["PortNum"]);
                sendEmail.SendUsing = Convert.ToInt32(ConfigurationManager.AppSettings["SendUsing"]);
                sendEmail.SMTPServer = ConfigurationManager.AppSettings["SMTPServer"];
                sendEmail.Subject = "Your Password is reset on iTradex";
                sendEmail.To = Email;
                sendEmail.UserName = ConfigurationManager.AppSettings["UserName"];
                sendEmail.SendEmail();

                //sconRegistration.Close();
                string script = "alert('The password of the selected customer is reset and the new password is emailed.');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                // ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Your Pin Number Has Reseted. Please Check Your Mail For New Pin Number.');window.location='Active.aspx';</script>'");
                //Response.Redirect("LoginPage.aspx");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "openModal();", true);

            }

            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace), false);
            }
        }



        /// <summary>
        /// send email
        /// </summary>
        private void SendMailWithPin(string pinNumber, string AccountNumber, string Email)
        {
            GetSession session = new GetSession();
            try
            {

                string userName = "";
                CommonFunction cmUser = new CommonFunction();
                string cmdUserName = "SELECT Distinct Name FROM InvestorProfile where AccountNumber='" + AccountNumber + "'";
                DataTable dtUserName = cmUser.GetDatatable(cmdUserName);
                if (dtUserName.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtUserName.Rows)
                    {
                        userName = dr["Name"].ToString();
                    }
                }
                BOSLEmailer3 sendEmail = new BOSLEmailer3();


                string emailMessage = "Dear " + userName + ",<br/><br/>" + "Your new PIN is:<br/>";

                string message = emailMessage + "<br/> " + pinNumber + ".<br/><br/><br/> If you have not requested this change, please call your stock broker immediately.";

                //sendEmail.AttachmentPath=;
                sendEmail.AuthenticationMode = Convert.ToInt32(ConfigurationManager.AppSettings["Authentication"]);//1;
                sendEmail.Body = message;
                //sendEmail.Cc=;
                sendEmail.From = ConfigurationManager.AppSettings["From"];
                //sendEmail.id=userId;
                sendEmail.IsHtml = true;//Convert.ToBoolean(ConfigurationManager.AppSettings["IsHtml"]);
                sendEmail.IsUseSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["IsUseSSL"]);
                sendEmail.Password = ConfigurationManager.AppSettings["Password"];
                sendEmail.PortNum = Convert.ToInt32(ConfigurationManager.AppSettings["PortNum"]);
                sendEmail.SendUsing = Convert.ToInt32(ConfigurationManager.AppSettings["SendUsing"]);
                sendEmail.SMTPServer = ConfigurationManager.AppSettings["SMTPServer"];
                sendEmail.Subject = "Your PIN is reset on iTradex";
                sendEmail.To = Email;
                sendEmail.UserName = ConfigurationManager.AppSettings["UserName"];
                sendEmail.SendEmail();

                //sconRegistration.Close();
                string script = "alert('The PIN of the selected customer is reset and the new PIN is emailed.');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                // ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Your Pin Number Has Reseted. Please Check Your Mail For New Pin Number.');window.location='Active.aspx';</script>'");
                //Response.Redirect("LoginPage.aspx");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "openModal();", true);

            }

            catch (Exception ex)
            {
                //Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace), false);
                throw ex;
            }
        }


        protected void btnResendEmail_click(object sender, EventArgs e)
        {
            try
            {
                GetSession session = new GetSession();
                foreach (RepeaterItem rpt in rptShowBrokerData.Items)
                {
                    CheckBox chkAcctive = (CheckBox)rpt.FindControl("chkChecked");
                    Label lblUserID = (Label)rpt.FindControl("lblUserId");
                    Label lblAccountNumber = (Label)rpt.FindControl("lblAccountNumber");
                    Label lblBONumber = (Label)rpt.FindControl("lblBONumber");
                    Label lblStatus = (Label)rpt.FindControl("lblStatus");
                    string userId = lblUserID.Text;
                    string accountNumber = lblAccountNumber.Text;
                    string boNumber = lblBONumber.Text;
                    string status = lblStatus.Text;
                    if (chkAcctive.Checked == true)
                    {
                        //CommonFunction cmVerifyAccount = new CommonFunction();
                        //string verifyAccount = "select BONumber,AccountNumber,Email from InvestorProfile where"
                        //+ "(BONumber='" + boNumber + "' and AccountNumber='" + accountNumber + "' and Email='" + userId + "' )";


                        //DataTable dtCheck = cmVerifyAccount.GetDatatable(verifyAccount);

                        //if (dtCheck.Rows.Count > 0)
                        //{
                        //    Registration(userId, accountNumber, boNumber, status);
                        //}

                        Registration(userId, accountNumber, boNumber, status);

                    }
                }

            }

            catch (Exception ex)
            {
                //Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace), false);
                throw ex;
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
                CommonFunction cmActiveInvestor = new CommonFunction();
                string query = "UPDATE ApplicationUser SET PinNumber ='" + pinNumber + "' WHERE AccountNumber='" + accountNumber + "'";
                cmActiveInvestor.InsertQuery(query);

                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('An email has sent to the investor.');window.location='Active.aspx';</script>'");

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
                string password = "select Password from ApplicationUser where UserId='" + session.UserName + "' and password='" + oldPassword + "'";

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

            GetSession session = new GetSession();

            try
            {
                RijndaelEncryption encryption = new RijndaelEncryption();
                string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
                string newPassword = encryption.EncryptText(txtNewPassord.Text, encryptionKey);
                string oldPassword = encryption.EncryptText(txtOldPassword.Text, encryptionKey);
                CommonFunction cmSaveData = new CommonFunction();
                string updatePassword = "update ApplicationUser set Password='" + newPassword + "' where(UserID='" + session.UserName + " '  )";
                cmSaveData.InsertQuery(updatePassword);
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Password change successfully');</script>'");
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }


        protected void btnSubmitDate_Click(object sender, EventArgs e)
        {
            GetSession session = new GetSession();
            try
            {

                //string databaseDateFormat = "yyyy/MM/dd";
                string status = ViewState["status"].ToString();

                if (status == "Active")
                {
                    ShowData(status);
                    btnResetPin.Visible = true;
                    btnSuspend.Visible = true;


                }

                else if (status == "Suspend")
                {

                    ShowData(status);
                    btnAcctive.Visible = true;
                    btnResetPin.Visible = false;
                    btnSuspend.Visible = false;

                }

                else if (status == "Verified")
                {

                    ShowData(status);
                    btnAcctive.Visible = false;
                    btnResetPin.Visible = false;
                    btnSuspend.Visible = false;
                    btnResendEmail.Visible = true;

                }
                else if (status == "Rejected")
                {

                    ShowData(status);
                    btnAcctive.Visible = false;
                    btnResetPin.Visible = false;
                    btnSuspend.Visible = false;
                    btnResendEmail.Visible = false;
                }
            }

            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('"+ ex.Message + "');window.location='Active.aspx';</script>'");

            }
        }

        protected void ddlStatus_TextChanged(object sender, EventArgs e)
        {
            ViewState["status"] = ddlStatus.SelectedItem.Text;

        }


        protected void btnAcctive_Click(object sender, EventArgs e)
        {
            GetSession session = new GetSession();
            try
            {

                foreach (RepeaterItem rpt in rptShowBrokerData.Items)
                {
                    CheckBox chkChecked = (CheckBox)rpt.FindControl("chkChecked");
                    if (chkChecked.Checked == true)
                    {
                        Label accountRef = (Label)rpt.FindControl("lblAccountNumber");
                        string accountNumber = accountRef.Text;

                        CommonFunction cmActiveInvestor = new CommonFunction();
                        string query = "update ApplicationUser set Status='Active' where(AccountNumber='" + accountNumber + "')";

                        cmActiveInvestor.InsertQuery(query);

                        string script = "alert('Account has activated');";
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);

                    }

                    else
                        continue;
                }

                ShowData(ViewState["status"].ToString());

            }

            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }
        /// <summary>
        /// Fund withdrawal reject Action
        /// </summary>
        /// <param name="sender"></param>
        protected void btnSuspend_Click(object sender, EventArgs e)
        {
            GetSession session = new GetSession();
            try
            {

                foreach (RepeaterItem rpt in rptShowBrokerData.Items)
                {
                    CheckBox chkChecked = (CheckBox)rpt.FindControl("chkChecked");
                    if (chkChecked.Checked == true)
                    {
                        Label accountRef = (Label)rpt.FindControl("lblAccountNumber");
                        string accountNumber = accountRef.Text;

                        CommonFunction cmActiveInvestor = new CommonFunction();
                        string query = "update ApplicationUser set Status='Suspend' where(AccountNumber='" + accountNumber + "')";

                        cmActiveInvestor.InsertQuery(query);
                        string script = "alert('Account has suspended');";
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                    }

                    else
                        continue;
                }

                ShowData(ViewState["status"].ToString());
            }

            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace), false);
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

        //                CommonFunction cmActiveInvestor = new CommonFunction();
        //                string query = "UPDATE ApplicationUser SET PinNumber ='" + encryptedPinNumber + "' WHERE AccountNumber='" + accountNumber + "'";
        //                cmActiveInvestor.InsertQuery(query);

        //                string script = "alert('An email has sent to the investor.');";
        //                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
        //            }

        //            else
        //                continue;
        //        }

        //        ShowData(ViewState["status"].ToString());
        //    }

        //    catch (Exception ex)
        //    {
        //        Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace)); 
        //    }
        //}


    }

}
