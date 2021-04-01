using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Data.SqlClient;
using iTradex.UI.App_Code;

namespace iTradex.UI
{
    public partial class CrystalReportViwer : System.Web.UI.Page
    {
    //    protected void Page_Load(object sender, EventArgs e)
    //    {
    //        ReportDocument rptDoc = new ReportDocument();
    //        CrystalReport cs = new CrystalReport(); // .xsd file name
    //        DataTable dt = new DataTable();
                

    //        dt = GetInvestorLedgerStatement(); //This function is located below this function
    //        cs.Tables[0].Merge(dt);

    //        // Your .rpt file path will be below
    //        rptDoc.Load(Server.MapPath("Transaction.rpt"));

    //        //set dataset to the report viewer.
    //        rptDoc.SetDataSource(cs);
    //        CrystalReportViewer.ReportSource = rptDoc;
    //    }


    //    public DataTable GetInvestorLedgerStatement()
    //    {
    //              string rangeA= Request.Form["rangeBa"];
    //            string rangeB=Request.Form["rangeBb"];
    //            if (rangeA == string.Empty || rangeB==string.Empty)
    //            {
    //                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script type='text/javascript'>alert('please select date');window.location='Transaction.aspx';</script>'");
    //            }
    //            else
    //            {
    //            string databaseDateFormat = "yyyy/MM/dd";
    //            string dateFrom = DateTime.ParseExact(Request.Form["rangeBa"],"dd/MM/yyyy" , null).ToString(databaseDateFormat);
    //            string dateTo = DateTime.ParseExact(Request.Form["rangeBb"], "dd/MM/yyyy", null).ToString(databaseDateFormat);
    //             SqlConnection sconTransaction = DatabaseConnection.GetConnection();
    //                SqlCommand command = new SqlCommand("GetInvestorLedgerStatement", sconTransaction);
    //                command.CommandType = CommandType.StoredProcedure;
    //                sconTransaction.Close();
    //                command.Parameters.Add("@AccountRef", SqlDbType.VarChar).Value =GetSession.accNo;
    //                command.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = dateFrom;
    //                command.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = dateTo;

    //          DataSet ds = null;
    //          SqlDataAdapter adapter;
    //    try
    //    {
       
         
    //        ds = new DataSet();
    //        adapter = new SqlDataAdapter(command);
    //        adapter.Fill(ds);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message);
    //    }
    //    finally
    //    {
    //        command.Dispose();
    //        if (sconTransaction.State != ConnectionState.Closed)
    //            sconTransaction.Close();
    //    }
        
        
        
    //    }
    //            return ds.Tables[0];
    //}

    }
}

