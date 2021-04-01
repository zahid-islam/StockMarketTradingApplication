using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iTradex.UI.App_Code;
using System.Globalization;
using System.Configuration;

namespace iTradex.UI.Pages.Investor
{
    public partial class IpoInformation : System.Web.UI.Page
    {

        public string reference;
        
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
                    ShowBrokerName();
                     
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace)); 
            }
        }

   

        private void ShowBrokerName()
        {
            try
            {
                GetSession session = new GetSession();
                Label lblBrokerName = this.Master.FindControl("PlaceHolder1").FindControl("lblUserName") as Label;
                string brokerRef = Session["BrokerRef"].ToString();
                CommonFunction cmDataTable = new CommonFunction();
                string query = "select BrokerName from Broker where (Reference='" + brokerRef + "')";
                DataTable dtBrokerName = cmDataTable.GetDatatable(query);

                if (dtBrokerName.Rows.Count > 0)
                {
                    lblBrokerName.Text = dtBrokerName.Rows[0]["BrokerName"].ToString();
                }
            }

            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace)); 
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ShowBrokerName();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                GetSession session = new GetSession();
                if (txtExpirationDate.Text != string.Empty && txtDeclarationDate.Text != string.Empty)
                {
                    string dateExpire = DateTime.ParseExact(txtExpirationDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("yyyy/MM/dd");
                    string dateDeclaration = DateTime.ParseExact(txtDeclarationDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("yyyy/MM/dd");
                    CommonFunction cmSaveData = new CommonFunction();
                    string insertQuery = "insert into IPODeclaration(CompanyName,AddressLine1,AddressLine2,City,Country,PostCode,Telephone,Fax,NumberOfShare,BuyRate,Reference,ExpireDate,DeclarationDate) Values('" + txtCompanyName.Text + "','" + txtAddressLine1.Text + "','" + txtAddressLine2.Text + "','" + txtCity.Text + "','" + txtCountry.Text + "','" + txtPostCode.Text + "','" + txtTelephone.Text + "','" + txtfax.Text + "','" + txtNumberOfShare.Text + "','" + txtBuyRate.Text + "',NEWID(),'" + dateExpire + "','" + dateDeclaration + "')";
                    cmSaveData.InsertQuery(insertQuery);
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('successfully Saved');window.location='IpoInformation.aspx';</script>'");
                    ShowData();
                }

                else return;

            }
            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace)); 

            }

        }


        private void ShowData()
        {
            try
            {
                GetSession session = new GetSession();
                CommonFunction cmDataTable = new CommonFunction();
                string showAddData = "select CompanyName,NumberOfShare,BuyRate,ExpireDate,Reference from IPODeclaration where(ExpireDate >='" + DateTime.Today + "') order by CompanyName ";

                DataTable dtIpoInformation = cmDataTable.GetDatatable(showAddData);
                dtIpoInformation.Columns.Add("TotalAmount", typeof(decimal));
                foreach (DataRow dr in dtIpoInformation.Rows)
                {
                    double total = 0;
                    total = total + (Double.Parse(dr["NumberOfShare"].ToString()) * Double.Parse(dr["BuyRate"].ToString()));
                    dr["TotalAmount"] = total.ToString();

                }


                rptIpoInformation.DataSource = dtIpoInformation;
                rptIpoInformation.DataBind();


            }
            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace)); 

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
                string password = "select Password from ApplicationUser where UserId='" + session.UserName + "'  and password='" + oldPassword + "'";

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
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace)); 
            }
        }

        protected void btnPasswordChange_Click(object sender, EventArgs e)
        {
           
            try
            {
                GetSession session = new GetSession();
                RijndaelEncryption encryption = new RijndaelEncryption();
                string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
                string newPassword = encryption.EncryptText(txtNewPassord.Text, encryptionKey);
                string oldPassword = encryption.EncryptText(txtOldPassword.Text, encryptionKey);
                CommonFunction cmSaveData = new CommonFunction();
                string updatePassword = "update ApplicationUser set Password='" + newPassword + "' where(UserID='" + session.UserName + " ')";
                cmSaveData.InsertQuery(updatePassword);
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Password change successfully');</script>'");
            }

            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace)); 
            }

           
        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                GetSession session = new GetSession();
                foreach (RepeaterItem rpt in rptIpoInformation.Items)
                {
                    CheckBox chkEdit = (CheckBox)rpt.FindControl("chkEdit");
                    if (chkEdit.Checked == true)
                    {


                        HiddenField hf = (HiddenField)rpt.FindControl("hdfReference");
                        reference = hf.Value;
                        Session["ref"] = reference;
                        CommonFunction cmDataTable = new CommonFunction();
                        string showAddData = "select CompanyName,AddressLine1,AddressLine2,City,Country,PostCode,Telephone,Fax,NumberOfShare,BuyRate,ExpireDate,DeclarationDate from IPODeclaration where Reference='" + reference + "'";
                        DataTable dtUpdateIpo = cmDataTable.GetDatatable(showAddData);
                        if (dtUpdateIpo.Rows.Count > 0)
                        {

                            txtCompanyName1.Text = dtUpdateIpo.Rows[0]["CompanyName"].ToString();
                            txtAddressLine11.Text = dtUpdateIpo.Rows[0]["AddressLine1"].ToString();
                            txtAddressLine21.Text = dtUpdateIpo.Rows[0]["AddressLine2"].ToString();
                            txtCity1.Text = dtUpdateIpo.Rows[0]["City"].ToString();
                            txtCountry1.Text = dtUpdateIpo.Rows[0]["Country"].ToString();
                            txtPostCode1.Text = dtUpdateIpo.Rows[0]["PostCode"].ToString();
                            txtTelephone1.Text = dtUpdateIpo.Rows[0]["Telephone"].ToString();
                            txtfax1.Text = dtUpdateIpo.Rows[0]["Fax"].ToString();
                            txtNumberOfShare1.Text = dtUpdateIpo.Rows[0]["NumberOfShare"].ToString();
                            txtBuyRate1.Text = dtUpdateIpo.Rows[0]["BuyRate"].ToString();

                            txtExpirationDate1.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(dtUpdateIpo.Rows[0]["ExpireDate"].ToString()));
                            txtDeclarationDate1.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(dtUpdateIpo.Rows[0]["DeclarationDate"].ToString()));
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                            break;
                        }
                    }

                    else continue;
                }
            }

            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace)); 
            
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtDeclarationDate1.Text != string.Empty && txtExpirationDate1.Text != string.Empty)
            {

                try
                {
                    GetSession session = new GetSession();
                    string reference = HttpContext.Current.Session["ref"].ToString();

                    string dateExpire = DateTime.ParseExact(txtExpirationDate1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("yyyy/MM/dd");
                    string dateDeclaration = DateTime.ParseExact(txtDeclarationDate1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("yyyy/MM/dd");
                    CommonFunction cmSaveData = new CommonFunction();
                    string insertQuery = "update IPODeclaration set CompanyName='" + txtCompanyName1.Text + "',AddressLine1='" + txtAddressLine11.Text + "',AddressLine2='" + txtAddressLine21.Text + "',City='" + txtCity1.Text + "',Country='" + txtCountry1.Text + "',PostCode='" + txtPostCode1.Text + "',Telephone='" + txtTelephone1.Text + "',Fax='" + txtfax1.Text + "',NumberOfShare='" + txtNumberOfShare1.Text + "',BuyRate='" + txtBuyRate1.Text + "',ExpireDate='" + dateExpire + "',DeclarationDate='" + dateDeclaration + "' where Reference='" + reference + "'";
                    cmSaveData.InsertQuery(insertQuery);
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Upadte Successfully');window.location='IpoInformation.aspx';</script>'");
                    ShowData();
                
                }
              
                catch (Exception )
                {

                 try
                 {
                     GetSession session = new GetSession();  
                    string reference = HttpContext.Current.Session["ref"].ToString();

                    string dateExpire = DateTime.ParseExact(txtExpirationDate1.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("yyyy/MM/dd");
                    string dateDeclaration = DateTime.ParseExact(txtDeclarationDate1.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("yyyy/MM/dd");
                    CommonFunction cmSaveData = new CommonFunction();
                    string insertQuery = "update IPODeclaration set CompanyName='" + txtCompanyName1.Text + "',AddressLine1='" + txtAddressLine11.Text + "',AddressLine2='" + txtAddressLine21.Text + "',City='" + txtCity1.Text + "',Country='" + txtCountry1.Text + "',PostCode='" + txtPostCode1.Text + "',Telephone='" + txtTelephone1.Text + "',Fax='" + txtfax1.Text + "',NumberOfShare='" + txtNumberOfShare1.Text + "',BuyRate='" + txtBuyRate1.Text + "',ExpireDate='" + dateExpire + "',DeclarationDate='" + dateDeclaration + "' where Reference='" + reference + "'";
                    cmSaveData.InsertQuery(insertQuery);
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Upadte Successfully');window.location='IpoInformation.aspx';</script>'");
                    ShowData();
                 
                 }

                  catch( Exception)
                 {

                     try
                     {
                         GetSession session = new GetSession();
                         string reference = HttpContext.Current.Session["ref"].ToString();

                         string dateExpire = DateTime.ParseExact(txtExpirationDate1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("yyyy/MM/dd");
                         string dateDeclaration = DateTime.ParseExact(txtDeclarationDate1.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("yyyy/MM/dd");
                         CommonFunction cmSaveData = new CommonFunction();
                         string insertQuery = "update IPODeclaration set CompanyName='" + txtCompanyName1.Text + "',AddressLine1='" + txtAddressLine11.Text + "',AddressLine2='" + txtAddressLine21.Text + "',City='" + txtCity1.Text + "',Country='" + txtCountry1.Text + "',PostCode='" + txtPostCode1.Text + "',Telephone='" + txtTelephone1.Text + "',Fax='" + txtfax1.Text + "',NumberOfShare='" + txtNumberOfShare1.Text + "',BuyRate='" + txtBuyRate1.Text + "',ExpireDate='" + dateExpire + "',DeclarationDate='" + dateDeclaration + "' where Reference='" + reference + "'";
                         cmSaveData.InsertQuery(insertQuery);
                         ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Upadte Successfully');window.location='IpoInformation.aspx';</script>'");
                         ShowData();

                     }


                     catch (Exception)

                     {
                         try
                         {
                             GetSession session = new GetSession();
                             string reference = HttpContext.Current.Session["ref"].ToString();

                             string dateExpire = DateTime.ParseExact(txtExpirationDate1.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("yyyy/MM/dd");
                             string dateDeclaration = DateTime.ParseExact(txtDeclarationDate1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("yyyy/MM/dd");
                             CommonFunction cmSaveData = new CommonFunction();
                             string insertQuery = "update IPODeclaration set CompanyName='" + txtCompanyName1.Text + "',AddressLine1='" + txtAddressLine11.Text + "',AddressLine2='" + txtAddressLine21.Text + "',City='" + txtCity1.Text + "',Country='" + txtCountry1.Text + "',PostCode='" + txtPostCode1.Text + "',Telephone='" + txtTelephone1.Text + "',Fax='" + txtfax1.Text + "',NumberOfShare='" + txtNumberOfShare1.Text + "',BuyRate='" + txtBuyRate1.Text + "',ExpireDate='" + dateExpire + "',DeclarationDate='" + dateDeclaration + "' where Reference='" + reference + "'";
                             cmSaveData.InsertQuery(insertQuery);
                             ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Upadte Successfully');window.location='IpoInformation.aspx';</script>'");
                             ShowData();

                         }

                         catch (Exception ex)
                         {

                             Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace)); 
                         }
                     
                     
                     }
                    
                  }
                
                }
               

            }

            else return;
        }
    }
}