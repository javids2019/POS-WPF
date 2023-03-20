using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entities;
using POS.Model;

namespace POS.DAL
{
    public class LookupDAL
    {


        public bool InsertSubCategory(SubCategory details)
        {
            bool IsValid = true;
            try
            {

                var db = new PetaPoco.Database(Constants.POSConnectionString);
                db.Insert("SubCategory", "SubCategoryID", true, details);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                IsValid = false;
            }
            return IsValid;
        }

        public bool UpdateSubCategory(SubCategory details)
        {
            bool IsValid = true;
            try
            {

                var db = new PetaPoco.Database(Constants.POSConnectionString);
                db.Update("SubCategory", "SubCategoryID", details);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                IsValid = false;
            }
            return IsValid;
        }

        public bool InsertCategory(category details)
        {
            bool IsValid = true;
            try
            {

                var db = new PetaPoco.Database(Constants.POSConnectionString);
                db.Insert("category", "CategoryID", true, details);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                IsValid = false;
            }
            return IsValid;
        }

        public bool UpdateCategory(category details)
        {
            bool IsValid = true;
            try
            {
                var db = new PetaPoco.Database(Constants.POSConnectionString);
                db.Update("category", "CategoryID", details);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                IsValid = false;
            }
            return IsValid;
        }

        public bool InsertType(SubCategoryType details)
        {
            bool IsValid = true;
            try
            {

                var db = new PetaPoco.Database(Constants.POSConnectionString);
                db.Insert("SubCategoryType", "TypeID",true, details);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                IsValid = false;
            }
            return IsValid;
        }

        public bool UpdateType(SubCategoryType details)
        {
            bool IsValid = true;
            try
            {
                var db = new PetaPoco.Database(Constants.POSConnectionString);
                db.Update("SubCategoryType", "TypeID", details);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                IsValid = false;
            }
            return IsValid;
        }
        public bool InsertSubType(SubType details)
        {
            bool IsValid = true;
            try
            {

                var db = new PetaPoco.Database(Constants.POSConnectionString);
                db.Insert("SubType", "SubTypeID", true, details);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                IsValid = false;
            }
            return IsValid;
        }

        public bool UpdateSubType(SubType details)
        {
            bool IsValid = true;
            try
            {
                var db = new PetaPoco.Database(Constants.POSConnectionString);
                db.Update("SubType", "SubTypeID", details);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                IsValid = false;
            }
            return IsValid;
        }
        public bool DeleteCategory(int id)
        {
            bool IsValid = true;
            try
            {
                var db = new PetaPoco.Database(Constants.POSConnectionString);
                db.Delete("Category", "CategoryID", null, id);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                IsValid = false;
            }
            return IsValid;
        }

        public bool DeleteType(int id)
        {
            bool IsValid = true;
            try
            {
                var db = new PetaPoco.Database(Constants.POSConnectionString);
                db.Delete("SubCategoryType", "TypeID", null, id);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                IsValid = false;
            }
            return IsValid;
        }

        public bool DeleteSubType(int id)
        {
            bool IsValid = true;
            try
            {
                var db = new PetaPoco.Database(Constants.POSConnectionString);
                db.Delete("SubType", "SubTypeID", null, id);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                IsValid = false;
            }
            return IsValid;
        }

        public bool DeleteSubCategory(int id)
        {
            bool IsValid = true;
            try
            {
                var db = new PetaPoco.Database(Constants.POSConnectionString);
                db.Delete("SubCategory", "SubCategoryID", null, id);
            }
            catch (Exception ex)
            {
                LogHelper.LogException(ex);
                IsValid = false;
            }
            return IsValid;
        }

        public IEnumerable<category> GetAllCategory()
        {
            var sql = PetaPoco.Sql.Builder.Append("SELECT * FROM category WHERE isActive=1");
            var db = new PetaPoco.Database(Constants.POSConnectionString);
            return db.Query<category>(sql);
        }

        public IEnumerable<SubCategory> GetAllSubCategory()
        {
            var sql = PetaPoco.Sql.Builder.Append("SELECT * FROM SubCategory WHERE isActive=1");
            var db = new PetaPoco.Database(Constants.POSConnectionString);
            return db.Query<SubCategory>(sql);
        }

        public IEnumerable<SubCategoryType> GetAllType()
        {
            var sql = PetaPoco.Sql.Builder.Append("SELECT * FROM SubCategoryType WHERE isActive=1");
            var db = new PetaPoco.Database(Constants.POSConnectionString);
            return db.Query<SubCategoryType>(sql);
        }

        public IEnumerable<SubType> GetAllSubType()
        {
            var sql = PetaPoco.Sql.Builder.Append("SELECT * FROM SubType WHERE isActive=1");
            var db = new PetaPoco.Database(Constants.POSConnectionString);
            return db.Query<SubType>(sql);
        }
    }
}
