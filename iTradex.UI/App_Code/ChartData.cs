using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTradex.UI.App_Code
{
        public class ChartData
        {
            //private string p;
            //private int p_2;
            //private int p_3;

            //public ChartData(string p, int p_2, int p_3)
            //{
            //    // TODO: Complete member initialization
            //    this.p = p;
            //    this.p_2 = p_2;
            //    this.p_3 = p_3;
            //}
            //public string Category { get; set; }
            //public int TotalInvestment { get; set; }
            //public int MarketValue { get; set; }
            public string ColumnName = "";
            public int Investment = 0;
            public int Value = 0;

            public ChartData(string columnName, int investment, int value)
            {
                ColumnName = columnName;
                Investment = investment;
                Value = value;
            }
        } 
}