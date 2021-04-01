using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTradex.UI.App_Code;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using iTradex.UI.Report;
using System.Configuration;
using BOSLCommonClassLib;
using System.Globalization;

namespace iTradex.UI.Pages.Investor
{
    public partial class FundWithdrawRequestBroker : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AccountNumber"] == null)
                {
                    Response.Redirect("../../Default.aspx");
                }

                //string request = null;
                //if (!IsPostBack)
                //{

                //    if(!string.IsNullOrEmpty(request))

                //    {
                //        ShowData("", "", "");
                //    }


                //}


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
            GetSession session = new GetSession();
            ShowBrokerName();
        }

        /// <summary>
        /// populate Datatable of fund withdraw request.
        /// </summary>
        private void ShowData(string status, string fromdate, string todate)
        {
            try
            {
                GetSession session = new GetSession();
                CommonFunction cmDataTable = new CommonFunction();
                string showAddData = "select AccountRef,TransactionDate,YourReference,TotalAmount,TotalVat,NetAmount,PaymentType,Status,Reference from TransactionHead where Status='" + status + "' and TransactionDate between '" + fromdate + "' and '" + todate + "' order by TransactionDate,AccountRef";
                DataTable dtInstrument = cmDataTable.GetDatatable(showAddData);
                rptFundWithdrawRequest.DataSource = dtInstrument;
                rptFundWithdrawRequest.DataBind();

                foreach (RepeaterItem rpt in rptFundWithdrawRequest.Items)
                {
                    HiddenField hf = (HiddenField)rpt.FindControl("HiddenField1");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace)); 
            }
        }
        /// <summary>
        /// Fund withdrawal accept Action
        /// </summary>
        /// <param name="sender"></param>
        protected void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                GetSession session = new GetSession();
                string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
                foreach (RepeaterItem rpt in rptFundWithdrawRequest.Items)
                {
                    CheckBox chkAcctive = (CheckBox)rpt.FindControl("chkAcctive");
                    if (chkAcctive.Checked == true)
                    {
                        Label accountRef = (Label)rpt.FindControl("lblAccountRef");
                        Label Amount = (Label)rpt.FindControl("lblNetAmount");
                        Label TrnDate = (Label)rpt.FindControl("lblTrnDate");
                        HiddenField hf = (HiddenField)rpt.FindControl("HiddenField1");
                        string userRef = hf.Value;
                        string accountReference = accountRef.Text;

                        CommonFunction cmActiveInvestor = new CommonFunction();
                        string query = "update TransactionHead set Status='Accepted' where(AccountRef='" + accountReference + "' and Status='Request' and Reference='" + userRef + "')";
                        cmActiveInvestor.InsertQuery(query);
                        SendMail(accountReference, currentMethod, Amount.Text, TrnDate.Text);
                    }

                    else
                        continue;
                }
                ShowData(ViewState["status"].ToString(), ViewState["fromDate"].ToString(), ViewState["toDate"].ToString());
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
        protected void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                GetSession session = new GetSession();
                string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
                foreach (RepeaterItem rpt in rptFundWithdrawRequest.Items)
                {
                    CheckBox chkAcctive = (CheckBox)rpt.FindControl("chkAcctive");
                    if (chkAcctive.Checked == true)
                    {
                        Label accountRef = (Label)rpt.FindControl("lblAccountRef");
                        Label Amount = (Label)rpt.FindControl("lblNetAmount");
                        Label TrnDate = (Label)rpt.FindControl("lblTrnDate");
                        HiddenField hf = (HiddenField)rpt.FindControl("HiddenField1");
                        string userRef = hf.Value;
                        string accountReference = accountRef.Text;

                        CommonFunction cmActiveInvestor = new CommonFunction();
                        string query = "update TransactionHead set Status='Rejected' where(AccountRef='" + accountReference + "' and Status='Request' and Reference='" + userRef + "')";

                        cmActiveInvestor.InsertQuery(query);
                        SendMail(accountReference, currentMethod, Amount.Text, TrnDate.Text);
                    }

                    else
                        continue;
                }

                ShowData(ViewState["status"].ToString(), ViewState["fromDate"].ToString(), ViewState["toDate"].ToString());
            }

            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace)); 
            }
        }
        /// <summary>
        /// Send mail for accept or reject
        /// </summary>
        /// <param name="AccountNumber"></param>
        private void SendMail(string AccountNumber, string MethodName, string Amount, string TrnDate)
        {
            string userName = "";
            string email = "";
            string mainMsg = "";
            GetSession session = new GetSession();
            if (MethodName == "btnReject_Click")
            {
                mainMsg = "rejected. Please contact with your borker";
            }
            else if (MethodName == "btnAccept_Click")
            {
                mainMsg = "accepted. Please contact with your borker";
            }

            CommonFunction cmUser = new CommonFunction();
            string cmdUserName = "SELECT Distinct Name, Email FROM InvestorProfile where AccountNumber='" + AccountNumber + "'";

            DataTable dtUserName = cmUser.GetDatatable(cmdUserName);
            if (dtUserName.Rows.Count > 0)
            {
                foreach (DataRow dr in dtUserName.Rows)
                {
                    userName = dr["Name"].ToString();
                    email = dr["Email"].ToString();
                }
            }
            BOSLEmailer3 sendEmail = new BOSLEmailer3();
            string emailMessage = "Hi " + userName + ",<br/>Your fund withdrawal request on " + TrnDate + " for taka " + Amount + " has " + mainMsg + ".";
            string message = emailMessage;

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
            sendEmail.Subject = "Fund Withdrawal Request On iTradeX";
            sendEmail.To = email;
            sendEmail.UserName = ConfigurationManager.AppSettings["UserName"];
            sendEmail.SendEmail();

            //sconRegistration.Close();
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            // ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('An Email Has Sent To Investor.');window.location='FundWithdrawRequestBroker.aspx';</script>'");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "openModal();", true);
        }
        /// <summary>
        /// Report generate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                GetSession session = new GetSession();
                string databaseDateFormat = "yyyy/MM/dd";
                string status = ViewState["status"].ToString();
                string fromDate = DateTime.ParseExact(Request.Form["rangeBa"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat); 
                string toDate = DateTime.ParseExact(Request.Form["rangeBb"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat); 
                ReportDocument oWithdrawalBrokerRequest = new ReportDocument();
                //CrystalReportDataSet ds = new CrystalReportDataSet();
                oWithdrawalBrokerRequest.Load(Server.MapPath(@"..\..\WithdrawalRequest.rpt"));
                Session["ReportName"] = "WithdrawalRequest";
                WithdrawalBrokerRequestLoader oLoder = new WithdrawalBrokerRequestLoader(status, fromDate, toDate, oWithdrawalBrokerRequest);

                ReportDocument rd = (ReportDocument)oLoder.GetReportSource();
                Session["ReportDocumentObj"] = rd;

                ResponseHelper.Redirect(Response, "ReportViwer.aspx", "_blank", "menubar=0,width=800,height=600");
            }

            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace)); 
               
            }
        }

        protected void textBox_TextChanged(object sender, EventArgs e)
        {
            RijndaelEncryption encryption = new RijndaelEncryption();
            string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
            string oldPassword = encryption.EncryptText(txtOldPassword.Text, encryptionKey);
            try
            {
                GetSession session = new GetSession();
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



            try
            {
                GetSession session = new GetSession();
                RijndaelEncryption encryption = new RijndaelEncryption();
                string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
                string newPassword = encryption.EncryptText(txtNewPassord.Text, encryptionKey);
                string oldPassword = encryption.EncryptText(txtOldPassword.Text, encryptionKey);
                CommonFunction cmSaveData = new CommonFunction();
                string updatePassword = "update ApplicationUser set Password='" + newPassword + "' where(UserID='" + session.UserName + " ' )";
                cmSaveData.InsertQuery(updatePassword);
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Password change successfully');</script>'");
            }

            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace)); 
            }

        }


        protected void btnSubmitDate_Click(object sender, EventArgs e)
        {
            try
            {
                GetSession session = new GetSession();
                string rangeA = Request.Form["rangeBa"];
                string rangeB = Request.Form["rangeBb"];
                if (rangeA == string.Empty || rangeB == string.Empty)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('please select date');window.location='FundWithdrawRequestBroker.aspx';</script>'");
                }

                else
                {
                    string databaseDateFormat = "yyyy/MM/dd";

                    string dateFrom = DateTime.ParseExact(Request.Form["rangeBa"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                    string dateTo = DateTime.ParseExact(Request.Form["rangeBb"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                    string status = ViewState["status"].ToString();
                    ViewState["fromDate"] = dateFrom;
                    ViewState["toDate"] = dateTo;
                    if (status == "Request")
                    {
                        ShowData(status, dateFrom, dateTo);
                        btnAccept.Visible = true;
                        btnReject.Visible = true;
                        btnResendEmail.Visible = false;

                    }

                    else if (status == "Accepted")
                    {

                        ShowData(status, dateFrom, dateTo);
                        btnAccept.Visible = false;
                        btnReject.Visible = false;
                        btnResendEmail.Visible = true;
                    }

                    else if (status == "Rejected")
                    {
                        ShowData(status, dateFrom, dateTo);
                        btnAccept.Visible = false;
                        btnReject.Visible = false;
                        btnResendEmail.Visible = true;
                    }

                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('" + ex.Message + "');window.location='FundWithdrawRequestBroker.aspx';</script>'");

            }
        }

        protected void ddlStatus_TextChanged(object sender, EventArgs e)
        {
            ViewState["status"] = ddlStatus.SelectedItem.Text;

        }

        protected void btnResendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                GetSession session = new GetSession();

                foreach (RepeaterItem rpt in rptFundWithdrawRequest.Items)
                {
                    CheckBox chkAcctive = (CheckBox)rpt.FindControl("chkAcctive");
                    if (chkAcctive.Checked == true)
                    {
                        Label accountRef = (Label)rpt.FindControl("lblAccountRef");
                        Label Amount = (Label)rpt.FindControl("lblNetAmount");
                        Label TrnDate = (Label)rpt.FindControl("lblTrnDate");
                        HiddenField hf = (HiddenField)rpt.FindControl("HiddenField1");
                        string userRef = hf.Value;
                        string accountReference = accountRef.Text;
                        SendMail(accountReference, ViewState["status"].ToString(), Amount.Text, TrnDate.Text);
                    }

                    else
                        continue;
                }
                ShowData(ViewState["status"].ToString(), ViewState["fromDate"].ToString(), ViewState["toDate"].ToString());
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('An email has sent to the user');</script>'");

            }

            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));

            }
        }


    }
}