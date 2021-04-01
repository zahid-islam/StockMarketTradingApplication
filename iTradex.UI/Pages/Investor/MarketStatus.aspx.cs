using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using iTradex.UI.App_Code;
using HtmlAgilityPack;
using KaziEquitiesWebSite;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Timers;

namespace iTradex.UI.Pages.Investor
{
    public partial class MarketStatus : System.Web.UI.Page
    {
        static System.Timers.Timer aTimer;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AccountNumber"] == null)
                {
                    Response.Redirect("../../Default.aspx");
                }
                if (!IsPostBack)
                {
                    GetTickerwidget();
                    GetTickerPriceTop();
                    //GetTickerValue();
                    GetNewsValue();
                    GetStockLedger();
                    AccountStatusTillToday();
                    GetDepositeWithdraw();
                    GetAccountName();
                    //Timer for price picker data update after
                    aTimer = new System.Timers.Timer(30000);
                    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                    aTimer.Enabled = true;
                }
            }
            catch (FormatException ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }
        /// <summary>
        /// Populate data from Dse Price widget.
        /// </summary>
        //public void GetTickerValue()
        //{
        //    if (!DSEParser.DSESite.IsUpdateStarted)
        //    {
        //        DSEParser.DSESite.StarUpdateData();
        //    }

        //    System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
        //        new System.Web.Script.Serialization.JavaScriptSerializer();

        //    string sJSON = "{}";
        //    string outPut = "<marquee behavior=\"scroll\"  style=\"vertical-align: middle;\" loop=\"repeat\" direction=\"left\" scrolldelay=\"20\" scrollamount=\"1\" truespeed=\"\"  id=\"marq\" onmouseout=\"this.start();\" onmouseover=\"this.stop();\">";
        //    //string outPut = "<li><span>Name</span><span>CurrentPrice</span><span>UpDownValue</span></li>";
        //    //string outPut = "";
        //    if (DSEParser.DSESite.CurrentInstument.Count > 0)
        //    {
        //        foreach (DSEParser.Instument oInstrument in DSEParser.DSESite.CurrentInstument)
        //        {
        //            //outPut += "<a rel='Ticker' href=\"http://www.dsebd.org/company_details.php?name=" + oInstrument.ShortName + "\" ><span>" + oInstrument.ShortName + " :</span> <span style=\" color:black;\">" + oInstrument.CurrentPrice.ToString(SiteAttributes.AppDecimalNumberFormat) + "</span><span class='" + oInstrument.Status + "' > (" + oInstrument.UpDownValue.ToString(SiteAttributes.AppDecimalNumberFormat) + ")</span> </a>";
        //            outPut += "<a rel='Ticker' href=\"http://www.dsebd.org/company_details.php?name=" + oInstrument.ShortName + "\" ><span>" + oInstrument.ShortName + " :</span> <span style=\" color:black;\">" + oInstrument.CurrentPrice.ToString(SiteAttributes.AppDecimalNumberFormat) + "</span><span class='" + oInstrument.Status + "' > (" + oInstrument.UpDownValue.ToString(SiteAttributes.AppDecimalNumberFormat) + ")</span> </a>&nbsp;&nbsp;";
        //            //rptTicker.DataSource = DSEParser.DSESite.CurrentInstument;
        //            //rptTicker.DataBind();

        //        }
        //    }
        //    else
        //    {
        //        outPut += "First time synchronization is not completed on the server, please wait for few minute..";
        //    }
        //    outPut += "</marquee>";
        //    sJSON = oSerializer.Serialize(DSEParser.DSESite.CurrentInstument);
        //    ltrTickerPrice.Text = outPut;
        //    //ticker.InnerHtml.
        //    //Response.Write(outPut);
        //}
        //public bool changed()
        //{
        //    try
        //    {
        //        string appPath = Server.MapPath("textfiles/tricker.txt");
        //        TextReader tr = new StreamReader(appPath);
        //        string date = tr.ReadLine();
        //        tr.Close();
        //        DateTime dt = Convert.ToDateTime(date);
        //        dt.AddMonths(5);
        //        if (dt > DateTime.Now)
        //        {
        //            return false;
        //        }
        //        else return true;
        //    }
        //    catch { return true; }
        //}
        //public string check()
        //{
        //    try
        //    {
        //        string str = "";

        //        HttpWebRequest wr = (HttpWebRequest)WebRequest.Create("http://www.dsebd.org/");

        //        string html = (new StreamReader(wr.GetResponse().GetResponseStream())).ReadToEnd();

        //        HtmlAgilityPack.HtmlDocument HD = new HtmlAgilityPack.HtmlDocument();
        //        HD.LoadHtml(html);

        //        var NoAltElements = HD.DocumentNode.SelectNodes("//marquee [(@id)]");
        //        if (NoAltElements != null)
        //        {
        //            foreach (HtmlNode HN in NoAltElements)
        //            {
        //                //HN.Attributes.Append("alt", "no alt image");
        //                str += HN.InnerHtml;

        //            }
        //        }
        //        return str;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;

        //    }

