using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTradex.UI.Report
{
    public class ReportLoaderBase
    {

        SessionObject oSessonObject;
        public ReportLoaderBase()
        {
            oSessonObject = HttpContext.Current.Session["sessionObject"] as SessionObject;
        }
        public string Branch
        {
            get { return oSessonObject.BranchName; }

        }

        public string Address
        {
            get { return oSessonObject.Address; }

        }

        public string CompanyName
        {
            get { return oSessonObject.CompanyName; }

        }
        public virtual object GetReportSource()
        {
            return null;
        }
    }
}