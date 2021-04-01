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
    public partial class Declined : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ExtractXmlMessageFromRequest()
        {
            XmlDocument xmlDoc = new XmlDocument();
            GetSession session = new GetSession();

            String OrderID;
            String TransactionType;
            String Currency;
            String PurchaseAmount;
            String OrderStatus;
            String PAN;

            if (Request["xmlmsg"] != "" && Request["xmlmsg"] != null)
            {
                try
                {
                    xmlDoc.LoadXml(Request["xmlmsg"]);
                    XmlNodeList nodeList = xmlDoc.SelectNodes("/Message");

                    OrderID = nodeList.Item(0)["OrderID"].InnerText;
                    TransactionType = nodeList.Item(0)["TransactionType"].InnerText;
                    Currency = nodeList.Item(0)["Currency"].InnerText;
                    PurchaseAmount = nodeList.Item(0)["PurchaseAmount"].InnerText;
                    OrderStatus = nodeList.Item(0)["OrderStatus"].InnerText;

                    if (OrderID == session.OrderID.ToString())
                    {
                        String data = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
                        data += "<TKKPG>";
                        data += "<Request>";
                        data += "<Operation>GetOrderInformation</Operation>";
                        data += "<Language>EN</Language>";
                        data += "<Order>";
                        data += "<Merchant>" + session.Merchant.ToString() + "</Merchant>";
                        data += "<OrderID>" + session.OrderID.ToString() + "</OrderID>";
                        data += "</Order>";
                        data += "<SessionID>" + session.SessionID.ToString() + "</SessionID>";
                        data += "<ShowParams>true</ShowParams>";
                        data += "<ShowOperations>false</ShowOperations>";
                        data += "<ClassicView>true</ClassicView>";
                        data += "</Request></TKKPG> ";

                        String response = Functions.PostQW(data);
                        XmlDocument xml = new XmlDocument();
                        xml.LoadXml(response.Substring(response.IndexOf("<TKKPG>")));

                        //Extract additional parameters for verification
                        XmlNodeList xmlNodes = xml.SelectNodes("/TKKPG/Response/Order/row/OrderParams/row");
                        foreach (XmlNode node in xmlNodes)
                            if (node.ChildNodes.Item(0).InnerText == "PAN")
                                PAN = node.ChildNodes.Item(1).InnerText;
                    }
                }
                catch (Exception) { }
            }
        }

        protected void btnDepositProceed_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx", false);
        }
    }
}