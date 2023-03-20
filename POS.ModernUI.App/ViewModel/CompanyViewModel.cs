using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFloor.ModernUI.ViewModel
{
    public class CompanyMasterViewModel
        : NotifyPropertyChanged, IDataErrorInfo
    {
        private string companyname;

        public string CompanyName
        {
            get { return this.companyname; }
            set
            {
                if (this.companyname != value)
                {
                    this.companyname = value;
                    OnPropertyChanged("CompanyName");
                }
            }
        }
        private string description;
        public string Description
        {
            get { return this.description; }
            set
            {
                if (this.description != value)
                {
                    this.description = value;
                    OnPropertyChanged("Description");
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

                if (columnName == "CompanyName")
                {
                    return "Required value";
                }
                if (columnName == "Description")
                {
                    return "Required value";
                }

                return null;
            }
        }
    }
}
