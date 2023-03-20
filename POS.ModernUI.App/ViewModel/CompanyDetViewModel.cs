using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFloor.ModernUI.ViewModel
{
    public class CompanyDetViewModel
        : NotifyPropertyChanged, IDataErrorInfo
    {
        private string companyName;


        public string CompanyName
        {
            get { return this.companyName; }
            set
            {
                if (this.companyName != value)
                {
                    this.companyName = value;
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

                if (columnName == "Description")
                {

                    return string.IsNullOrEmpty(this.Description) ? "Required value" : null;
                }
                if (columnName == "CompanyName")
                {

                    return string.IsNullOrEmpty(this.CompanyName) ? "Required value" : null;
                }
             
                return null;
            }
        }
    }
}
