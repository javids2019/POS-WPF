using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFloor.ModernUI.ViewModel
{
    public class StockSalesViewModel
        : NotifyPropertyChanged, IDataErrorInfo
    {
        private int quantity = 1;


        public int Quantity
        {
            get { return this.quantity; }
            set
            {
                if (this.quantity != value)
                {
                    this.quantity = value;
                    OnPropertyChanged("Quantity");
                }
            }
        }




        public string Error
        {
            get { return null; }
        }


        public string this[string columnName]
        {
            get
            {

                if (columnName == "Quantity")
                {
                    return "Required value";
                }

                return null;
            }
        }
    }
}
