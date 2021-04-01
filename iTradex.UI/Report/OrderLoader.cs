using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using iTradex.UI.App_Code;
using System.Data;
using System.Globalization;

namespace iTradex.UI.Report
{
    public class OrderLoader
    {
        ReportDocument oOrderReportDocument = new ReportDocument();
        string status = string.Empty;
        string fromDate;
        string toDate;
        GetSession session = new GetSession();
        public OrderLoader(string status, string fromDate, string toDate, ReportDocument _oOrderReportDocument)
        {
            oOrderReportDocument = _oOrderReportDocument;
            this.status = status;
            this.fromDate = fromDate;
            this.toDate = toDate;
        }


        public ReportDocument GetReportSource()
        {
            try
            {
                string databaseDateFormat = "yyyy/MM/dd";
                CommonFunction cmDataTable = new CommonFunction();
                string showAddData = "select InvestorACRef, Reference,Instrument,TransactionType,ShareQuantity,Rate,Status,TransactionTime,TransactionDate from TradeOrderFromWeb WHERE TransactionDate between '" + DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat) + "' and '" + DateTime.ParseExact(toDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString(databaseDateFormat) + "' and status='" + status + "' order by TransactionTime,InvestorACRef,Instrument ";

                DataTable dtAllOrders = cmDataTable.GetDatatable(showAddData);


                oOrderReportDocument.SetDataSource(dtAllOrders);
                SetReportParameters();
                return oOrderReportDocument;
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
                CommonFunction cmDataTable = new CommonFunction();
                string query = "select Address,Telephone,Fax,Email,ExchangeID,Web,BrokerName from Broker where Reference='" + session.BrokerRef + "'";
                DataTable dtbrokerRef = cmDataTable.GetDatatable(query);
                if (dtbrokerRef.Rows.Count > 0)
                {
                    oOrderReportDocument.SetParameterValue("Address", dtbrokerRef.Rows[0]["Address"].ToString());
                    oOrderReportDocument.SetParameterValue("Telephone", dtbrokerRef.Rows[0]["Telephone"].ToString());
                    oOrderReportDocument.SetParameterValue("Email", dtbrokerRef.Rows[0]["Email"].ToString());
                    oOrderReportDocument.SetParameterValue("Web", dtbrokerRef.Rows[0]["Web"].ToString());
                    oOrderReportDocument.SetParameterValue("Fax", dtbrokerRef.Rows[0]["Fax"].ToString());
                    oOrderReportDocument.SetParameterValue("StockExchange", dtbrokerRef.Rows[0]["ExchangeID"].ToString());
                    oOrderReportDocument.SetParameterValue("CompanyName", dtbrokerRef.Rows[0]["BrokerName"].ToString());
                }
                else
                {
                    oOrderReportDocument.SetParameterValue("Address", string.Empty);
                    oOrderReportDocument.SetParameterValue("Telephone", string.Empty);
                    oOrderReportDocument.SetParameterValue("Email", string.Empty);
                    oOrderReportDocument.SetParameterValue("Web", string.Empty);
                    oOrderReportDocument.SetParameterValue("Fax", string.Empty);
                    oOrderReportDocument.SetParameterValue("StockExchange", string.Empty);
                    oOrderReportDocument.SetParameterValue("CompanyName", string.Empty);
                }

                oOrderReportDocument.SetParameterValue("HeadOfficeName", "");
                oOrderReportDocument.SetParameterValue("HeadOfficeAddress", "");
                oOrderReportDocument.SetParameterValue("ReportTitle", "List Of Orders");
                oOrderReportDocument.SetParameterValue("CDBL", "");
                oOrderReportDocument.SetParameterValue("ReportBranch", "");
                oOrderReportDocument.SetParameterValue("PrintedBy", "");
                oOrderReportDocument.SetParameterValue("Period", "");
                oOrderReportDocument.SetParameterValue("Branch", "");


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}