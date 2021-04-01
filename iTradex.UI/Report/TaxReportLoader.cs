using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using iTradex.UI.App_Code;
using System.Data.SqlClient;
using System.Data;

namespace iTradex.UI.Report
{
    public class TaxReportLoader
    {
        ReportDocument oTaxReport = new ReportDocument();

        string accountRef = string.Empty;
        string fromDate;
        string toDate;
       
        GetSession session = new GetSession();
        public TaxReportLoader(string accountRef, string fromDate, string toDate, ReportDocument _oTaxReport)
        {
            oTaxReport = _oTaxReport;
            this.accountRef = accountRef;
            this.fromDate = fromDate;
            this.toDate = toDate;
            //FirstDateOfmonth = new DateTime(fromDate.Year, fromDate.Month, 1);
        }

        public ReportDocument GetReportSource()
        {
            try
            {
                string dateFrom=HttpContext.Current.Session["FromoDate"].ToString();
                string dateTo = HttpContext.Current.Session["ToDate"].ToString();
                SqlConnection sconTransaction = DatabaseConnection.GetConnection();
                SqlCommand command = new SqlCommand("InvestorTaxCertificate_iTradex", sconTransaction);
                command.CommandType = CommandType.StoredProcedure;
                sconTransaction.Close();
                command.Parameters.Add("@AccountRef", SqlDbType.VarChar).Value = session.AccountNumber;
                command.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = dateFrom;
                command.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = dateTo;

                SqlDataAdapter sdaInvestorTaxReport = new SqlDataAdapter(command);
                DataTable dtTaxReport = new DataTable();

                sdaInvestorTaxReport.Fill(dtTaxReport);

                oTaxReport.SetDataSource(dtTaxReport);
                SetReportParameters();
                return oTaxReport;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetReportParameters()
        {
            try
            {
               // double opening = 0;
               // SqlConnection sconTransactionBalanceForward = DatabaseConnection.GetConnection();
               // SqlCommand commandTransactionBalanceForward = new SqlCommand("GetClientAccountStatusDetailsAsOn", sconTransactionBalanceForward);
               // commandTransactionBalanceForward.CommandType = CommandType.StoredProcedure;
               // sconTransactionBalanceForward.Close();
                
               // commandTransactionBalanceForward.Parameters.Add("@AccountRef", SqlDbType.VarChar).Value = session.AccountNumber;
               // commandTransactionBalanceForward.Parameters.Add("@LedgerDate", SqlDbType.DateTime).Value = HttpContext.Current.Session["date"].ToString();


               // SqlDataAdapter sdaTransactionBalanceForward = new SqlDataAdapter(commandTransactionBalanceForward);
               // DataTable dtTransactionBalanceForward = new DataTable();

               // double forwardBalance = 0;
               // sdaTransactionBalanceForward.Fill(dtTransactionBalanceForward);

               // if (dtTransactionBalanceForward.Rows.Count > 0)
               // {
               //     oTaxReport.SetParameterValue("OpeningBalance", dtTransactionBalanceForward.Rows[0]["LedgerBalance"].ToString());

               // }

               // else
               // {
               //     oTaxReport.SetParameterValue("OpeningBalance", opening);
                
               // }

               // string accountName = session.AccountNumber;
               // CommonFunction cmDataTable = new CommonFunction();
               // //string query = "select Address,Telephone,Fax,Email,ExchangeID,Web,BrokerName from Broker where Reference='"+session.BrokerRef+"'";
               // string query = "select Address,Telephone,Fax,Email,ExchangeID,Web,BrokerName from Broker";
               // DataTable dtbrokerRef = cmDataTable.GetDatatable(query);
               //if(dtbrokerRef.Rows.Count > 0)
               // {
               //     oTaxReport.SetParameterValue("Address", dtbrokerRef.Rows[0]["Address"].ToString());
               //     oTaxReport.SetParameterValue("Telephone",dtbrokerRef.Rows[0]["Telephone"].ToString());
               //     oTaxReport.SetParameterValue("Email",dtbrokerRef.Rows[0]["Email"].ToString());
               //     oTaxReport.SetParameterValue("Web", dtbrokerRef.Rows[0]["Web"].ToString());
               //     oTaxReport.SetParameterValue("Fax", dtbrokerRef.Rows[0]["Fax"].ToString());
               //     oTaxReport.SetParameterValue("StockExchange", dtbrokerRef.Rows[0]["ExchangeID"].ToString());
               //     oTaxReport.SetParameterValue("CompanyName", dtbrokerRef.Rows[0]["BrokerName"].ToString());
               // }

               // oTaxReport.SetParameterValue("Branch", " "); 
               // oTaxReport.SetParameterValue("CDBL", " ");                  
                

               // oTaxReport.SetParameterValue("ReportTitle", "Investor Ledger Statement");
               // //oInvestorLedgerStatement.SetParameterValue("OpeningBalance", opening);
                oTaxReport.SetParameterValue("period", "Period : " + fromDate + " To " + toDate);
                
              
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}