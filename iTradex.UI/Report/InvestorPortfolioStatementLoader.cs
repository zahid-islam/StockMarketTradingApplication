using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using System.Collections;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using iTradex.UI.App_Code;
using iTradex.UI.Report;
using System.Data.SqlClient;

namespace iTradex.UI.Report
{

    public class InvestorPortfolioStatementLoader
    {
        //Investor oInvestor;
        string investorAc = string.Empty;
        DateTime portfolioDate;
        ReportDocument oInvestorProtfilioStatement = new ReportDocument();
        SqlConnection sqlConnect = DatabaseConnection.GetConnection();
        GetSession session = new GetSession();

        public InvestorPortfolioStatementLoader(string investorAc, DateTime portfolioDate, ReportDocument _oInvestorProtfilioStatement)
        {

            oInvestorProtfilioStatement = _oInvestorProtfilioStatement;
            //oInvestor = new Investor();
            this.portfolioDate = portfolioDate;
            string Accno = session.AccountNumber;
            this.investorAc = Accno;
            //if (string.IsNullOrEmpty(investorAc))
            //{
            //    throw new Exception("Please insert Investor Account Number");
            //}
            //oInvestor.AccountNumber = investorAc;

            //if (!oInvestor.Select())
            //{

            //    throw new Exception("Investor is not found for Account Number #" + investorAc);

            //}
            //this.investorAc = investorAc;


            oInvestorProtfilioStatement = new InvestorPortfolioStatement();


        }

