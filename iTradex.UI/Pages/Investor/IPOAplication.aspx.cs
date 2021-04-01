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
using CrystalDecisions.CrystalReports.Engine;
using iTradex.UI.Report;

namespace iTradex.UI.Pages.Investor
{
    public partial class IPOAplication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Session["AccountNumber"] == null)
                {
                    Response.Redirect("../../Default.aspx");
                }

            }
            catch (FormatException ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }

            if (!IsPostBack)
            {
                showCompanyName();
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

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ShowBrokerName();
        }

        public void ShowData(string status, string company)
        {
            try
            {
                GetSession session = new GetSession();
                CommonFunction cmDataTable = new CommonFunction();
                string showAData = "select AccountNumber,AccountBalance,BONumber,AccountName,Status,CompanyName,IPOReference,Category from IPOApplication where(CompanyName='" + company + "' and Status='" + status + "')";
                DataTable dtshowAData = cmDataTable.GetDatatable(showAData);
                rptIPOApplication.DataSource = dtshowAData;
                rptIPOApplication.DataBind();

                if (status == "Accepted")
                {
                    btnAccept.Visible = false;
                    btnReject.Visible = false;

                }

                else if (status == "Rejected")
                {

                    btnAccept.Visible = false;
                    btnReject.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }

        public void showCompanyName()
        {
            try
            {
                GetSession session = new GetSession();
                if (!IsPostBack)
                {
                    CommonFunction cmDataTable = new CommonFunction();

                    string commandComanyName = "select DISTINCT CompanyName from IPODeclaration where (ExpireDate >='" + DateTime.Today + "') order by CompanyName";

                    DataTable dtComanyName = cmDataTable.GetDatatable(commandComanyName);


                    ddlCompany.DataSource = dtComanyName;

                    ddlCompany.DataTextField = "CompanyName";

                    ddlCompany.DataBind();
                }


            }
            catch (Exception ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));

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
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
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
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }

        }


        protected void btnIPOApplication_Click(object sender, EventArgs e)
        {
            try
            {

                ShowData(ddlStatus.SelectedValue, ddlCompany.SelectedValue);
                if (ddlStatus.SelectedValue == "Accepted" || ddlStatus.SelectedValue == "Rejected")
                {
                    btnResendEmail.Visible = true;
                }

                else
                {
                    btnResendEmail.Visible = false;
                }

            }

            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('" + ex.Message + "');window.location='Active.aspx';</script>'");

            }
        }


        protected void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                GetSession session = new GetSession();
                string currentMethod = System.Reflection.MethodBase.GetCurrentMethod().Name;
                foreach (RepeaterItem rpt in rptIPOApplication.Items)
                {
                    CheckBox chkAcctive = (CheckBox)rpt.FindControl("chkChecked");
                    if (chkAcctive.Checked == true)
                    {
                        Label accountRef = (Label)rpt.FindControl("lblAccountNumber");

                        HiddenField hf1 = (HiddenField)rpt.FindControl("HiddenField1");
                        string companyName = hf1.Value;

                        HiddenField hf2 = (HiddenField)rpt.FindControl("HiddenField2");
                        string ipoRefference = hf2.Value;

                        string accountReference = accountRef.Text;
                        Label catg = (Label)rpt.FindControl("lblCategory");
                        string category = catg.Text;

                        CommonFunction cmActiveInvestor = new CommonFunction();
                        string query = "update IPOApplication set Status='Accepted' where (AccountNumber='" + accountReference + "' and IPOReference='" + ipoRefference + "')";
                        cmActiveInvestor.InsertQuery(query);
                        SendMail(accountReference, currentMethod, companyName);
                    }

                    else
                        continue;
                }
                ShowData(ddlStatus.SelectedValue, ddlCompany.SelectedValue);
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('An email has sent to the user');</script>'");
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
                foreach (RepeaterItem rpt in rptIPOApplication.Items)
                {
                    CheckBox chkAcctive = (CheckBox)rpt.FindControl("chkChecked");
                    if (chkAcctive.Checked == true)
                    {
                        Label accountRef = (Label)rpt.FindControl("lblAccountNumber");

                        HiddenField hf1 = (HiddenField)rpt.FindControl("HiddenField1");
                        string companyName = hf1.Value;

                        HiddenField hf2 = (HiddenField)rpt.FindControl("HiddenField2");
                        string ipoRefference = hf2.Value;

                        string accountReference = accountRef.Text;


                        Label catg = (Label)rpt.FindControl("lblCategory");
                        string category = catg.Text;

                        CommonFunction cmActiveInvestor = new CommonFunction();
                        string query = "update IPOApplication set Status='Rejected' where (AccountNumber='" + accountReference + "' and IPOReference='" + ipoRefference + "' )";
                        cmActiveInvestor.InsertQuery(query);
                        SendMail(accountReference, currentMethod, companyName);
                    }
                }

                ShowData(ddlStatus.SelectedValue, ddlCompany.SelectedValue);
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('An email has sent to the user');</script>'");


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
        private void SendMail(string AccountNumber, string MethodName, string companyName)
        {
            string userName = "";
            string email = "";
            string mainMsg = "";
            GetSession session = new GetSession();
            if (MethodName == "btnReject_Click" || MethodName == "Rejected")
            {
                mainMsg = "rejected. Please contact with your borker";
            }
            else if (MethodName == "btnAccept_Click" || MethodName == "Accepted")
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
            string emailMessage = "Hi " + userName + ",<br/>Your IPO request on iTradeX for " + companyName + " has " + mainMsg + ".";
            string message = emailMessage;


            sendEmail.AuthenticationMode = 1;
            sendEmail.Body = message;

            sendEmail.From = ConfigurationManager.AppSettings["From"];

            sendEmail.IsHtml = Convert.ToBoolean(ConfigurationManager.AppSettings["IsHtml"]);
            sendEmail.IsUseSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["IsUseSSL"]);
            sendEmail.Password = ConfigurationManager.AppSettings["IPOPassword"];
            sendEmail.PortNum = Convert.ToInt32(ConfigurationManager.AppSettings["PortNum"]);
            sendEmail.SendUsing = Convert.ToInt32(ConfigurationManager.AppSettings["SendUsing"]);
            sendEmail.SMTPServer = ConfigurationManager.AppSettings["IPOSMTPServer"];
            sendEmail.Subject = "Fund Withdrawal Request On iTradeX";
            sendEmail.To = email;
            sendEmail.UserName = ConfigurationManager.AppSettings["IPOUserName"];
            sendEmail.SendEmail();


        }


        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                GetSession session = new GetSession();
                string status = ddlStatus.SelectedValue;
                string companyname = ddlCompany.SelectedValue;
                ReportDocument oIPOApplicationLoder = new ReportDocument();

                oIPOApplicationLoder.Load(Server.MapPath(@"..\..\IPOApplicationList.rpt"));
                Session["ReportName"] = "WithdrawalRequest";
                IPOApplicationlistLoader oLoder = new IPOApplicationlistLoader(status, companyname, oIPOApplicationLoder);

                ReportDocument rd = (ReportDocument)oLoder.GetReportSource();
                Session["ReportDocumentObj"] = rd;

                ResponseHelper.Redirect(Response, "ReportViwer.aspx", "_blank", "menubar=0,width=800,height=600");
            }

            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));

            }
        }

        protected void btnResendEmail_Click(object sender, EventArgs e)
        {
            try
            {


                foreach (RepeaterItem rpt in rptIPOApplication.Items)
                {
                    CheckBox chkAcctive = (CheckBox)rpt.FindControl("chkChecked");
                    if (chkAcctive.Checked == true)
                    {
                        Label accountRef = (Label)rpt.FindControl("lblAccountNumber");

                        HiddenField hf1 = (HiddenField)rpt.FindControl("HiddenField1");
                        string companyName = hf1.Value;

                        HiddenField hf2 = (HiddenField)rpt.FindControl("HiddenField2");
                        string ipoRefference = hf2.Value;

                        string accountReference = accountRef.Text;
                        Label catg = (Label)rpt.FindControl("lblCategory");
                        string category = catg.Text;
                        SendMail(accountReference, ddlStatus.SelectedValue, companyName);
                    }

                    else
                        continue;
                }
                ShowData(ddlStatus.SelectedValue, ddlCompany.SelectedValue);
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('An email has sent to the user');</script>'");

            }

            catch (Exception ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));

            }
        }

    }
}