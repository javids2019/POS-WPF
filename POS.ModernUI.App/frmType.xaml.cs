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
    public partial class frmType : UserControl
    {
        POS.BAL.LookupBAL lookup = new POS.BAL.LookupBAL();
        public frmType()
        {
            InitializeComponent();
            Clear();
        }

        private void Clear()
        {
            txtType.Text = string.Empty;
            txtDescription.Text = string.Empty;
            gridType.Visibility = Visibility.Collapsed;
            gridgroupbox.Visibility = Visibility.Collapsed;
            IEnumerable<SubCategoryType> details = lookup.GetAllType().ToList();
            if (details.Count() > 0)
            {
                gridType.Visibility = Visibility.Visible;
                gridgroupbox.Visibility = Visibility.Visible;
                gridType.DataContext = details;
            }
            btnSubmit.Content = "Save";
        }

        private bool IsValid()
        {
            bool isflag = true;
            if (string.IsNullOrWhiteSpace(txtType.Text))
            {
                txtType.Focus();
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
                SubCategoryType detail = new SubCategoryType();
                Utility.UserID = 1;
                detail.Type = txtType.Text.Trim();
                detail.ShortDescription = txtDescription.Text.Trim();
                detail.IsActive = true;
                if (btnSubmit.Content.ToString().ToUpper() == "SAVE")
                {
                    detail.CreatedBy = Utility.UserID;
                    detail.CreatedDate = DateTime.Now;
                    lookup.InsertType(detail);
                }
                else
                {
                    detail = lookup.GetAllType().ToList().Find(x => x.TypeID == typeID);
                    //m LookupDetailsID
                    detail.Type = txtType.Text.Trim();
                    detail.ShortDescription = txtDescription.Text.Trim();
                    detail.TypeID = typeID;
                    detail.ModifiedBy = Utility.UserID;
                    detail.ModifiedDate = DateTime.Now;
                    lookup.UpdateType(detail);
                }
                IEnumerable<SubCategoryType> details = lookup.GetAllType().ToList();
                gridType.DataContext = details;
            }
            Clear();
        }
        int typeID = 0;

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            int ID = Convert.ToInt32(((Button)sender).CommandParameter);
            typeID = ID;
            var details = lookup.GetAllType().ToList().Find(x => x.TypeID == ID);
            txtType.Text = details.Type;
            txtDescription.Text = details.ShortDescription;
            btnSubmit.Content = "Update";
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var ID = ((Button)sender).CommandParameter;
            lookup.DeleteType(Convert.ToInt32(ID));
            Clear();
        }
        int LookupDetailsID;
       

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
    }
}
