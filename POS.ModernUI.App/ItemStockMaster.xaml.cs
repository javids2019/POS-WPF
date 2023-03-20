using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using POS.Entities;
using POS.Model;

namespace FirstFloor.ModernUI.App
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ItemStockMaster : UserControl
    {
        POS.BAL.CompanyBAL companybal = new POS.BAL.CompanyBAL();
        POS.BAL.PurchaseItemsBAL purchasebal = new POS.BAL.PurchaseItemsBAL();
        POS.BAL.LookupBAL lookup = new POS.BAL.LookupBAL();
        IEnumerable<PurchaseDetail> detailslist = null;

        int PurchaseDetailID = 0;
        public ItemStockMaster()
        {
            InitializeComponent();
            Clear();
        }

        private void cmbPurchasefrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbPurchasefrom.Text))
            {
                var companylist = companybal.GetAllCompanyDetails();
                int count = (from x in companylist where x.CompanyName == cmbPurchasefrom.Text.Trim() select x).Count();
                if (count > 0)
                {
                    CompanyDetail companydetails = (from x in companylist where x.CompanyName == cmbPurchasefrom.Text.Trim() select x).FirstOrDefault();
                    txtadress.Text = companydetails.Address;
                    txtContactNo.Text = companydetails.ContactNo;
                }
            }
        }


        private bool IsValid()
        {
            bool isflag = true;
            if (string.IsNullOrWhiteSpace(txtPurchasebillno.Text))
            {
                txtPurchasebillno.Focus();
                isflag = false;
            }
            else if (string.IsNullOrWhiteSpace(cmbPurchasefrom.Text))
            {
                cmbPurchasefrom.Focus();
                isflag = false;
            }
            else if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                txtItemName.Focus();
                isflag = false;
            }
            else if (string.IsNullOrWhiteSpace(txtItemCode.Text))
            {
                txtItemCode.Focus();
                isflag = false;
            }
            else if (string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                txtQuantity.Focus();
                isflag = false;
            }
            else if (string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                cmbCategory.Focus();
                isflag = false;
            }
            else if (string.IsNullOrWhiteSpace(cmbSubCategory.Text))
            {
                cmbSubCategory.Focus();
                isflag = false;
            }

            return isflag;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var ID = ((Button)sender).CommandParameter;
            bool isDelete = purchasebal.Delete(Convert.ToInt32(ID));
            Clear();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var ID = ((Button)sender).CommandParameter;

            PurchaseDetail details = purchasebal.GetAllpurchasedetail().Where(x => x.PurchaseDetailsID == Convert.ToInt32(ID)).FirstOrDefault();

            cmbPurchasefrom_SelectionChanged(null, null);
            txtPurchasebillno.Text = details.PurchaseBillNo;
            cmbPurchasefrom.SelectedIndex = 0;
            txtItemBarcode.Text = details.Barcode;
            txtItemCode.Text = details.ItemCode;
            PurchaseDetailID = Convert.ToInt32(ID);

            txtBuyingPrice.Text = details.BuyingPrice.ToString();
            txtItemDescription.Text = details.Description;
            dtExpirydate.SelectedDate = details.ItemExpiryDate;
            txtItemName.Text = details.ItemName;
            txtQuantity.Text = details.Quantity.ToString();
            txtReOrderLevel.Text = details.ReOrderLevel.ToString();
            txtSellingPrice.Text = details.SellingPrice.ToString();
            //cmbSubCategory.Text = details.SubCategory;
            cmbSubType.Text = details.SubType;
            cmbType.Text = details.Type;
            TypeDropdownSelect(false);

            btnAddItems.Content = "Update";
            IEnumerable<category> categoryList = lookup.GetAllCategory().ToList();
            IEnumerable<SubCategory> subcategoryList = lookup.GetAllSubCategory().ToList().Where(x => x.CategoryID == (Convert.ToInt32(details.CategoryID)));

            IEnumerable<SubCategoryType> typeList = lookup.GetAllType().ToList().Where(x => x.Type == details.Type);
            IEnumerable<SubType> subtypeList = lookup.GetAllSubType().ToList().Where(x => x._SubType == details.SubType);


            // IEnumerable<SubCategory> subcategoryList = lookup.GetAllSubCategory(Convert.ToInt32(details.CategoryID)).ToList();

            cmbCategory.ItemsSource = (from x in categoryList select new { x.CategoryID, x.Category }).ToList();

            if (details.CategoryID != 0)
            {
                cmbCategory.SelectedValue = details.CategoryID;
            }

            cmbSubCategory.ItemsSource = (from x in subcategoryList
                                          select new { x.SubCategoryID, x.SubCategoryName }).ToList();
            if (details.SubCategoryID != 0)
            {
                cmbSubCategory.SelectedValue = details.SubCategoryID;
            }
            CompanyDetail companydetails = (from x in companybal.GetAllCompanyDetails()
                                            where x.CompanyID
                                                == details.PurchaseID
                                            select x).FirstOrDefault();
            // Type
            var listtype = (from x in typeList
                        select new { x.TypeID, x.Type }).ToList();

            cmbType.ItemsSource = listtype;
            cmbType.SelectedIndex = 0;


           

            if (cmbType.Text == "Nos")
            {
                lblSubType.IsEnabled = false;
                cmbSubType.IsEnabled = false;
                lblSubType.Content = "";

            }
            else
            {
                lblSubType.IsEnabled = true;
                cmbSubType.IsEnabled = true;
                lblSubType.Content = cmbType.Text;
            }

            if (details.Type != "Nos")
            {
                var subcategorydetails = lookup.GetAllSubType().ToList().Where(x => x.TypeID == (Convert.ToInt32(cmbType.SelectedValue)));
                var list = (from x in subcategorydetails
                            select new { x.SubTypeID, x._SubType }).ToList();

                cmbSubType.ItemsSource = list;
            }
            else
            {
                cmbSubType.ItemsSource = null;
            }
            // Sub Type
            var sublist = (from x in subtypeList
                           select new { x.TypeID, x.Type }).FirstOrDefault();

            cmbSubType.SelectedItem = sublist;
        }


        private void btnAddItems_Click(object sender, RoutedEventArgs e)
        {

            if (IsValid())
            {
                PurchaseDetail detail = new PurchaseDetail();
                detail.CreatedBy = Utility.UserID;
                detail.CreatedDate = DateTime.Now;
                detail.PurchaseBillNo = txtPurchasebillno.Text.Trim();
                detail.PurchaseID = cmbPurchasefrom.SelectedIndex;
                detail.Barcode = txtItemBarcode.Text.Trim() != string.Empty ? txtItemBarcode.Text.Trim() : string.Empty;
                detail.BuyingPrice = txtBuyingPrice.Text.Trim() != string.Empty ? Convert.ToDecimal(txtBuyingPrice.Text.Trim()) : 0;
                detail.Description = txtItemDescription.Text.Trim();
                detail.Category = cmbCategory.Text;
                detail.SubCategory = cmbSubCategory.Text;
                detail.ItemExpiryDate = dtExpirydate.SelectedDate;
                detail.ItemCode = txtItemCode.Text.Trim() != string.Empty ? txtItemCode.Text.Trim() : null;
                detail.ItemName = txtItemName.Text.Trim() != string.Empty ? txtItemName.Text.Trim() : null;
                detail.Quantity = txtQuantity.Text.Trim() != string.Empty ? Convert.ToInt32(txtQuantity.Text.Trim()) : 0;
                detail.ReOrderLevel = txtReOrderLevel.Text.Trim() != string.Empty ? Convert.ToInt32(txtReOrderLevel.Text) : 0;
                detail.SellingPrice = txtSellingPrice.Text.Trim() != string.Empty ? Convert.ToDecimal(txtSellingPrice.Text) : 0;
                if (!string.IsNullOrWhiteSpace(cmbSubCategory.SelectedValue.ToString()))
                    detail.SubCategoryID = Convert.ToInt32(cmbSubCategory.SelectedValue);

                if (!string.IsNullOrWhiteSpace(cmbCategory.SelectedValue.ToString()))
                    detail.CategoryID = Convert.ToInt32(cmbCategory.SelectedValue);

                detail.IsActive = 1;
                detail.SubType = cmbSubType.Text.Trim() != string.Empty ? cmbSubType.Text.Trim() : null;
                //detail.Tax = txt.Text.Trim();
                detail.Type = cmbType.Text.Trim() != string.Empty ? cmbType.Text.Trim() : string.Empty;

                if (btnAddItems.Content == "Update")
                {
                    detail.PurchaseDetailsID = PurchaseDetailID;
                    purchasebal.Update(detail);
                }
                else
                {
                    //New
                    purchasebal.Insert(detail);
                }

                Clear();
            }
        }

        private void Clear()
        {
            txtadress.Text = string.Empty;
            txtContactNo.Text = string.Empty;
            btnAddItems.Content = "Add Stock Items";
            txtPurchasebillno.Text = string.Empty;
            cmbPurchasefrom.SelectedIndex = 0;
            txtItemBarcode.Text = string.Empty;
            txtItemCode.Text = string.Empty;
            txtItemCode.IsEnabled = false;
            txtBuyingPrice.Text = string.Empty;
            dtExpirydate.Text = string.Empty;
            txtItemName.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtReOrderLevel.Text = string.Empty;
            txtSellingPrice.Text = string.Empty;
            cmbSubCategory.Text = string.Empty;
            cmbSubType.Text = string.Empty;
            cmbCategory.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;
            txtadress.Text = "";
            cmbPurchasefrom_SelectionChanged(null, null);
            TypeDropdownSelect(false);
            txtItemDescription.Text = string.Empty;

            // Type
            IEnumerable<SubCategoryType> typedetails = lookup.GetAllType().ToList();
            var typelist = (from x in typedetails
                            select new { x.TypeID, x.Type }).ToList();

            cmbType.ItemsSource = typelist;
            cmbType.SelectedIndex = 0;


            //Purchase Master Details
            IEnumerable<CompanyDetail> companydetails = companybal.GetAllCompanyDetails().ToList();
            cmbPurchasefrom.ItemsSource = (from x in companydetails select new { x.CompanyName, x.CompanyID }).ToList();

            //Category
            IEnumerable<category> categorydetails = lookup.GetAllCategory().ToList();

            var catlist = (from x in categorydetails
                           select new { x.CategoryID, x.Category }).ToList();
            category obj = new category();
            cmbCategory.ItemsSource = catlist;
            cmbCategory.SelectedIndex = 0;

            // Sub Category
            if (catlist.Count() > 0)
            {
                IEnumerable<SubCategory> subcategorydetails = lookup.GetAllSubCategory().ToList().Where(x => x.CategoryID == (Convert.ToInt32(cmbCategory.SelectedValue)));

                //IEnumerable<SubCategory> subcategorydetails = lookup.GetAllSubCategory(Convert.ToInt32(cmbCategory.SelectedValue)).ToList();
                var list = (from x in subcategorydetails
                            select new { x.SubCategoryID, x.SubCategoryName }).ToList();

                cmbSubCategory.ItemsSource = list;
                cmbSubCategory.SelectedIndex = 0;
            }

            TypeDropdownSelect(true);
            IEnumerable<PurchaseDetail> detailslist = purchasebal.GetAllpurchasedetail().ToList();
            gridPurchaseItems.DataContext = detailslist;
        }

        private void txtItemName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtItemName.Text.Trim()))
                BindItemCode();
            BuildItemDescription();
        }
        public void BindItemCode()
        {
            if (btnAddItems.Content != "Update")
            {
                string strItemName = txtItemName.Text.Replace(" ", "").Trim();
                string strItemcode = string.Empty;
                if (strItemName.Length > 6)
                {
                    strItemName = strItemName.Substring(0, 6);
                    strItemcode = strItemName.ToUpper() + "_" + "1";
                }
                else
                {
                    strItemcode = strItemName.ToUpper() + "_" + "1";
                }

                var detailslists = (IEnumerable<PurchaseDetail>)gridPurchaseItems.DataContext;
                int itemCount = (from x in detailslists where x.ItemCode == strItemcode select x).Count();

                if (itemCount > 0)
                {
                    string[] splititemcode = strItemcode.Split('_');
                    if (splititemcode.Count() == 2)
                    {
                        int value = Convert.ToInt32(splititemcode[1]) + 1;
                        strItemcode = splititemcode[0] + "_" + value.ToString();
                    }
                }

                txtItemCode.Text = strItemcode.Trim().ToUpper();
            }
        }

        private void cmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbCategory_DropDownClosed(object sender, EventArgs e)
        {
            IEnumerable<SubCategory> subcategorydetails = lookup.GetAllSubCategory().ToList().Where(x => x.CategoryID == (Convert.ToInt32(cmbCategory.SelectedValue)));
            //IEnumerable<SubCategory> subcategorydetails = lookup.GetAllSubCategory(Convert.ToInt32(cmbCategory.SelectedValue) ).ToList();
            var list = (from x in subcategorydetails
                        select new { x.SubCategoryID, x.SubCategoryName }).ToList();

            cmbSubCategory.ItemsSource = list;
            cmbSubCategory.SelectedIndex = 0;
            TypeDropdownSelect(true);
        }

        private void cmbType_DropDownClosed(object sender, EventArgs e)
        {
            TypeDropdownSelect(true);
        }


        private void TypeDropdownSelect(bool IsFlag)
        {
            var details = lookup.GetAllSubCategory().ToList().Where(x => x.SubCategoryID == (Convert.ToInt32(cmbSubCategory.SelectedValue))).FirstOrDefault();
            if (details != null)
            {
                cmbType.SelectedValue = details.TypeID;
                if (details.Type != "Nos")
                {
                    var subcategorydetails = lookup.GetAllSubType().ToList().Where(x => x.TypeID == (Convert.ToInt32(cmbType.SelectedValue)));
                    var list = (from x in subcategorydetails
                                select new { x.SubTypeID, x._SubType }).ToList();

                    cmbSubType.ItemsSource = list;
                    cmbSubType.SelectedIndex = 0;
                }
                else
                {
                    cmbSubType.ItemsSource = null;
                }
            }

            if (cmbType.Text == "Nos")
            {
                lblSubType.IsEnabled = false;
                cmbSubType.IsEnabled = false;
                lblSubType.Content = "";
               
            }
            else
            {
                lblSubType.IsEnabled = true;
                cmbSubType.IsEnabled = true;
                lblSubType.Content = cmbType.Text;
            }


            if (IsFlag)
            {
                BuildItemDescription();
            }
        }


        private void BuildItemDescription()
        {
            string Description = string.Empty;

            if (!string.IsNullOrWhiteSpace(txtItemName.Text.Trim()))
            {
                Description += txtItemName.Text.Trim();
            }
            if (cmbCategory.Items.Count > 0)
            {
                if (!string.IsNullOrWhiteSpace(cmbCategory.Text.Trim()))
                    Description += " " + cmbCategory.Text.Trim();
            }
            if (cmbSubCategory.Items.Count > 0)
            {
                if (!string.IsNullOrWhiteSpace(cmbSubCategory.Text.Trim()))
                    Description += " " + cmbSubCategory.Text.Trim();
            }
            //if (cmbType.Items.Count > 0)
            //{
            //    if (!string.IsNullOrWhiteSpace(cmbType.Text.Trim()))
            //        Description += " " + cmbType.Text.Trim();
            //}
            if (cmbSubType.Items.Count > 0)
            {
                if (!string.IsNullOrWhiteSpace(cmbSubType.Text.Trim()))
                    Description += " " + cmbSubType.Text.Trim();
            }
            txtItemDescription.Text = Description;
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void cmbType_LostFocus(object sender, RoutedEventArgs e)
        {
            TypeDropdownSelect(true);
        }

        private void cmbSubCategory_DropDownClosed(object sender, EventArgs e)
        {
            TypeDropdownSelect(true);
        }
    }


}
