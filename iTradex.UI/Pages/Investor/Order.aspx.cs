using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTradex.UI.App_Code;
using System.Data;
using System.Configuration;

namespace iTradex.UI.Pages.Investor
{
    public partial class Order : System.Web.UI.Page
    {
        
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
                    ShowAllOrders();
                }
            }
            catch (FormatException ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }

        //string accountReference = session.AccountNumber;
        
        private void ShowAllOrders()
        {
            try
            {
                GetSession session = new GetSession();
                lblInvestorname.Text = session.AccountNumber; 
                CommonFunction cmDataTable = new CommonFunction();
                string showAddData = "select Instrument,TransactionType,ShareQuantity,Rate,Status,TransactionDate,TransactionTime from TradeOrderFromWeb where(InvestorACRef='" + session.AccountNumber + "' and TransactionDate='" + DateTime.Today + "' ) order by TransactionTime, Instrument";
               
                DataTable dtAllOrders = cmDataTable.GetDatatable(showAddData);
                dtAllOrders.Columns.Add("TotalAmount", typeof(decimal));
                foreach (DataRow dr in dtAllOrders.Rows)
                {
                    double total = 0;
                    total = total + (Double.Parse(dr["ShareQuantity"].ToString()) * Double.Parse(dr["Rate"].ToString()));
                    dr["TotalAmount"] = total.ToString();
                }
               rptAllOrder.DataSource = dtAllOrders;
               rptAllOrder.DataBind();
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
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Password change successfully');window.location='Order.aspx';</script>'");
                }

                catch (Exception ex)
                {
                    Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
                }
          
        }

    }

}