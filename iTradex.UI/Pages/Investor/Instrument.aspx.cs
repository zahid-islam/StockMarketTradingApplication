using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using iTradex.UI.App_Code;

namespace iTradex.UI.Pages.Investor
{
    public partial class Instrument : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccountNumber"] == null)
            {
                Response.Redirect("../../Default.aspx");
            }
            GetUserInformation();
            GetInstrument();
        }

        //private string GetConnection()
        //{
        //    return ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        //}
        /// <summary>
        /// Load Instrument List On DataTable
        /// </summary>

        private void GetInstrument()
        {

            try
            {
                GetSession session = new GetSession();
                    CommonFunction cmDataTable = new CommonFunction();
                    //SqlConnection sconGetInstrument = DatabaseConnection.GetConnection();
                    
                    string getInstrumentQuery = "select ShortName,ISIN,InstrumentType,InstrumentCategory,FaceValue,MarketPrice,DeclarationDate,EntryDate from Instrument order by ShortName ";
                    //SqlCommand cmdGetInstrument = new SqlCommand(getInstrumentQuery, sconGetInstrument);
                    //sconGetInstrument.Close();
                    //SqlDataAdapter sdaGetInstrument = new SqlDataAdapter(cmdGetInstrument);
                    DataTable dtGetInstrument = cmDataTable.GetDatatable(getInstrumentQuery);


                    //sdaGetInstrument.Fill(dtGetInstrument);

                    rptInstrument.DataSource = dtGetInstrument;
                    rptInstrument.DataBind();



            }

            catch (Exception ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        
        }

        private void GetUserInformation()
        {
            //string DBCon = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
            //SqlConnection sqlConnect = new SqlConnection(DBCon);

            //string Query = "SELECT FirstName,ShortName, AccountNumber FROM InvestorProfile WHERE AccountNumber='" + session.AccountNumber + "' ";

            //SqlCommand sqlCmd = new SqlCommand(Query, sqlConnect);
            //try
            //{
            //    sqlConnect.Open();
            //    SqlDataReader rdr = sqlCmd.ExecuteReader();

            //    if (rdr.HasRows)
            //    {
            //        while (rdr.Read())
            //        {
            //            lblInvestorname.Text = rdr["FirstName"].ToString();
            //        }
            //    }
            //}
            //catch (SqlException ex)
            //{
            //    throw ex;
            //}
            //catch (FormatException ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    sqlConnect.Close();
            //    sqlConnect.Dispose();
            //}
            GetSession session = new GetSession();
            lblInvestorname.Text = session.AccountNumber;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtOldPassword.Text == string.Empty)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Please enter your password');</script>'");

            }
            else
            {
                try
                {
                    GetSession session = new GetSession();
                    RijndaelEncryption encryption = new RijndaelEncryption();
                    string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
                    string newPassword = encryption.EncryptText(txtNewPassord.Text, encryptionKey);
                    string oldPassword = encryption.EncryptText(txtOldPassword.Text, encryptionKey);
                    CommonFunction cmSaveData = new CommonFunction();
                    string updatePassword = "update ApplicationUser set Password='" + newPassword + "' where(UserID='" + session.UserName + " ' and AccountNumber='" + session.AccountNumber + "' and password='" + oldPassword + "' )";
                    cmSaveData.InsertQuery(updatePassword);
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Password change successfully');window.location='Instrument.aspx';</script>'");
                }

                catch (Exception ex)
                {
                    Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
                }
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

                string password = "select Password from ApplicationUser where UserId='" + session.UserName + "' and AccountNumber='" + session.AccountNumber + "' ";

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

    }
}