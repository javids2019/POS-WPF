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
    public partial class frmSubCategory : UserControl
    {
        POS.BAL.LookupBAL lookup = new POS.BAL.LookupBAL();

        public frmSubCategory()
        {
            InitializeComponent();
            Clear();
        }


        private bool IsValid()
        {
            bool isflag = true;
            if (string.IsNullOrWhiteSpace(txtSubCategory.Text))
            {
                txtSubCategory.Focus();
                isflag = false;
            }
            else if (string.IsNullOrWhiteSpace(CmbCategory.Text))
            {
                CmbCategory.Focus();
                isflag = false;
            }
            else if (string.IsNullOrWhiteSpace(CmbType.Text))
            {
                CmbType.Focus();
                isflag = false;
            }
            else if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                txtDescription.Focus();
                isflag = false;
            }

            return isflag;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid())
            {
                POS.BAL.LookupBAL lookup = new POS.BAL.LookupBAL();
                SubCategory detail = new SubCategory();
               
                if (btnSubmit.Content.ToString().ToUpper() == "SAVE")
                {
                    detail.Category = CmbCategory.Text.ToString();
                    detail.TypeID = Convert.ToInt32(CmbType.SelectedValue);
                    detail.Type = CmbType.Text.Trim();
                    detail.CategoryID = Convert.ToInt32(CmbCategory.SelectedValue);
                    detail.SubCategoryName = txtSubCategory.Text.Trim();
                    detail.ShortDescription = txtDescription.Text.Trim();
                    detail.CreatedBy = Utility.UserID;
                    detail.CreatedDate = DateTime.Now;
                    detail.IsActive = true;
                    lookup.InsertSubCategory(detail);
                }
                else
                {
                    detail = lookup.GetAllSubCategory().ToList().Find(x => x.SubCategoryID == categoryID);
                    detail.Category = CmbCategory.Text.ToString();
                    detail.CategoryID = Convert.ToInt32(CmbCategory.SelectedValue);
                    detail.SubCategoryName = txtSubCategory.Text.Trim();
                    detail.TypeID = Convert.ToInt32(CmbType.SelectedValue);
                    detail.Type = CmbType.Text.Trim();
                    detail.ShortDescription = txtDescription.Text.Trim();
                    detail.ModifiedBy = Utility.UserID;
                    detail.ModifiedDate = DateTime.Now;
                    detail.IsActive = true;
                    lookup.UpdateSubCategory(detail);
                }
                Clear();
            }
        }

        private void Clear()
        {
            txtSubCategory.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtSubCategory.Text = string.Empty;
            CmbCategory.SelectedIndex = 0;

            gridCategory.Visibility = Visibility.Collapsed;
            gridgroupbox.Visibility = Visibility.Collapsed;

            IEnumerable<category> categorydetails = lookup.GetAllCategory().ToList();

            var list = (from x in categorydetails
                        select new { x.CategoryID, x.Category }).ToList();
            category obj = new category();
            obj.ShortDescription = "Select";
            obj.CategoryID = 0;
            // list.Insert(0, obj);
            CmbCategory.ItemsSource = list;


            IEnumerable<SubCategoryType> typedetails = lookup.GetAllType().ToList();

            var typelist = (from x in typedetails
                        select new { x.TypeID, x.Type }).ToList();
            CmbType.ItemsSource = typelist;
            CmbType.SelectedIndex = 0;

            btnSubmit.Content = "Save";
            if (list.Count() > 0)
            {
                IEnumerable<SubCategory> subcategorydetails = lookup.GetAllSubCategory().ToList();
                gridCategory.DataContext = subcategorydetails;
                if (categorydetails.Count() > 0)
                {
                    gridCategory.Visibility = Visibility.Visible;
                    gridgroupbox.Visibility = Visibility.Visible;
                    gridCategory.DataContext = subcategorydetails;
                }
            }
        }
        int categoryID = 0;
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var ID = ((Button)sender).CommandParameter;
            lookup.DeleteSubCategory(Convert.ToInt32(ID));
            Clear();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            int ID = Convert.ToInt32(((Button)sender).CommandParameter);
            categoryID = ID;
            var categorydetails = lookup.GetAllSubCategory().ToList().Find(x => x.SubCategoryID == ID);
            if (categorydetails != null)
            {
                txtSubCategory.Text = categorydetails.SubCategoryName;
                txtDescription.Text = categorydetails.ShortDescription;
                CmbType.SelectedValue = categorydetails.TypeID;
                btnSubmit.Content = "Update";
            }
        }
    }
}
