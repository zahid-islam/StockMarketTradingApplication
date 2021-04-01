using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.Services;
using iTradex.UI.App_Code;
using CrystalDecisions.CrystalReports.Engine;
using iTradex.UI.Report;
using Newtonsoft.Json;
using CityBankASP;

namespace iTradex.UI.Pages.Investor
{
    public class TokenModel
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string TransactionId { get; set; }
    }

    public class ResultModel
    {
        public int ResponseCode { get; set; }
        public string Message { get; set; }
        public ItemModel Items { get; set; }
    }

    public class ItemModel
    {
        public string OrderId { get; set; }
        public string SessionId { get; set; }
        public string Status { get; set; }
        public string Url { get; set; }
    }

    public partial class Dashboard : System.Web.UI.Page
    {
        public double ledgerBalanceGlobal;
        public double sumTotalCostGlobal;
        public double sumMarketValueGlobal;
        public double unclearChequeGlobal;
        public double availableBalanceGlobal;
        public string accountTypeGlobal;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AccountNumber"] == null)
                {
                    //Response.Redirect("../../Default.aspx");

                    Response.Redirect("../../LoginErrorPage.aspx?ex= AccountNumber in Session" + "&st=" + Session["AccountNumber"]);
                }
                if (!IsPostBack)
                {
                    AccountStatusTillToday();
                    GetDepositeWithdraw();
                    GetStockLedger();
                    GetInvestorInfo();
                    GetCurrentInvestmentPosition();
                    GetDepositInformatio();
                }
            }
            catch (FormatException ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }



        /// <summary>
        /// Data Populate for Capital/Gain
        /// </summary>
        protected void GetStockLedger()
        {
            GetSession session = new GetSession();
            CommonFunction dt = new CommonFunction();

            SqlConnection sqlConnect = DatabaseConnection.GetConnection();
            SqlCommand sqlCmd = new SqlCommand("GetInvestorPortfolioList", sqlConnect);
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;

                //sqlCmd.Parameters.Add("@ParamInvestor", SqlDbType.VarChar).Value = HttpContext.Current.Session["AccountNumber"];
                sqlCmd.Parameters.Add("@ParamInvestor", SqlDbType.VarChar).Value = session.AccountNumber;
                sqlCmd.Parameters.Add("@PortfolioDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy/MM/dd");
                sqlCmd.Parameters.Add("@BusinessDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy/MM/dd");

                SqlDataAdapter sdaInvestorPortfolioList = new SqlDataAdapter(sqlCmd);
                DataTable dtInvestorPortfolioList = new DataTable();
                //DataSet dsInvestorPortfolioList = new DataSet();
                //dt = ds.Tables["YourTableName"];
                sdaInvestorPortfolioList.Fill(dtInvestorPortfolioList);

                if (dtInvestorPortfolioList != null)
                {
                    if (dtInvestorPortfolioList.Rows.Count > 0)
                    {
                        //Sum of Martket value of securities
                        double sumMarketValue = Convert.ToDouble(dtInvestorPortfolioList.Compute("Sum(MarketValue)", ""));
                        lblMarketValueOfSecurity.Text = sumMarketValue.ToString("#,##0.00");

                        //Sum of Total Cost of Securities
                        double sumTotalCost = Convert.ToDouble(dtInvestorPortfolioList.Compute("Sum(TotalCost)", ""));
                        lblCostOfSecurity.Text = sumTotalCost.ToString("#,##0.00");

                        //Sum of Realized Gain/Loss
                        double sumRealizedGainLoss = Convert.ToDouble(dtInvestorPortfolioList.Compute("Sum(RealisedGain)", ""));
                        lblRealizedGainLoss.Text = sumRealizedGainLoss.ToString("#,##0.00");
                        // lblRealizedGainLossDeposite.Text = sumRealizedGainLoss.ToString("#,##0.00");

                        //Sum of UnRealized Gain/Loss
                        double sumUnRealizedGainLoss = Convert.ToDouble(dtInvestorPortfolioList.Compute("Sum(UnRealisedGain)", ""));
                        lblUnrealizedGainLoss.Text = sumUnRealizedGainLoss.ToString("#,##0.00");

                        lblnetGainLoss.Text = (sumUnRealizedGainLoss + sumRealizedGainLoss).ToString("#,##0.00");

                        this.sumMarketValueGlobal = sumMarketValue;
                        this.sumTotalCostGlobal = sumTotalCost;
                        //MarketValue for formatting 2 multiplied field.
                        double MarketValueData = 0;

                        foreach (DataRow dr in dtInvestorPortfolioList.Rows)
                        {
                            MarketValueData = (Double.Parse(dr["NetBalance"].ToString()) * Double.Parse(dr["MarketPrice"].ToString()));
                            dr["MarketValue"] = MarketValueData;
                        }
                    }
                }
                //Data bind to rptLedger datable
                rptLedger.DataSource = dtInvestorPortfolioList;
                rptLedger.DataBind();

            }
            catch (SqlException ex)
            {
                //lblStatus.Text = "An error occured" + ex.Message;
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
            finally
            {
                sqlConnect.Close();
            }
        }
        /// <summary>
        /// Pupolate Account Status till today panel
        /// </summary>
        protected void AccountStatusTillToday()
        {
            GetSession session = new GetSession();
            SqlConnection sqlConnect = DatabaseConnection.GetConnection();
            SqlCommand sqlCmd = new SqlCommand("GetClientAccountStatusDetailsAsOn", sqlConnect);
            sqlCmd.CommandTimeout = 360;

            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.Add("@AccountRef", SqlDbType.VarChar).Value = session.AccountNumber;
                sqlCmd.Parameters.Add("@LedgerDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy/MM/dd");

                SqlDataAdapter sdaClientAccountStatusDetailsAsOn = new SqlDataAdapter(sqlCmd);
                DataTable dtClientAccountStatusDetailsAsOn = new DataTable();
                sdaClientAccountStatusDetailsAsOn.Fill(dtClientAccountStatusDetailsAsOn);

                if (dtClientAccountStatusDetailsAsOn != null)
                {
                    if (dtClientAccountStatusDetailsAsOn.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtClientAccountStatusDetailsAsOn.Rows)
                        {
                            double ledgerBalance = Convert.ToDouble(dr["LedgerBalance"]);
                            double AvailableBalance = Convert.ToDouble(dr["AvailableBalance"]);
                            double immaturedBalance = ledgerBalance - AvailableBalance;
                            double unclearCheque = Convert.ToDouble(dr["UnclearCheque"]);
                            lblAvailableBalanceTillToday.Text = AvailableBalance.ToString("#,##0.00");
                            lblImmaturedBalance.Text = immaturedBalance.ToString("#,##0.00");
                            UnclearCheque.Text = unclearCheque.ToString("#,##0.00");
                            LedgerBalance.Text = ledgerBalance.ToString("#,##0.00");

                            this.ledgerBalanceGlobal = ledgerBalance;
                            this.unclearChequeGlobal = unclearCheque;
                            this.availableBalanceGlobal = AvailableBalance;
                        }
                    }
                }
                //Data bind to rptLedger datable

            }
            catch (SqlException ex)
            {
                //lblStatus.Text = "An error occured" + ex.Message;
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
            finally
            {
                sqlConnect.Close();
            }
        }

        /// <summary>
        /// Data populate for Making Deposit
        /// </summary>
        protected void GetDepositInformatio()
        {
            GetSession session = new GetSession();
            txtAccountNumber.Text = session.AccountNumber;
            SqlConnection sqlConnect = DatabaseConnection.GetConnection();

            string queryPaymentMode = "SELECT p.Description, p.APIUrl, p.MerchantID, p.Username, p.Password FROM PaymentMode p";

            SqlCommand sqlCmd = new SqlCommand(queryPaymentMode, sqlConnect);
            try
            {
                SqlDataReader sdReader = sqlCmd.ExecuteReader();

                if (sdReader.HasRows)
                {
                    while (sdReader.Read())
                    {
                        PaymentModeDropDownList.Items.Add(new ListItem(sdReader[0].ToString(), sdReader[1].ToString()));
                        Session["Merchant"] = sdReader["MerchantID"].ToString();
                        Session["MerchantUserName"] = sdReader["Username"].ToString();
                        Session["MerchantPassword"] = sdReader["Password"].ToString();
                    }
                    PaymentModeDropDownList.SelectedIndex = 0;
                    btnDepositProceed.Disabled = true;
                    policyCheckBox.Checked = false;

                    var value = PaymentModeDropDownList.SelectedItem;
                    var vale = PaymentModeDropDownList.SelectedItem.Value;
                }
            }
            catch (SqlException ex)
            {
                //lblStatus.Text = "An error occured" + ex.Message;
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
            catch (FormatException ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
            finally
            {
                sqlConnect.Close();
                sqlConnect.Dispose();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            policyCheckBox.Checked = false;
        }

        protected void btnTermsAndPolicy_Click(object sender, EventArgs e)
        {
            Response.Redirect("TermsAndPrivacyPolicy.aspx");
        }

        protected void btnDepositProceed_Click(object sender, EventArgs e)
        {
            btnDepositProceed.Disabled = true;
            policyCheckBox.Checked = false;
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            GetSession session = new GetSession();

            string Merchant = session.Merchant;
            decimal PurchaseAmount = Convert.ToDecimal(txtAmount.Text);
            string Description = txtYourReference.Text.ToString();

            string proxy = "";
            string proxyauth = "";
            string postDataToken = "{\"userName\":\"" + session.MerchantUserName + "\",\"password\":\"" + session.MerchantPassword + "\"}";
            string serviceUrltoken = "https://sandbox.thecitybank.com:7788/transaction/token";
            string certPath = Server.MapPath("/");
            int port = Request.Url.Port;

            //Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(certPath));

            string resToken = Functions.ProcessRequest(certPath, postDataToken, serviceUrltoken, proxy, proxyauth);

            TokenModel resTokenList = JsonConvert.DeserializeObject<TokenModel>(resToken.ToString());
            string txnID = resTokenList.TransactionId;

            string serviceUrlEcom = "https://sandbox.thecitybank.com:7788/transaction/createorder";

            string postDataEcom = "{\"merchantId\":\"" + Merchant + "\","
                + "\"amount\":\"" + PurchaseAmount + "\","
                + "\"currency\":\"050\","
                + "\"description\":\"" + Description + "\","
                + "\"approveUrl\":\"http://localhost:"+port+"/Pages/Investor/Approved.aspx\","
                + "\"cancelUrl\":\"http://localhost:"+port+"/Pages/Investor/Declined.aspx\","
                + "\"declineUrl\":\"http://localhost:"+port+"/Pages/Investor/Declined.aspx\","
                + "\"userName\":\"" + session.MerchantUserName + "\","
                + "\"passWord\":\"" + session.MerchantPassword + "\","
                + "\"secureToken\":\"" + txnID + "\"}";


            string resEcom = Functions.ProcessRequest(certPath, postDataEcom, serviceUrlEcom, proxy, proxyauth);
            ResultModel resEcomList = JsonConvert.DeserializeObject<ResultModel>(resEcom);

            string URL = resEcomList.Items.Url;
            string OrderID = resEcomList.Items.OrderId;
            string SessionID = resEcomList.Items.SessionId;

            //Call for Payment Page
            if (OrderID != "" && SessionID != "")
            {
                //Merchant have to store Created Order Details in Shop DB
                Session["Merchant"] = Merchant;
                Session["OrderID"] = OrderID;
                Session["SessionID"] = SessionID;
                Session["PurchaseAmount"] = PurchaseAmount;
                Session["Description"] = Description;
                Session["onlineTransactionID"] = txnID;
                Session["Status"] = "Created";

                Response.Redirect(URL + "?ORDERID=" + OrderID + "&SESSIONID=" + SessionID);
            }
        }

        protected void GetCurrentInvestmentPosition()
        {
            double totalEquity = this.ledgerBalanceGlobal + sumMarketValueGlobal - unclearChequeGlobal;
            lblTotalEquity.Text = totalEquity.ToString("#,##0.00");
            {
                if (this.accountTypeGlobal == "Margin")
                {
                    double purchasePower = ledgerBalanceGlobal - unclearChequeGlobal + (totalEquity * 0.5);
                    lblPurchasePower.Text = purchasePower.ToString("#,##0.00");
                }
                else if (this.accountTypeGlobal == "Cash")
                {
                    double purchasePower = ledgerBalanceGlobal - unclearChequeGlobal;
                    lblPurchasePower.Text = purchasePower.ToString("#,##0.00");
                }
            }
            {
                if (ledgerBalanceGlobal < 0)
                {
                    double exposure = (Math.Abs(ledgerBalanceGlobal) / sumMarketValueGlobal) * 100;
                    lblExposure.Text = exposure.ToString("#,##0.00");

                }
                else
                    lblExposure.Text = "0.00";

            }
        }


        /// <summary>
        /// Data populate for investor information
        /// </summary>
        protected void GetInvestorInfo()
        {
            GetSession session = new GetSession();
            SqlConnection sqlConnect = DatabaseConnection.GetConnection();

            string queryInvestorInfo = "SELECT p.Mobile, p.ShortName AS ShortName, p.SecondHolder, p.Status, p.AccountStatus, p.Nationality, p.BONumber,"
                            + "p.FirstName, p.Name, p.AccountCategory, p.AccountNumber, "
                            + "i.AccountType AS accountType, i.AccountBalance AS LedgerBalance, i.Branch, i.InvestorGroup FROM InvestorProfile p, Investor i  WHERE (p.AccountNumber= i.AccountNumber) AND p.AccountNumber='" + session.AccountNumber + "' ";

            SqlCommand sqlCmd = new SqlCommand(queryInvestorInfo, sqlConnect);
            try
            {
                SqlDataReader sdReader = sqlCmd.ExecuteReader();

                if (sdReader.HasRows)
                {
                    while (sdReader.Read())
                    {
                        lblName.Text = sdReader["Name"].ToString();
                        Session["AccountName"] = sdReader["Name"].ToString();

                        lblAccountNumber.Text = sdReader["AccountNumber"].ToString();
                        lblBoNumber.Text = sdReader["BONumber"].ToString();
                        lblAccountType.Text = sdReader["accountType"].ToString().Trim();
                        lblInvestorGroup.Text = sdReader["InvestorGroup"].ToString();
                        lblBranch.Text = sdReader["Branch"].ToString().ToString();
                        lblAccountStatus.Text = sdReader["AccountStatus"].ToString().ToString();
                        lblAccountCategory.Text = sdReader["AccountCategory"].ToString();

                        //string secondHolder = sdReader["SecondHolder"].ToString().ToString();
                        //RijndaelEncryption deccryption = new RijndaelEncryption();
                        //string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
                        //string joinHolder = deccryption.DecryptText(secondHolder, encryptionKey);

                        //lblJointHolder.Text = joinHolder.ToString();
                        lblJointHolder.Text = sdReader["SecondHolder"].ToString().ToString();
                        lblNationality.Text = sdReader["Nationality"].ToString();
                        lblContact.Text = sdReader["Mobile"].ToString().ToString();
                        //int ledgerBalance = Convert.ToInt32(sdReader["LedgerBalance"]);
                        //lblAvailableBalance.Text = ledgerBalance.ToString("#,##0.00");
                        lblAvailableBalance.Text = availableBalanceGlobal.ToString("#,##0.00");
                        lblUserName.Text = sdReader["Name"].ToString();

                        this.accountTypeGlobal = sdReader["accountType"].ToString().Trim();

                        //int Ledger = Convert.ToInt32(sdReader["LedgerBalance"]);
                        //if (ledgerBalance < 0)
                        //{
                        //    lblExposure.Text = Math.Abs(ledgerBalance).ToString();
                        //}
                        //else
                        //{
                        //    lblExposure.Text = "0.00";
                        //}
                    }
                }
            }
            catch (SqlException ex)
            {
                //lblStatus.Text = "An error occured" + ex.Message;
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
            catch (FormatException ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
            finally
            {
                sqlConnect.Close();
                sqlConnect.Dispose();
            }
        }

        /// <summary>
        /// Pupolate Deposite Withdraw 
        /// </summary>
        private void GetDepositeWithdraw()
        {
            GetSession session = new GetSession();
            SqlConnection sqlConnect = DatabaseConnection.GetConnection();
            SqlCommand sqlCmd = new SqlCommand("InvestorFinancialPosition", sqlConnect);
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.Add("@AccountRef", SqlDbType.VarChar).Value = session.AccountNumber;
                sqlCmd.Parameters.Add("@LedgerDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy/MM/dd");

                SqlDataAdapter sdaInvestorFinancialPosition = new SqlDataAdapter(sqlCmd);
                DataTable dtInvestorFinancialPosition = new DataTable();
                sdaInvestorFinancialPosition.Fill(dtInvestorFinancialPosition);

                if (dtInvestorFinancialPosition != null)
                {
                    if (dtInvestorFinancialPosition.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtInvestorFinancialPosition.Rows)
                        {
                            double TotalDeposit = Convert.ToDouble(dr["TOTALINVESTMENT"]);
                            double RealizedGainLossDeposite = Convert.ToDouble(dr["REALIZEDGAIN"]);
                            double TotalWidthdraw = Convert.ToDouble(dr["TOTALWITHDRAW"]);
                            double AccuredInterestCharge = Convert.ToDouble(dr["ACCRUEDINTEREST"]);

                            lblTotalDeposit.Text = TotalDeposit.ToString("#,##0.00");
                            lblRealizedGainLossDeposite.Text = RealizedGainLossDeposite.ToString("#,##0.00");
                            lblTotalWidthdraw.Text = TotalWidthdraw.ToString("#,##0.00");
                            lblAccuredInterestCharge.Text = AccuredInterestCharge.ToString("#,##0.00");

                            lblCurrentDepositTotal.Text = ((TotalDeposit + RealizedGainLossDeposite) - (TotalWidthdraw + AccuredInterestCharge)).ToString("#,##0.00");
                        }
                    }
                }
                //Data bind to rptLedger datable

            }
            catch (SqlException ex)
            {
                //lblStatus.Text = "An error occured" + ex.Message;
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
            finally
            {
                sqlConnect.Close();
            }
        }

        [WebMethod]
        public static List<ChartData> GetData()
        {
            GetSession session = new GetSession();
            SqlConnection sqlCon = DatabaseConnection.GetConnection();
            SqlCommand sqlCmd = new SqlCommand("GetSegmentwiseInvestment", sqlCon);

            List<ChartData> dataList = new List<ChartData>();

            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.Add("@ParamInvestor", SqlDbType.VarChar).Value = session.AccountNumber;

                SqlDataAdapter sdaSegmentwiseInvestment = new SqlDataAdapter(sqlCmd);
                DataTable dtSegmentwiseInvestment = new DataTable();
                DataSet dsSegmentwiseInvestment = new DataSet();
                //dt = ds.Tables["YourTableName"];
                sdaSegmentwiseInvestment.Fill(dtSegmentwiseInvestment);
                foreach (DataRow dr in dtSegmentwiseInvestment.Rows)
                {
                    string Category = dr["Category"].ToString();
                    int TotalInvestment = Convert.ToInt32(dr["TotalInvestment"]);
                    int MarketValue = Convert.ToInt32(dr["MarketValue"]);


                    dataList.Add(new ChartData(Category, TotalInvestment, MarketValue));
                    //dataList.Add(new ChartData("Engineering", 15170, 25000));
                    //dataList.Add(new ChartData("Fuel Power", 25660, 21120));
                    //dataList.Add(new ChartData("Miscellanous", 1030, 540));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataList;
        }

        /// <summary>
        /// Generate Report Investor Portfolio Statement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btPrint_Click(object sender, EventArgs e)
        {
            #region Investor Portfolio Statement
            try
            {
                GetSession session = new GetSession();
                string Investor = session.AccountNumber;

                DateTime fromDate = DateTime.Today;
                DateTime dateFrom = DateTime.Today;

                Session["ReportName"] = "InvestorPortfolioStatementWeb";
                ReportDocument oInvestorProtfilioStatement = new ReportDocument();
                //JScript.Alert(Server.MapPath(@"Reports\InvestorPortfolioStatement.rpt"), Page);
                oInvestorProtfilioStatement.Load(Server.MapPath(@"..\..\InvestorPortfolioStatement.rpt"));
                //JScript.Alert("Load Report pass", Page);

                InvestorPortfolioStatementLoader oLoder = new InvestorPortfolioStatementLoader(Investor, dateFrom, oInvestorProtfilioStatement);
                //JScript.Alert("after Report pass", Page);
                ReportDocument rd = (ReportDocument)oLoder.GetReportSource();

                Session["ReportDocumentObj"] = rd;
                //   const string url = "";

                ResponseHelper.Redirect(Response, "ReportViwer.aspx", "_blank", "menubar=0,width=800,height=600");
            }
            catch (Exception ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
                return;
            }

            #endregion

        }

        protected void textBox_TextChanged(object sender, EventArgs e)
        {
            GetSession session = new GetSession();
            RijndaelEncryption encryption = new RijndaelEncryption();
            string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
            string oldPassword = encryption.EncryptText(txtOldPassword.Text, encryptionKey);
            try
            {
                CommonFunction cm = new CommonFunction();

                string password = "select Password from ApplicationUser where UserId='" + session.UserName + "' and AccountNumber='" + session.AccountNumber + "' and password='" + oldPassword + "'";

                DataTable dtpassword = cm.GetDatatable(password);

                if (dtpassword.Rows.Count > 0)
                {
                    txtNewPassord.ReadOnly = false;
                    txtConfirmPassword.ReadOnly = false;
                    lblMessage.Text = "";
                }

                else
                {
                    txtNewPassord.ReadOnly = true;
                    txtConfirmPassword.ReadOnly = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Password does not match";
                }
            }

            catch (Exception ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {


            try
            {
                GetSession session = new GetSession();
                RijndaelEncryption encryption = new RijndaelEncryption();
                string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
                string newPassword = encryption.EncryptText(txtNewPassord.Text, encryptionKey);
                string oldPassword = encryption.EncryptText(txtOldPassword.Text, encryptionKey);
                CommonFunction cmSaveData = new CommonFunction();
                string updatePassword = "update ApplicationUser set Password='" + newPassword + "' where(UserID='" + session.UserName + " ' and AccountNumber='" + session.AccountNumber + "' )";
                cmSaveData.InsertQuery(updatePassword);
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Password change successfully');window.location='Dashboard.aspx';</script>'");
            }

            catch (Exception ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }



        }

    }

}