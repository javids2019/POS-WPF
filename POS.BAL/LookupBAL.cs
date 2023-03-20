using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entities;
using POS.Model;

namespace POS.BAL
{
    public class LookupBAL
    {
        POS.DAL.LookupDAL DAL = null;

        public LookupBAL()
        {
            DAL = new DAL.LookupDAL();
        }

        public IEnumerable<category> GetAllCategory()
        {
            return DAL.GetAllCategory();
        }

        public IEnumerable<SubCategory> GetAllSubCategory()
        {
            return DAL.GetAllSubCategory();
        }
        public IEnumerable<SubCategoryType> GetAllType()
        {
            return DAL.GetAllType();
        }

        public IEnumerable<SubType> GetAllSubType()
        {
            return DAL.GetAllSubType();
        }
      
        public bool DeleteCategory(int id)
        {
            return DAL.DeleteCategory(id);
        }

        public bool DeleteSubCategory(int id)
        {
            return DAL.DeleteSubCategory(id);
        }

        public bool DeleteType(int id)
        {
            return DAL.DeleteType(id);
        }

        public bool DeleteSubType(int id)
        {
            return DAL.DeleteSubType(id);
        }

        public bool InsertSubCategory(SubCategory det)
        {
            return DAL.InsertSubCategory(det);
        }

        public bool UpdateSubCategory(SubCategory det)
        {
            return DAL.UpdateSubCategory(det);
        }

        public bool InsertCategory(category categorydet)
        {
            return DAL.InsertCategory(categorydet);
        }

        public bool UpdateCategory(category categorydet)
        {
            return DAL.UpdateCategory(categorydet);
        }
        public bool InsertType(SubCategoryType details)
        {
            return DAL.InsertType(details);
        }

        public bool UpdateType(SubCategoryType categorydet)
        {
            return DAL.UpdateType(categorydet);
        }

        public bool InsertSubType(SubType details)
        {
            return DAL.InsertSubType(details);
        }

        public bool UpdateSubType(SubType categorydet)
        {
            return DAL.UpdateSubType(categorydet);
        }
        
    }
}
