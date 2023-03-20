using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entities;
using POS.Model;

namespace POS.DAL
{
    public class CompanyDAL
    {

        public bool Insert(CompanyDetail details)
        {
            bool IsValid = true;
            try
            {
                var db = new PetaPoco.Database(Constants.POSConnectionString);
                db.Insert(Constants.companydetail, Constants.CompanyID, true, details);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                IsValid = false;
            }
            return IsValid;
        }

        public bool Update(CompanyDetail details)
        {
            bool IsValid = true;
            try
            {
                var db = new PetaPoco.Database(Constants.POSConnectionString);
                db.Update(Constants.companydetail, Constants.CompanyID, details);
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
                db.Delete(Constants.companydetail, Constants.CompanyID, null, id);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                IsValid = false;
            }
            return IsValid;
        }


        public IEnumerable<CompanyDetail> GetAllCompanydetail()
        {
            var sql = PetaPoco.Sql.Builder.Append("SELECT * FROM companydetails WHERE isActive=@0", 1);
            var db = new PetaPoco.Database(Constants.POSConnectionString);
            return db.Query<CompanyDetail>(sql);
        }

    }
}
