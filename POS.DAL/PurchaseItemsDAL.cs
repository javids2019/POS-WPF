using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entities;
using POS.Model;

namespace POS.DAL
{
    public class PurchaseItemsDAL
    {

        public bool Insert(PurchaseDetail details)
        {
            bool IsValid = true;
            try
            {

                var db = new PetaPoco.Database(Constants.POSConnectionString);
                db.Insert(Constants.purchasedetail, Constants.PurchaseDetailsID, true, details);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                IsValid = false;
            }
            return IsValid;
        }

        public bool Update(PurchaseDetail details)
        {
            bool IsValid = true;
            try
            {
                var db = new PetaPoco.Database(Constants.POSConnectionString);
                db.Update(Constants.purchasedetail, Constants.PurchaseDetailsID, details);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                IsValid = false;
            }
            return IsValid;
        }

        public bool Delete(int id)
        {
            bool IsValid = true;
            try
            {
                var db = new PetaPoco.Database(Constants.POSConnectionString);
                db.Delete(Constants.purchasedetail, Constants.PurchaseDetailsID, null, id);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                IsValid = false;
            }
            return IsValid;
        }

        public IEnumerable<PurchaseDetail> GetAllpurchasedetail()
        {
            var sql = PetaPoco.Sql.Builder.Append("SELECT * FROM purchasedetails WHERE isActive=1");
            var db = new PetaPoco.Database(Constants.POSConnectionString);
            return db.Query<PurchaseDetail>(sql);
        }

    }
}
