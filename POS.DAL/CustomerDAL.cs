using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entities;
using POS.Model;

namespace POS.DAL
{
    public class CustomerDAL
    {

        public bool Insert(CustomerDetail details)
        {
            bool IsValid = true;
            try
            {
                var db = new PetaPoco.Database(Constants.POSConnectionString);
                db.Insert(Constants.customerdetail, Constants.CustomerDetailsID, true, details);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                IsValid = false;
            }
            return IsValid;
        }

        public bool Update(CustomerDetail details)
        {
            bool IsValid = true;
            try
            {
                var db = new PetaPoco.Database(Constants.POSConnectionString);
                db.Insert(Constants.customerdetail, Constants.CustomerDetailsID, details);
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
                db.Delete(Constants.customerdetail, Constants.CustomerDetailsID, null, id);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                IsValid = false;
            }
            return IsValid;
        }


        public IEnumerable<CustomerDetail> GetAllCustomerDetails()
        {
            var sql = PetaPoco.Sql.Builder.Append("SELECT * FROM customerdetails WHERE isActive=1");
            var db = new PetaPoco.Database(Constants.POSConnectionString);
            return db.Query<CustomerDetail>(sql);
        }

    }
}
