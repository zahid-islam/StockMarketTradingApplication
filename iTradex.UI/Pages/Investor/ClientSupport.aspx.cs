using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTradex.UI.App_Code;
using System.Data;
using System.Globalization;
using System.Configuration;

namespace iTradex.UI
{
    public partial class ClientSupport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblInvestorname.Text = "System Admin";
           
        }

        private void ShowSystemAdminName()
        {
            Label lblBrokerName = this.Master.FindControl("PlaceHolder1").FindControl("lblUserName") as Label;

            lblBrokerName.Text = "System Admin";

        }

        /// <summary>
        /// For showing System Admin Name On Header
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ShowSystemAdminName();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ApplicationUser loggedUser = new ApplicationUser();
            RijndaelEncryption passwordEncription = new RijndaelEncryption();
            //string userEmail = Request.Form["Email"].ToString();
            string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
            string userAccountNumber = Request.Form["accountNumber"].ToString();
            try
            {
                CommonFunction cm = new CommonFunction();

                //string loginCommand = "select UserId,AccountNumber,BONumber,Password,IsActive, IsRegistered,UserType,BrokerRef from ApplicationUser where UserId='" + userEmail + "' and AccountNumber='" + userAccountNumber + "' ";
                string loginCommand = "SELECT Distinct i.AccountNumber, i.AccountType, i.BONumber,  i.BrokerRef FROM Investor i "
                                        + "where (i.AccountNumber='"+userAccountNumber+"')";
                DataTable dtLogin = cm.GetDatatable(loginCommand);

                if (dtLogin.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtLogin.Rows)
                    {
                        if (userAccountNumber == dr["AccountNumber"].ToString())
                        {
                            //loggedUser.UserID = dr["Email"].ToString().Trim();
                            loggedUser.AccountNumber = dr["AccountNumber"].ToString();
                            loggedUser.BoNumber = dr["BONumber"].ToString();
                            loggedUser.UserType = "Investor";
                            loggedUser.BrokerRef = dr["BrokerRef"].ToString();

                            Session["AccountNumber"] = loggedUser.AccountNumber;
                            //Session["UserID"] = loggedUser.UserID;
                            Session["BOID"] = loggedUser.BoNumber;
                            Session["UserType"] = loggedUser.UserType;
                            Session["BrokerRef"] = loggedUser.BrokerRef;

                            //Store session informations
                            //session.AccountNumber = loggedUser.AccountNumber;
                            //session.BoNumber = loggedUser.BoNumber;
                            //session.BrokerRef = loggedUser.BrokerRef;
                            ////session.UserName = loggedUser.UserID;
                            //GetSession.userType = loggedUser.UserType;

                            if (loggedUser.UserType == "Investor")
                            {
                                Response.Redirect("Dashboard.aspx", false);
                                //if (! string.IsNullOrEmpty(loggedUser.UserID))
                                //{
                                //   
                                //}
                                //else
                                //{
                                //    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Email Address Not Found.');window.location='ClientSupport.aspx';</script>'");
                                //}
                            }
                            else
                                return;
                        }
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Account Number is not Valid. Please Enter The Correct One');window.location='ClientSupport.aspx';</script>'");
                }
            }

            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace)); 
            }

        }
    }
}