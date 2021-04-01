using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTradex.UI.App_Code;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.Data.SqlClient;
using iTradex.UI.Report;
using CrystalDecisions.CrystalReports.Engine;

namespace iTradex.UI
{
    public partial class Ipo : System.Web.UI.Page
    {
        GetSession session = new GetSession();
        
        string companyName;
      
        double totalAmmount;
        string ipoRefference;
        double availableBalance;
        string category;
    


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
                    ShowData();
                }
                    if (Request.QueryString["CompanyName"] != null)
                    {

                        companyName = Request.QueryString["CompanyName"];
                        totalAmmount = Convert.ToDouble(Request.QueryString["TotalAmount"]);
                        ipoRefference = Request.QueryString["Reference"];
                        category= Request.QueryString["id"];

                        GetAccountBalance();
                        if (!IsPostBack)
                        {
                            bool success = IPOCheck();

                            if (success == true)
                            {
                                if (availableBalance >= totalAmmount)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);


                                }

                                else
                                {

                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal2();", true);

                                }
                            }

                            else
                            {

                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal3();", true);
                            }

                          
                        }

                        if (IsPostBack)
                        {
                            bool success = IPOCheck();

                            if (success == true)
                            {
                                IPOApplicationSave();
                                GenerateIPO();
                            }
                            else

                            {

                                GenerateIPO();
                            }
                        
                        }
                     
                    }
            }
            catch (FormatException ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }

        private void ShowData()
        {
            try
            {
                GetSession session = new GetSession();
                lblInvestorname.Text = session.AccountNumber;
                CommonFunction cmDataTable = new CommonFunction();
                string showAddData = "select CompanyName, NumberOfShare,BuyRate,ExpireDate,Reference from IPODeclaration where(ExpireDate >='" + DateTime.Today + "') and Reference NOT IN (SELECT IPOReference FROM IPOApplication WHERE AccountNumber = '" + Session["AccountNumber"].ToString() + "') order by CompanyName ";

                DataTable dtIpoInformation = cmDataTable.GetDatatable(showAddData);
                dtIpoInformation.Columns.Add("TotalAmount", typeof(decimal));

                //dt.Columns.Add(new DataColumn(columnName = "Balance", dataType = typeof (decimal)));

                foreach (DataRow dr in dtIpoInformation.Rows)
                {
                    double total = 0;
                    total = total + (Double.Parse(dr["NumberOfShare"].ToString()) * Double.Parse(dr["BuyRate"].ToString()));
                    dr["TotalAmount"] = total.ToString();
                }

                rptIpo.DataSource = dtIpoInformation;
                rptIpo.DataBind();
            }
            catch (Exception ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
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
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Password change successfully');window.location='Ipo.aspx';</script>'");
            }

            catch (Exception ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }


        }


        protected void btnIPOApplication_Click(object sender, EventArgs e)
        {

            //try
            //{

            //    GetSession session = new GetSession();

            //    CommonFunction cmSaveData = new CommonFunction();
            //    string insertQuery = "insert into IPOApplication (Reference, AccountNumber,BONumber,AccountName,Status,IPOReference,AccountBalance,CompanyName,Category) Values(newid(), '" + session.AccountNumber + "','" + session.BoNumber + "','" +session.UserName + "', 'Pending','" + ipoRefference + "','" + availableBalance + "','" + companyName + "','" + category + "')";
            //    cmSaveData.InsertQuery(insertQuery);
            //    btnIPOApplication.Disabled = true;
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "ValidateDate();", true);
            //}

            //catch (Exception ex)
            //{
            //    Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            //}

        }


        public void IPOApplicationSave()
        {

            try
            {
                GetSession session = new GetSession();

                CommonFunction cmSaveData = new CommonFunction();

                try
                {
                    float buyRate = float.Parse(Session["BuyRate"].ToString());
                    int marketLot = Int16.Parse(Session["NoOfShares"].ToString());
                }
                catch (Exception)
                {
                }
                

                string insertQuery = "insert into IPOApplication (Reference, AccountNumber,BONumber,AccountName,Status,IPOReference,AccountBalance,CompanyName,Category) Values(NewID(), '" + session.AccountNumber + "','" + session.BoNumber + "','" + Session["AccountName"].ToString() + "', 'Pending','" + ipoRefference + "','" + availableBalance + "','" + companyName + "','" + category + "')";
                cmSaveData.InsertQuery(insertQuery);
                btnIPOApplication.Disabled = true;
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "ValidateDate();", true);

                //Response.Redirect("../../Default.aspx");
            }

            catch (Exception ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }

        private void GetAccountBalance()
        {
            try
            {
                GetSession session = new GetSession();
                SqlConnection sqlConnect = DatabaseConnection.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("GetClientAccountStatusDetailsAsOn", sqlConnect);
                sqlCmd.CommandTimeout = 360;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.Add("@AccountRef", SqlDbType.VarChar).Value = session.AccountNumber;
                sqlCmd.Parameters.Add("@LedgerDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy/MM/dd");

                SqlDataAdapter sdaClientAccountStatusDetailsAsOn = new SqlDataAdapter(sqlCmd);
                DataTable dtClientAccountStatusDetailsAsOn = new DataTable();
                sdaClientAccountStatusDetailsAsOn.Fill(dtClientAccountStatusDetailsAsOn);
                if (dtClientAccountStatusDetailsAsOn.Rows.Count > 0)
                {
                    availableBalance =Convert.ToDouble(dtClientAccountStatusDetailsAsOn.Rows[0]["LedgerBalance"].ToString());
                  
                }

            }
            catch (Exception ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }

        public bool IPOCheck()
        {
            GetSession session = new GetSession();
           
            CommonFunction cmDataTable = new CommonFunction();
            string showAddData = "select AccountNumber,IPOReference from IPOApplication where(AccountNumber='"+session.AccountNumber+"' and IPOReference='"+ipoRefference+"')";

            DataTable dtIpoInformation = cmDataTable.GetDatatable(showAddData);

            if (dtIpoInformation.Rows.Count > 0)
            {
                return false;
            }

            return true;
        }

        public void GenerateIPO()
        {


            GetSession session = new GetSession();
            // ClientScript.RegisterStartupScript(GetType(), "CLOSE", "<script language='javascript'> window.close(); </script>");
            Session["CompanyName"] = Request.QueryString["CompanyName"].ToString();
            Session["NoOfShares"] = Request.QueryString["NumberOfShare"].ToString();
            Session["BuyRate"] = Request.QueryString["BuyRate"].ToString();

            Session["ExpireDate"] = Request.QueryString["ExpireDate"].ToString();
            Session["Id"] = Request.QueryString["id"].ToString();
           // ReportDocument oIpoInformation = new ReportDocument();

           // if (Request.QueryString["id"] == "NRB")
           // {
           //     oIpoInformation.Load(Server.MapPath(@"..\..\IpoStatement.rpt"));

           // }

           // else
           // {
           //     oIpoInformation.Load(Server.MapPath(@"..\..\IpoStatement3.rpt"));
           // }
            

           // Session["ReportName"] = "IPOReport";

           // string[] company = companyName.Split(' ');
           // string name = company[0].ToString();
           // string reportName = "IPO" + name + session.AccountNumber;

           

           // IpoInformationLoader oLoder = new IpoInformationLoader(oIpoInformation);

           // ReportDocument rd = (ReportDocument)oLoder.GetReportSource();

           // rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, reportName);
           
           // rd.Close();
           // rd.Dispose();
           // GC.Collect();
        }
    }
}