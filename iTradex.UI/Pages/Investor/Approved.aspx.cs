using iTradex.UI.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using CityBankASP;

namespace iTradex.UI.Pages.Investor
{
    public partial class Approved : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["xmlmsg"] != "" && Request["xmlmsg"] != null)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(Request["xmlmsg"]);
                XmlNodeList nodeList = xmlDoc.SelectNodes("/Message");

                string OrderID = nodeList.Item(0)["OrderID"].InnerText ?? "";
                string TransactionType = nodeList.Item(0)["TransactionType"].InnerText ?? "";
                string Currency = nodeList.Item(0)["Currency"].InnerText ?? "";
                string PurchaseAmount = nodeList.Item(0)["PurchaseAmount"].InnerText ?? "";
                string ResponseCode = nodeList.Item(0)["ResponseCode"].InnerText ?? "";
                string OrderStatus = nodeList.Item(0)["OrderStatus"].InnerText ?? "";
                string ApprovalCode = nodeList.Item(0)["ApprovalCode"].InnerText ?? "";
                string Description = nodeList.Item(0)["OrderDescription"].InnerText ?? "";

                string data = "{\"OrderId\":\"" + OrderID + "\","
                + "\"TransactionType\":\"" + TransactionType + "\","
                + "\"Currency\":\"" + Currency + "\","
                + "\"Description\":\"" + Description + "\","
                + "\"PurchaseAmount\":\"" + PurchaseAmount + "\","
                + "\"OrderStatus\":\"" + OrderStatus + "\","
                + "\"ResponseCode\":\"" + ResponseCode + "\","
                + "\"ApprovalCode\":\"" + ApprovalCode + "\"}";

                Response.Redirect("../../ApprovedOriginal.aspx?data=" + data, false);
            }
        }
    }
}