        public ReportDocument GetReportSource()
        {
            try
            {
                DateTime openDate = DateTime.Today;
                //WorkingCalendar workingDate = new WorkingCalendar() { Status = "Open" };
                //if (workingDate.Select())
                //    openDate = workingDate.WorkingDate;

                openDate = DateTime.Today;

                //Main report

                SqlCommand sqlCmd = new SqlCommand("GetInvestorPortfolioList", sqlConnect);
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add("@ParamInvestor", SqlDbType.VarChar).Value = session.AccountNumber;
                    sqlCmd.Parameters.Add("@PortfolioDate", SqlDbType.DateTime).Value = this.portfolioDate.ToString("yyyy/MM/dd");
                    sqlCmd.Parameters.Add("@BusinessDate", SqlDbType.DateTime).Value = openDate.ToString("yyyy/MM/dd");

                    SqlDataAdapter sdaInvestorPortfolioList = new SqlDataAdapter(sqlCmd);
                    DataTable dtInvestorPortfolioList = new DataTable();
                    sdaInvestorPortfolioList.Fill(dtInvestorPortfolioList);
                    oInvestorProtfilioStatement.SetDataSource(dtInvestorPortfolioList);
                }
                //List<DataService.DataServiceParameter> oParameters = new List<DataService.DataServiceParameter>();
                //oParameters.Add(new DataServiceParameter() { ParameterName = "ParamInvestor", Value = this.investorAc });
                //oParameters.Add(new DataServiceParameter() { ParameterName = "PortfolioDate", Value = this.portfolioDate.ToString("yyyy/MM/dd") });
                //oParameters.Add(new DataServiceParameter() { ParameterName = "BusinessDate", Value = openDate.ToString("yyyy/MM/dd") });

                ////Add dictionary
                //oInvestorProtfilioStatement.SetDataSource(DataService.Utility.GetDataView("GetInvestorPortfolioList", oParameters).ToTable());


                //Subreport Bonus
                SqlCommand CmdBonusReceivable = new SqlCommand("GetPortfolioBonusRec", sqlConnect);
                CmdBonusReceivable.CommandType = CommandType.StoredProcedure;
                CmdBonusReceivable.Parameters.Add("@accountNumber", SqlDbType.VarChar).Value = session.AccountNumber;
                CmdBonusReceivable.Parameters.Add("@caType", SqlDbType.VarChar).Value = "Bonus";

                SqlDataAdapter sdaBonusReceivable = new SqlDataAdapter(CmdBonusReceivable);
                DataTable dtBonusReceivable = new DataTable();
                sdaBonusReceivable.Fill(dtBonusReceivable);
                //oInvestorProtfilioStatement.SetDataSource(dtBonusReceivable);
                oInvestorProtfilioStatement.Subreports["BonusReceivable"].SetDataSource(dtBonusReceivable);

                //DataTable dtGetPortfolioBonusRec = new DataTable();
                //oInvestorProtfilioStatement.Subreports["BonusReceivable"].SetDataSource(dtGetPortfolioBonusRec);
                //List<DataService.DataServiceParameter> oParaSubReportBonus = new List<DataService.DataServiceParameter>();
                //oParaSubReportBonus.Add(new DataServiceParameter() { ParameterName = "accountNumber", Value = this.investorAc });
                //oParaSubReportBonus.Add(new DataServiceParameter() { ParameterName = "caType", Value = "Bonus" });
                ////Add dictionary
                //oInvestorProtfilioStatement.Subreports["BonusReceivable"].SetDataSource(DataService.Utility.GetDataView("GetPortfolioBonusRec", oParaSubReportBonus).ToTable());


                ////Subreport Rights Rec
                //SqlCommand CmdRightsRec = new SqlCommand("GetPortfolioRightsRec", sqlConnect);
                //CmdRightsRec.CommandType = CommandType.StoredProcedure;
                //CmdRightsRec.Parameters.Add("@accountNumber", SqlDbType.VarChar).Value = session.AccountNumber;
                //CmdRightsRec.Parameters.Add("@caType", SqlDbType.VarChar).Value = "Rights";

                //SqlDataAdapter sdaRightsRec = new SqlDataAdapter(CmdRightsRec);
                //DataTable dtRightsRec = new DataTable();
                //sdaRightsRec.Fill(dtRightsRec);
                ////oInvestorProtfilioStatement.SetDataSource(dtRightsRec);
                //oInvestorProtfilioStatement.Subreports["RightsReceivable"].SetDataSource(dtRightsRec);

                //DataTable dtGetPortfolioRightsRec = new DataTable();
                //oInvestorProtfilioStatement.Subreports["RightsReceivable"].SetDataSource(dtGetPortfolioRightsRec);
                //List<DataService.DataServiceParameter> oParaSubReportRights = new List<DataService.DataServiceParameter>();
                //oParaSubReportRights.Add(new DataServiceParameter() { ParameterName = "accountNumber", Value = this.investorAc });
                //oParaSubReportRights.Add(new DataServiceParameter() { ParameterName = "caType", Value = "Rights" });
                ////Add dictionary
                //oInvestorProtfilioStatement.Subreports["RightsReceivable"].SetDataSource(DataService.Utility.GetDataView("GetPortfolioRightsRec", oParaSubReportRights).ToTable());



                //Subreport Dividends
                SqlCommand CmdDividendRec = new SqlCommand("GetPortfolioDividendRec", sqlConnect);
                CmdDividendRec.CommandType = CommandType.StoredProcedure;
                CmdDividendRec.Parameters.Add("@accountNumber", SqlDbType.VarChar).Value = session.AccountNumber;
                CmdDividendRec.Parameters.Add("@caType", SqlDbType.VarChar).Value = "Dividend";

                SqlDataAdapter sdaDividendRec = new SqlDataAdapter(CmdDividendRec);
                DataTable dtDividendRec = new DataTable();
                sdaDividendRec.Fill(dtDividendRec);
                //oInvestorProtfilioStatement.SetDataSource(dtDividendRec);
                oInvestorProtfilioStatement.Subreports["DividendReceivable"].SetDataSource(dtDividendRec);

                //DataTable dtGetPortfolioDividendRec = new DataTable();
                //oInvestorProtfilioStatement.Subreports["DividendReceivable"].SetDataSource(dtGetPortfolioDividendRec);
                //List<DataService.DataServiceParameter> oParaSubReportDiv = new List<DataService.DataServiceParameter>();
                //oParaSubReportDiv.Add(new DataServiceParameter() { ParameterName = "accountNumber", Value = this.investorAc });
                //oParaSubReportDiv.Add(new DataServiceParameter() { ParameterName = "caType", Value = "Dividend" });
                ////Add dictionary
                //oInvestorProtfilioStatement.Subreports["DividendReceivable"].SetDataSource(DataService.Utility.GetDataView("GetPortfolioDividendRec", oParaSubReportDiv).ToTable());

                //Subreport Dividends
                //SqlCommand CmdDividendRec = new SqlCommand("GetPortfolioDividendRec", sqlConnect);
                //CmdDividendRec.CommandType = CommandType.StoredProcedure;
                //CmdDividendRec.Parameters.Add("@accountNumber", SqlDbType.VarChar).Value = session.AccountNumber;
                //CmdDividendRec.Parameters.Add("@caType", SqlDbType.VarChar).Value = "Dividen";

                //SqlDataAdapter sdaDividendRec = new SqlDataAdapter(CmdDividendRec);
                //DataTable dtDividendRec = new DataTable();
                //sdaDividendRec.Fill(dtDividendRec);
                //oInvestorProtfilioStatement.SetDataSource(dtDividendRec);
                //oInvestorProtfilioStatement.Subreports["DividendReceivable"].SetDataSource(dtDividendRec);

                DataTable dtGetInvestmentSegmentwise = new DataTable();
                oInvestorProtfilioStatement.Subreports["Segment"].SetDataSource(dtGetInvestmentSegmentwise);
                //List<DataService.DataServiceParameter> oParaSubReportSegment = new List<DataService.DataServiceParameter>();
                //oParaSubReportSegment.Add(new DataServiceParameter() { ParameterName = "accountNumber", Value = this.investorAc });
                ////Add dictionary
                //oInvestorProtfilioStatement.Subreports["Segment"].SetDataSource(DataService.Utility.GetDataView("GetInvestmentSegmentwise", oParaSubReportSegment).ToTable());


                SetReportParameters(this.portfolioDate);
                return oInvestorProtfilioStatement;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void SetReportParameters(DateTime openDate)
        {
            //Bottom Part of the report
            double immaturedBalance = 0;
            double maturedBalance = 0;
            //double openingBalance = 0;
            double unClearCheque = 0;
            double totalDeposit = 0;
            double totalWithDraw = 0;
            double totalCharges = 0;
            double ledgerBalance = 0;
            double realizeGain = 0;
            double nav = 0;
            double depitratio = 0;
            double exposure = 0;

            //Client AccountS tatus
            SqlCommand cmdStatusDetailsAsOn = new SqlCommand("GetClientAccountStatusDetailsAsOn", sqlConnect);

            cmdStatusDetailsAsOn.CommandType = CommandType.StoredProcedure;
            cmdStatusDetailsAsOn.Parameters.Add("@AccountRef", SqlDbType.VarChar).Value = session.AccountNumber;
            cmdStatusDetailsAsOn.Parameters.Add("@LedgerDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy/MM/dd");

            SqlDataAdapter sdaClientAccountStatusDetailsAsOn = new SqlDataAdapter(cmdStatusDetailsAsOn);
            DataTable dtClientAccountStatusDetailsAsOn = new DataTable();
            //DataSet dsInvestorPortfolioList = new DataSet();
            //dt = ds.Tables["YourTableName"];
            sdaClientAccountStatusDetailsAsOn.Fill(dtClientAccountStatusDetailsAsOn);

            if (dtClientAccountStatusDetailsAsOn != null)
            {
                if (dtClientAccountStatusDetailsAsOn.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtClientAccountStatusDetailsAsOn.Rows)
                    {
                        immaturedBalance = Convert.ToDouble(dr["ImmaturedSale"]);
                        ledgerBalance = Convert.ToDouble(dr["LedgerBalance"]);
                        maturedBalance = Convert.ToDouble(dr["AvailableBalance"]);
                        unClearCheque = Convert.ToDouble(dr["UnclearCheque"]);
                        //immaturedBalance = ledgerBalance - AvailableBalance;
                    }
                }
            }

            //Investor Financial Position     
            SqlCommand CmdFinancialPosition = new SqlCommand("InvestorFinancialPosition", sqlConnect);
            CmdFinancialPosition.CommandType = CommandType.StoredProcedure;

            CmdFinancialPosition.Parameters.Add("@AccountRef", SqlDbType.VarChar).Value = session.AccountNumber;
            CmdFinancialPosition.Parameters.Add("@LedgerDate", SqlDbType.DateTime).Value = openDate.ToString("yyyy-MM-dd");

            SqlDataAdapter sdaInvestorFinancialPosition = new SqlDataAdapter(CmdFinancialPosition);
            DataTable dtFinancialPosition = new DataTable();
            sdaInvestorFinancialPosition.Fill(dtFinancialPosition);

            if (dtFinancialPosition != null)
            {
                if (dtFinancialPosition.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtFinancialPosition.Rows)
                    {
                        totalDeposit = Convert.ToDouble(dr["TOTALINVESTMENT"]);
                        realizeGain = Convert.ToDouble(dr["REALIZEDGAIN"]);
                        totalWithDraw = Convert.ToDouble(dr["TOTALWITHDRAW"]);
                        totalCharges = Convert.ToDouble(dr["ACCRUEDINTEREST"]);
                    }
                }
            }

