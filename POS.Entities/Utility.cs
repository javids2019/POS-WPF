using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Entities
{
    public class Utility
    {
        public static int UserID { get; set; }

        public static string UserName { get; set; }

        public Utility()
        {
            UserID = 1;
        }
        //        public static string UserName { get; set; }
    }


    public class Constants
    {
        public static string POSConnectionString = "POSConnectionString";
        public static string CustomerDetailsID = "CustomerDetailsID";
        public static string customerdetail = "customerdetails";
        public static string companydetail = "companydetails";
        public static string CompanyID = "CompanyID";
        public static string lookup = "lookup";
        public static string lookupid = "lookupid";
        public static string lookupdetails = "LookupDetails";
        public static string lookupdetailsid = "lookupdetailsid";
        public static string purchasedetail = "purchasedetails";
        public static string PurchaseDetailsID = "PurchaseDetailsID";

        public static string possalesmaster = "possalesmaster";
        public static string POSSalesMasterID = "POSSalesMasterID";
        public static string salesdetails = "salesdetails";
        public static string SalesDetailsID = "SalesDetailsID";
        
        

    }

    public enum LookupUtility
    {
        Category = 1,
        SubCategory = 2,



    }
}
