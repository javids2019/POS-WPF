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
using iTextSharp.text;
using iTextSharp.text.pdf;
using POS.Model;
using POS.Entities;

namespace FirstFloor.ModernUI.App
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class POSSalesMaster : System.Windows.Controls.UserControl
    {
        POS.BAL.CompanyBAL companybal = new POS.BAL.CompanyBAL();
        POS.BAL.CustomerBAL customerbal = new POS.BAL.CustomerBAL();
        POS.BAL.PurchaseItemsBAL purchasebal = new POS.BAL.PurchaseItemsBAL();
        POS.BAL.SalesBAL salesbal = new POS.BAL.SalesBAL();
        POS.BAL.LookupBAL lookup = new POS.BAL.LookupBAL();
        IEnumerable<PurchaseDetail> detailslist = null;
        public POSSalesMaster()
        {
            InitializeComponent();
            btnRefresh_Click(null, null);
        }

        private void cmbType_DropDownClosed(object sender, EventArgs e)
        {
            BindItemCode();
        }

        private void cmbSubCategory_DropDownClosed(object sender, EventArgs e)
        {
            BindItemCode();
        }

        private void cmbType_LostFocus(object sender, RoutedEventArgs e)
        {
            BindItemCode();
        }

        private void BindItemCode()
        {
            int categoryid = 0;
            int subcategoryid = 0;
            string type = string.Empty;

            if (cmbCategory.Items.Count > 0)
            {
                categoryid = Convert.ToInt32(cmbCategory.SelectedValue);
            }

            if (cmbSubCategory.Items.Count > 0)
            {
                subcategoryid = Convert.ToInt32(cmbSubCategory.SelectedValue);
            }

            if (cmbType.Items.Count > 0)
            {
                type = cmbType.Text.Trim();
            }
            IEnumerable<PurchaseDetail> detailslist = purchasebal.GetAllpurchasedetail().ToList();
            var itemCodelist = (from x in detailslist
                                where x.Quantity > 0 && x.CategoryID == categoryid ||
                                x.SubCategoryID == subcategoryid || x.Type == type
                                select new { x.PurchaseDetailsID, x.ItemCode }).ToList();

            comStockItemCode.ItemsSource = itemCodelist;
            comStockItemCode.SelectedIndex = 0;
        }

        private void cmbCategory_DropDownClosed(object sender, EventArgs e)
        {
            IEnumerable<SubCategory> subcategorydetails = lookup.GetAllSubCategory().ToList().Where(x=> x.CategoryID == (Convert.ToInt32(cmbCategory.SelectedValue)));
            var list = (from x in subcategorydetails
                        select new { x.SubCategoryID, x.ShortDescription }).ToList();
            cmbSubCategory.ItemsSource = list;
            BindItemCode();
        }

        private void cmbItemCode_DropDownClosed(object sender, EventArgs e)
        {
            IEnumerable<PurchaseDetail> detailslist = purchasebal.GetAllpurchasedetail().ToList();
            var item = (from x in detailslist
                        where x.Quantity > 0 && x.ItemCode == comStockItemCode.Text.Trim()
                        select new { x.Description, x.Quantity, x.SellingPrice }).FirstOrDefault();
            if (item != null)
            {
                txtItemDescription.Content = item.Description;
                txtAvailableQty.Text = item.Quantity.ToString();
                txtRate.Text = item.SellingPrice.ToString();
            }
        }


        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(comStockItemCode.Text))
            {
                IEnumerable<PurchaseDetail> detailslist = purchasebal.GetAllpurchasedetail().ToList();
                var itemList = (from x in detailslist
                                where x.Quantity > 0 && x.ItemCode == comStockItemCode.Text.Trim()
                                select x).FirstOrDefault();

                int count = (from x in detailsStockItem where x.PurchaseDetailsID == itemList.PurchaseDetailsID select x).Count();
                if (count == 0 && Convert.ToInt32(txtQty.Text) <= itemList.Quantity)
                {
                    itemList.Quantity = Convert.ToInt32(txtQty.Text.Trim());
                    detailsStockItem.Add(itemList);
                    int n = 0;
                    stockItemList = new List<StockItems>();
                    foreach (var item in detailsStockItem)
                    {
                        StockItems obj = new StockItems();
                        obj.PurchaseDetailsID = item.PurchaseDetailsID;
                        obj.ID = ++n;
                        obj.Description = item.Description;
                        obj.SellingPrice = item.SellingPrice * item.Quantity;
                        obj.Quantity = item.Quantity;
                        stockItemList.Add(obj);
                    }
                    gridStockItem.ItemsSource = stockItemList;
                    Calculate();
                }
            }
        }

        private void Calculate()
        {
            decimal TotalAmount = stockItemList.Sum(x => x.SellingPrice).GetValueOrDefault();
            int TotalQuantity = stockItemList.Sum(x => x.Quantity).GetValueOrDefault();

            lblTotalAmount.Content = TotalAmount.ToString();
            lblNetAmount.Content = TotalAmount.ToString();
            lblTotalQuantity.Content = TotalQuantity.ToString();
            if (!string.IsNullOrWhiteSpace(txtProvidedAmount.Text))
            {
                lblProvidedAmount.Content = txtProvidedAmount.Text.Trim();
                decimal balanceamount = Convert.ToDecimal(txtProvidedAmount.Text) - TotalAmount;
                lblBalanceAmount.Content = balanceamount.ToString();
            }
        }

        List<PurchaseDetail> detailsStockItem = new List<PurchaseDetail>();
        List<StockItems> stockItemList = new List<StockItems>();
        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            btnSave_Click(sender, e);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var ID = ((Button)sender).CommandParameter;
            var removeitem = detailsStockItem.Where(x => x.PurchaseDetailsID == Convert.ToInt32(ID)).FirstOrDefault();
            detailsStockItem.Remove(removeitem);
            int n = 0;
            stockItemList = new List<StockItems>();
            foreach (var item in detailsStockItem)
            {
                StockItems obj = new StockItems();
                obj.PurchaseDetailsID = item.PurchaseDetailsID;
                obj.ID = ++n;
                obj.Description = item.Description;
                obj.SellingPrice = item.SellingPrice * item.Quantity;
                obj.Quantity = item.Quantity;
                stockItemList.Add(obj);
            }
            gridStockItem.ItemsSource = stockItemList;
            Calculate();

        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {

            var customerlist = (from x in customerbal.GetAll()
                                select new { x.CustomerDetailsID, x.FirstName }).ToList();
            cmbCustomer.ItemsSource = customerlist;
            

            //Purchase Master Details
            IEnumerable<category> categorydetails = lookup.GetAllCategory().ToList();

            var catlist = (from x in categorydetails
                           select new { x.CategoryID, x.ShortDescription }).ToList();
            cmbCategory.ItemsSource = catlist;
            cmbCategory.SelectedIndex = 0;

            // Sub Category
            IEnumerable<SubCategory> subcategorydetails = lookup.GetAllSubCategory().ToList().Where(x => x.CategoryID == (Convert.ToInt32(cmbCategory.SelectedValue)));

            //IEnumerable<SubCategory> subcategorydetails = lookup.GetAllSubCategory(Convert.ToInt32(cmbCategory.SelectedValue)).ToList();
            var list = (from x in subcategorydetails
                        select new { x.SubCategoryID, x.ShortDescription }).ToList();

            cmbSubCategory.ItemsSource = list;
            cmbSubCategory.SelectedIndex = 0;


            IEnumerable<PurchaseDetail> detailslist = purchasebal.GetAllpurchasedetail().ToList();
            var itemCodelist = (from x in detailslist
                                where x.Quantity > 0
                                select new { x.PurchaseDetailsID, x.ItemCode }).ToList();

            comStockItemCode.ItemsSource = itemCodelist;
            //comStockItemCode.SelectedIndex = 0;

        }

        private void btnOnlyprint_Click(object sender, RoutedEventArgs e)
        {
            if (stockItemList.Count() > 0)
                GeneratePDF();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SalesMaster salesmaster = new SalesMaster();
            salesmaster.BalanceAmount = lblBalanceAmount.Content != string.Empty ? Convert.ToDecimal(lblBalanceAmount.Content) : 0;
            salesmaster.Tax = txtTax.Text.Trim() != string.Empty ? Convert.ToDecimal(txtTax.Text.Trim()) : 0;
            salesmaster.TotalAmount = lblBalanceAmount.Content != string.Empty ? Convert.ToDecimal(lblBalanceAmount.Content) : 0;
            salesmaster.TotalQuantity = lblBalanceAmount.Content != string.Empty ? Convert.ToInt32(lblBalanceAmount.Content) : 0;
            salesmaster.ProvidedAmount = lblProvidedAmount.Content != string.Empty ? Convert.ToDecimal(lblProvidedAmount.Content) : 0;
            salesmaster.NetAmount = lblNetAmount.Content != string.Empty ? Convert.ToDecimal(lblNetAmount.Content) : 0;

            if (rdCredit.IsChecked == true)
            {
                salesmaster.PaymentMode = "Credit Card";
            }
            else if (rdDebit.IsChecked == true)
            {
                salesmaster.PaymentMode = "Debit Card";
            }
            else if (rdCash.IsChecked == true)
            {
                salesmaster.PaymentMode = "Cash";
            }

            int ?num = salesbal.GetAllSalesMaster().Max(x => x.InvoiceNumber);
            int Invoicenumber = Convert.ToInt32(num) + 1;
            salesmaster.InvoiceNumber = Invoicenumber;
            salesmaster.InvoiceDate = DateTime.Now;
            salesmaster.Discount = txtDiscount.Text.Trim() != string.Empty ? Convert.ToDecimal(txtDiscount.Text.Trim()) : 0;
            salesbal.Insert(salesmaster, stockItemList);
        }

        private void NumericOnly(System.Object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);
        }


        private static bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str);
        }


        private void GeneratePDF()
        {
            Document doc = new Document(iTextSharp.text.PageSize.A4);
            string pdfDirectoryName = @"C:\POS\";
            string pdfpath = pdfDirectoryName +"PDF" + DateTime.Now.ToString("ddMMyyHHmmss") + ".pdf";
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(pdfDirectoryName);
            if (!dir.Exists)
            {
                dir.Create();
            }

            System.IO.FileStream file = new System.IO.FileStream(pdfpath, System.IO.FileMode.OpenOrCreate);
            PdfWriter writer = PdfWriter.GetInstance(doc, file);
            // calling PDFFooter class to Include in document
            writer.PageEvent = new PDFFooter();
            doc.Open();
            PdfPTable tab = new PdfPTable(4);
            PdfPCell cell = new PdfPCell(new Phrase("POS SuperMarket \n Hastampatty \n salem \n Tamil Nadu - 636007", new Font(Font.FontFamily.HELVETICA, 16F)));
            cell.Colspan = 4;
            float[] widths = new float[] { 1f, 5f, 2, 2 };
            tab.SetWidths(widths);

            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            //Style
            //cell.BorderColor = new BaseColor(System.Drawing.Color.Red);
            //cell.Border = Rectangle.BOTTOM_BORDER; // | Rectangle.TOP_BORDER;
            //cell.BorderWidthBottom = 3f;
            tab.SpacingAfter = 2f;
            tab.AddCell(cell);
            //row 1
            var boldFont = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK);
            var normalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK);



            tab.AddCell(new Phrase("No.", boldFont));
            tab.AddCell(new Phrase("Item Description", boldFont));
            tab.AddCell(new Phrase("Qty", boldFont));
            tab.AddCell(new Phrase("Price", boldFont));
            //row 2
            int i = 0;
            decimal? totalAmount =0;
            int? totalQty =0;
            foreach (var item in stockItemList)
            {
                string num = (++i).ToString();
                tab.AddCell(new Phrase(num));
                tab.AddCell(new Phrase(item.Description));
                tab.AddCell(item.Quantity.ToString());
                tab.AddCell(item.SellingPrice.ToString());
                totalAmount +=item.SellingPrice;
                totalQty +=item.Quantity;
            }

            tab.AddCell(new Phrase("", boldFont));
            tab.AddCell(new Phrase("", boldFont));
            tab.AddCell(new Phrase("", boldFont));
            tab.AddCell(new Phrase("", boldFont));


            tab.AddCell(new Phrase("Total No's.", boldFont));
            tab.AddCell(new Phrase("", boldFont));
            tab.AddCell(new Phrase("Total Qty", boldFont));
            tab.AddCell(new Phrase("Total Price", boldFont));
            tab.AddCell(new Phrase(i.ToString(), boldFont));
            tab.AddCell(new Phrase("", boldFont));
            tab.AddCell(new Phrase(totalQty.ToString(), boldFont));
            tab.AddCell(new Phrase(totalAmount.ToString(), boldFont));
            tab.HorizontalAlignment = 1;
            doc.Add(tab);
            doc.Close();
            file.Close();
            System.Diagnostics.Process.Start(pdfpath);
        }
    }
}
