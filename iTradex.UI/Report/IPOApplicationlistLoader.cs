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
    public class IPOApplicationlistLoader
    {
        ReportDocument oIPOApplicationLoder = new ReportDocument();
        string status;
        string companyName;
        GetSession session = new GetSession();
        public IPOApplicationlistLoader(string status, string companyName, ReportDocument _oIPOApplicationLoder)
        {
            oIPOApplicationLoder = _oIPOApplicationLoder;
            this.status = status;
            this.companyName = companyName;
        }

        public ReportDocument GetReportSource()
        {
            try
            {
                SqlConnection conWithdrawalRequest = DatabaseConnection.GetConnection();
                SqlCommand cmdWithdrawalRequest = new SqlCommand("GetIPOApplicationList", conWithdrawalRequest);
                cmdWithdrawalRequest.CommandType = CommandType.StoredProcedure;

                cmdWithdrawalRequest.Parameters.Add("@Status", SqlDbType.VarChar).Value = status;
                cmdWithdrawalRequest.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = companyName;

                SqlDataAdapter sdaWithdrawalRequest = new SqlDataAdapter(cmdWithdrawalRequest);
                DataTable dtWithdrawalRequest = new DataTable();
                sdaWithdrawalRequest.Fill(dtWithdrawalRequest);
                oIPOApplicationLoder.SetDataSource(dtWithdrawalRequest);
                SetParameters();
                return oIPOApplicationLoder;
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
                    oIPOApplicationLoder.SetParameterValue("Address", dtbrokerRef.Rows[0]["Address"].ToString());
                    oIPOApplicationLoder.SetParameterValue("Telephone", dtbrokerRef.Rows[0]["Telephone"].ToString());
                    oIPOApplicationLoder.SetParameterValue("Email", dtbrokerRef.Rows[0]["Email"].ToString());
                    oIPOApplicationLoder.SetParameterValue("Web", dtbrokerRef.Rows[0]["Web"].ToString());
                    oIPOApplicationLoder.SetParameterValue("Fax", dtbrokerRef.Rows[0]["Fax"].ToString());
                    oIPOApplicationLoder.SetParameterValue("StockExchange", dtbrokerRef.Rows[0]["ExchangeID"].ToString());
                    oIPOApplicationLoder.SetParameterValue("CompanyName", dtbrokerRef.Rows[0]["BrokerName"].ToString());
                }
                else
                {
                    oIPOApplicationLoder.SetParameterValue("Address", string.Empty);
                    oIPOApplicationLoder.SetParameterValue("Telephone", string.Empty);
                    oIPOApplicationLoder.SetParameterValue("Email", string.Empty);
                    oIPOApplicationLoder.SetParameterValue("Web", string.Empty);
                    oIPOApplicationLoder.SetParameterValue("Fax", string.Empty);
                    oIPOApplicationLoder.SetParameterValue("StockExchange", string.Empty);
                    oIPOApplicationLoder.SetParameterValue("CompanyName", string.Empty);
                }

                oIPOApplicationLoder.SetParameterValue("HeadOfficeName", "");
                oIPOApplicationLoder.SetParameterValue("HeadOfficeAddress", "");
                oIPOApplicationLoder.SetParameterValue("ReportTitle", "IPO Applications List");
                oIPOApplicationLoder.SetParameterValue("CDBL", "");
                oIPOApplicationLoder.SetParameterValue("ReportBranch", "");
                oIPOApplicationLoder.SetParameterValue("PrintedBy", "");
                oIPOApplicationLoder.SetParameterValue("Period", "");
                oIPOApplicationLoder.SetParameterValue("Branch", "");


            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}