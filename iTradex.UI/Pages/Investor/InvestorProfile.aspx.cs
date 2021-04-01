using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using iTradex.UI.App_Code;
using System.Data;
using System.Configuration;

namespace iTradex.UI.Pages.Investor
{
    public partial class InvestorProfile : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BrokerRef"] == null)
            {
                Response.Redirect("../../Default.aspx");
            }

            if (!IsPostBack)
            {
                GetDepositeWithdraw();
                GetStockLedger();
                LoadInvestorInfo();
                AccountStatusTillToday();
            }
        }

        protected void LoadInvestorInfo()
        {
            GetSession session = new GetSession();
            //string AccNo = Session["AccountNumber"].ToString();
            //SqlConnection sqlConnect = DatabaseConnection.GetConnection();
            string queryInvestorInfo = "SELECT Distinct Investor.BalanceOutstanding, Investor.TotalInvestment, Investor.AccountType AS AcType, Investor.BONumber AS BoNo,"
                         + "Investor.AccountName AS InvName, Investor.AccountNumber AS AcNo, InvestorProfile.BankName AS Bank, "
                         + "InvestorProfile.Branch AS InvBranch, InvestorProfile.BankAccountNumber AS bAcNo, InvestorProfile.MiddleName, InvestorProfile.Photo, InvestorProfile.Mobile AS Cell, InvestorProfile.PassportNo, "
                         + "InvestorProfile.Nationality AS InvpNationality, InvestorProfile.BONumber AS Expr3, InvestorProfile.Name AS Name,InvestorProfile.RoutingNumber AS routingNo, "
                         +"InvestorProfile.TaxID AS InvpTax, InvestorProfile.DateofBirth AS DOBirth, InvestorProfile.Title, InvestorProfile.ShortName, InvestorProfile.LastName, "
                         +"InvestorProfile.FirstName, InvestorProfile.Reference, InvestorProfile.AccountCategory AS AcCategory, "
                         +"InvestorProfile.AccountNumber AS Expr4, InvestorProfile.SecondHolder AS JoinHolder, InvestorProfile.Email AS Mail,"
                         +"InvestorProfile.Signature, InvestorProfile.Gender AS Sex FROM Investor, "
                         + "InvestorProfile WHERE (Investor.AccountNumber = InvestorProfile.AccountNumber) AND (Investor.AccountNumber='" + HttpContext.Current.Session["AccountNumber"] + "')";

            //SqlCommand sqlCmdInvestorInfo = new SqlCommand(queryInvestorInfo, sqlConnect);
            try
            {
                CommonFunction dt = new CommonFunction();
                DataTable dtInvestorInfo = dt.GetDatatable(queryInvestorInfo);

                if (dtInvestorInfo.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtInvestorInfo.Rows)
                    {
                        //DateTime dateformat = Convert.ToDateTime(dr["NewsDate"]);
                        lblUserName.Text = dr["Name"].ToString();
                        lblAccountNumber.Text = session.AccountNumber;
                        lblAccountName.Text = dr["Name"].ToString();
                        lblBONumber.Text = dr["BoNo"].ToString();
                        lblAccountType.Text = dr["AcType"].ToString();
                        lblCategory.Text = dr["AcCategory"].ToString();
                        lblJointHolder.Text = dr["JoinHolder"].ToString();
                        lblInverstorName.Text = dr["InvName"].ToString();
                        DateTime birthDate = Convert.ToDateTime(dr["DOBirth"]);
                        lblDateOfBirth.Text = birthDate.ToString("dd/MM/yyyy");
                        lblNationality.Text = dr["InvpNationality"].ToString();
                        lblTaxID.Text = dr["InvpTax"].ToString();
                        lblSex.Text = dr["Sex"].ToString();
                        lblMobile.Text = dr["Cell"].ToString();
                        lblEmail.Text = dr["Mail"].ToString();
                        lblAcNo.Text = dr["bAcNo"].ToString();
                        lblAcName.Text = dr["Name"].ToString();
                        lblBank.Text = dr["Bank"].ToString();
                        lblBranch.Text = dr["InvBranch"].ToString();
                        lblRoutingNo.Text = dr["routingNo"].ToString();
                        
                    }
                }
            }
            catch (SqlException ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
            finally
            {
                //sqlConnect.Close();
                //sqlConnect.Dispose();
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
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.Add("@AccountRef", SqlDbType.VarChar).Value = HttpContext.Current.Session["AccountNumber"];
                sqlCmd.Parameters.Add("@LedgerDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy/MM/dd");

                SqlDataAdapter sdaClientAccountStatusDetailsAsOn = new SqlDataAdapter(sqlCmd);
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
                            Decimal ledgerBalance = Convert.ToDecimal(dr["LedgerBalance"]);
                            Decimal AvailableBalance = Convert.ToDecimal(dr["AvailableBalance"]);
                            //lblAvailableBalanceTillToday.Text = AvailableBalance.ToString(); ;
                            Decimal immaturedBalance = ledgerBalance - AvailableBalance;
                            Decimal unclearCheque = Convert.ToDecimal(dr["UnclearCheque"]);
                            lblAvailableBalanceTillToday.Text = AvailableBalance.ToString("#,##0.00");
                            lblImmaturedBalance.Text = immaturedBalance.ToString("#,##0.00");
                            UnclearCheque.Text = unclearCheque.ToString("#,##0.00");
                            LedgerBalance.Text = ledgerBalance.ToString("#,##0.00");
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
        /// Populate data for Deposite/Widthdraw widget.
        /// </summary>
        private void GetDepositeWithdraw()
        {
            GetSession session = new GetSession();
            SqlConnection sqlConnect = DatabaseConnection.GetConnection();
            SqlCommand sqlCmd = new SqlCommand("InvestorFinancialPosition", sqlConnect);
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.Add("@AccountRef", SqlDbType.VarChar).Value = HttpContext.Current.Session["AccountNumber"];
                sqlCmd.Parameters.Add("@LedgerDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy/MM/dd");

                SqlDataAdapter sdaInvestorFinancialPosition = new SqlDataAdapter(sqlCmd);
                DataTable dtInvestorFinancialPosition = new DataTable();
                //DataSet dsInvestorPortfolioList = new DataSet();
                //dt = ds.Tables["YourTableName"];
                sdaInvestorFinancialPosition.Fill(dtInvestorFinancialPosition);

                if (dtInvestorFinancialPosition != null)
                {
                    if (dtInvestorFinancialPosition.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtInvestorFinancialPosition.Rows)
                        {

                            Decimal TotalDeposit = Convert.ToDecimal(dr["TOTALINVESTMENT"]);
                            Decimal RealizedGainLossDeposite = Convert.ToDecimal(dr["REALIZEDGAIN"]);
                            Decimal TotalWidthdraw = Convert.ToDecimal(dr["TOTALWITHDRAW"]);
                            Decimal AccuredInterestCharge = Convert.ToDecimal(dr["ACCRUEDINTEREST"]);

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

        /// <summary>
        /// Populate data for Stocke Ledger widget.
        /// </summary>
        protected void GetStockLedger()
        {
            GetSession session = new GetSession();
            //string AccNo = Session["AccountNumber"].ToString();
            SqlConnection sqlConnect = DatabaseConnection.GetConnection();
            SqlCommand sqlCmd = new SqlCommand("GetInvestorPortfolioList", sqlConnect);
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.Add("@ParamInvestor", SqlDbType.VarChar).Value = session.AccountNumber;
                sqlCmd.Parameters.Add("@PortfolioDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy/MM/dd"); ;
                sqlCmd.Parameters.Add("@BusinessDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy/MM/dd"); ;

                SqlDataAdapter sdaInvestorPortfolioList = new SqlDataAdapter(sqlCmd);
                DataTable dtInvestorPortfolioList = new DataTable();
                sdaInvestorPortfolioList.Fill(dtInvestorPortfolioList);
                if (dtInvestorPortfolioList.Rows.Count > 0)
                {
                    //Sum of Realized Gain/Loss
                    int sumRealizedGainLoss = Convert.ToInt32(dtInvestorPortfolioList.Compute("Sum(RealisedGain)", ""));
                    lblRealizedGainLoss.Text = sumRealizedGainLoss.ToString("#,##0.00");
                    lblRealizedGainLossDeposite.Text = sumRealizedGainLoss.ToString("#,##0.00");

                    //Sum of UnRealized Gain/Loss
                    int sumUnRealizedGainLoss = Convert.ToInt32(dtInvestorPortfolioList.Compute("Sum(UnRealisedGain)", ""));
                    lblUnrealizedGainLoss.Text = sumUnRealizedGainLoss.ToString("#,##0.00");

                    lblnetGainLoss.Text = (sumUnRealizedGainLoss + sumRealizedGainLoss).ToString("#,##0.00");

                }
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
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Password change successfully');</script>'");
                }

                catch (Exception ex)
                {
                    Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
                }
            
        }
    }
}