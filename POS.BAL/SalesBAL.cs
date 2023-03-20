using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;
using POS.Entities;

namespace POS.BAL
{
    public class SalesBAL
    {
        POS.DAL.SalesDAL DAL = null;

        public SalesBAL()
        {
            DAL = new DAL.SalesDAL();
        }
       
        public bool Insert(SalesMaster details, List<StockItems> stocklist)
        {
            return DAL.Insert(details, stocklist);
        }

        public IEnumerable<SalesMaster> GetAllSalesMaster()
        {
            return DAL.GetAllSalesMaster();
        }

        public IEnumerable<SalesDetail> GetAllSalesDetails()
        {
            return DAL.GetAllSalesDetails();
        }
    }
}
