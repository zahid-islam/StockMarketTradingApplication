using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using iTradex.UI.App_Code;
using System.Data.SqlClient;

namespace iTradex.UI.Report
{
    public class InvestorLedgerStatementLoader
    {
        ReportDocument oInvestorLedgerStatement = new ReportDocument();
        GetSession session = new GetSession();
        string accountRef = string.Empty;
        string fromDate;
        string toDate;
        ////DateTime fromDate;
        ////DateTime toDate;
        //DateTime FirstDateOfmonth;

        //////public InvestorLedgerStatementLoader(string accountRef, DateTime fromDate, DateTime toDate, ReportDocument _oInvestorLedgerStatement)
        //////{
        //////    oInvestorLedgerStatement = _oInvestorLedgerStatement;
        //////    this.accountRef = accountRef;
        //////    this.fromDate = fromDate;
        //////    this.toDate = toDate;
        //////    FirstDateOfmonth = new DateTime(fromDate.Year, fromDate.Month, 1);
        //////}


        public InvestorLedgerStatementLoader(string accountRef, string fromDate, string toDate, ReportDocument _oInvestorLedgerStatement)
        {
            oInvestorLedgerStatement = _oInvestorLedgerStatement;
            this.accountRef = accountRef;
            this.fromDate = fromDate;
            this.toDate = toDate;
            //FirstDateOfmonth = new DateTime(fromDate.Year, fromDate.Month, 1);
        }

        public ReportDocument GetReportSource()
        {
            try
            {
                
                string dateFrom = HttpContext.Current.Session["FromoDate"].ToString();
                string dateTo = HttpContext.Current.Session["ToDate"].ToString();
                SqlConnection sconTransaction = DatabaseConnection.GetConnection();
                SqlCommand command = new SqlCommand("GetInvestorLedgerStatement", sconTransaction);
                command.CommandTimeout = 360;
                command.CommandType = CommandType.StoredProcedure;
                sconTransaction.Close();
                command.Parameters.Add("@AccountRef", SqlDbType.VarChar).Value = session.AccountNumber;
                command.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = dateFrom;
                command.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = dateTo;

                SqlDataAdapter sdaInvestorLedgerStatement = new SqlDataAdapter(command);
                DataTable dtInvestorLedgerStatement = new DataTable();


                sdaInvestorLedgerStatement.Fill(dtInvestorLedgerStatement);


                oInvestorLedgerStatement.SetDataSource(dtInvestorLedgerStatement);
                SetReportParameters();
                return oInvestorLedgerStatement;
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
                double opening = 0;
                SqlConnection sconTransactionBalanceForward = DatabaseConnection.GetConnection();
                SqlCommand commandTransactionBalanceForward = new SqlCommand("GetClientAccountStatusDetailsAsOn", sconTransactionBalanceForward);
                commandTransactionBalanceForward.CommandType = CommandType.StoredProcedure;
                sconTransactionBalanceForward.Close();

                commandTransactionBalanceForward.Parameters.Add("@AccountRef", SqlDbType.VarChar).Value = session.AccountNumber;
                commandTransactionBalanceForward.Parameters.Add("@LedgerDate", SqlDbType.DateTime).Value = HttpContext.Current.Session["date"].ToString();


                SqlDataAdapter sdaTransactionBalanceForward = new SqlDataAdapter(commandTransactionBalanceForward);
                DataTable dtTransactionBalanceForward = new DataTable();

                //double forwardBalance = 0;
                sdaTransactionBalanceForward.Fill(dtTransactionBalanceForward);

                if (dtTransactionBalanceForward.Rows.Count > 0)
                {
                    oInvestorLedgerStatement.SetParameterValue("OpeningBalance", dtTransactionBalanceForward.Rows[0]["LedgerBalance"].ToString());
                }

                else
                {
                    oInvestorLedgerStatement.SetParameterValue("OpeningBalance", opening);
                }

                string accountName = session.AccountNumber;
                CommonFunction cmDataTable = new CommonFunction();
                //string query = "select Address,Telephone,Fax,Email,ExchangeID,Web,BrokerName from Broker where Reference='"+session.BrokerRef+"'";
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


                oInvestorLedgerStatement.SetParameterValue("ReportTitle", "Investor Ledger Statement");
                //oInvestorLedgerStatement.SetParameterValue("OpeningBalance", opening);
                oInvestorLedgerStatement.SetParameterValue("period", "Period : " + fromDate + " To " + toDate);

                oInvestorLedgerStatement.SetParameterValue("Investor", session.AccountNumber + " : " + session.AccountName);
                //Add dictionary
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}