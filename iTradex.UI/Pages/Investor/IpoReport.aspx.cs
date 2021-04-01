using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using iTradex.UI.Report;
using iTradex.UI.App_Code;

namespace iTradex.UI
{
  
    public partial class IpoReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetSession session = new GetSession();
            ClientScript.RegisterStartupScript(GetType(), "CLOSE", "<script language='javascript'> window.close(); </script>");
            Session["CompanyName"] = Request.QueryString["CompanyName"].ToString();
            Session["NoOfShares"] = Request.QueryString["NumberOfShare"].ToString();
            Session["BuyRate"] = Request.QueryString["BuyRate"].ToString();
            //Session["DeclarationDate"] = Request.QueryString["DeclarationDate"].ToString();
            Session["ExpireDate"] = Request.QueryString["ExpireDate"].ToString();
            Session["Id"] = Request.QueryString["id"].ToString();
            ReportDocument oIpoInformation = new ReportDocument();

            if (Request.QueryString["id"] == "2")
            {
                oIpoInformation.Load(Server.MapPath(@"..\..\IpoStatement.rpt"));

            }

            else
            {
                oIpoInformation.Load(Server.MapPath(@"..\..\IpoStatement3.rpt"));
            }
            //CrystalReportDataSet ds = new CrystalReportDataSet();
           
            Session["ReportName"] = "IPOReport";

            string[] company = Request.QueryString["CompanyName"].ToString().Split(' ');
            string companyName=company[0].ToString();
            string reportName="IPO"+companyName+session.AccountNumber;
          
            //char[] array = Request.QueryString["CompanyName"].ToString().ToCharArray();
            //string company = array[0].ToString() + array[1].ToString() + array[2].ToString() +array[3].ToString() + array[4].ToString();
          
            IpoInformationLoader oLoder = new IpoInformationLoader(oIpoInformation);

            ReportDocument rd = (ReportDocument)oLoder.GetReportSource();

           


            //MemoryStream oStream;
            //oStream = (MemoryStream)rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            //Response.Clear();
            //Response.Buffer = true;
            //Response.ContentType = "application/pdf";
            //Response.BinaryWrite(oStream.ToArray());
            ////Response.End();
            ////Response.Close();
            //oStream.Dispose();
            rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true,reportName );
            rd.Close();
            rd.Dispose();
            GC.Collect();
            
            //rd.Dispose();
            //Session["ReportDocumentObj"] = rd;

            //ResponseHelper.Redirect(Response, "ReportViwer.aspx", "_blank", "menubar=0,width=800,height=600");
           
            
        }
    }
}