using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTradex.UI.App_Code;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Data;

namespace iTradex.UI.Report
{
    public class InvestorWithdrawalBrokerRequestLoader
    {
        ReportDocument oInvestorWithdrawalBrokerRequest = new ReportDocument();
        string status = string.Empty;
        string fromDate;
        string toDate;

        public InvestorWithdrawalBrokerRequestLoader(string status, string fromDate, string toDate, ReportDocument _oInvestorWithdrawalBrokerRequest)
        {
            oInvestorWithdrawalBrokerRequest = _oInvestorWithdrawalBrokerRequest;
            this.status = status;
            this.fromDate = fromDate;
            this.toDate = toDate;
        }

        public ReportDocument GetReportSource()
        {
            try
            {
                SqlConnection conWithdrawalRequest = DatabaseConnection.GetConnection();
                SqlCommand cmdWithdrawalRequest = new SqlCommand("GetWithdrawalRequestList", conWithdrawalRequest);
                cmdWithdrawalRequest.CommandType = CommandType.StoredProcedure;

                cmdWithdrawalRequest.Parameters.Add("@Status", SqlDbType.VarChar).Value = "Request";
                cmdWithdrawalRequest.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy/MM/dd"); 
                cmdWithdrawalRequest.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy/MM/dd");

                SqlDataAdapter sdaWithdrawalRequest = new SqlDataAdapter(cmdWithdrawalRequest);
                DataTable dtWithdrawalRequest = new DataTable();
                sdaWithdrawalRequest.Fill(dtWithdrawalRequest);
                oInvestorWithdrawalBrokerRequest.SetDataSource(dtWithdrawalRequest);
                SetParameters();
                return oInvestorWithdrawalBrokerRequest;
              
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
                string query = "select Address,Telephone,Fax,Email,ExchangeID,Web,BrokerName from Broker where Reference='" + GetSession.brokerRef + "'";
                DataTable dtbrokerRef = cmDataTable.GetDatatable(query);
                if (dtbrokerRef.Rows.Count > 0)
                {
                    oInvestorWithdrawalBrokerRequest.SetParameterValue("Address", dtbrokerRef.Rows[0]["Address"].ToString());
                    oInvestorWithdrawalBrokerRequest.SetParameterValue("Telephone", dtbrokerRef.Rows[0]["Telephone"].ToString());
                    oInvestorWithdrawalBrokerRequest.SetParameterValue("Email", dtbrokerRef.Rows[0]["Email"].ToString());
                    oInvestorWithdrawalBrokerRequest.SetParameterValue("Web", dtbrokerRef.Rows[0]["Web"].ToString());
                    oInvestorWithdrawalBrokerRequest.SetParameterValue("Fax", dtbrokerRef.Rows[0]["Fax"].ToString());
                    oInvestorWithdrawalBrokerRequest.SetParameterValue("StockExchange", dtbrokerRef.Rows[0]["ExchangeID"].ToString());
                    oInvestorWithdrawalBrokerRequest.SetParameterValue("CompanyName", dtbrokerRef.Rows[0]["BrokerName"].ToString());
                }

                oInvestorWithdrawalBrokerRequest.SetParameterValue("HeadOfficeName", "");
                oInvestorWithdrawalBrokerRequest.SetParameterValue("HeadOfficeAddress", "");
                oInvestorWithdrawalBrokerRequest.SetParameterValue("CompanyName", "");
                oInvestorWithdrawalBrokerRequest.SetParameterValue("Address", "");
                oInvestorWithdrawalBrokerRequest.SetParameterValue("ReportTitle", "");
                oInvestorWithdrawalBrokerRequest.SetParameterValue("CDBL", "");
                oInvestorWithdrawalBrokerRequest.SetParameterValue("Telephone", "");
                oInvestorWithdrawalBrokerRequest.SetParameterValue("Fax", "");
                oInvestorWithdrawalBrokerRequest.SetParameterValue("Email", "");
                oInvestorWithdrawalBrokerRequest.SetParameterValue("Web", "");
                oInvestorWithdrawalBrokerRequest.SetParameterValue("StockExchange", "");
                oInvestorWithdrawalBrokerRequest.SetParameterValue("ReportBranch", "");
                oInvestorWithdrawalBrokerRequest.SetParameterValue("PrintedBy", "");
                oInvestorWithdrawalBrokerRequest.SetParameterValue("Period", "");
                oInvestorWithdrawalBrokerRequest.SetParameterValue("Branch", "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}