            //Report Parameters    
            oInvestorProtfilioStatement.SetParameterValue("ReportTitle", "Investor Portfolio Statement");
            oInvestorProtfilioStatement.SetParameterValue("CashBalance", ledgerBalance);
            oInvestorProtfilioStatement.SetParameterValue("AmountReceivable", immaturedBalance);
            oInvestorProtfilioStatement.SetParameterValue("UnClearCheque", unClearCheque);
            oInvestorProtfilioStatement.SetParameterValue("TotalDeposit", totalDeposit);
            //oInvestorProtfilioStatement.SetParameterValue("RealizeGain", oInvestor.RealisedGain);
            oInvestorProtfilioStatement.SetParameterValue("RealizeGain", realizeGain);
            oInvestorProtfilioStatement.SetParameterValue("TotalWithdraw", totalWithDraw);
            oInvestorProtfilioStatement.SetParameterValue("AccruedCommission", totalCharges);
            oInvestorProtfilioStatement.SetParameterValue("NAV", nav);
            double loan = 0.00;
            //if (oInvestor.InvestorGroup.MarginCategory != null)
            //{
            //    loan = oInvestor.InvestorGroup.MarginCategory.MarginRatio;
            //}
            oInvestorProtfilioStatement.SetParameterValue("LoanRatio", loan);
            oInvestorProtfilioStatement.SetParameterValue("DepitRatio", depitratio);
            oInvestorProtfilioStatement.SetParameterValue("Exposure", exposure);
            oInvestorProtfilioStatement.SetParameterValue("BONumber", session.BoNumber);
            oInvestorProtfilioStatement.SetParameterValue("AccountType", string.Empty);
            oInvestorProtfilioStatement.SetParameterValue("PortfolioDate", openDate.ToString("dd-MMM-yyyy"));
            oInvestorProtfilioStatement.SetParameterValue("AccountCode", session.AccountNumber);
            oInvestorProtfilioStatement.SetParameterValue("AccountName", session.AccountName);

