using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using iTradex.UI.App_Code;
using System.Data.SqlClient;

namespace iTradex.UI
{
    public partial class CrystalReportViewer : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    ReportDocument rptDoc = new ReportDocument();
        //    dsSample ds = new dsSample(); 
        //    DataTable dt = new DataTable();

            
           
        //    dt = ShowData(); 
        //    ds.Tables[0].Merge(dt);

            
        //    rptDoc.Load(Server.MapPath(""));

            
        //    rptDoc.SetDataSource(ds);
        //   FundWithdrawCrystalReportViewer.ReportSource = rptDoc;
        //}


        //public DataTable ShowData()
        //{
            
        //    SqlConnection sconShowData = DatabaseConnection.GetConnection();
        //    string showAddData = "select AccountRef,TransactionDate,YourReference,TotalAmount,TotalVat,NetAmount,PaymentType,Status from TransactionHead where (AccountRef='" + accountReference + "' and Status='Request') order by TransactionDate desc";
        //    SqlCommand cmdshowAddData = new SqlCommand(showAddData, sconShowData);
        //    DataSet ds = null;
        //    SqlDataAdapter adapter;
        //    try
        //    {
                
        //        ds = new DataSet();
        //        adapter = new SqlDataAdapter(cmdshowAddData);
        //        adapter.Fill(ds, "Users");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        cmdshowAddData.Dispose();
        //        if (sconShowData.State != ConnectionState.Closed)
        //            sconShowData.Close();
        //    }
        //    return ds.Tables[0];
        //}
    }

}