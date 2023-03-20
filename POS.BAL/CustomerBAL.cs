using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Model;

namespace POS.BAL
{
    public class CustomerBAL
    {
        POS.DAL.CustomerDAL DAL = null;

        public CustomerBAL()
        {
            DAL = new DAL.CustomerDAL();
        }

        public IEnumerable<CustomerDetail> GetAll()
        {
            return DAL.GetAllCustomerDetails();
        }

        public bool Insert(CustomerDetail details)
        {
            return DAL.Insert(details);
        }

        public bool Update(CustomerDetail details)
        {
            return DAL.Update(details);
        }

        public bool Delete(int ID)
        {
            return DAL.Delete(ID);
        }
    }
}
