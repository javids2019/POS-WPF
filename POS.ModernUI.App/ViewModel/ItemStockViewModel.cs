using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFloor.ModernUI.ViewModel
{
    public class ItemStockViewModel
        : NotifyPropertyChanged, IDataErrorInfo
    {
        private string purchaseBillNo;


        public string PurchaseBillNo
        {
            get { return this.purchaseBillNo; }
            set
            {
                if (this.purchaseBillNo != value)
                {
                    this.purchaseBillNo = value;
                    OnPropertyChanged("PurchaseBillNo");
                }
            }
        }
        private string itemName;
        public string ItemName
        {
            get { return this.itemName; }
            set
            {
                if (this.itemName != value)
                {
                    this.itemName = value;
                    OnPropertyChanged("ItemName");
                }
            }
        }

        private string itemCode;
        public string ItemCode
        {
            get { return this.itemCode; }
            set
            {
                if (this.itemCode != value)
                {
                    this.itemCode = value;
                    OnPropertyChanged("ItemCode");
                }
            }
        }

        private string category;
        public string Category
        {
            get { return this.category; }
            set
            {
                if (this.category != value)
                {
                    this.category = value;
                    OnPropertyChanged("Category");
                }
            }
        }


        private string subCategory;
        public string SubCategory
        {
            get { return this.subCategory; }
            set
            {
                if (this.subCategory != value)
                {
                    this.subCategory = value;
                    OnPropertyChanged("SubCategory");
                }
            }
        }

        private string type;
        public string Type
        {
            get { return this.type; }
            set
            {
                if (this.type != value)
                {
                    this.type = value;
                    OnPropertyChanged("Type");
                }
            }
        }

        private int? quantity = null;
        public int? Quantity
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

                if (columnName == "PurchaseBillNo")
                {

                    return string.IsNullOrEmpty(this.PurchaseBillNo) ? "Required value" : null;
                }
                if (columnName == "ItemName")
                {

                    return string.IsNullOrEmpty(this.ItemName) ? "Required value" : null;
                }
                if (columnName == "ItemCode")
                {
                    return string.IsNullOrEmpty(this.ItemCode) ? "Required value" : null;
                }
                if (columnName == "Category")
                {
                    return string.IsNullOrEmpty(this.Category) ? "Required value" : null;
                }
                if (columnName == "Type")
                {
                    return string.IsNullOrEmpty(this.Type) ? "Required value" : null;
                }
                if (columnName == "SubType")
                {
                    //if (this.Type != "Nos")
                    return string.IsNullOrEmpty(this.Type) ? "Required value" : null;
                }
                if (columnName == "SubCategory")
                {
                    return string.IsNullOrEmpty(this.SubCategory) ? "Required value" : null;
                }
                if (columnName == "Quantity")
                {
                    return Convert.ToInt32(this.Quantity) == 0 ? "Required value" : null;
                }

                return null;
            }
        }
    }
}
