using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;

namespace POS.BAL
{
    public class CompanyBAL
    {
        POS.DAL.CompanyDAL DAL = null;

        public CompanyBAL()
        {
            DAL = new DAL.CompanyDAL();
        }

        public IEnumerable<CompanyDetail> GetAllCompanyDetails()
        {
            return DAL.GetAllCompanydetail();
        }

        public bool Insert(CompanyDetail company)
        {
            return DAL.Insert(company);
        }

        public bool Update(CompanyDetail company)
        {
            return DAL.Update(company);
        }

        public bool Delete(int id)
        {
            return DAL.Delete(id);
        }
    }
}
