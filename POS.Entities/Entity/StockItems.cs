using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace POS.Model
{
    public class StockItems
    {
        public int ID { get; set; }
        public int PurchaseDetailsID { get; set; }
        public string Description { get; set; }
        public decimal? SellingPrice { get; set; }
        public int? Quantity { get; set; }
    }

    public class POSStockItems
    {
        public SalesMaster salesmaster;
        public List<SalesDetail> salesList;
    }
}
