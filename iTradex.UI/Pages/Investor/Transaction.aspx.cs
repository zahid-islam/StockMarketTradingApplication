using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using iTradex.UI.App_Code;
using System.Globalization;
using iTradex.UI.Report;
using CrystalDecisions.CrystalReports.Engine;

namespace iTradex.UI.Pages.Investor
{
    public partial class Transaction : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccountNumber"] == null)
            {
                Response.Redirect("../../Default.aspx");
            }
            GetUserInformation();
        }

         /// <summary>
         /// Data bind on DataTable
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        protected void btnSubmitDate_Click(object sender, EventArgs e)
        {
            try
            {
                GetSession session = new GetSession();
                string rangeA= Request.Form["rangeBa"];
                string rangeB=Request.Form["rangeBb"];
                if (rangeA == string.Empty || rangeB==string.Empty)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('please select date');window.location='Transaction.aspx';</script>'");
                }
                else
                {
                string databaseDateFormat = "yyyy/MM/dd";
                string dateFrom = DateTime.ParseExact(Request.Form["rangeBa"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
              //string dateFrom = Convert.ToDateTime(Request.Form["rangeBa"].ToString()).ToString(databaseDateFormat);
               //string test= Request.Form["rangeBa"];
                //string dateFrom = DateTime.Parse(Request.Form["rangeBa"].ToString()).ToString();
                //DateTime dt = DateTime.ParseExact(dateFrom,databaseDateFormat,null);
                //string dateFrom = DateTime.Parse(Request.Form["rangeBa"].ToString()).ToString(databaseDateFormat);
                string dateTo = DateTime.ParseExact(Request.Form["rangeBb"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                //string dateTo = DateTime.Parse(Request.Form["rangeBb"].ToString()).ToString(databaseDateFormat);


                SqlConnection sconTransaction = DatabaseConnection.GetConnection();
                SqlCommand command = new SqlCommand("GetInvestorLedgerStatement", sconTransaction);
                command.CommandTimeout = 360;
                command.CommandType = CommandType.StoredProcedure;
                
                sconTransaction.Close();
                command.Parameters.Add("@AccountRef", SqlDbType.VarChar).Value =session.AccountNumber;
                command.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = dateFrom;
                command.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = dateTo;

                SqlDataAdapter sdaInvestorLedgerStatement = new SqlDataAdapter(command);
                DataTable dtInvestorLedgerStatement = new DataTable();
                sdaInvestorLedgerStatement.Fill(dtInvestorLedgerStatement);

                //ADD BALANCE COLUMN
                SqlConnection sconTransactionBalanceForward = DatabaseConnection.GetConnection();
                SqlCommand commandTransactionBalanceForward = new SqlCommand("GetClientAccountStatusDetailsAsOn", sconTransactionBalanceForward);
                commandTransactionBalanceForward.CommandType = CommandType.StoredProcedure;
                sconTransactionBalanceForward.Close();
                //string dateFrom = DateTime.ParseExact(Request.Form["rangeBa"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                string date = DateTime.Parse(dateFrom).AddDays(-1).ToString("yyyy/MM/dd");
                Session["date"] = date;
                commandTransactionBalanceForward.Parameters.Add("@AccountRef", SqlDbType.VarChar).Value = session.AccountNumber;
                commandTransactionBalanceForward.Parameters.Add("@LedgerDate", SqlDbType.DateTime).Value = date;
                   
                SqlDataAdapter sdaTransactionBalanceForward = new SqlDataAdapter(commandTransactionBalanceForward);
                DataTable dtTransactionBalanceForward = new DataTable();

                double forwardBalance = 0;
                sdaTransactionBalanceForward.Fill(dtTransactionBalanceForward);

                if (dtTransactionBalanceForward.Rows.Count > 0)
                {
                    forwardBalance = Double.Parse(dtTransactionBalanceForward.Rows[0]["LedgerBalance"].ToString());
                    
                }

                double balanceForward = forwardBalance;
                dtInvestorLedgerStatement.Columns.Add("Balance", typeof(decimal));
                //dt.Columns.Add(new DataColumn(columnName = "Balance", dataType = typeof (decimal)));
                   
                foreach (DataRow dr in dtInvestorLedgerStatement.Rows)
                {
                    forwardBalance = forwardBalance + (Double.Parse(dr["Credit"].ToString()) - Double.Parse(dr["Debit"].ToString()));
                    dr["Balance"] = forwardBalance;
                }

                rptLedger.DataSource = dtInvestorLedgerStatement;
                rptLedger.DataBind();

                Control HeaderTemplate = rptLedger.Controls[0].Controls[0];
                Label lblHeader = HeaderTemplate.FindControl("lblBalanceForward") as Label;
                lblHeader.Text = balanceForward.ToString("#,##0.00");
                    
                double totalDebit = 0;
                foreach (DataRow dr in dtInvestorLedgerStatement.Rows)
                {
                    totalDebit = totalDebit + Double.Parse(dr["Debit"].ToString());
                }

                lblDebit.Text = totalDebit.ToString("#,##0.00");

                double totalCredit = 0;
                foreach (DataRow dr in dtInvestorLedgerStatement.Rows)
                {
                    totalCredit = totalCredit + Double.Parse(dr["Credit"].ToString());
                }

                lblCredit.Text = totalCredit.ToString("#,##0.00");
                lblBalance.Text = forwardBalance.ToString("#,##0.00");
                }
            }

            catch(Exception ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }

        /// <summary>
        /// User Name And Account On Modal
        /// </summary>

        private void GetUserInformation()
        {
            GetSession session = new GetSession();
            lblInvestorname.Text = session.AccountNumber;
        }


        /// <summary>
        /// For Crystal Report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            GetSession session = new GetSession(); string databaseDateFormat = "yyyy/MM/dd";
            string dateFrom = DateTime.ParseExact(Request.Form["rangeBa"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
            if (Request.Form["rangeBa"] == string.Empty || Request.Form["rangeBb"] == string.Empty)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('please select date');window.location='Transaction.aspx';</script>'");
            }

            else
            {
                string date = DateTime.Parse(dateFrom).AddDays(-1).ToString("yyyy/MM/dd");
                Session["date"] = date;
                Session["FromoDate"] = DateTime.ParseExact(Request.Form["rangeBa"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                Session["ToDate"] = DateTime.ParseExact(Request.Form["rangeBb"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                string fromDate = DateTime.ParseExact(Request.Form["rangeBa"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                string toDate = DateTime.ParseExact(Request.Form["rangeBb"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat);
                ReportDocument oInvestorProtfilioStatement = new ReportDocument();
                //CrystalReportDataSet ds = new CrystalReportDataSet();
                oInvestorProtfilioStatement.Load(Server.MapPath(@"..\..\InvestorLedgerStatement.rpt"));
                Session["ReportName"] = "InvestorLedgerStatement";
                InvestorLedgerStatementLoader oLoder = new InvestorLedgerStatementLoader(session.AccountNumber, fromDate, toDate, oInvestorProtfilioStatement);

                ReportDocument rd = (ReportDocument)oLoder.GetReportSource();

                Session["ReportDocumentObj"] = rd;

                ResponseHelper.Redirect(Response, "ReportViwer.aspx", "_blank", "menubar=0,width=800,height=600");
            
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
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Password change successfully');window.location='Transaction.aspx';</script>'");
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

    }

}
