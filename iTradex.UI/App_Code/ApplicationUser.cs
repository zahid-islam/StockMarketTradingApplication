using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTradex.UI
{
    public class ApplicationUser
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        string userID;
        string accountNumber;
        string boNumber;
        string userType;
        string brokerRef;

        public string BrokerRef
        {
            get { return brokerRef; }
            set { brokerRef = value; }
        }

        public string BoNumber
        {
            get { return boNumber; }
            set { boNumber = value; }
        }
        

        public string UserType
        {
            get { return userType; }
            set { userType = value; }
        }

      

        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }
       

        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }
       

      
    }
}