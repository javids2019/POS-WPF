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
    public partial class frmCategoryMaster : UserControl
    {
        POS.BAL.LookupBAL lookup = new POS.BAL.LookupBAL();
        public frmCategoryMaster()
        {
            InitializeComponent();
            Clear();
        }

        private void Clear()
        {
            txtCategory.Text = string.Empty;
            txtDescription.Text = string.Empty;
            gridCategory.Visibility = Visibility.Collapsed;
            gridgroupbox.Visibility = Visibility.Collapsed;
            IEnumerable<category> categorydetails = lookup.GetAllCategory().ToList();
            if (categorydetails.Count() > 0)
            {
                gridCategory.Visibility = Visibility.Visible;
                gridgroupbox.Visibility = Visibility.Visible;
                gridCategory.DataContext = categorydetails;
            }
            btnSubmit.Content = "Save";
        }

        private bool IsValid()
        {
            bool isflag = true;
            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                txtCategory.Focus();
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
                category detail = new category();
                Utility.UserID = 1;
                detail.Category = txtCategory.Text.Trim();
                detail.ShortDescription = txtDescription.Text.Trim();
                detail.IsActive = true;
                if (btnSubmit.Content.ToString().ToUpper() == "SAVE")
                {
                    detail.CreatedBy = Utility.UserID;
                    detail.CreatedDate = DateTime.Now;
                    lookup.InsertCategory(detail);
                }
                else
                {
                    detail = lookup.GetAllCategory().ToList().Find(x => x.CategoryID == categoryID);
                    detail.Category = txtCategory.Text.Trim();
                    detail.ShortDescription = txtDescription.Text.Trim();
                    detail.CategoryID = categoryID;
                    detail.ModifiedBy = Utility.UserID;
                    detail.ModifiedDate = DateTime.Now;
                    lookup.UpdateCategory(detail);
                }
                IEnumerable<category> categorydetails = lookup.GetAllCategory().ToList();
                gridCategory.DataContext = categorydetails;
            }
            Clear();
        }
        int categoryID = 0;

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            int ID = Convert.ToInt32(((Button)sender).CommandParameter);
            categoryID = ID;
            var categorydetails = lookup.GetAllCategory().ToList().Find(x => x.CategoryID == ID);
            txtCategory.Text = categorydetails.Category;
            txtDescription.Text = categorydetails.ShortDescription;
            btnSubmit.Content = "Update";
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var ID = ((Button)sender).CommandParameter;
            lookup.DeleteCategory(Convert.ToInt32(ID));
            Clear();
        }
        int LookupDetailsID;


        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
    }
}
