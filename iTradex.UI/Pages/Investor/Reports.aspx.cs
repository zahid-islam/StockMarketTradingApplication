using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTradex.UI.App_Code;
using System.Data;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using iTradex.UI.Report;
using System.Globalization;
using System.IO;

namespace iTradex.UI.Pages.Investor
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AccountNumber"] == null)
                {
                    //Response.Redirect("../../Default.aspx");
                }
                ShowData();
                LoadShortName();
            }

            catch (Exception ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" +  Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));

            }
        }

        private void LoadShortName()
        {
            try
            {
                GetSession session = new GetSession();
                if (!IsPostBack)
                {
                    CommonFunction cmDataTable = new CommonFunction();
                    //SqlConnection sconLoadShortName = DatabaseConnection.GetConnection();
                    string commandLoadShortName = "select ShortName from CurrentStockLedger where InvestorACRef='" + session.AccountNumber + "' order by ShortName ";
                    //SqlCommand commandLoadShortName = new SqlCommand("select ShortName from CurrentStockLedger where InvestorACRef='" + GetSession.accNo + "' order by ShortName ", sconLoadShortName);
                    //sconLoadShortName.Close();
                    //SqlDataAdapter sdaLoadShortName = new SqlDataAdapter(commandLoadShortName);
                    DataTable dtLoadShortName = cmDataTable.GetDatatable(commandLoadShortName);
                    //sdaLoadShortName.Fill(dtLoadShortName);

                    ddlInstrument.DataSource = dtLoadShortName;

                    ddlInstrument.DataTextField = "ShortName";

                    ddlInstrument.DataBind();
                }


            }
            catch (Exception ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));

            }

        }

        private void ShowData()
        {
            try
            {
                GetSession session = new GetSession();
                lblInvestorname.Text = Session["AccountNumber"] + " - " + HttpContext.Current.Session["AccountName"].ToString();
                CommonFunction cmDataTable = new CommonFunction();
                string shoData = "select ReportName,Description from Reports";

                DataTable dtTaxReports = cmDataTable.GetDatatable(shoData);

                rptTaxREports.DataSource = dtTaxReports;
                rptTaxREports.DataBind();
            }
            catch (Exception ex)
            {
                //Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
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

                string password = "select Password from ApplicationUser where UserId='" + session.UserName + "' and AccountNumber='" + session.AccountNumber + "' and password='" + oldPassword + "'";

                DataTable dtpassword = cm.GetDatatable(password);

                if (dtpassword.Rows.Count > 0)
                {
                    txtNewPassord.ReadOnly = false;
                    txtConfirmPassword.ReadOnly = false;
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

        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                GetSession session = new GetSession();
                RijndaelEncryption encryption = new RijndaelEncryption();
                string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
                string newPassword = encryption.EncryptText(txtNewPassord.Text, encryptionKey);
                string oldPassword = encryption.EncryptText(txtOldPassword.Text, encryptionKey);
                CommonFunction cmSaveData = new CommonFunction();
                string updatePassword = "update ApplicationUser set Password='" + newPassword + "' where(UserID='" + session.UserName + " ' and AccountNumber='" + session.AccountNumber + "' )";
                cmSaveData.InsertQuery(updatePassword);
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Password change successfully');window.location='Ipo.aspx';</script>'");
            }

            catch (Exception ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }


        }


        protected void Print_Click(Object sender, CommandEventArgs e)
        {

            string reportName = e.CommandArgument.ToString();
            string rangeA = Request.Form["rangeBa"];
            string rangeB = Request.Form["rangeBb"];

            if (reportName == "Portfolio Statement")
            {
                try
                {
                    GetSession session = new GetSession();
                    string Investor = session.AccountNumber;

                    DateTime fromDate = DateTime.Today;
                    DateTime dateFrom = DateTime.Today;

                    Session["ReportName"] = "InvestorPortfolioStatementWeb";
                    ReportDocument oInvestorProtfilioStatement = new ReportDocument();
                    //JScript.Alert(Server.MapPath(@"Reports\InvestorPortfolioStatement.rpt"), Page);
                    oInvestorProtfilioStatement.Load(Server.MapPath(@"..\..\InvestorPortfolioStatement.rpt"));
                    //JScript.Alert("Load Report pass", Page);

                    InvestorPortfolioStatementLoader oLoder = new InvestorPortfolioStatementLoader(Investor, dateFrom, oInvestorProtfilioStatement);
                    //JScript.Alert("after Report pass", Page);
                    ReportDocument rd = (ReportDocument)oLoder.GetReportSource();

                    Session["ReportDocumentObj"] = rd;
                    //   const string url = "";

                    ResponseHelper.Redirect(Response, "ReportViwer.aspx", "_blank", "menubar=0,width=800,height=600");

                    //MemoryStream oStream;
                    //oStream = (MemoryStream)rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    //Response.Clear();
                    //Response.Buffer = true;
                    //Response.ContentType = "application/pdf";
                    //Response.BinaryWrite(oStream.ToArray());
                    //Response.Flush();
                    //Response.End();


                    //Response.Redirect(Global.BaseUrl + "ReportViewer.aspx");
                   // Response.Redirect("../../ReportViewer.aspx");
                }
                catch (Exception ex)
                {
                    //JScript.Alert(ex.Message, Page);
                    throw ex;
                }


            }

            else if (reportName == "Client Ledger Statement")
            {
                GetSession session = new GetSession(); string databaseDateFormat = "yyyy/MM/dd";
               
                if (Request.Form["rangeBa"] == string.Empty || Request.Form["rangeBb"] == string.Empty)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('please select date');window.location='Reports.aspx';</script>'");
                }
                 
                else
                {
                    string dateFrom = DateTime.ParseExact(rangeA, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                    string date = DateTime.Parse(dateFrom).AddDays(-1).ToString("yyyy/MM/dd");
                    Session["date"] = date;
                    Session["FromoDate"] = DateTime.ParseExact(rangeA, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                    Session["ToDate"] = DateTime.ParseExact(rangeB, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                    string fromDate = DateTime.ParseExact(rangeA, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                    string toDate = DateTime.ParseExact(rangeB, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                    ReportDocument oInvestorProtfilioStatement = new ReportDocument();
                    //CrystalReportDataSet ds = new CrystalReportDataSet();
                    oInvestorProtfilioStatement.Load(Server.MapPath(@"..\..\InvestorLedgerStatement.rpt"));
                    Session["ReportName"] = "InvestorLedgerStatement";
                    InvestorLedgerStatementLoader oLoder = new InvestorLedgerStatementLoader(session.AccountNumber, fromDate, toDate, oInvestorProtfilioStatement);

                    ReportDocument rd = (ReportDocument)oLoder.GetReportSource();

                    Session["ReportDocumentObj"] = rd;

                    ResponseHelper.Redirect(Response, "ReportViwer.aspx", "_blank", "menubar=0,width=800,height=600");
                    //MemoryStream oStream;
                    //oStream = (MemoryStream)rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    //Response.Clear();
                    //Response.Buffer = true;
                    //Response.ContentType = "application/pdf";
                    //Response.BinaryWrite(oStream.ToArray());
                    //Response.Flush();
                    //Response.End();
                }
            
            }

            else if (reportName == "Instrument Ledger")
            {
                try
                {
                    GetSession session = new GetSession();
                    string databaseDateFormat = "yyyy/MM/dd";
                    if (Request.Form["rangeBa"] == string.Empty || Request.Form["rangeBb"] == string.Empty || ddlInstrument.SelectedIndex < 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('please select date');window.location='Ledger.aspx';</script>'");
                    }

                    else
                    {
                        Session["instrumentName"] = ddlInstrument.SelectedValue;
                        Session["FromoDate"] = DateTime.ParseExact(Request.Form["rangeBa"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                        Session["ToDate"] = DateTime.ParseExact(Request.Form["rangeBb"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                        string fromDate = DateTime.ParseExact(Request.Form["rangeBa"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                        string toDate = DateTime.ParseExact(Request.Form["rangeBb"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                        ReportDocument oInvestorProtfilioStatement = new ReportDocument();
                        //CrystalReportDataSet ds = new CrystalReportDataSet();
                        oInvestorProtfilioStatement.Load(Server.MapPath(@"..\..\DSEInstrumentLedger.rpt"));
                        Session["ReportName"] = "InstrumentWiseLedger";
                        LedgerLoader oLoder = new LedgerLoader(session.AccountNumber, fromDate, toDate, ddlInstrument.SelectedItem.Text, oInvestorProtfilioStatement);

                        ReportDocument rd = (ReportDocument)oLoder.GetReportSource();

                        Session["ReportDocumentObj"] = rd;

                        ResponseHelper.Redirect(Response, "ReportViwer.aspx", "_blank", "menubar=0,width=800,height=600");

                    }
                }

                catch (Exception ex)
                {
                    Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
                }

            }


            else if (reportName == "Tax Certificate")
            {
                GetSession session = new GetSession();
                string databaseDateFormat = "yyyy/MM/dd";

                if (Request.Form["rangeBa"] == string.Empty || Request.Form["rangeBb"] == string.Empty)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('please select date');window.location='Reports.aspx';</script>'");
                }

                else
                {
                    Session["FromoDate"] = DateTime.ParseExact(Request.Form["rangeBa"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                    Session["ToDate"] = DateTime.ParseExact(Request.Form["rangeBb"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                    string fromDate = DateTime.ParseExact(Request.Form["rangeBa"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                    string toDate = DateTime.ParseExact(Request.Form["rangeBb"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                    ReportDocument oTaxReport = new ReportDocument();
                    //CrystalReportDataSet ds = new CrystalReportDataSet();
                    oTaxReport.Load(Server.MapPath(@"..\..\InvestorTaxCertificate.rpt"));
                    Session["ReportName"] = "Tax Report";
                    TaxReportLoader oLoder = new TaxReportLoader(session.AccountNumber, fromDate, toDate, oTaxReport);

                    ReportDocument rd = (ReportDocument)oLoder.GetReportSource();

                    Session["ReportDocumentObj"] = rd;

                    ResponseHelper.Redirect(Response, "ReportViwer.aspx", "_blank", "menubar=0,width=800,height=600");

                }
            

            }

            else if (reportName == "Trade Confirmation")
            {
                GetSession session = new GetSession(); string databaseDateFormat = "yyyy/MM/dd";

                if (Request.Form["rangeBa"] == string.Empty || Request.Form["rangeBb"] == string.Empty)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('please select date');window.location='Reports.aspx';</script>'");
                }

                else
                {
                    string dateFrom = DateTime.ParseExact(rangeA, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                    string date = DateTime.Parse(dateFrom).AddDays(-1).ToString("yyyy/MM/dd");
                    Session["date"] = date;
                    Session["FromoDate"] = DateTime.ParseExact(rangeA, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                    Session["ToDate"] = DateTime.ParseExact(rangeB, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                    string fromDate = DateTime.ParseExact(rangeA, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                    string toDate = DateTime.ParseExact(rangeB, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                    ReportDocument oReportDoc = new ReportDocument();
                    //CrystalReportDataSet ds = new CrystalReportDataSet();
                    oReportDoc.Load(Server.MapPath(@"..\..\TradeConfirmationSummaryNew.rpt"));
                    Session["ReportName"] = "TradeConfirmationSummaryNew";
                    TradeConfirmationLoader oLoder = new TradeConfirmationLoader(session.AccountNumber, fromDate, toDate, oReportDoc);

                    ReportDocument rd = (ReportDocument)oLoder.GetReportSource();

                    Session["ReportDocumentObj"] = rd;

                    ResponseHelper.Redirect(Response, "ReportViwer.aspx", "_blank", "menubar=0,width=800,height=600");
                    MemoryStream oStream;
                    oStream = (MemoryStream)rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/pdf";
                    Response.BinaryWrite(oStream.ToArray());
                    Response.Flush();
                    Response.End();
                }

            }

            else if (reportName == "BO Acknowledgement")
            {

                GetSession session = new GetSession();
                string databaseDateFormat = "yyyy/MM/dd";

                if (Request.Form["rangeBa"] == string.Empty || Request.Form["rangeBb"] == string.Empty)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('please select date');window.location='Reports.aspx';</script>'");
                }

                else
                {
                    Session["FromoDate"] = DateTime.ParseExact(Request.Form["rangeBa"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                    Session["ToDate"] = DateTime.ParseExact(Request.Form["rangeBb"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                    string fromDate = DateTime.ParseExact(Request.Form["rangeBa"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                    string toDate = DateTime.ParseExact(Request.Form["rangeBb"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                    ReportDocument oBOAcknowledgement = new ReportDocument();
                    //CrystalReportDataSet ds = new CrystalReportDataSet();
                    oBOAcknowledgement.Load(Server.MapPath(@"..\..\BOOpened.rpt"));
                    Session["ReportName"] = "Tax Report";
                    BOOpenLoader oLoder = new BOOpenLoader(session.AccountNumber, fromDate, toDate, oBOAcknowledgement);

                    ReportDocument rd = (ReportDocument)oLoder.GetReportSource();

                    Session["ReportDocumentObj"] = rd;

                    ResponseHelper.Redirect(Response, "ReportViwer.aspx", "_blank", "menubar=0,width=800,height=600");

                }
            }

        }

        
    }
}