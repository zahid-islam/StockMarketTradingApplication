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
    public class WithdrawalBrokerRequestLoader
    {
        ReportDocument oWithdrawalBrokerRequest = new ReportDocument();
        string status = string.Empty;
        string fromDate;
        string toDate;
        GetSession session = new GetSession();
        public WithdrawalBrokerRequestLoader(string status, string fromDate, string toDate, ReportDocument _oWithdrawalBrokerRequest)
        {
            oWithdrawalBrokerRequest = _oWithdrawalBrokerRequest;
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

                cmdWithdrawalRequest.Parameters.Add("@Status", SqlDbType.VarChar).Value = status;
                cmdWithdrawalRequest.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = fromDate;
                cmdWithdrawalRequest.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = toDate; 

                SqlDataAdapter sdaWithdrawalRequest = new SqlDataAdapter(cmdWithdrawalRequest);
                DataTable dtWithdrawalRequest = new DataTable();
                sdaWithdrawalRequest.Fill(dtWithdrawalRequest);
                oWithdrawalBrokerRequest.SetDataSource(dtWithdrawalRequest);
                SetParameters();
                return oWithdrawalBrokerRequest;
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
                string query = "select Address,Telephone,Fax,Email,ExchangeID,Web,BrokerName from Broker where Reference='" + session.BrokerRef + "'";
                DataTable dtbrokerRef = cmDataTable.GetDatatable(query);
                if (dtbrokerRef.Rows.Count > 0)
                {
                    oWithdrawalBrokerRequest.SetParameterValue("Address", dtbrokerRef.Rows[0]["Address"].ToString());
                    oWithdrawalBrokerRequest.SetParameterValue("Telephone", dtbrokerRef.Rows[0]["Telephone"].ToString());
                    oWithdrawalBrokerRequest.SetParameterValue("Email", dtbrokerRef.Rows[0]["Email"].ToString());
                    oWithdrawalBrokerRequest.SetParameterValue("Web", dtbrokerRef.Rows[0]["Web"].ToString());
                    oWithdrawalBrokerRequest.SetParameterValue("Fax", dtbrokerRef.Rows[0]["Fax"].ToString());
                    oWithdrawalBrokerRequest.SetParameterValue("StockExchange", dtbrokerRef.Rows[0]["ExchangeID"].ToString());
                    oWithdrawalBrokerRequest.SetParameterValue("CompanyName", dtbrokerRef.Rows[0]["BrokerName"].ToString());
                }
                else
                {
                    oWithdrawalBrokerRequest.SetParameterValue("Address", string.Empty);
                    oWithdrawalBrokerRequest.SetParameterValue("Telephone", string.Empty);
                    oWithdrawalBrokerRequest.SetParameterValue("Email", string.Empty);
                    oWithdrawalBrokerRequest.SetParameterValue("Web", string.Empty);
                    oWithdrawalBrokerRequest.SetParameterValue("Fax", string.Empty);
                    oWithdrawalBrokerRequest.SetParameterValue("StockExchange", string.Empty);
                    oWithdrawalBrokerRequest.SetParameterValue("CompanyName", string.Empty);
                }

                oWithdrawalBrokerRequest.SetParameterValue("HeadOfficeName", "");
                oWithdrawalBrokerRequest.SetParameterValue("HeadOfficeAddress", "");
                oWithdrawalBrokerRequest.SetParameterValue("ReportTitle", "Withdrawal Request");
                oWithdrawalBrokerRequest.SetParameterValue("CDBL", "");
                oWithdrawalBrokerRequest.SetParameterValue("ReportBranch", "");
                oWithdrawalBrokerRequest.SetParameterValue("PrintedBy", "");
                oWithdrawalBrokerRequest.SetParameterValue("Period", "");
                oWithdrawalBrokerRequest.SetParameterValue("Branch", "");

                oWithdrawalBrokerRequest.SetParameterValue("@FromDate", this.fromDate);
                oWithdrawalBrokerRequest.SetParameterValue("@ToDate", this.toDate);
                oWithdrawalBrokerRequest.SetParameterValue("@Status", this.status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}