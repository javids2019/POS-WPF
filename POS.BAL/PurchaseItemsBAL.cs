using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Entities;
using POS.Model;

namespace POS.BAL
{
    public class PurchaseItemsBAL
    {
        POS.DAL.PurchaseItemsDAL DAL = null;

        public PurchaseItemsBAL()
        {
            DAL = new DAL.PurchaseItemsDAL();
        }

        public IEnumerable<PurchaseDetail> GetAllpurchasedetail()
        {
            return DAL.GetAllpurchasedetail();
        }

        public bool Insert(PurchaseDetail details)
        {
            return DAL.Insert(details);
        }

        public bool Update(PurchaseDetail details)
        {
            return DAL.Update(details);
        }

        public bool Delete(int id)
        {
            return DAL.Delete(id);
        }
    }
}
