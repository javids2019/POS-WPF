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
    public partial class frmCustomer : UserControl
    {
        POS.BAL.CustomerBAL customerBAL = new POS.BAL.CustomerBAL();
        int CustomerDetailsID;
        public frmCustomer()
        {
            InitializeComponent();

            Clear();

        }


        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid())
            {

              
                CustomerDetail customerdetails = new CustomerDetail();
                customerdetails.FirstName = txtName.Text.Trim();
                //customerdetails.LastName = txtLastName.Text.Trim();
                customerdetails.ContactNo = txtContactNo.Text.Trim();
                customerdetails.MobileNo = txtMobileNo.Text.Trim();
                if (rdMale.IsChecked == true)
                    customerdetails.Gender = "Male";
                else
                    customerdetails.Gender = "Female";
                customerdetails.DateOfBirth = dtBirthdaydate.SelectedDate;
                customerdetails.Address = txtAddress.Text.Trim();
                customerdetails.City = txtCity.Text.Trim();
                customerdetails.State = CmbState.Text.ToString();
                customerdetails.ZipCode = txtZipCode.Text.Trim();
                customerdetails.IsActive = 1;

                if (btnSubmit.Content == "Save")
                {
                    customerdetails.CreatedBy = Utility.UserID;
                    customerdetails.CreatedDate = DateTime.Now;
                    customerBAL.Insert(customerdetails);
                }
                else
                {
                    customerdetails.CustomerDetailsID = CustomerDetailsID;
                    customerdetails.ModifiedBy = Utility.UserID;
                    customerdetails.ModifiedDate = DateTime.Now;
                    customerBAL.Update(customerdetails);
                }

                Clear();
            }
        }

        private void Clear()
        {
            gridCustomer.Visibility = Visibility.Collapsed;
            gridgroupbox.Visibility = Visibility.Collapsed;
            txtContactNo.Text = string.Empty;
            txtName.Text = string.Empty;
            dtBirthdaydate.SelectedDate = null;
            txtAddress.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtZipCode.Text = string.Empty;
            CmbState.SelectedIndex = 0;
            btnSubmit.Content = "Save";
             rdMale.IsChecked = true;
            IEnumerable<CustomerDetail> customerdetails = customerBAL.GetAll().ToList();
            if (customerdetails.Count() > 0)
            {
                gridCustomer.Visibility = Visibility.Visible;
                gridgroupbox.Visibility = Visibility.Visible;
                gridCustomer.DataContext = customerdetails;
            }
        }

        private bool IsValid()
        {
            bool isflag = true;
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                txtName.Focus();
                isflag = false;
            }
            else if (string.IsNullOrWhiteSpace(txtMobileNo.Text))
            {
                txtMobileNo.Focus();
                isflag = false;
            }

            return isflag;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var ID = ((Button)sender).CommandParameter;
            customerBAL.Delete(Convert.ToInt32(ID));
            Clear();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var ID = ((Button)sender).CommandParameter;
            var details = customerBAL.GetAll().Where(x => x.CustomerDetailsID == Convert.ToInt32(ID)).FirstOrDefault();
            CustomerDetailsID = details.CustomerDetailsID;
            txtName.Text = details.FirstName;

            if (details.Gender == "Male")
                rdMale.IsChecked = true;
            else
                rdFemale.IsChecked = true;

            txtContactNo.Text = details.ContactNo;
            dtBirthdaydate.SelectedDate = details.DateOfBirth;
            txtMobileNo.Text = details.MobileNo;
            txtAddress.Text = details.Address;
            txtCity.Text = details.City;
            txtMobileNo.Text = details.MobileNo;
            txtZipCode.Text = details.ZipCode;
            CmbState.Text = details.State;
            btnSubmit.Content = "Update";

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
    }
}
