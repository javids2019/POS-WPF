using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entities;
using POS.Model;

namespace POS.DAL
{
    public class SalesDAL
    {

        public bool Insert(SalesMaster details, List<StockItems> stocklist)
        {
            bool IsValid = true;
            var db = new PetaPoco.Database(Constants.POSConnectionString);
            try
            {
                db.BeginTransaction();
                db.Insert(Constants.possalesmaster, Constants.POSSalesMasterID, true, details);
                foreach (var item in stocklist)
                {
                    PurchaseDetail purdetails = db.SingleOrDefault<PurchaseDetail>("SELECT * FROM purchasedetails WHERE PurchaseDetailsID=@0", item.PurchaseDetailsID);
                    SalesDetail sales = new SalesDetail();
                    sales.Barcode = purdetails.Barcode;
                    sales.BuyingPrice = purdetails.BuyingPrice;
                    sales.CreatedBy = purdetails.CreatedBy;
                    sales.CreatedDate = purdetails.CreatedDate;
                    sales.Description = purdetails.Description;
                    sales.IsActive = purdetails.IsActive;
                    sales.ItemCode = purdetails.ItemCode;
                    sales.ItemExpiryDate = purdetails.ItemExpiryDate;
                    sales.ItemName = purdetails.ItemName;
                    sales.PurchaseBillNo = purdetails.PurchaseBillNo;
                    sales.PurchaseID =Convert.ToInt32(purdetails.PurchaseID);

                    sales.ReOrderLevel = purdetails.ReOrderLevel;
                    sales.SellingPrice = purdetails.SellingPrice;
                    sales.SubCategoryID = purdetails.SubCategoryID;
                    sales.CategoryID = purdetails.CategoryID;
                    sales.SubType = purdetails.SubType;
                    sales.Tax = purdetails.Tax;
                    sales.Type = purdetails.Type;
                    sales.Quantity = item.Quantity;
                    sales.SalesMasterID =Convert.ToInt32(details.POSSalesMasterID);
                    // db = new PetaPoco.Database(Constants.POSConnectionString);
                    db.Insert(Constants.salesdetails, Constants.SalesDetailsID, true, sales);

                    //update stock
                    int? qty = purdetails.Quantity - item.Quantity;
                    //UpdateStock(purdetails.PurchaseDetailsID, qty, db);

                    db.Execute("Update PurchaseDetails SET Quantity=@0,ModifiedDate=@1,ModifiedBy=@2,IsActive=1 WHERE PurchaseDetailsID=@3",
                    qty, DateTime.Now, Utility.UserID, purdetails.PurchaseDetailsID);

                }

                db.CompleteTransaction();
            }
            catch (Exception ex)
            {
                db.AbortTransaction();
                LogHelper.LogException(ex);
                throw ex;
                IsValid = false;
            }

            return IsValid;
        }


        private void UpdateStock(int PurchaseDetailsID, int? qty)
        {
            var db = new PetaPoco.Database(Constants.POSConnectionString);

        }

        public IEnumerable<SalesMaster> GetAllSalesMaster()
        {
            IEnumerable<SalesMaster> result = null;
            try
            {
                var sql = PetaPoco.Sql.Builder.Append("SELECT * FROM possalesmaster WHERE isActive=1");
                var db = new PetaPoco.Database(Constants.POSConnectionString);
                result = db.Query<SalesMaster>(sql);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
            }
            return result;
        }

        public IEnumerable<SalesDetail> GetAllSalesDetails()
        {
            var sql = PetaPoco.Sql.Builder.Append("SELECT * FROM salesdetail WHERE isActive=1");
            var db = new PetaPoco.Database(Constants.POSConnectionString);
            return db.Query<SalesDetail>(sql);
        }

    }
}
