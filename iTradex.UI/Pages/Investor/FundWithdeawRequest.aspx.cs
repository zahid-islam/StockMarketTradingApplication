using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using iTradex.UI.App_Code;
using System.Globalization;
using System.Security.Cryptography;
using System.Net.Mail;
using BOSLCommonClassLib;

namespace iTradex.UI.Pages.Investor
{
    public partial class FundWithdeawRequest : System.Web.UI.Page
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
                    GetAccountBalance();
                    //GetAccountBalance2();
                    ShowData();
                    //btnSave.Visible = false;
                    TimeCheck();
                }
            }
            catch (FormatException ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }

        double availableBalancef = 0.00;
        private void GetAccountBalance2(string paymentType, double balance)
        {
            try
            {
                GetSession session = new GetSession();
                SqlConnection sqlConnect = DatabaseConnection.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("GetClientAccountStatusDetailsAsOn", sqlConnect);
                sqlCmd.CommandTimeout = 120;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.Add("@AccountRef", SqlDbType.VarChar).Value = session.AccountNumber;
                sqlCmd.Parameters.Add("@LedgerDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy/MM/dd");

                SqlDataAdapter sdaClientAccountStatusDetailsAsOn = new SqlDataAdapter(sqlCmd);
                DataTable dtClientAccountStatusDetailsAsOn = new DataTable();
                sdaClientAccountStatusDetailsAsOn.Fill(dtClientAccountStatusDetailsAsOn);
                if (dtClientAccountStatusDetailsAsOn.Rows.Count > 0)
                {
                    TextBox3.Text = dtClientAccountStatusDetailsAsOn.Rows[0]["LedgerBalance"].ToString();
                    availableBalancef = Convert.ToDouble(TextBox3.Text);
                }


                TextBox9.Text = paymentType;
                TextBox1.Text = session.AccountNumber;
                TextBox5.Text = DateTime.Now.ToString("yyyy/MM/dd");
                TextBox8.Text = balance.ToString();

                CommonFunction cmDataTable = new CommonFunction();
                string cmdInvestorName = "select Name, BankName, Branch  from InvestorProfile where(AccountNumber='" + session.AccountNumber + "')";
                DataTable dtInvestorName = cmDataTable.GetDatatable(cmdInvestorName);
                if (dtInvestorName.Rows.Count > 0)
                {
                    TextBox2.Text = dtInvestorName.Rows[0]["Name"].ToString();
                    TextBox6.Text = dtInvestorName.Rows[0]["BankName"].ToString();
                    TextBox7.Text = dtInvestorName.Rows[0]["Branch"].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }

        double availableBalance = 0.00;
        private void GetAccountBalance()
        {
            try
            {
                GetSession session = new GetSession();
                SqlConnection sqlConnect = DatabaseConnection.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("GetClientAccountStatusDetailsAsOn", sqlConnect);
                sqlCmd.CommandTimeout = 120;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.Add("@AccountRef", SqlDbType.VarChar).Value = session.AccountNumber;
                sqlCmd.Parameters.Add("@LedgerDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy/MM/dd");

                SqlDataAdapter sdaClientAccountStatusDetailsAsOn = new SqlDataAdapter(sqlCmd);
                DataTable dtClientAccountStatusDetailsAsOn = new DataTable();
                sdaClientAccountStatusDetailsAsOn.Fill(dtClientAccountStatusDetailsAsOn);
                  if (dtClientAccountStatusDetailsAsOn.Rows.Count > 0)
                    {
                        txtAccountBalance.Text = dtClientAccountStatusDetailsAsOn.Rows[0]["LedgerBalance"].ToString();
                        availableBalance = Convert.ToDouble( txtAccountBalance.Text);
                    }



                txtAccountReference.Text = session.AccountNumber;
                txtTransactionDate.Text = DateTime.Now.ToString("yyyy/MM/dd");

                CommonFunction cmDataTable = new CommonFunction();
                string cmdInvestorName = "select Name, BankName, Branch  from InvestorProfile where(AccountNumber='" + session.AccountNumber + "')";
                DataTable dtInvestorName = cmDataTable.GetDatatable(cmdInvestorName);
                if (dtInvestorName.Rows.Count > 0)
                {
                    txtInvestorName.Text = dtInvestorName.Rows[0]["Name"].ToString();
                    txtBankName.Text = dtInvestorName.Rows[0]["BankName"].ToString();
                    txtBranch.Text = dtInvestorName.Rows[0]["Branch"].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }

        /// <summary>
        ///        Show On Page Load
        /// </summary>
        private void ShowData()
        {
            try
            {
                GetSession session = new GetSession();
                CommonFunction cmDataTable = new CommonFunction();
                string showAddData = "select AccountRef,TransactionDate,YourReference,TotalAmount,TotalVat,NetAmount,PaymentType,Status from TransactionHead where (AccountRef='" + session.AccountNumber + "' and Status='Request') order by TransactionDate";
                DataTable dtInstrument = cmDataTable.GetDatatable(showAddData);
                rptFundWithdrawRequest.DataSource = dtInstrument;
                rptFundWithdrawRequest.DataBind();
            }
            catch (Exception ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }

        /// <summary>
        /// Save and Show
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void btnSave_Click_1st(object sender, EventArgs e)
        {
            GetSession session = new GetSession();
            string accountReference = TextBox1.Text;
            string investorName = TextBox2.Text;
            double accountBalance = Convert.ToDouble(TextBox3.Text);
            string code = Request.Form["confirmCode"];
            string paymentType = TextBox9.Text;
            string transactionDate = TextBox5.Text;
            string bankName = TextBox6.Text;
            string branch = TextBox7.Text;
            string withdrawAmount = TextBox8.Text;
            string cheque = " ";

            if (Global.GlobalValueRandom == code)
            {


                if (transactionDate == string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "ValidateDate();", true);
                }
                else
                {
                    if (withdrawAmount == string.Empty)
                    {
                        //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('please enter withdrawl ammount');window.location='FundWithdeawRequest.aspx';</script>'");
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "WithdrawlAmmount();", true);
                    }

                    else
                    {
                        double withdrawlAmmount = Convert.ToDouble(withdrawAmount);
                        if (accountBalance >= withdrawlAmmount)
                        {
                            try
                            {
                                CommonFunction cmSaveData = new CommonFunction();
                                string insertQuery = "insert into TransactionHead(NetAmount,TransactionCreated,Description,AccountRef,Status,BankBranch,CreatedBy,TransactionDate,LastUpdated,TranType,Reference,TotalAmount,TransactionTypeCode,OurReference,PaymentType,YourReference,TransactionType,BankName) Values('" + withdrawlAmmount + "','" + DateTime.Now.ToString() + "','Fund Deposit by A/C: " + accountReference + " Ref: " + cheque + "','" + accountReference + "','Request','" + branch + "','" + investorName + "','" + transactionDate + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "','P ',NEWId(),'" + withdrawlAmmount + "','INV-FW ','" + cheque + "','" + ddlPaymentType.SelectedItem.Text + "','" + cheque + "','28','" + bankName + "')";
                                cmSaveData.InsertQuery(insertQuery);

                                CommonFunction cmDataTable = new CommonFunction();
                                string showAddData = "select AccountRef,TransactionDate,YourReference,TotalAmount,TotalVat,NetAmount,PaymentType,Status from TransactionHead where (AccountRef='" + accountReference + "' and Status='Request') order by TransactionDate desc";
                                DataTable dtInstrument = cmDataTable.GetDatatable(showAddData);

                                rptFundWithdrawRequest.DataSource = dtInstrument;
                                rptFundWithdrawRequest.DataBind();

                                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('successfully Saved');window.location='FundWithdeawRequest.aspx';</script>'");

                            }

                            catch (Exception ex)
                            {
                                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
                            }
                        }

                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Withdrawl ammount is greater than ledger balance');window.location='FundWithdeawRequest.aspx';</script>'");

                        }

                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Your entered code is not matched.');window.location='FundWithdeawRequest.aspx';</script>'");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                GetSession session = new GetSession();  
                Random rnd = new Random();
                int myRandomNo = rnd.Next(100000, 999999);

                Global.GlobalValueRandom = myRandomNo.ToString();
                
                string bal = Request.Form["txtWithdrawlAmmount"];
                double balance = Convert.ToDouble(bal);
                string paymentType = ddlPaymentType.SelectedItem.Text;

                string accountReference = session.AccountNumber;
                string name = "";
                string toUser = session.UserName;
                CommonFunction cmDataTable = new CommonFunction();
                string cmdInvestorName = "select Name from InvestorProfile where(AccountNumber='" + session.AccountNumber + "')";
                DataTable dtInvestorName = cmDataTable.GetDatatable(cmdInvestorName);
                if (dtInvestorName.Rows.Count > 0)
                {
                    name = dtInvestorName.Rows[0]["Name"].ToString();
                    //toUser = dtInvestorName.Rows[0]["Email"].ToString();
                }

                BOSLEmailer3 sendEmail = new BOSLEmailer3();

                //string siteUrl = ConfigurationManager.AppSettings["SiteUrl"];
                string message = "Dear " + name + ",<br/><br/>" + "please input this number for your withdrawl request to complete - " + myRandomNo;

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
                sendEmail.Subject = "Transaction confirmation digit on iTradex";
                sendEmail.To = toUser;
                sendEmail.UserName = ConfigurationManager.AppSettings["UserName"];
                sendEmail.SendEmail();
                GetAccountBalance2(paymentType, balance);
                //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Your verification code has sent, Please check your email for code.');</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "openModal3();", true);
            }
            catch (Exception ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }

        //protected void textBox_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        RijndaelEncryption encryption = new RijndaelEncryption();
        //        string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
        //        string pinNumber = encryption.EncryptText(txtPin.Text, encryptionKey);

        //        CommonFunction cm = new CommonFunction();
        //        string matchPin = "select PinNumber from ApplicationUser where UserId='" + session.UserName + "' and AccountNumber='" + session.AccountNumber + "' and PinNumber='" + pinNumber + "' ";

        //        DataTable dtmatchPin = cm.GetDatatable(matchPin);
        //        if (dtmatchPin.Rows.Count > 0)
        //        {
        //            btnSave.Visible = true;
        //        }

        //        else
        //        {
        //            btnSave.Visible = false;
        //            lblMessage.ForeColor = System.Drawing.Color.Red;
        //            lblMessage.Text = "Pin number do not match";
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private void TimeCheck()
        {
            //GetSession session = new GetSession();
            //string now = DateTime.Now.ToString("hh:mm:ss tt", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            //DateTime currentTime = DateTime.Parse(now);
            //string from = ConfigurationManager.AppSettings["FromTime"];
            //DateTime fromTime = DateTime.Parse(from);
            //string to = ConfigurationManager.AppSettings["ToTime"];
            //DateTime toTime = DateTime.Parse(to);
            //if (currentTime >= fromTime && currentTime <= toTime)
            //{
            //    btnAdd.Disabled = false;
            //    pnlMessage.Visible = false;
            //}

            //else
            //{
            //    btnAdd.Disabled = true;
            //    lblShowMessage.Text = "You can post withdraw request from " + from + " to " + to + "";
            //}
        }

        protected void textBox_PasswordTextChanged(object sender, EventArgs e)
        {
            GetSession session = new GetSession();
            RijndaelEncryption encryption = new RijndaelEncryption();
            string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
            string oldPassword = encryption.EncryptText(txtOldPassword.Text, encryptionKey);
            try
            {
                CommonFunction cm = new CommonFunction();

                string password = "select Password from ApplicationUser where UserId='" + session.UserName + "' and AccountNumber='" + session.AccountNumber + "' and password='" + oldPassword + "'";

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
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }

        protected void btnSavePassword_Click(object sender, EventArgs e)
        {
           
                try
                {
                    GetSession session = new GetSession();
                    RijndaelEncryption encryption = new RijndaelEncryption();
                    string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
                    string newPassword = encryption.EncryptText(txtNewPassord.Text, encryptionKey);
                    string oldPassword = encryption.EncryptText(txtOldPassword.Text, encryptionKey);
                    CommonFunction cmSaveData = new CommonFunction();
                    string updatePassword = "update ApplicationUser set Password='" + newPassword + "' where(UserID='" + session.UserName + " ' and AccountNumber='" + session.AccountNumber + "')";
                    cmSaveData.InsertQuery(updatePassword);
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Password change successfully');window.location='FundWithdeawRequest.aspx';</script>'");
                }

                catch (Exception ex)
                {
                    Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
                }
          
        }

        protected void btnCheckPin_Click(object sender, EventArgs e)
        {
           try
           {
               GetSession session = new GetSession();
               if (txtPin.Text == string.Empty)
               {
                   ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Please enter your pin number');window.location='FundWithdeawRequest.aspx';</script>'");
               }

               else
               {
                   RijndaelEncryption encryption = new RijndaelEncryption();
                   string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
                   string pinNumber = encryption.EncryptText(txtPin.Text, encryptionKey);

                   CommonFunction cm = new CommonFunction();
                   string matchPin = "select Password from ApplicationUser where UserId='" + session.UserName + "' and AccountNumber='" + session.AccountNumber + "' and Password='" + pinNumber + "' ";

                   DataTable dtmatchPin = cm.GetDatatable(matchPin);
                   if (dtmatchPin.Rows.Count > 0)
                   {
                       //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModal();", true);
                       ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                   }

                   else
                   {
                       ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Pin number is incorrect. Please enter the correct one');window.location='FundWithdeawRequest.aspx';</script>'");
                       //lblMessage.ForeColor = System.Drawing.Color.Red;
                       //lblMessage.Text = "Pin number do not match";
                   }
               }

             
           }

           catch (Exception ex)
           {
               Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }

        
        }

        //protected void textBox_PinChange(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        RijndaelEncryption encryption = new RijndaelEncryption();
        //        string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
        //        string pinNumber = encryption.EncryptText(txtPin.Text, encryptionKey);

        //        CommonFunction cm = new CommonFunction();
        //        string matchPin = "select PinNumber from ApplicationUser where UserId='" + session.UserName + "' and AccountNumber='" + session.AccountNumber + "' and PinNumber='" + pinNumber + "' ";

        //        DataTable dtmatchPin = cm.GetDatatable(matchPin);
        //        if (dtmatchPin.Rows.Count > 0)
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModal();", true);
        //            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        //        }

        //        else
        //        {
                   
        //            lblMessage.ForeColor = System.Drawing.Color.Red;
        //            lblMessage.Text = "Pin number do not match";
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

         
        
        //}
    }
}