using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTradex.UI.Report
{
    public class SessionObject
    {
        string companyName;
        string branchName;
        string address;

        Branch headOffice = new Branch();
        //public SessionObject()
        //{
        //    GetHeadOffice();
        //}
        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        public string BranchName
        {
            get { return branchName; }
            set { branchName = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        //public Branch HeadOffice
        //{
        //    get { return headOffice; }
        //}

        //private void GetHeadOffice()
        //{
        //    try
        //    {
        //        headOffice.BranchType = "HO";
        //        headOffice.Select();
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}
    }
}