        //}
        //public void GetNewsValue()
        //{
        //    string Today = DateTime.Today.ToString("yyyy/MM/dd");
        //    string Value = "";
        //    SqlConnection sqlConnect = DatabaseConnection.GetConnection();
        //    string queryNews = "SELECT Reference, NewsDate, NewsTime, News, Instrument, uniqueNumber FROM MarketNews WHERE NewsDate='6/3/2013 12:00:00 AM'";

        //    SqlCommand sqlCmd = new SqlCommand(queryNews, sqlConnect);
        //    try
        //    {
        //        SqlDataReader sdReader = sqlCmd.ExecuteReader();
        //        if (sdReader.HasRows)
        //        {
        //            while (sdReader.Read())
        //            {
        //                //lblName.Text = sdReader["FirstName"].ToString();
        //                string Instrument = sdReader["Instrument"].ToString();
        //                string News = sdReader["News"].ToString();
        //                Value = "Trading Code :" + Instrument + "<br/>" + News + "";

        //                StringWriter sw = new StringWriter();
        //                HtmlTextWriter htw = new HtmlTextWriter(sw);

        //                // instantiate a datagrid
        //                DataGrid dg = new DataGrid();
        //                dg.DataSource = Value; //your dataTable
        //                dg.DataBind();
        //                dg.RenderControl(htw);
        //                divHtml.InnerHtml = sw.ToString();  
        //            }
        //        }

        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //    catch (FormatException ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        sqlConnect.Close();
        //        sqlConnect.Dispose();
        //    }
        //    //return Value;
        //}
        /// <summary>
        /// Populate data for News widget.
        /// </summary>
        public void GetNewsValue()
        {
            try
            {
                GetSession session = new GetSession();
                string queryNews = "SELECT NewsDate, NewsTime, News, Instrument FROM MarketNews ORDER BY NewsTime DESC ";
                CommonFunction dt = new CommonFunction();
                DataTable dtsdaNews = dt.GetDatatable(queryNews);
                
                rptNews.DataSource = dtsdaNews;
                rptNews.DataBind();
                //SqlConnection sqlConnect = DatabaseConnection.GetConnection();
                //SqlCommand sqlCmd = new SqlCommand(queryNews, sqlConnect);
                //SqlDataAdapter sdaNews = new SqlDataAdapter(sqlCmd);
                //DataTable dtsdaNews = new DataTable();
                //sdaNews.Fill(dtsdaNews);
                //StringWriter sw = new StringWriter();
                //HtmlTextWriter htw = new HtmlTextWriter(sw);
                //foreach (DataRow dr in dtsdaNews.Rows)
                //{
                //    DateTime dateformat = Convert.ToDateTime(dr["NewsDate"]);
                //    string Date = dateformat.ToString("dd/MM/yyyy");
                //    string Name = dr["Instrument"].ToString();
                //    string News = dr["News"].ToString();

                //    string tickerNews = "";
                //    //string tickerNews = "<marquee behavior=\"scroll\"  style=\"text-align: left;\" loop=\"repeat\" direction=\"up\" scrolldelay=\"20\" scrollamount=\"1\" truespeed=\"\" onmouseout=\"this.start();\" onmouseover=\"this.stop();\">";
                //    //tickerNews = "<li><a href=\"http://www.dsebd.org/displayCompany.php?name=" + Name + "\" >Name : <b>" + Name + "</b>&nbsp;<br>" + News + "</a><hr color=\"99ccff\" size=\"1\">";
                //    tickerNews = "<li><span>" + Date + "</span><span><a rel='Ticker' href=\"http://www.dsebd.org/company_details.php?name=" + Name + "\" >" + Name + " </a></span> <span style=\" color:black;\">" + News + "</span>";
                //    tickerNews += "</li>";
                //    ltrlNews.Text = tickerNews;
                //}
            }
            catch (SqlException ex)
            {
                //lblStatus.Text = "An error occured" + ex.Message;
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
            finally
            {
                //sqlConnect.Close();
            }
            // instantiate a datagrid
            //DataGrid dg = new DataGrid();
            //dg.DataSource = ; //your dataTable
            //dg.DataBind();
            //dg.RenderControl(htw);
            //divHtml.InnerHtml = sw.ToString();
        }
        /// <summary>
        /// Populate data for Stocke Ledger widget.
        /// </summary>
        protected void GetStockLedger()
        {
            GetSession session = new GetSession();
            SqlConnection sqlConnect = DatabaseConnection.GetConnection();
            SqlCommand sqlCmd = new SqlCommand("GetInvestorPortfolioList", sqlConnect);
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.Add("@ParamInvestor", SqlDbType.VarChar).Value = session.AccountNumber;
                sqlCmd.Parameters.Add("@PortfolioDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy/MM/dd");
                sqlCmd.Parameters.Add("@BusinessDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy/MM/dd");

                SqlDataAdapter sdaInvestorPortfolioList = new SqlDataAdapter(sqlCmd);
                DataTable dtInvestorPortfolioList = new DataTable();
                //DataSet dsInvestorPortfolioList = new DataSet();
                //dt = ds.Tables["YourTableName"];
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
                //Data bind to rptLedger datable
                //rptLedger.DataSource = dtInvestorPortfolioList;
                //rptLedger.DataBind();

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
        /// Get Account Name
        /// </summary>
        private void GetAccountName()
        {
            GetSession session = new GetSession();
            SqlConnection sqlConnect = DatabaseConnection.GetConnection();
            string queryDepositeWithdraw = "SELECT Name FROM InvestorProfile WHERE AccountNumber='" + session.AccountNumber + "'";
            try
            {
                CommonFunction dt = new CommonFunction();
                DataTable dtDepositeWithdraw = dt.GetDatatable(queryDepositeWithdraw);
                if (dtDepositeWithdraw.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtDepositeWithdraw.Rows)
                    {
                        lblUserName.Text = dr["Name"].ToString();
                    }
                }
            }
            catch (SqlException ex)
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

                sqlCmd.Parameters.Add("@AccountRef", SqlDbType.VarChar).Value = session.AccountNumber;
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
        /// 
        /// </summary>
        public void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            GetTickerwidget();
            GetTickerPriceTop();
        }
        /// <summary>
        /// Populate Priceticker data
        /// </summary>
        public void GetTickerwidget()
        {
            try
            {
                GetSession session = new GetSession();
                if (!DSEParser.DSESite.IsUpdateStarted)
                {
                    DSEParser.DSESite.StarUpdateData();
                }

                //System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
                //new System.Web.Script.Serialization.JavaScriptSerializer();

                //string sJSON = "{}";
                //string outPut = "<marquee behavior=\"scroll\"  style=\"vertical-align: middle;\" loop=\"repeat\" direction=\"left\" scrolldelay=\"20\" scrollamount=\"1\" truespeed=\"\"  id=\"marq\" onmouseout=\"this.start();\" onmouseover=\"this.stop();\">";
                //string outPut = "<li><span>Name</span><span>CurrentPrice</span><span>UpDownValue</span></li>";
                //string outPut = "";
                //if (DSEParser.DSESite.CurrentInstument.Count > 0)
                //{
                //    foreach (DSEParser.Instument oInstrument in DSEParser.DSESite.CurrentInstument)
                //    {
                //        //outPut += "<a rel='Ticker' href=\"http://www.dsebd.org/company_details.php?name=" + oInstrument.ShortName + "\" ><span>" + oInstrument.ShortName + " :</span> <span style=\" color:black;\">" + oInstrument.CurrentPrice.ToString(SiteAttributes.AppDecimalNumberFormat) + "</span><span class='" + oInstrument.Status + "' > (" + oInstrument.UpDownValue.ToString(SiteAttributes.AppDecimalNumberFormat) + ")</span> </a>";
                //        //outPut += "<a rel='Ticker' href=\"http://www.dsebd.org/company_details.php?name=" + oInstrument.ShortName + "\" ><span>" + oInstrument.ShortName + " :</span> <span style=\" color:black;\">" + oInstrument.CurrentPrice.ToString(SiteAttributes.AppDecimalNumberFormat) + "</span><span class='" + oInstrument.Status + "' > (" + oInstrument.UpDownValue.ToString(SiteAttributes.AppDecimalNumberFormat) + ")</span> </a>&nbsp;&nbsp;";
                //        outPut += "<li><span><a rel='Ticker' href=\"http://www.dsebd.org/company_details.php?name=" + oInstrument.ShortName + "\" >" + oInstrument.ShortName + "";
                //        outPut += "</a></span> <span style=\" color:black;\">" + oInstrument.CurrentPrice.ToString(SiteAttributes.AppDecimalNumberFormat) + "";
                //        outPut +=  "</span><span class='" + oInstrument.Status + "' > (" + oInstrument.UpDownValue.ToString(SiteAttributes.AppDecimalNumberFormat) + ")</span>";
                //        outPut += "<span class='" + oInstrument.Status + "'>" + oInstrument.UpDownPercent + "</span>";
                //        outPut = outPut.Replace(@"(", @"");
                //        outPut = outPut.Replace(@")", @"");
                //    }
                //}
                //else
                //{
                //    outPut += "First time synchronization is not completed on the server, please wait for few minute..";
                //}
                //outPut += "</li>";
                //sJSON = oSerializer.Serialize(DSEParser.DSESite.CurrentInstument);
                rptPriceTicker.DataSource = DSEParser.DSESite.CurrentInstument.Where(ins => ins.Status == "Down").ToList();
                rptPriceTicker.DataBind();
            }

            catch (FormatException ex)
            {
                //lblStatus.Text = "An error occured" + ex.Message;
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
            finally
            {
                //sqlConnect.Close();
            }
        }
        /// <summary>
        /// Populate Ticker Price Top
        /// </summary>
        public void GetTickerPriceTop()
        {
            try
            {
                if (!DSEParser.DSESite.IsUpdateStarted)
                {
                    DSEParser.DSESite.StarUpdateData();
                }

                rptPriceTop.DataSource = DSEParser.DSESite.CurrentInstument.Where(ins => ins.Status == "Up").ToList();
                rptPriceTop.DataBind();
            }
            catch (FormatException ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
            finally
            {
                //sqlConnect.Close();
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