using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace iTradex.UI.App_Code
{
    public class GetSession
    {
        //    public string accountNumber = HttpContext.Current.Session["AccountNumber"].ToString();
        //    public  string userName = HttpContext.Current.Session["UserID"].ToString();
        //    public  string boNumber = HttpContext.Current.Session["BOID"].ToString();
        //    public  string brokerRef = HttpContext.Current.Session["BrokerRef"].ToString();
        //    public  string userType = HttpContext.Current.Session["UserType"].ToString();
        private string accountNumber;
        private string userName;
        private string boNumber;
        private string brokerRef;
        private string userType;
        private string accountName;
        private string merchant;
        private string merchantPassword;
        private string merchantUserName;
        private string orderID;
        private string sessionID;
        private string purchaseAmount;
        private string onlineTransactionID;

        public string OnlineTransactionID
        {
            get
            {
                return HttpContext.Current.Session["OnlineTransactionID"].ToString();
            }

            set
            {
                onlineTransactionID = HttpContext.Current.Session["OnlineTransactionID"].ToString();
            }
        }

        public string PurchaseAmount
        {
            get
            {
                return HttpContext.Current.Session["PurchaseAmount"].ToString();
            }

            set
            {
                purchaseAmount = HttpContext.Current.Session["PurchaseAmount"].ToString();
            }
        }

        public string SessionID
        {
            get
            {
                return HttpContext.Current.Session["SessionID"].ToString();
            }

            set
            {
                sessionID = HttpContext.Current.Session["SessionID"].ToString();
            }
        }

        public string OrderID
        {
            get
            {
                return HttpContext.Current.Session["OrderID"].ToString();
            }

            set
            {
                orderID = HttpContext.Current.Session["OrderID"].ToString();
            }
        }

        public string MerchantUserName
        {
            get
            {
                return HttpContext.Current.Session["MerchantUserName"].ToString();
            }

            set
            {
                merchantUserName = HttpContext.Current.Session["MerchantUserName"].ToString();
            }
        }

        public string AccountNumber
        {
          get 
          {
              return HttpContext.Current.Session["AccountNumber"].ToString();
          }
   
          set
          {
              accountNumber = HttpContext.Current.Session["AccountNumber"].ToString(); 
          }
        }

        public string MerchantPassword
        {
            get
            {
                return HttpContext.Current.Session["MerchantPassword"].ToString();
            }

            set
            {
                merchantPassword = HttpContext.Current.Session["MerchantPassword"].ToString();
            }
        }

        public string Merchant
        {
            get
            {
                return HttpContext.Current.Session["Merchant"].ToString();
            }

            set
            {
                merchant = HttpContext.Current.Session["Merchant"].ToString();

            }
        }

        public string AccountName
        {
            get
            {
                return HttpContext.Current.Session["AccountName"].ToString();
            }

            set
            {
                accountName = HttpContext.Current.Session["AccountName"].ToString();

            }
        }

        public string UserName
        {
            get { return HttpContext.Current.Session["UserID"].ToString(); }
            set { userName = HttpContext.Current.Session["UserID"].ToString(); }
        }
        public string BoNumber
        {
            get { return HttpContext.Current.Session["BOID"].ToString(); ; }
            set { boNumber = HttpContext.Current.Session["BOID"].ToString(); }
        }
        public string BrokerRef
        {
            get { return HttpContext.Current.Session["BrokerRef"].ToString(); }
            set { brokerRef = HttpContext.Current.Session["BrokerRef"].ToString(); }
        }
        public string UserType
        {
            get { return HttpContext.Current.Session["UserType"].ToString(); }
            set { userType = HttpContext.Current.Session["UserType"].ToString(); }
        }

        //public static string accName = session.AccountNumber;

        //public static string AccUser
        //{
        //    get { return accUser; }
        //    set { accUser = value; }
        //}
        //public static string AccBoId
        //{
        //    get { return accBoId; }
        //    set { accBoId = value; }
        //}
        //public static string AccNo = HttpContext.Current.Session["AccountNumber"].ToString();
        //public static string AccUser = HttpContext.Current.Session["UserID"].ToString();
        //public static string AccBoId = HttpContext.Current.Session["BOID"].ToString();

        public static void DistroySession()
        {
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.Clear();
        }
    }
}