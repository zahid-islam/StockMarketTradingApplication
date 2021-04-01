using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iTradex.UI.App_Code;
using BOSLCommonClassLib;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using iTradex.UI.Report;
using System.Globalization;

namespace iTradex.UI.Pages.Investor
{
    public partial class OrderBroker : System.Web.UI.Page
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
                    ShowData();
                   
                   
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
            Label lblBrokerName = this.Master.FindControl("PlaceHolder1").FindControl("lblUserName") as Label;
            CommonFunction cmDataTable = new CommonFunction();
            string query = "select BrokerName from Broker";
            DataTable dtBrokerName = cmDataTable.GetDatatable(query);

            if (dtBrokerName.Rows.Count > 0)
            {
                lblBrokerName.Text = dtBrokerName.Rows[0]["BrokerName"].ToString();
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


        protected void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                GetSession session = new GetSession();
                string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
                foreach (RepeaterItem rpt in rptAllOrder.Items)
                {
                    CheckBox chkAcctive = (CheckBox)rpt.FindControl("chkAcctive");
                    if (chkAcctive.Checked == true)
                    {

                        HiddenField hf = (HiddenField)rpt.FindControl("HiddenField1");
                        string orderRef = hf.Value;
                        Label accountRef = (Label)rpt.FindControl("lblAccountRef");
                        string accountReference = accountRef.Text;
                        Label transactionDate = (Label)rpt.FindControl("lblTransactionDate");
                        string tranDate = transactionDate.Text;
                        Label instrument = (Label)rpt.FindControl("lblInstrument");
                        string instrumentName = instrument.Text;
                        Label shareRate = (Label)rpt.FindControl("lblRate");
                        string rate = shareRate.Text;
                        Label shareQuantity = (Label)rpt.FindControl("lblShareQuantity");
                        string quantity = shareQuantity.Text;
                        CommonFunction cmdAcceptOrder = new CommonFunction();
                        string query = "update TradeOrderFromWeb set Status='Submitted' where(Reference='" + orderRef + "' and InvestorACRef='" + accountReference + "')";
                        cmdAcceptOrder.InsertQuery(query);
                        SendMail(accountReference, currentMethod, accountReference, tranDate, instrumentName, rate, quantity);
                        ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('An Email Has Sent To Investor.');window.location='OrderBroker.aspx';</script>'");
                    }

                    else
                        continue;
                }
                ShowData();
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
                foreach (RepeaterItem rpt in rptAllOrder.Items)
                {
                    CheckBox chkAcctive = (CheckBox)rpt.FindControl("chkAcctive");
                    if (chkAcctive.Checked == true)
                    {
                        HiddenField hf = (HiddenField)rpt.FindControl("HiddenField1");
                        string orderRef = hf.Value;
                        Label accountRef = (Label)rpt.FindControl("lblAccountRef");
                        string accountReference = accountRef.Text;
                        Label transactionDate = (Label)rpt.FindControl("lblTransactionDate");
                        string tranDate = transactionDate.Text;
                        Label instrument = (Label)rpt.FindControl("lblInstrument");
                        string instrumentName = instrument.Text;
                        Label shareRate = (Label)rpt.FindControl("lblRate");
                        string rate = shareRate.Text;
                        Label shareQuantity = (Label)rpt.FindControl("lblShareQuantity");
                        string quantity = shareQuantity.Text;

                        CommonFunction cmdRejectOrder = new CommonFunction();
                        string query = "update TradeOrderFromWeb set Status='Rejected' where(Reference='" + orderRef + "' and InvestorACRef='" + accountReference + "')";

                        cmdRejectOrder.InsertQuery(query);
                        SendMail(accountReference, currentMethod, accountReference, tranDate, instrumentName, rate, quantity);
                        ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('An Email Has Sent To Investor.');window.location='OrderBroker.aspx';</script>'");
                    }

                    else
                        continue;
                }
                ShowData();
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
        private void SendMail(string AccountNumber, string MethodName, string accountReference, string trnDate, string instrumentName, string rate, string quantity)
        {
            GetSession session = new GetSession();
            string userName = "";
            string email = "";
            string orderStatus = "";

            if (MethodName == "btnReject_Click")
            {
                orderStatus = "Rejected";
            }
            else if (MethodName == "btnAccept_Click")
            {
                orderStatus = "Accepted";
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

            string messageBody = ConfigurationManager.AppSettings["EmailBodyForOrder"];
            messageBody = messageBody.Replace("@newLine", "<br/>");
            messageBody = messageBody.Replace("@userName", userName);
            messageBody = messageBody.Replace("@orderStatus", orderStatus);
            messageBody = messageBody.Replace("@trnDate", trnDate);
            messageBody = messageBody.Replace("@instrumentName", instrumentName);
            messageBody = messageBody.Replace("@rate", rate);
            messageBody = messageBody.Replace("@quantity", quantity);




            BOSLEmailer3 sendEmail = new BOSLEmailer3();
            //   string emailMessage = "Dear "+userName+", <br/>Your order place in iTradex has been " + orderStatus + ". Order details are bellow : <br/> Order Date - " + trnDate + " <br/> Instrument Name - " + instrumentName + " <br/>Share Rate - " + rate + " <br/> Share Quantity - " + quantity + "";

            string message = messageBody;

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
            sendEmail.Subject = ConfigurationManager.AppSettings["Subject"];
            sendEmail.To = email;
            sendEmail.UserName = ConfigurationManager.AppSettings["UserName"];
            sendEmail.SendEmail();

            //sconRegistration.Close();


            //Response.Redirect("LoginPage.aspx");
        }

   

        private void ShowData()
        {
            try
            {
                GetSession session = new GetSession();
                CommonFunction cmDataTable = new CommonFunction();
                string showAddData = "select InvestorACRef, Reference,Instrument,TransactionType,ShareQuantity,Rate,Status,TransactionTime,TransactionDate from TradeOrderFromWeb WHERE TransactionDate = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' and status='Pending' order by TransactionTime,InvestorACRef,Instrument ";

                DataTable dtAllOrders = cmDataTable.GetDatatable(showAddData);
                dtAllOrders.Columns.Add("TotalAmount", typeof(decimal));
                foreach (DataRow dr in dtAllOrders.Rows)
                {
                    double total = 0;
                    total = total + (Double.Parse(dr["ShareQuantity"].ToString()) * Double.Parse(dr["Rate"].ToString()));
                    dr["TotalAmount"] = total.ToString();
                }
                rptAllOrder.DataSource = dtAllOrders;
                rptAllOrder.DataBind();


                foreach (RepeaterItem rpt in rptAllOrder.Items)
                {
                    HiddenField hf = (HiddenField)rpt.FindControl("HiddenField1");
                }
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
                    if (status == "Pending")
                    {
                        //ShowData(status, dateFrom, dateTo);
                        btnAccept.Visible = true;
                        btnReject.Visible = true;

                    }

                    else if (status == "Accepted")
                    {
                        status = "Submitted";
                        // ShowData(status, dateFrom, dateTo);
                        btnAccept.Visible = false;
                        btnReject.Visible = false;

                    }

                    else if (status == "Rejected")
                    {
                        // ShowData(status, dateFrom, dateTo);
                        btnAccept.Visible = false;
                        btnReject.Visible = false;
                    }

                    CommonFunction cmDataTable = new CommonFunction();
                    string showAddData = "select InvestorACRef, Reference,Instrument,TransactionType,ShareQuantity,Rate,Status,TransactionTime,TransactionDate from TradeOrderFromWeb WHERE TransactionDate between '" + dateFrom + "' and '" + dateTo + "' and status='" + status + "' order by TransactionTime,InvestorACRef,Instrument ";

                    DataTable dtAllOrders = cmDataTable.GetDatatable(showAddData);
                    dtAllOrders.Columns.Add("TotalAmount", typeof(decimal));
                    foreach (DataRow dr in dtAllOrders.Rows)
                    {
                        double total = 0;
                        total = total + (Double.Parse(dr["ShareQuantity"].ToString()) * Double.Parse(dr["Rate"].ToString()));
                        dr["TotalAmount"] = total.ToString();
                    }
                    rptAllOrder.DataSource = dtAllOrders;
                    rptAllOrder.DataBind();


                    foreach (RepeaterItem rpt in rptAllOrder.Items)
                    {
                        HiddenField hf = (HiddenField)rpt.FindControl("HiddenField1");
                    }

                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('" + ex.Message + "');window.location='OrderBroker.aspx';</script>'");

            }
        }

        protected void ddlStatus_TextChanged(object sender, EventArgs e)
        {
            ViewState["status"] = ddlStatus.SelectedItem.Text;

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                GetSession session = new GetSession();
                string status = ViewState["status"].ToString();
                if (status == "Accepted")
                {
                    status = "Submitted";
                }
                string fromDate = Request.Form["rangeBa"];
                string toDate = Request.Form["rangeBb"];
                ReportDocument oOrderReportDocument = new ReportDocument();
                //CrystalReportDataSet ds = new CrystalReportDataSet();
                oOrderReportDocument.Load(Server.MapPath(@"..\..\OrderReport.rpt"));
                Session["ReportName"] = "List Of Oredrs";
                OrderLoader oLoder = new OrderLoader(status, fromDate, toDate, oOrderReportDocument);

                ReportDocument rd = (ReportDocument)oLoder.GetReportSource();
                Session["ReportDocumentObj"] = rd;

                ResponseHelper.Redirect(Response, "ReportViwer.aspx", "_blank", "menubar=0,width=800,height=600");
            }

            catch (Exception ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));

            }
        }



    }
}