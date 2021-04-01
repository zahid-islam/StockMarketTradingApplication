using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using iTradex.UI.App_Code;
using System.Globalization;
using CrystalDecisions.CrystalReports.Engine;
using iTradex.UI.Report;

namespace iTradex.UI.Pages.Investor
{
    public partial class Ledger : System.Web.UI.Page
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
                    LoadShortName();
                    //   Request.Form["rangeBa"].
                    //   Request.Form["rangeBb"].ToString();
                    GetUserInformation();
                }
            }
            catch (FormatException ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }

        //private string GetConnection()
        //{
        //  return  ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        //}



        /// <summary>
        /// Load Short Name INTO DropDownList
        /// </summary>
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


        /// <summary>
        /// Binding DataTable using DatePicker and DropDownList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void btnSubmitDate_Click(object sender, EventArgs e)
        {
            try
            {
                GetSession session = new GetSession();
                string rangeA = Request.Form["rangeBa"];
                string rangeB = Request.Form["rangeBb"];
                if (rangeA == string.Empty || rangeB == string.Empty)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('please select date');window.location='Ledger.aspx';</script>'");
                }

                else
                {
                    string databaseDateFormat = "yyyy/MM/dd";
                    string dateFrom = DateTime.ParseExact(Request.Form["rangeBa"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                    string dateTo = DateTime.ParseExact(Request.Form["rangeBb"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);



                    SqlConnection sconFillDataTable = DatabaseConnection.GetConnection();
                    SqlCommand cmdFillDataTable = new SqlCommand("GetInstrumentLedger", sconFillDataTable);
                    cmdFillDataTable.CommandType = CommandType.StoredProcedure;

                    cmdFillDataTable.Parameters.Add("@AccountRef", SqlDbType.VarChar).Value = session.AccountNumber;
                    cmdFillDataTable.Parameters.Add("@ShortName", SqlDbType.VarChar).Value = ddlInstrument.SelectedValue;
                    cmdFillDataTable.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = dateFrom;
                    cmdFillDataTable.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = dateTo;
                    sconFillDataTable.Close();
                    SqlDataAdapter sdaGetInstrumentLedger = new SqlDataAdapter(cmdFillDataTable);
                    DataTable dtGetInstrumentLedger = new DataTable();
                    sdaGetInstrumentLedger.Fill(dtGetInstrumentLedger);


                    double forwardBalance = 0;
                    if (dtGetInstrumentLedger.Rows.Count > 0)
                    {
                        forwardBalance = Double.Parse(dtGetInstrumentLedger.Rows[0]["OpeningBalance"].ToString());

                    }

                    double balanceForward = forwardBalance;

                    dtGetInstrumentLedger.Columns.Add("Balance", typeof(decimal));


                    foreach (DataRow dr in dtGetInstrumentLedger.Rows)
                    {

                        forwardBalance = forwardBalance + Double.Parse(dr["Buy"].ToString()) - Double.Parse(dr["Sale"].ToString()) + Double.Parse(dr["Receive"].ToString()) - Double.Parse(dr["Issue"].ToString());
                        dr["Balance"] = forwardBalance;
                    }
                    rptInstrumentLedger.DataSource = dtGetInstrumentLedger;
                    rptInstrumentLedger.DataBind();

                    Control HeaderTemplate = rptInstrumentLedger.Controls[0].Controls[0];
                    Label lblHeader = HeaderTemplate.FindControl("lblBalanceForward") as Label;
                    lblHeader.Text = balanceForward.ToString("#,##0.00");

                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }

        private void GetUserInformation()
        {
            GetSession session = new GetSession();
            lblInvestorname.Text = session.AccountNumber;
        }


        protected void btnPrint_Click(object sender, EventArgs e)
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
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Password change successfully');window.location='Ledger.aspx';</script>'");
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

                string password = "select Password from ApplicationUser where UserId='" + session.UserName + "' and AccountNumber='" + session.AccountNumber + "'";

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

    }
}