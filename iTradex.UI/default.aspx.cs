﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTradex.UI.App_Code;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

namespace iTradex.UI.Pages.Investor
{
    public partial class LoginPage : System.Web.UI.Page
    {
        GetSession session = new GetSession();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["e"] != null && Request.QueryString["e"] != "0")
                        Acctivation();
                }


                //if (Request.Cookies["loginCookies"] != null)
                //{
                //    Response.Cookies["loginCookies"].Expires = DateTime.Now.AddDays(-1);
                //    Cookies();

                //}

                pnlMessage.Visible = false;
            }


            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }


        }



        /// <summary>
        /// Code For Login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ApplicationUser loggedUser = new ApplicationUser();
            RijndaelEncryption passwordEncription = new RijndaelEncryption();
            //string userEmail = Request.Form["Email"].ToString();
            string userEmail = txtEmail.Text;
            string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
            string userPassword = passwordEncription.EncryptText(Request.Form["password"].ToString(), encryptionKey);
            //string userPassword = passwordEncription.EncryptText(txtPassword.Text, encryptionKey);
            try
            {
                CommonFunction cm = new CommonFunction();

                //SqlConnection conLogin = DatabaseConnection.GetConnection();

                string loginCommand = string.Empty;
                string[] userid = userEmail.Split('@');

                if (userid.Length > 1)
                {
                    loginCommand = "SELECT UserId,AccountNumber,BONumber,Password,IsActive, IsRegistered,UserType,BrokerRef,Status FROM ApplicationUser where UserId ='" + userEmail + "' and password ='" + userPassword + "' ORDER BY LastLoginTime DESC";
                }
                else
                {
                    loginCommand = "SELECT UserId,AccountNumber,BONumber,Password,IsActive, IsRegistered,UserType,BrokerRef,Status FROM ApplicationUser where AccountNumber ='" + userEmail + "' and password ='" + userPassword + "' ";
                }


                
                //SqlCommand cmdCommand = new SqlCommand(loginCommand, conLogin);
                DataTable dtLogin = cm.GetDatatable(loginCommand);
                //SqlDataAdapter sdaLogin = new SqlDataAdapter(cmdCommand);
                //DataSet dtsLogin = new DataSet();

                //sdaLogin.Fill(dtsLogin);

                //if (dtsLogin.Tables[0].Rows.Count > 0)
                if (dtLogin.Rows.Count > 0)
                {
                    //foreach (DataRow dr in dtsLogin.Tables[0].Rows)
                    foreach (DataRow dr in dtLogin.Rows)
                    {
                        if (Convert.ToBoolean(dr["IsRegistered"]) == true)
                        {
                            if (dr["Status"].ToString() == "Active")
                            {
                                if (userPassword == dr["Password"].ToString())
                                {
                                    CommonFunction cmLogin = new CommonFunction();
                                    string loginTimeQuery = "Update ApplicationUser set LastLoginTime = '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "',IsLogin='true' where UserId='" + userEmail + "'";
                                    cmLogin.InsertQuery(loginTimeQuery);
                                    //SqlConnection conLogin = DatabaseConnection.GetConnection();
                                    //SqlCommand cmdLoginFlag = new SqlCommand("Update ApplicationUser set IsLogin='true' where(UserId='" + userEmail + "')", conLogin);
                                    //cmdLoginFlag.ExecuteNonQuery();
                                    //conLogin.Close();
                                    loggedUser.UserID = dr["UserID"].ToString();
                                    loggedUser.AccountNumber = dr["AccountNumber"].ToString();
                                    loggedUser.BoNumber = dr["BONumber"].ToString();
                                    loggedUser.UserType = dr["UserType"].ToString();
                                    loggedUser.BrokerRef = dr["BrokerRef"].ToString();

                                    Session["AccountNumber"] = loggedUser.AccountNumber;
                                    Session["UserID"] = loggedUser.UserID;
                                    Session["BOID"] = loggedUser.BoNumber;
                                    Session["UserType"] = loggedUser.UserType;
                                    Session["BrokerRef"] = loggedUser.BrokerRef;
                                    string name = RegionInfo.CurrentRegion.DisplayName;
                                    string strClientIP = HttpContext.Current.Request.UserHostAddress;

                                    //store session in Getsession class
                                    //session.AccountNumber = loggedUser.AccountNumber;
                                    //session.BoNumber = loggedUser.BoNumber;
                                    //session.BrokerRef = loggedUser.BrokerRef;
                                    //session.UserName = loggedUser.UserID;
                                    //GetSession.userType = loggedUser.UserType;

                                    //CommonFunction cpAppLog = new CommonFunction();
                                    //String insertQuery = "insert into ApplicationLog (Id,LogTime,LogType,LogDetails) values ('" + loggedUser.AccountNumber + "','" + DateTime.Now + "','Information','" + strClientIP + "')";
                                    //cpAppLog.InsertQuery(insertQuery);


                                    //if (chkCookie.Checked == true)
                                    //{
                                    //    HttpCookie loginCookies = new HttpCookie("loginCookies");
                                    //    Response.Cookies["loginCookies"]["Email"] = userEmail;
                                    //    Response.Cookies["loginCookies"]["Password"] = userPassword;
                                    //    Response.Cookies["loginCookies"].Expires = DateTime.Now.AddDays(1);

                                    //}
                                    //Session["USER"] = loggedUser;
                                    if (dr["UserType"].ToString() == "Broker")
                                    {
                                        Response.Redirect(@"Pages\Investor\OrderBroker.aspx", false);
                                    }

                                    else if (dr["UserType"].ToString() == "SystemAdmin")
                                    {
                                        Response.Redirect(@"Pages\Investor\SystemAdmin.aspx", false);
                                    }

                                    else
                                    {
                                        Response.Redirect(@"Pages\Investor\Dashboard.aspx", false);
                                        //Response.Redirect("Transaction.aspx",false);
                                    }
                                }

                                else
                                {
                                    //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Please Enter The Correct Password');window.location='default.aspx';</script>'");
                                    pnlMessage.Visible = true;
                                    lblShowMessage.Text = "Please enter the correct password.";
                                }

                            }

                            else
                            {
                                //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Your Account Is Not acctivated Yet, Please Contact With Your Broker');window.location='default.aspx';</script>'");
                                pnlMessage.Visible = true;
                                lblShowMessage.Text = "Your account is not acctivated yet.";
                            }

                        }

                        else
                        {
                            //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Your Account is Not Still Registered, Please Visit Registration Page For Being Registered');window.location='default.aspx';</script>'");
                            pnlMessage.Visible = true;
                            lblShowMessage.Text = "Your account is not still registered.";

                        }

                        break;
                    }

                }

                else
                {
                    //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Invalid Email Address, Please Enter The Correct One');window.location='default.aspx';</script>'");
                    pnlMessage.Visible = true;
                    lblShowMessage.Text = "The email or password you entered is incorrect.";
                }

            }

            catch (Exception ex)
            {

                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));

            }

        }


        /// <summary>
        /// For Acctivate User Account
        /// </summary>
        private void Acctivation()
        {
            try
            {
                RijndaelEncryption decreption = new RijndaelEncryption();
                string encryptionKey = ConfigurationManager.AppSettings["EncryptionKey"];
                string userId = decreption.DecryptText((Request.QueryString["e"].ToString()), encryptionKey);
                string accountNumber = decreption.DecryptText((Request.QueryString["a"].ToString()), encryptionKey);

                if (string.IsNullOrEmpty(userId))
                    return;

                //string accountNumber = Request.Form["AccountNumber"].ToString();
                //SqlConnection sconAcctivation = DatabaseConnection.GetConnection();
                CommonFunction cmAcctivation = new CommonFunction();
                string acctivationQuery = "update ApplicationUser set IsRegistered='true',Status='Active' where(UserID='" + userId + " ' and AccountNumber='" + accountNumber + "' )";
                //SqlCommand cmdAcctivation = new SqlCommand(acctivationQuery, sconAcctivation);
                //cmdAcctivation.ExecuteNonQuery();
                //sconAcctivation.Close();
                cmAcctivation.InsertQuery(acctivationQuery);
                if (userId != null)
                {
                    //ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('Your Account Has Been Acctivated, Please Login');window.location='default.aspx';</script>'");
                    pnlMessage.Visible = true;
                    lblShowMessage.Text = "Your account has been acctivated. Please login";

                }
            }
            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }


        /// <summary>
        /// Get Cookies
        /// </summary>
        ///
        private void Cookies()
        {
            string email = Request.Cookies["loginCookies"]["Email"];
            string password = Request.Cookies["loginCookies"]["Password"];
            ApplicationUser loggedUser = new ApplicationUser();
            RijndaelEncryption passwordEncription = new RijndaelEncryption();

            try
            {
                CommonFunction cm = new CommonFunction();

                string loginCommand = "select UserId,AccountNumber,BONumber,Password,IsActive, IsRegistered,UserType,BrokerRef from ApplicationUser where UserId='" + email + "' ";
                DataTable dtLogin = cm.GetDatatable(loginCommand);

                if (dtLogin.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtLogin.Rows)
                    {
                        loggedUser.UserID = dr["UserID"].ToString();
                        loggedUser.AccountNumber = dr["AccountNumber"].ToString();
                        loggedUser.BoNumber = dr["BONumber"].ToString();
                        loggedUser.UserType = dr["UserType"].ToString();
                        loggedUser.BrokerRef = dr["BrokerRef"].ToString();

                        Session["AccountNumber"] = loggedUser.AccountNumber;
                        Session["UserID"] = loggedUser.UserID;
                        Session["BOID"] = loggedUser.BoNumber;
                        Session["UserType"] = loggedUser.UserType;
                        Session["BrokerRef"] = loggedUser.BrokerRef;

                        if (dr["UserType"].ToString() == "Broker")
                        {
                            Response.Redirect("Pages/Investor/RegistrationConfirmation.aspx");
                        }

                        else if (dr["UserType"].ToString() == "SysAdmin")
                        {
                            Response.Redirect("Pages/Investor/SystemAdmin.aspx", false);
                        }

                        else
                        {
                            Response.Redirect("Pages/Investor/Dashboard.aspx");
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Response.Redirect("LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
            }
        }
    }
}
