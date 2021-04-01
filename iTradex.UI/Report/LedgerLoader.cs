using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using iTradex.UI.App_Code;
using System.Data;

namespace iTradex.UI.Report
{
    public class LedgerLoader
    {

        ReportDocument oInvestorLedgerStatement = new ReportDocument();

        string accountRef = string.Empty;
        string fromDate;
        string toDate;
        string instrumentName;
        GetSession session = new GetSession();
        public LedgerLoader(string accountRef, string fromDate, string toDate,string instrumentName, ReportDocument _oInvestorLedgerStatement)
        {
            oInvestorLedgerStatement = _oInvestorLedgerStatement;
            this.accountRef = accountRef;
            this.fromDate = fromDate;
            this.toDate = toDate;
            this.instrumentName = instrumentName;
            //FirstDateOfmonth = new DateTime(fromDate.Year, fromDate.Month, 1);
        }

        public ReportDocument GetReportSource()
        {
            try
            {
                string dateFrom = HttpContext.Current.Session["FromoDate"].ToString();
                string dateTo = HttpContext.Current.Session["ToDate"].ToString();
                string instrumentName = HttpContext.Current.Session["instrumentName"].ToString();
                SqlConnection sconFillDataTable = DatabaseConnection.GetConnection();
                SqlCommand cmdFillDataTable = new SqlCommand("GetInstrumentLedger", sconFillDataTable);
                cmdFillDataTable.CommandType = CommandType.StoredProcedure;

                cmdFillDataTable.Parameters.Add("@AccountRef", SqlDbType.VarChar).Value = session.AccountNumber;
                cmdFillDataTable.Parameters.Add("@ShortName", SqlDbType.VarChar).Value = instrumentName;
                cmdFillDataTable.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = dateFrom;
                cmdFillDataTable.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = dateTo;
                sconFillDataTable.Close();
                SqlDataAdapter sdaGetInstrumentLedger = new SqlDataAdapter(cmdFillDataTable);
                DataTable dtGetInstrumentLedger = new DataTable();
                sdaGetInstrumentLedger.Fill(dtGetInstrumentLedger);
                oInvestorLedgerStatement.SetDataSource(dtGetInstrumentLedger);
                SetParameters();
                return oInvestorLedgerStatement;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetParameters()
        {
            try
            {
                CommonFunction cmDataTable = new CommonFunction();
                string query = "select Address,Telephone,Fax,Email,ExchangeID,Web,BrokerName from Broker";
                DataTable dtbrokerRef = cmDataTable.GetDatatable(query);
                if (dtbrokerRef.Rows.Count > 0)
                {
                    oInvestorLedgerStatement.SetParameterValue("Address", dtbrokerRef.Rows[0]["Address"].ToString());
                    oInvestorLedgerStatement.SetParameterValue("Telephone", dtbrokerRef.Rows[0]["Telephone"].ToString());
                    oInvestorLedgerStatement.SetParameterValue("Email", dtbrokerRef.Rows[0]["Email"].ToString());
                    oInvestorLedgerStatement.SetParameterValue("Web", dtbrokerRef.Rows[0]["Web"].ToString());
                    oInvestorLedgerStatement.SetParameterValue("Fax", dtbrokerRef.Rows[0]["Fax"].ToString());
                    oInvestorLedgerStatement.SetParameterValue("StockExchange", dtbrokerRef.Rows[0]["ExchangeID"].ToString());
                    oInvestorLedgerStatement.SetParameterValue("CompanyName", dtbrokerRef.Rows[0]["BrokerName"].ToString());
                }

                oInvestorLedgerStatement.SetParameterValue("Branch", " ");
                oInvestorLedgerStatement.SetParameterValue("CDBL", " ");
                oInvestorLedgerStatement.SetParameterValue("ReportBranch", " ");
                oInvestorLedgerStatement.SetParameterValue("ReportTitle", "Instrument Ledger");
                
                oInvestorLedgerStatement.SetParameterValue("Trader", instrumentName);
                oInvestorLedgerStatement.SetParameterValue("AccountName", HttpContext.Current.Session["AccountName"].ToString());
                oInvestorLedgerStatement.SetParameterValue("fromDate", fromDate);
                oInvestorLedgerStatement.SetParameterValue("toDate", toDate);
                //Add dictionary
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}