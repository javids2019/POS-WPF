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

namespace FirstFloor.ModernUI.App
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class frmPayOut : UserControl
    {
        public frmPayOut()
        {
            InitializeComponent();

            //POS.BAL.SalesBAL sales = new POS.BAL.SalesBAL();
            //List<POS.Entities.salesmaster> saleslist =
            //sales.GetAllsalesmaster().ToList<salesmaster>();

            //salesmaster item = new salesmaster();
            //item.CustomerName = "jvd";
            //item.SalesMasterID = 2;

            //item.CreatedDate = DateTime.Now;
            //sales.Insert(item);

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            //POS.BAL.CustomerBAL customerBAL = new POS.BAL.CustomerBAL();
            //customerdetail customerdetails = new customerdetail();
            //customerdetails.FirstName = txtFirstName.Text.Trim();
            //customerdetails.LastName = txtLastName.Text.Trim();
            //customerdetails.ContactNo = txtContactNo.Text.Trim();
            //customerdetails.MobileNo = txtMobileNo.Text.Trim();
            //if (rdGendeMale.IsChecked == true)
            //    customerdetails.Gender = "Male";
            //else
            //    customerdetails.Gender = "Female";
            //customerdetails.DateOfBirth = DateofBirth.SelectedDate;
            //customerdetails.Address = txtAddress.Text.Trim();
            //customerdetails.City = txtCity.Text.Trim();
            //customerdetails.State = ComboState.SelectedItem.ToString();
            //customerdetails.ZipCode = txtZipCode.Text.Trim();
            //customerdetails.IsActive = 1;
            //customerdetails.CreatedDate = DateTime.Now;
            //customerdetails.CreatedBy = Utility.UserID;
            //customerBAL.Insert(customerdetails);
        }
    }
}
