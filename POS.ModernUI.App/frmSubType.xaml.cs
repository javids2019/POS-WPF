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
    public partial class frmSubType : UserControl
    {
        POS.BAL.LookupBAL lookup = new POS.BAL.LookupBAL();

        public frmSubType()
        {
            InitializeComponent();
            Clear();
        }


        private bool IsValid()
        {
            bool isflag = true;
            if (string.IsNullOrWhiteSpace(txtSubType.Text))
            {
                txtSubType.Focus();
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
                SubType detail = new SubType();
               
                if (btnSubmit.Content.ToString().ToUpper() == "SAVE")
                {
                    detail._SubType = txtSubType.Text.ToString();
                    detail.TypeID = Convert.ToInt32(CmbType.SelectedValue);
                    detail.Type = CmbType.Text;
                    detail.ShortDescription = txtDescription.Text.Trim();
                    detail.CreatedBy = Utility.UserID;
                    detail.CreatedDate = DateTime.Now;
                    detail.IsActive = true;
                    lookup.InsertSubType(detail);
                }
                else
                {
                    detail = lookup.GetAllSubType().ToList().Find(x => x.SubTypeID == subTypeID);
                    detail._SubType = txtSubType.Text.ToString();
                    detail.Type = CmbType.Text;
                    detail.TypeID = Convert.ToInt32(CmbType.SelectedValue);
                    detail.ShortDescription = txtDescription.Text.Trim();
                    detail.SubTypeID = subTypeID;
                    detail.ModifiedBy = Utility.UserID;
                    detail.ModifiedDate = DateTime.Now;
                    detail.IsActive = true;
                    lookup.UpdateSubType(detail);
                }
                Clear();
            }
        }

        private void Clear()
        {
            txtSubType.Text = string.Empty;
            txtDescription.Text = string.Empty;
            CmbType.SelectedIndex = 0;

            gridSubType.Visibility = Visibility.Collapsed;
            gridgroupbox.Visibility = Visibility.Collapsed;

            IEnumerable<SubCategoryType> categorydetails = lookup.GetAllType().ToList();

            var list = (from x in categorydetails
                        select new { x.TypeID, x.Type }).ToList();
            
            CmbType.ItemsSource = list;
            btnSubmit.Content = "Save";

            if (list.Count() > 0)
            {
                IEnumerable<SubType> subcategorydetails = lookup.GetAllSubType().ToList();
                gridSubType.DataContext = subcategorydetails;
                if (categorydetails.Count() > 0)
                {
                    gridSubType.Visibility = Visibility.Visible;
                    gridgroupbox.Visibility = Visibility.Visible;
                    gridSubType.DataContext = subcategorydetails;
                }
            }
        }
        int subTypeID = 0;
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var ID = ((Button)sender).CommandParameter;
            lookup.DeleteSubType(Convert.ToInt32(ID));
            Clear();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            int ID = Convert.ToInt32(((Button)sender).CommandParameter);
            subTypeID = ID;
            var categorydetails = lookup.GetAllSubType().ToList().Find(x => x.SubTypeID == ID);
            if (categorydetails != null)
            {
                txtSubType.Text = categorydetails._SubType;
                CmbType.SelectedValue = categorydetails.TypeID;
                txtDescription.Text = categorydetails.ShortDescription;
                btnSubmit.Content = "Update";
            }
        }
    }
}