            CommonFunction cmDataTable = new CommonFunction();
            string query = "select Address,Telephone,Fax,Email,ExchangeID,Web,BrokerName from Broker";
            DataTable dtbrokerRef = cmDataTable.GetDatatable(query);
            if (dtbrokerRef.Rows.Count > 0)
            {
                oInvestorProtfilioStatement.SetParameterValue("Address", dtbrokerRef.Rows[0]["Address"].ToString());
                oInvestorProtfilioStatement.SetParameterValue("Telephone", dtbrokerRef.Rows[0]["Telephone"].ToString());
                oInvestorProtfilioStatement.SetParameterValue("Email", dtbrokerRef.Rows[0]["Email"].ToString());
                oInvestorProtfilioStatement.SetParameterValue("Web", dtbrokerRef.Rows[0]["Web"].ToString());
                oInvestorProtfilioStatement.SetParameterValue("Fax", dtbrokerRef.Rows[0]["Fax"].ToString());
                oInvestorProtfilioStatement.SetParameterValue("StockExchange", dtbrokerRef.Rows[0]["ExchangeID"].ToString());
                oInvestorProtfilioStatement.SetParameterValue("CompanyName", dtbrokerRef.Rows[0]["BrokerName"].ToString());
            }

            oInvestorProtfilioStatement.SetParameterValue("Branch", string.Empty);
            oInvestorProtfilioStatement.SetParameterValue("CDBL", string.Empty);
        }
    }
}