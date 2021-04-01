using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using iTradex.UI.App_Code;
using System.Data;
using System.Text;
using BOSLCommonClassLib;
using System.Configuration;
using System.Web.Configuration;


namespace iTradex.UI.Pages.Investor
{
    public partial class RegAndLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showBrokerName();
            }

            pnlMessage.Visible = false;
            pnlLoginMessage.Visible = false;

        }

        /// <summary>
        /// For Showing Broker Name On DroDownList
        /// </summary>
        private void showBrokerName()
        {
            try
            {
                CommonFunction cmDataTable = new CommonFunction();

                string showBrokerNameQuery = "select Distinct Reference,BrokerName from Broker order by BrokerName";
                DataTable dtshowBrokerName = cmDataTable.GetDatatable(showBrokerNameQuery);
                ddlBroker.DataSource = dtshowBrokerName;

                ddlBroker.DataTextField = "BrokerName";
                ddlBroker.DataValueField = "Reference";
                ddlBroker.DataBind();
            }

            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }

        /// <summary>
        /// Registration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegistration_Click(object sender, EventArgs e)
        {
            try
            {
                RijndaelEncryption encryption = new RijndaelEncryption();

                //string userId = Request.Form["Email"].ToString();
                string userId = txtEmail.Text;
                string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
                string password = encryption.EncryptText((Request.Form["password"].ToString()), encryptionKey);
                string boNumber = txtPrefix.Text + txtBONumber.Text;
                string accountNumber = txtAccountNumber.Text;
                string secreteAnswer = txtSecretAnswer.Text;

                //CommonFunction cmEmailCheck = new CommonFunction();
                ////string emailCheckQuery = "select UserID from ApplicationUser where(UserID='" + userId + "' and AccountNumber='" + accountNumber + "' and BONumber='" + boNumber + "' AND Password='" + password + "')";
                //string emailCheckQuery = "select UserID from ApplicationUser where"
                //    +"(UserID='" + userId + "' and AccountNumber='" + accountNumber + "' and BONumber='" + boNumber + "')";

                //DataTable dtEmailCheck = cmEmailCheck.GetDatatable(emailCheckQuery);

                //if (dtEmailCheck.Rows.Count > 0)
                //{
                //    //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert(' This account is already exist. Please contact with System Admin');window.location='RegAndLogin.aspx';</script>'");
                //    pnlMessage.Visible = true;
                //    lblShowMessage.Text = "This account is already exist. Please contact with System Admin";
                //}

                //else
                //{
                //    if (ddlBroker.SelectedIndex > 0)
                //    {
                //        CommonFunction cmCheckBoAndAccountNo = new CommonFunction();
                //        string boAndAccountCheck = "select BONumber,AccountNumber,Email from InvestorProfile where"
                //            +"(BONumber='" + boNumber + "' and AccountNumber='" + accountNumber + "' and Email='" + userId + "' )";

                //        DataTable dtCheck = cmCheckBoAndAccountNo.GetDatatable(boAndAccountCheck);

                //        if (dtCheck.Rows.Count > 0)
                //        {
                //            Registration();
                //        }
                //        else
                //        {
                //            //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Information Does not Match');window.location='RegAndLogin.aspx';</script>'");
                //            pnlMessage.Visible = true;
                //            lblShowMessage.Text = "Information does not match. Please enter the correct one";
                //        }
                //    }
                //    else
                //    {
                //        //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Please Select Broker Name');window.location='RegAndLogin.aspx';</script>'");
                //        pnlMessage.Visible = true;
                //        lblShowMessage.Text = "Please Select Broker Name from the broker list";
                //    }
                //}

                CommonFunction cmEmailCheck = new CommonFunction();
                //string emailCheckQuery = "select UserID from ApplicationUser where(UserID='" + userId + "' and AccountNumber='" + accountNumber + "' and BONumber='" + boNumber + "' AND Password='" + password + "')";
                string emailCheckQuery = "select AccountNumber from ApplicationUser where "
                    + "AccountNumber='" + accountNumber + "' and BONumber='" + boNumber + "'";

                DataTable dtEmailCheck = cmEmailCheck.GetDatatable(emailCheckQuery);

                if (dtEmailCheck.Rows.Count > 0)
                {
                    pnlMessage.Visible = true;
                    lblShowMessage.Text = "This account is already exist. Please contact with Your Broker";

                }

                else
                {
                    CommonFunction cmRegistration = new CommonFunction();
                    string checkQuery = "select UserID from ApplicationUser where (UserID='" + userId + "' AND Password='" + password + "')";
                    DataTable dtEmailPass = cmRegistration.GetDatatable(checkQuery);

                    CommonFunction cm = new CommonFunction();
                    string insertQuery = "insert into ApplicationUser(UserID,Password,BrokerRef,BONumber,AccountNumber,"
                    + "SecretQuestion,SecretAnswer,LastLoginTime,IsActive,IsRegistered,UserType,RegistrationTime,Status)"
                    + "Values('" + userId + "','" + password + "','" + ddlBroker.SelectedValue + "','" + boNumber + "','" + accountNumber + "','" + ddlSecreteQuestion.SelectedItem.Text + "','" + secreteAnswer + "','" + DateTime.Now + "','false','false','Investor','" + DateTime.Now + "','Pending')";

                    cm.InsertQuery(insertQuery);
                    pnlLoginMessage.Visible = true;
                    lblLoginMessage.Text = "Your Account Has successfully Registered. You will get an email from your broker for activating account within 3 working days.";

                    //if (dtEmailPass.Rows.Count > 0)
                    //{
                    //    //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('This Email and Password Already Exist.Please Try Another Password.');window.location='RegAndLogin.aspx';</script>'");
                    //    pnlMessage.Visible = true;
                    //    lblShowMessage.Text = "This Email and Password already exist. Please try another password.";
                    //}

                    //else
                    //{
                    //    CommonFunction cm = new CommonFunction();
                    //    string insertQuery = "insert into ApplicationUser(UserID,Password,BrokerRef,BONumber,AccountNumber,"
                    //    + "SecretQuestion,SecretAnswer,LastLoginTime,IsActive,IsRegistered,UserType,RegistrationTime,Status)"
                    //    + "Values('" + userId + "','" + password + "','" + ddlBroker.SelectedValue + "','" + boNumber + "','" + accountNumber + "','" + ddlSecreteQuestion.SelectedItem.Text + "','" + secreteAnswer + "','" + DateTime.Now + "','false','false','Investor','" + DateTime.Now + "','Pending')";

                    //    cm.InsertQuery(insertQuery);
                    //    pnlLoginMessage.Visible = true;
                    //    lblLoginMessage.Text = "Your Account Has successfully Registered. You will get an email from your broker for activating account within 3 working days.";

                    //}

                }
            }

            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }

        }

        private void Registration()
        {
            Random rnd = new Random();
            string number = rnd.Next(1000, 9999).ToString();
            CommonFunction cmRegistration = new CommonFunction();
            if (Session["CAPTCHA"].ToString().Equals(txtInput.Text))
            {
                RijndaelEncryption encryption = new RijndaelEncryption();

                //string userId = Request.Form["Email"].ToString();
                string userId = txtEmail.Text;
                string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
                string password = encryption.EncryptText((Request.Form["password"].ToString()), encryptionKey);
                //string accountNumber = Request.Form["AccountNumber"].ToString();
                string accountNumber = txtAccountNumber.Text;
                //string secreteAnswer = Request.Form["SecreteAnswer"].ToString();
                string secreteAnswer = txtSecretAnswer.Text;
                //string boNumber = Request.Form["BONumber"].ToString();
                string boNumber = txtPrefix.Text + txtBONumber.Text;
                string encriptedUserId = encryption.EncryptText(userId, encryptionKey);
                string encriptedAccount = encryption.EncryptText(accountNumber, encryptionKey);
                string pinNumber = encryption.EncryptText(number, encryptionKey);

                string emailCheckQuery = "select UserID from ApplicationUser where(UserID='" + userId + "' AND Password='" + password + "')";
                DataTable dtEmailPass = cmRegistration.GetDatatable(emailCheckQuery);
                if (dtEmailPass.Rows.Count > 0)
                {
                    //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('This Email and Password Already Exist.Please Try Another Password.');window.location='RegAndLogin.aspx';</script>'");
                    pnlMessage.Visible = true;
                    lblShowMessage.Text = "This Email and Password already exist. Please try another password.";
                }

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
                    string emailMessage = "Hi " + userName + ",<br/>" + "One more step to verify your email address on iTradeX. Just click on the link below:<br/>";

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
                    pnlLoginMessage.Visible = true;
                    lblLoginMessage.Text = "Your Account Has successfully Registered, Please Check Your Email For Activate Your Account";

                    string insertQuery = "insert into ApplicationUser(UserID,Password,BrokerRef,BONumber,AccountNumber,"
                    + "SecretQuestion,SecretAnswer,LastLoginTime,IsActive,IsRegistered,UserType,PinNumber,RegistrationTime,Status)"
                    + "Values('" + userId + "','" + password + "','" + ddlBroker.SelectedValue + "','" + boNumber + "','" + accountNumber + "','" + ddlSecreteQuestion.SelectedItem.Text + "','" + secreteAnswer + "','" + DateTime.Now + "','false','false','Investor','" + pinNumber + "','" + DateTime.Now + "','Pending')";

                    cmRegistration.InsertQuery(insertQuery);
                    //Response.Redirect("LoginPage.aspx");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            else
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('No Match Found From Captcha Input');window.location='RegAndLogin.aspx';</script>'");
                pnlMessage.Visible = true;
                lblShowMessage.Text = "No match found from captcha input. Please enter the correct one";
            }
        }


        /// <summary>
        ///   Load Broker Prefix Using DropDownList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        //protected void ddlBroker_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        CommonFunction cmDataTable = new CommonFunction();
        //        string selectQuery = "select Prefix from Broker where (BrokerName='" + ddlBroker.SelectedItem.Text + "') ";
        //        DataTable dtShowData = cmDataTable.GetDatatable(selectQuery);

        //        if (dtShowData.Rows.Count > 0)
        //        {
        //            txtPrefix.Text = dtShowData.Rows[0]["Prefix"].ToString(); 
        //        }

        //        else
        //        {
        //            txtPrefix.Text = string.Empty;
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;

        //    }

        //}

        protected void ddlBroker_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CommonFunction cmDataTable = new CommonFunction();
                string selectQuery = "select Prefix from Broker where (BrokerName='" + ddlBroker.SelectedItem.Text + "') ";
                DataTable dtShowData = cmDataTable.GetDatatable(selectQuery);

                if (dtShowData.Rows.Count > 0)
                {
                    txtPrefix.Text = dtShowData.Rows[0]["Prefix"].ToString();
                }

                else
                {
                    txtPrefix.Text = string.Empty;
                }
            }

            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));

            }
        }

    }
}