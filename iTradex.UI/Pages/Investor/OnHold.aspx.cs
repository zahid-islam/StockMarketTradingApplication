using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using iTradex.UI.App_Code;
using System.Configuration;

namespace iTradex.UI.Pages.Investor
{
    public partial class OnHold : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccountNumber"] == null)
            {
                Response.Redirect("../../Default.aspx");
            }

            ShowBrokerData();
            //ShowBrokerNameOnSuccessModal();
        }


        private void ShowBrokerData()
        {
            try
            {
                GetSession session = new GetSession();
                //string brokerRef = Session["BrokerRef"].ToString();
                //SqlConnection sconShowBrokerData = DatabaseConnection.GetConnection();
                CommonFunction cmDatatTable = new CommonFunction();
                string query = "select UserID,AccountNumber,BONumber from ApplicationUser where (IsRegistered='false' or IsActive='false'  and UserType='Investor')";
                //SqlCommand cmdBrokerData = new SqlCommand(query, sconShowBrokerData);
                //SqlDataAdapter sdaShowBrokerData = new SqlDataAdapter(cmdBrokerData);
                DataTable dtShowBrokerData =cmDatatTable.GetDatatable(query);
                //sdaShowBrokerData.Fill(dtShowBrokerData);
                rptShowBrokerData.DataSource = dtShowBrokerData;
                rptShowBrokerData.DataBind();

            }


            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void ShowBrokerName()
        {
            GetSession session = new GetSession();
            Label lblBrokerName = this.Master.FindControl("PlaceHolder1").FindControl("lblUserName") as Label;
            //string brokerRef = Session["BrokerRef"].ToString();
            CommonFunction cmDataTable = new CommonFunction();
            //SqlConnection sconShowBrokerName = DatabaseConnection.GetConnection();
            string query = "select BrokerName from Broker";
            //SqlCommand cmdBrokerName = new SqlCommand(query, sconShowBrokerName);
            //SqlDataAdapter sdaShowBrokerName = new SqlDataAdapter(cmdBrokerName);
            //sconShowBrokerName.Close();
            DataTable dtBrokerName = cmDataTable.GetDatatable(query);
            //sdaShowBrokerName.Fill(dtBrokerName);

            if (dtBrokerName.Rows.Count > 0)
            {

                lblBrokerName.Text = dtBrokerName.Rows[0]["BrokerName"].ToString();
            }
        }

        /// <summary>
        /// For showing Broker Name On Header
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ShowBrokerName();
        }

        //private void ShowBrokerNameOnSuccessModal()
        //{

        //    try
        //    {

        //        string brokerRef = Session["BrokerRef"].ToString();
        //        //SqlConnection sconShowBrokerName = DatabaseConnection.GetConnection();
        //        CommonFunction cmDataTable = new CommonFunction();
        //        string query = "select BrokerName from Broker where (Reference='" + brokerRef + "')";
        //        //SqlCommand cmdBrokerName = new SqlCommand(query,sconShowBrokerName);
        //        //SqlDataAdapter sdaShowBrokerName = new SqlDataAdapter(cmdBrokerName);
        //        //sconShowBrokerName.Close();
        //        DataTable dtBrokerName = cmDataTable.GetDatatable(query);
        //        //sdaShowBrokerName.Fill(dtBrokerName);

        //        if (dtBrokerName.Rows.Count > 0)
        //        {

        //            lblInvestorname.Text = dtBrokerName.Rows[0]["BrokerName"].ToString();
        //        }

        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        protected void textBox_TextChanged(object sender, EventArgs e)
        {
            GetSession session = new GetSession();
            RijndaelEncryption encryption = new RijndaelEncryption();
            string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
            string oldPassword = encryption.EncryptText(txtOldPassword.Text, encryptionKey);
            try
            {
                CommonFunction cm = new CommonFunction();
                string password = "select Password from ApplicationUser where UserId='" + session.UserName + "' and BONumber='" + session.BoNumber + "'";

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
                throw ex;
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
                string updatePassword = "update ApplicationUser set Password='" + newPassword + "' where(UserID='" + session.UserName + " ' and AccountNumber='" + session.AccountNumber + "' and password='" + oldPassword + "' )";
                cmSaveData.InsertQuery(updatePassword);
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Password change successfully');window.location='BrokerInformation.aspx';</script>'");
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}