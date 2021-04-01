using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using CityBankASP;
using iTradex.UI.App_Code;
using Newtonsoft.Json;

namespace iTradex.UI
{
    public class ResponseModel
    {
        public string OrderId { get; set; }
        public string TransactionType { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string PurchaseAmount { get; set; }
        public string OrderStatus { get; set; }
        public string ResponseCode { get; set; }
        public string ApprovalCode { get; set; }
    }

    public partial class ApprovedOriginal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetSession session = new GetSession();
                string nodeData = Request.QueryString["data"];


                ResponseModel nodeList = JsonConvert.DeserializeObject<ResponseModel>(nodeData);

                decimal totalAmount = Convert.ToDecimal(nodeList.PurchaseAmount);

                if (nodeList.OrderId == session.OrderID.ToString())
                {
                    lblTtransactionType.Text = "Transaction Type : " + nodeList.TransactionType.ToString();
                    //lblTtransactionType.Text = "Transaction Type : " + "27";
                    lblCurrency.Text = "Currency : " + nodeList.Currency.ToString();
                    lblCurrency.Text = "Deposit Amount : " + nodeList.PurchaseAmount.ToString();
                    lblResponseCode.Text = "Response Code : " + nodeList.ResponseCode.ToString();
                    lblOrderStatus.Text = "Order Status : " + nodeList.OrderStatus.ToString();
                    lblApprovalCode.Text = "Approval Code : " + nodeList.ApprovalCode.ToString();

                    try
                    {
                        CommonFunction cmSaveData = new CommonFunction();
                        //string insertQuery = "insert into TransactionHead(NetAmount,Description,AccountRef,Status,TransactionDate,PaymentType,TransactionType,Reference,TotalAmount,TranType,OnlineTransactionID)" + "Values('" + totalAmount + "','" + nodeList.Description + "','" + session.AccountNumber + "','" + "Pending" + "','" + DateTime.Now.ToString() + "','" + "Card ',' 27 ',NEWId(),'" + totalAmount + "',' 27 ','" + session.OnlineTransactionID + "')";


                        string insertQuery = "insert into TransactionHead" +
                                "(NetAmount, Description, AccountRef, Status, TransactionDate, PaymentType, TransactionType, Reference, TotalAmount, TranType, OnlineTransactionID, OurReference, TransactionTypeCode, YourReference, TransactionCreated)"
                                + "Values(" + totalAmount + ",'" + nodeList.Description + "','" + session.AccountNumber + "','" + "Pending" + "','" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "','" + "Card','27',NEWID()," + totalAmount + ",'R','" + session.OnlineTransactionID + "', '" + nodeList.ApprovalCode.ToString() + "','INV-FD', '" + nodeList.Description + "', '" + DateTime.Now.ToString() + "')";

                        cmSaveData.InsertQuery(insertQuery);
                    }

                    catch (Exception ex)
                    {
                        Response.Redirect("../../LoginErrorPage.aspx?ex=" + Server.UrlEncode(ex.Message) + "&st=" + Server.UrlEncode(ex.StackTrace));
                    }
                }
            }
        }

        protected void btnBacktoDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pages/Investor/Dashboard.aspx", false);
        }
    }
}