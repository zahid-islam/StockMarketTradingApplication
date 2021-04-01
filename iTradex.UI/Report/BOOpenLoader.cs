using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using System.Web;
using iTradex.UI.App_Code;
using System.Data.SqlClient;
using System.Data;

namespace iTradex.UI.Pages.Investor
{
    class BOOpenLoader
    {
        
        ReportDocument oBOAcknowledgement = new ReportDocument();

        string accountRef = string.Empty;
        string fromDate;
        string toDate;
        //string instrumentName;

        GetSession session = new GetSession();

        public BOOpenLoader(string accountRef, string fromDate, string toDate, ReportDocument _oBOAcknowledgement)
        {
            oBOAcknowledgement = _oBOAcknowledgement;
            this.accountRef = accountRef;
            this.fromDate = fromDate;
            this.toDate = toDate;
            //this.instrumentName = instrumentName;
            //FirstDateOfmonth = new DateTime(fromDate.Year, fromDate.Month, 1);
        }

        public ReportDocument GetReportSource()
        {
            try
            {
                string dateFrom = HttpContext.Current.Session["FromoDate"].ToString();
                string dateTo = HttpContext.Current.Session["ToDate"].ToString();
                //string instrumentName = HttpContext.Current.Session["instrumentName"].ToString();
                SqlConnection sconFillDataTable = DatabaseConnection.GetConnection();
                SqlCommand cmdFillDataTable = new SqlCommand("BORegistrationConfirmation", sconFillDataTable);
                cmdFillDataTable.CommandType = CommandType.StoredProcedure;

                cmdFillDataTable.Parameters.Add("@accountNumber", SqlDbType.VarChar).Value = session.AccountNumber;
               
                cmdFillDataTable.Parameters.Add("@fomdate", SqlDbType.DateTime).Value = dateFrom;
                cmdFillDataTable.Parameters.Add("@toDate", SqlDbType.DateTime).Value = dateTo;
                sconFillDataTable.Close();
                SqlDataAdapter sdaBOAcknowledgement = new SqlDataAdapter(cmdFillDataTable);
                DataTable dtBOAcknowledgement = new DataTable();
                sdaBOAcknowledgement.Fill(dtBOAcknowledgement);
                oBOAcknowledgement.SetDataSource(dtBOAcknowledgement);
                SetParameters();
                return oBOAcknowledgement;
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
                    oBOAcknowledgement.SetParameterValue("Address", dtbrokerRef.Rows[0]["Address"].ToString());
                    oBOAcknowledgement.SetParameterValue("Telephone", dtbrokerRef.Rows[0]["Telephone"].ToString());
                    oBOAcknowledgement.SetParameterValue("Email", dtbrokerRef.Rows[0]["Email"].ToString());
                    oBOAcknowledgement.SetParameterValue("Web", dtbrokerRef.Rows[0]["Web"].ToString());
                    oBOAcknowledgement.SetParameterValue("Fax", dtbrokerRef.Rows[0]["Fax"].ToString());
                    oBOAcknowledgement.SetParameterValue("StockExchange", dtbrokerRef.Rows[0]["ExchangeID"].ToString());
                    oBOAcknowledgement.SetParameterValue("CompanyName", dtbrokerRef.Rows[0]["BrokerName"].ToString());
                }

                oBOAcknowledgement.SetParameterValue("Branch", " ");
                oBOAcknowledgement.SetParameterValue("CDBL", " ");
               // oBOAcknowledgement.SetParameterValue("ReportBranch", " ");
                oBOAcknowledgement.SetParameterValue("ReportTitle", "Instrument Ledger");
                
                //oBOAcknowledgement.SetParameterValue("Trader", instrumentName);
               // oBOAcknowledgement.SetParameterValue("AccountName", session.AccountNumber);
               // oBOAcknowledgement.SetParameterValue("fromDate", fromDate);
               // oBOAcknowledgement.SetParameterValue("toDate", toDate);
                //Add dictionary
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
