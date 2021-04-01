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
    public partial class PurchaseOrder : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["AccountNumber"] == null)
            {
                Response.Redirect("../../Default.aspx");
            }
            GetSession session = new GetSession();
            lblInvestorname.Text = session.AccountNumber;
            txtAccountReference.Text = session.AccountNumber;
            PurchaseOrders();
            LoadShortName();
        }

        //string accountReference = session.AccountNumber;
       
        private void PurchaseOrders()
        {
            try
            {
                GetSession session = new GetSession();
                CommonFunction cmDataTable = new CommonFunction();
                string showAddData = "select Instrument,TransactionType,ShareQuantity,Rate,Status,TransactionTime,TransactionDate from TradeOrderFromWeb where(InvestorACRef='" + session.AccountNumber + "' and TransactionType='B' and TransactionDate='" + DateTime.Today + "') order by TransactionTime, Instrument ";

                DataTable dtPurchaseOrder = cmDataTable.GetDatatable(showAddData);
                dtPurchaseOrder.Columns.Add("TotalAmount", typeof(decimal));

                //dt.Columns.Add(new DataColumn(columnName = "Balance", dataType = typeof (decimal)));

                foreach (DataRow dr in dtPurchaseOrder.Rows)
                {
                    double total = 0;
                    total = total + (Double.Parse(dr["ShareQuantity"].ToString()) * Double.Parse(dr["Rate"].ToString()));
                    dr["TotalAmount"] = total.ToString();
                }
                rptPurchaseOrder.DataSource = dtPurchaseOrder;
                rptPurchaseOrder.DataBind();
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
                if (ddlInstrument.SelectedIndex > 0)
                {
                    if (txtShareQuantity.Text == string.Empty || txtRate.Text == string.Empty)
                    {
                        return;
                    }

                    else
                    {
                        CommonFunction cmSaveData = new CommonFunction();
                        string insertQuery = "insert into TradeOrderFromWeb(InvestorACRef,ShareQuantity,Rate,TransactionDate,TransactionTime,Memo,Status,TransactionType,Reference,Instrument) Values('" + session.AccountNumber + "','" + txtShareQuantity.Text + "','" + txtRate.Text + "','" + DateTime.Today.ToString("yyyy/MM/dd") + "','" + DateTime.Now + "','Online','Pending','B',NEWID(),'" + ddlInstrument.SelectedItem.Text + "')";
                        cmSaveData.InsertQuery(insertQuery);
                        ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('successfully Saved');window.location='PurchaseOrder.aspx';</script>'");
                        PurchaseOrders();
                    }
                  
                }

                else 
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Please Select Instrument');</script>'");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }

        private void LoadShortName()
        {
            try
            {
                GetSession session = new GetSession();
                if (!IsPostBack)
                {
                    CommonFunction cmDataTable = new CommonFunction();
                    string commandLoadShortName = "select ShortName from Instrument order by ShortName ";
                    DataTable dtLoadShortName = cmDataTable.GetDatatable(commandLoadShortName);
                    ddlInstrument.DataSource = dtLoadShortName;
                    ddlInstrument.DataTextField = "ShortName";

                    ddlInstrument.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }

        }

        protected void ddlInstrument_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GetSession session = new GetSession();
                CommonFunction cmDataTable = new CommonFunction();
                string selectQuery = "select MarketPrice from Instrument where (ShortName='" + ddlInstrument.SelectedItem.Text + "') ";

                DataTable dtShowData = cmDataTable.GetDatatable(selectQuery);
                if (dtShowData.Rows.Count > 0)
                {
                    txtRate.Text = dtShowData.Rows[0]["MarketPrice"].ToString(); //Where ColumnName is the Field from the DB that you want to display
                }

                else
                {
                    txtRate.Text = string.Empty;
                    //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Please Select Instrument');window.location='PurchaseOrder.aspx';</script>'");
                }
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

        protected void btnPasswordSave_Click(object sender, EventArgs e)
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