using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Data;
using iTradex.UI.App_Code;
using System.Configuration;

namespace iTradex.UI.Report
{
    public class IpoInformationLoader
    {
        ReportDocument oIpoInformation = new ReportDocument();

        GetSession session = new GetSession();



        public IpoInformationLoader(ReportDocument _oIpoInformation)
        {
            oIpoInformation = _oIpoInformation;
        }

        public ReportDocument GetReportSource()
        {
            try
            {


                SqlConnection sconTransaction = DatabaseConnection.GetConnection();
                SqlCommand command = new SqlCommand("GetInvestorInformation", sconTransaction);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@AccountNumber", SqlDbType.VarChar).Value = session.AccountNumber;
                string accou = session.AccountNumber;

                sconTransaction.Close();
                SqlDataAdapter sdaIpoInformation = new SqlDataAdapter(command);
                DataTable dtIpoInformation = new DataTable();
                sdaIpoInformation.Fill(dtIpoInformation);

                DataColumn newColumn=new DataColumn();
                newColumn.ColumnName="ApplicantCategory";
                newColumn.DefaultValue = "Resident";
                dtIpoInformation.Columns.Add(newColumn);

               

                oIpoInformation.SetDataSource(dtIpoInformation);

                SetReportParameters();

                if (HttpContext.Current.Session["Id"].ToString() == "NRB")
                {


                    if (dtIpoInformation.Rows.Count > 0)
                    {
                        string numbers = dtIpoInformation.Rows[0]["BONumber"].ToString();
                        char[] array = numbers.ToCharArray();

                        string sa = array[0].ToString();

                        oIpoInformation.SetParameterValue("BONumber1", array[0].ToString());
                        oIpoInformation.SetParameterValue("BONumber2", array[1].ToString());
                        oIpoInformation.SetParameterValue("BONumber3", array[2].ToString());
                        oIpoInformation.SetParameterValue("BONumber4", array[3].ToString());
                        oIpoInformation.SetParameterValue("BONumber5", array[4].ToString());
                        oIpoInformation.SetParameterValue("BONumber6", array[5].ToString());
                        oIpoInformation.SetParameterValue("BONumber7", array[6].ToString());
                        oIpoInformation.SetParameterValue("BONumber8", array[7].ToString());
                        oIpoInformation.SetParameterValue("BONumber9", array[8].ToString());
                        oIpoInformation.SetParameterValue("BONumber10", array[9].ToString());
                        oIpoInformation.SetParameterValue("BONumber11", array[10].ToString());
                        oIpoInformation.SetParameterValue("BONumber12", array[11].ToString());
                        oIpoInformation.SetParameterValue("BONumber13", array[12].ToString());
                        oIpoInformation.SetParameterValue("BONumber14", array[13].ToString());
                        oIpoInformation.SetParameterValue("BONumber15", array[14].ToString());
                        oIpoInformation.SetParameterValue("BONumber16", array[15].ToString());


                    }
                
                }






                return oIpoInformation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void SetReportParameters()
        {


            try
            {
                string companyName = HttpContext.Current.Session["CompanyName"].ToString();
                string NumberOfShare = HttpContext.Current.Session["NoOfShares"].ToString();
                string buyRate = HttpContext.Current.Session["BuyRate"].ToString();
                string id = HttpContext.Current.Session["Id"].ToString();
                string[] brokerAddress;
                string formFor = "";
             
                 if (id == "RB")
                {
                    formFor = "APPLICATION FOR RESIDENT BANGLADESHI(S)";
                }

                 if (id == "ASI")
                 {
                     formFor = "APPLICATION FOR AFFECTED SMALL INVESTORS";
                 
                 }
              

                //string declarationDate = HttpContext.Current.Session["DeclarationDate"].ToString();
                string expireDate = HttpContext.Current.Session["ExpireDate"].ToString();
                CommonFunction cmDataTable = new CommonFunction();
                string query = "select CompanyName,AddressLine1,AddressLine2,NumberOfShare,City,Country,PostCode,Telephone,Fax,BuyRate from IPODeclaration where CompanyName='" + companyName + "' and NumberOfShare='" + NumberOfShare + "' and BuyRate='" + buyRate + "'  and ExpireDate='" + expireDate + "' ";
                DataTable dtIpoInformation = cmDataTable.GetDatatable(query);
                if (dtIpoInformation.Rows.Count > 0)
                {

                    if (id == "NRB")
                    {
                        oIpoInformation.SetParameterValue("CompanyName", dtIpoInformation.Rows[0]["CompanyName"].ToString());
                    }

                    else
                    {
                        oIpoInformation.SetParameterValue("IPOCompanyName", dtIpoInformation.Rows[0]["CompanyName"].ToString());
                    }
                   
                    oIpoInformation.SetParameterValue("AddressLine1", dtIpoInformation.Rows[0]["AddressLine1"].ToString());
                    oIpoInformation.SetParameterValue("AddressLine2", dtIpoInformation.Rows[0]["AddressLine2"].ToString());
                    oIpoInformation.SetParameterValue("City", dtIpoInformation.Rows[0]["City"].ToString());
                    oIpoInformation.SetParameterValue("NumberOfShare", dtIpoInformation.Rows[0]["NumberOfShare"].ToString());
                    oIpoInformation.SetParameterValue("Country", dtIpoInformation.Rows[0]["Country"].ToString());
                    oIpoInformation.SetParameterValue("PostCode", dtIpoInformation.Rows[0]["PostCode"].ToString());
                    oIpoInformation.SetParameterValue("Telephone", dtIpoInformation.Rows[0]["Telephone"].ToString());
                    oIpoInformation.SetParameterValue("Fax", dtIpoInformation.Rows[0]["Fax"].ToString());

                    oIpoInformation.SetParameterValue("BuyRate", string.Format("{0:###,###,0.00}", Convert.ToDouble(dtIpoInformation.Rows[0]["BuyRate"].ToString())));

                    oIpoInformation.SetParameterValue("formFor", formFor);
                }

                dtIpoInformation.Columns.Add("TotalAmount", typeof(decimal));

                //dt.Columns.Add(new DataColumn(columnName = "Balance", dataType = typeof (decimal)));

                foreach (DataRow dr in dtIpoInformation.Rows)
                {
                    double total = 0;
                    total = total + (Double.Parse(dr["NumberOfShare"].ToString()) * Double.Parse(dr["BuyRate"].ToString()));
                    dr["TotalAmount"] = total.ToString();
                    oIpoInformation.SetParameterValue("TotalAmount", string.Format("{0:###,###,0.00}", Convert.ToDouble(dtIpoInformation.Rows[0]["TotalAmount"].ToString())));
                }


                if (id != "NRB")
                {
                    CommonFunction cmdDataTable = new CommonFunction();
                    string company = "select BrokerName,Address,Telephone,Web,Email from Broker where email='itradex@mikasecurities.net'";
                    DataTable dtCompanyName = cmDataTable.GetDatatable(company);

                    if (dtCompanyName.Rows.Count > 0)
                    {

                        oIpoInformation.SetParameterValue("CompanyName", dtCompanyName.Rows[0]["BrokerName"].ToString());
                        oIpoInformation.SetParameterValue("BrokerAddress", dtCompanyName.Rows[0]["Address"].ToString());
                        oIpoInformation.SetParameterValue("BrokerTelephone", dtCompanyName.Rows[0]["Telephone"].ToString());
                        oIpoInformation.SetParameterValue("BrokerWeb", dtCompanyName.Rows[0]["Web"].ToString());
                        oIpoInformation.SetParameterValue("BrokerEmail", dtCompanyName.Rows[0]["Email"].ToString());

                        brokerAddress = cmdDataTable.GetAddress(dtCompanyName.Rows[0]["Address"].ToString());
                        oIpoInformation.SetParameterValue("BrokerAddressLine1", brokerAddress[0].ToString());
                        oIpoInformation.SetParameterValue("BrokerAddressLine2", brokerAddress[1].ToString());
                        oIpoInformation.SetParameterValue("BrokerAddressLine3", brokerAddress[2].ToString());
                    }

                
                }
          
                
                oIpoInformation.SetParameterValue("ReportTitle", "Ipo Information");
                //oIpoInformation.SetParameterValue("@AccountNumber", session.AccountNumber);
                //oInvestorLedgerStatement.SetParameterValue("period", "Period : " + fromDate + " To " + toDate);

                //oInvestorLedgerStatement.SetParameterValue("Investor", session.AccountNumber + " : " + accountName);
                //Add dictionary
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }




    }
}