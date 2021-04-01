using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

namespace iTradex.UI
{
    public partial class ReportViwer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //txtTitle.BackColor = Color.Transparent;
                string reportName = Session["ReportName"] as string;

                #region Test-Successed No Need
                /* if (!string.IsNullOrEmpty(reportName))
            {
                switch (reportName)
                {
                    case "InvestorPortfolioStatement":
                        InvestorPortfolioStatementLoader oLoader = Session["ReportObj"] as InvestorPortfolioStatementLoader;                        
                        crvReport.ReportSource = oLoader.GetReportSource();
                        txtTitle.Text = "Investor Portfolio Statement";
                        break;
                    case "StockBalancebyInvestor":
                        StockBalancebyInvestorLoader oStockBalancebyInvestorLoader = Session["ReportObj"] as StockBalancebyInvestorLoader;                    
                        crvReport.ReportSource = oStockBalancebyInvestorLoader.GetReportSource();
                        txtTitle.Text = "Stock Balance by Investor";
                        break;

                    case "InvestorLedgerStatement":
                        InvestorLedgerStatementLoader oInvestorLedgerStatementLoader = Session["ReportObj"] as InvestorLedgerStatementLoader;
                        crvReport.ReportSource = oInvestorLedgerStatementLoader.GetReportSource();
                        txtTitle.Text = "Investor Ledger Statement";
                        break;
                    case "ClientwiseTransactionSummaryStatement":
                        ClientwiseTransactionSummaryStatementLoader oClientwiseTransactionSummaryStatementLoader = Session["ReportObj"] as ClientwiseTransactionSummaryStatementLoader;
                        crvReport.ReportSource = oClientwiseTransactionSummaryStatementLoader.GetReportSource();
                        txtTitle.Text = "Clientwise Transaction Summary Statement Loader";
                        break;
                    case "InvestorsImmaturedCashBalance":

                        InvestorsImmatureCashBalanceLoader oInvestorsImmatureCashBalanceLoader = Session["ReportObj"] as InvestorsImmatureCashBalanceLoader;
                        crvReport.ReportSource = oInvestorsImmatureCashBalanceLoader.GetReportSource();
                        txtTitle.Text = "Investors Immatured Cash Balance";
                        break;
                    case "InstrumentWiseLedger":

                        InstrumentWiseLedgerLoader oInstrumentWiseLedgerLoader = Session["ReportObj"] as InstrumentWiseLedgerLoader;
                        crvReport.ReportSource = oInstrumentWiseLedgerLoader.GetReportSource();
                        txtTitle.Text = "Instrument Wise Ledger";
                        break;
                    case "InvestorLessCashBalance":
                        InvestorLessCashBalanceLoader oInvestorLessCashBalanceLoader = Session["ReportObj"] as InvestorLessCashBalanceLoader;
                        crvReport.ReportSource = oInvestorLessCashBalanceLoader.GetReportSource();
                        txtTitle.Text = "Investor Less Cash Balancer";
                        break;
                    case "InvestorsProfitandLossStatement":
                        InvestorsProfitandLossStatementLoader oInvestorsProfitandLossStatementLoader = Session["ReportObj"] as InvestorsProfitandLossStatementLoader;
                        crvReport.ReportSource = oInvestorsProfitandLossStatementLoader.GetReportSource();
                        txtTitle.Text = "Investors Profit and Loss Statement";
                        break;
                    default:
                        break;
                }*/
                #endregion

                ReportDocument rd = Session["ReportDocumentObj"] as ReportDocument;
                //ReportDocument rd = (ReportDocument)oReportLoader.GetReportSource();

                MemoryStream oStream;
                oStream = (MemoryStream)rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(oStream.ToArray());
                Response.End();
                Response.Close();
                oStream.Dispose();
                rd.Close();
                rd.Dispose();
                GC.Collect();

                // txtTitle.Text = System.Text.RegularExpressions.Regex.Replace(reportName, "([A-Z])", " $1");
                // crvReport.Zoom(150);
                //crvReport.DisplayGroupTree = false;
                //crvReport.DisplayToolbar = true;
                //crvReport.HasPrintButton = true;
                //crvReport.DataBind();
                //crvReport.PrintMode = PrintMode.ActiveX;
                // CrystalReportViewer 

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }

        }
    }
}