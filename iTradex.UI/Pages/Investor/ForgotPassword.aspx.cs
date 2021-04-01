using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTradex.UI.App_Code;
using System.Data;
using System.Configuration;
using BOSLCommonClassLib;

namespace iTradex.UI.Pages.Investor
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    if (Request.QueryString["e"] != null && Request.QueryString["e"] != "0")
            //        ResetPassword();
            //}
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            CommonFunction cm = new CommonFunction();
            string Email = Request.Form["Email"];
            string AccountNumber = Request.Form["AccountNumber"];
            string emailAccounCheck = "SELECT UserID ,AccountNumber FROM ApplicationUser WHERE UserID='" + Email + "' AND AccountNumber='" + AccountNumber + "'";
            DataTable dtemailAccounCheck = cm.GetDatatable(emailAccounCheck);
            if (dtemailAccounCheck.Rows.Count > 0)
            {
                //SendLinkReset();
                ResetPassword();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Information Does not Match');window.location='../../Default.aspx';</script>'");
            }

        }

        /// <summary>
        /// Send email with Reset Link
        /// </summary>
        private void SendLinkReset()
        {
            string userName = "";
            CommonFunction cmRegistration = new CommonFunction();

            RijndaelEncryption encryption = new RijndaelEncryption();

            string Email = Request.Form["Email"].ToString();
            string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
            string accountNumber = Request.Form["AccountNumber"];
            string encriptedEmail = encryption.EncryptText(Email, encryptionKey);
            string encriptedAccount = encryption.EncryptText(accountNumber, encryptionKey);
            //string accountNumber = encryption.EncryptText((Request.Form["AccountNumber"].ToString()), encryptionKey);

            string cmdUserName = "SELECT Distinct Name FROM InvestorProfile where AccountNumber='" + accountNumber + "'";
            DataTable dtUserName = cmRegistration.GetDatatable(cmdUserName);
            if (dtUserName.Rows.Count > 0)
            {
                foreach (DataRow dr in dtUserName.Rows)
                {
                    userName = dr["Name"].ToString();
                }
            }

            try
            {
                BOSLEmailer3 sendEmail = new BOSLEmailer3();

                string siteUrl = ConfigurationManager.AppSettings["SiteUrl"];
                string emailMessage = "Hi " + userName + ",<br/>" + "We received a password reset request for your iTradeX account. To reset your password, use the links below:<br/>";
                string message = emailMessage + "<br/><b>Reset your password using a web browser:</b><br/>"
                    + "<a href='" + siteUrl + "Pages/Investor/ForgotPassword.aspx?" + "e=" + encriptedEmail + "&a=" + encriptedAccount + "'>Reset Password</a>"
                    + "<br/><br/>If you didn't request a password reset, you can ignore this message and your password will not be changed, someone"
                    + "probably typed in your username or email address by accident.<br/><br/>-The iTradeX Team";

            

                //sendEmail.AttachmentPath=;
                sendEmail.AuthenticationMode = 1;
                sendEmail.Body = message;
                //sendEmail.Cc=;
                sendEmail.From = ConfigurationManager.AppSettings["From"];
                //sendEmail.id=userId;
                sendEmail.IsHtml = Convert.ToBoolean(ConfigurationManager.AppSettings["IsHtml"]);
                sendEmail.IsUseSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["IsUseSSL"]);
                sendEmail.Password = ConfigurationManager.AppSettings["Password"];
                sendEmail.PortNum = Convert.ToInt32(ConfigurationManager.AppSettings["PortNum"]);
                sendEmail.SendUsing = Convert.ToInt32(ConfigurationManager.AppSettings["SendUsing"]);
                sendEmail.SMTPServer = ConfigurationManager.AppSettings["SMTPServer"];
                sendEmail.Subject = "Forgotten password request from iTradeX";
                sendEmail.To = Email;
                sendEmail.UserName = ConfigurationManager.AppSettings["UserName"];
                sendEmail.SendEmail();

                //sconRegistration.Close();
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Please Check Your Email. Click On The Link To Reset You Password.');window.location='../../Default.aspx';</script>'");
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Mail server is currently unavailable. "+ex.Message+"');window.location='../../Default.aspx';</script>'");
            }
        }
        /// <summary>
        /// Reset Password Operation
        /// </summary>
        private void ResetPassword()
        {
            try
            {
                //Random rnd = new Random();
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

                string Email = Request.Form["Email"].ToString();
                string accountNumber = Request.Form["AccountNumber"];


                //if (string.IsNullOrEmpty(Email))
                //    return;
                if (Email != null)
                {
                    SendMailWithPassword(rndPassword, Email, accountNumber);
                   
                }
                CommonFunction cmAcctivation = new CommonFunction();
                string acctivationQuery = "update ApplicationUser set Password='" + encriptedPassword + "' where(UserID='" + Email + " ' and AccountNumber='" + accountNumber + "' )";

                cmAcctivation.InsertQuery(acctivationQuery);
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Your Password Has Reset Successfully, Please Check Your Email For New Password.');window.location='../../Default.aspx';</script>'");
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Mail server is currently unavailable. Please contact with your broker');window.location='../../Default.aspx';</script>'");
            }
        }

        /// <summary>
        /// Send Mail With reset Password
        /// </summary>
        private void SendMailWithPassword(string resetPassword, string Email, string AccountNumber)
        {
            RijndaelEncryption encryption = new RijndaelEncryption();
            string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
            CommonFunction cmRegistration = new CommonFunction();

            string userName = "";
            string newPassword = resetPassword;
            string email = Email;
            string accountNumber = AccountNumber;

            string cmdUserName = "SELECT Distinct Name FROM InvestorProfile where AccountNumber='" + accountNumber + "'";
            DataTable dtUserName = cmRegistration.GetDatatable(cmdUserName);
            if (dtUserName.Rows.Count > 0)
            {
                foreach (DataRow dr in dtUserName.Rows)
                {
                    userName = dr["Name"].ToString();
                }
            }

            try
            {
                BOSLEmailer3 sendEmail = new BOSLEmailer3();

                //string siteUrl = ConfigurationManager.AppSettings["SiteUrl"];
                string emailMessage = "Dear " + userName + ",<br/><br/>" + "iTradeX has reset your password as you have requested.<br/>";
                string message = emailMessage + "<br/><b>Your new password is:</b><br/>"
                    + "Password: " + newPassword + "<br/><br/>You can also change your password again after login.<br/><br/>";

                //sendEmail.AttachmentPath=;
                sendEmail.AuthenticationMode = 1;
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
                sendEmail.Subject = "Forgotten Password Reset on iTradex";
                sendEmail.To = email;
                sendEmail.UserName = ConfigurationManager.AppSettings["UserName"];
                sendEmail.SendEmail();

                //sconRegistration.Close();
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('iTradeX has reset your password. Please Check Your Email.');window.location='../../Default.aspx';</script>'");
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Mail server is currently unavailable. "+ex.Message+"');window.location='../../Default.aspx';</script>'");
            }
        }
    }
}