using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace KaziEquitiesWebSite
{
     public static class SiteAttributes
    {
         public static string BaseUrl
         {
             get {

                 HttpContext context = HttpContext.Current;
                 string baseUrl = context.Request.Url.Scheme + "://" + context.Request.Url.Authority + context.Request.ApplicationPath.TrimEnd('/') + '/';

                 return baseUrl;
             
             }
         }
         public static string BasePath
         {
             get
             {
                 HttpContext context = HttpContext.Current;
                 return System.AppDomain.CurrentDomain.BaseDirectory; ;
             }

         }
         public static string AppDecimalNumberFormat = "#,##0.00";
         public static DataSet GetTopTenGainer()
         {



             DataSet result = new DataSet();
             result.Tables.Add("results");
             result.Tables["results"].Columns.Add("TradingCode");
             result.Tables["results"].Columns.Add("CloseP");       
             result.Tables["results"].Columns.Add("%Change");
             result.Tables["results"].Columns.Add("YCP");
             result.Tables["results"].Columns.Add("High");
             result.Tables["results"].Columns.Add("Low");

             //For Each item As FileSearchResultItem In list
             foreach (DSEParser.GainterLoser o in DSEParser.DSESite.TopTenGainer)
             {

                 DataRow newRow = result.Tables["results"].NewRow();
                 newRow["TradingCode"] = o.TradingCode;
                 newRow["CloseP"] = o.CloseP;           
                 newRow["%Change"] = o.ParcentageChange;
                 newRow["YCP"] = o.YCP;
                 newRow["High"] = o.High;
                 newRow["Low"] = o.Low;
                 result.Tables["results"].Rows.Add(newRow);
             }


             return result;
         }
         //public static DataSet GetTopTenLoser()
         //{

         //    DataSet result = new DataSet();
         //    result.Tables.Add("results");
         //    result.Tables["results"].Columns.Add("TradingCode");
         //    result.Tables["results"].Columns.Add("CloseP");
         //    result.Tables["results"].Columns.Add("%Change");
         //    result.Tables["results"].Columns.Add("YCP");
         //    result.Tables["results"].Columns.Add("High");
         //    result.Tables["results"].Columns.Add("Low");

         //    //For Each item As FileSearchResultItem In list
         //    foreach (DSEParser.GainterLoser o in DSEParser.DSESite.TopTenLoser)
         //    {

         //        DataRow newRow = result.Tables["results"].NewRow();
         //        newRow["TradingCode"] = o.TradingCode;
         //        newRow["CloseP"] = o.CloseP;             
         //        newRow["%Change"] = o.ParcentageChange;
         //        newRow["YCP"] = o.YCP;
         //        newRow["High"] = o.High;
         //        newRow["Low"] = o.Low;
         //        result.Tables["results"].Rows.Add(newRow);
         //    }


         //    return result;
         //}
    }
}
