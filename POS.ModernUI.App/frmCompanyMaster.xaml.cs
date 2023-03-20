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
using POS.Model;
using POS.Entities;

namespace FirstFloor.ModernUI.App
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class frmCompanyMaster : UserControl
    {
        POS.BAL.CompanyBAL companybal = new POS.BAL.CompanyBAL();
        Int32 CompanyID = 0;
        public frmCompanyMaster()
        {
            InitializeComponent();
            Clear();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid())
            {
                CompanyDetail detail = new CompanyDetail();
                detail.CreatedBy = Utility.UserID;
                detail.CreatedDate = DateTime.Now;
                detail.CompanyName = txtcompanyName.Text.Trim();
                detail.ContactNo = txtContactNo.Text.Trim();
                detail.ContactPerson = txtContactPerson.Text.Trim();
                detail.Description = txtDescription.Text.Trim();
                detail.Address = txtAddress.Text.Trim();
                detail.City = txtCity.Text.Trim();
                detail.IsActive = 1;
                detail.MobileNo = txtMobileNo.Text.Trim();
                detail.ZipCode = txtZipCode.Text.Trim();
                detail.State = CmbState.Text.ToString();
                if (btnSubmit.Content == "Save")
                {
                    detail.CreatedBy = Utility.UserID;
                    detail.CreatedDate = DateTime.Now;
                    companybal.Insert(detail);
                }
                else
                {
                    detail.CompanyID = CompanyID;
                    detail.ModifiedBy = Utility.UserID;
                    detail.ModifiedDate = DateTime.Now;
                    companybal.Update(detail);
                }

                Clear();
            }
        }

        private void Clear()
        {
            gridCompany.Visibility = Visibility.Collapsed;
            gridgroupbox.Visibility = Visibility.Collapsed;
            txtcompanyName.Text = string.Empty;
            txtContactNo.Text = string.Empty;
            txtContactPerson.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtZipCode.Text = string.Empty;
            CmbState.SelectedIndex = 0;
            btnSubmit.Content = "Save";
            IEnumerable<CompanyDetail> companydetails = null;
            try
            {
                companydetails = companybal.GetAllCompanyDetails().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
            if (companydetails.Count() > 0) 
            {
                gridCompany.Visibility = Visibility.Visible;
                gridgroupbox.Visibility = Visibility.Visible;
                gridCompany.DataContext = companydetails;
            }
        }

        private bool IsValid()
        {
            bool isflag = true;
            if (string.IsNullOrWhiteSpace(txtcompanyName.Text))
            {
                txtcompanyName.Focus();
                isflag = false;
            }
            else if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                txtDescription.Focus();
                isflag = false;
            }
                   
            return isflag;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var ID = ((Button)sender).CommandParameter;
            companybal.Delete(Convert.ToInt32(ID));
            Clear();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var ID = ((Button)sender).CommandParameter;
            var company = companybal.GetAllCompanyDetails().Where(x => x.CompanyID == Convert.ToInt32(ID)).FirstOrDefault();
            CompanyID = company.CompanyID;
            txtcompanyName.Text = company.CompanyName;
            txtContactNo.Text = company.ContactNo;
            txtContactPerson.Text = company.ContactPerson;
            txtDescription.Text = company.Description;
            txtAddress.Text = company.Address;
            txtCity.Text = company.City;
            txtMobileNo.Text = company.MobileNo;
            txtZipCode.Text = company.ZipCode;
            CmbState.Text = company.State;
            btnSubmit.Content = "Update";

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
    }
}
