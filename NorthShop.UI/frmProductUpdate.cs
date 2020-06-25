using NorthShop.BLL;
using NorthShop.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthShop.UI
{
    public partial class frmProductUpdate : Form
    {
        private Product product;
        public frmProductUpdate(Product _product)
        {
            product = _product;
            InitializeComponent();
        }
        ProductService service = new ProductService();
        CategoryService cateService = new CategoryService();

        private void frmProductUpdate_Load(object sender, EventArgs e)
        {
            DataFill();
            txtName.Text = product.ProductName;
            txtPrice.Text = product.UnitPrice.ToString();
            txtStock.Text = product.UnitsInStock.ToString();
            int index = cmbCategories.FindString(product.Category.CategoryName);
            cmbCategories.SelectedIndex = index;
        }

        private void DataFill()
        {
            cmbCategories.DataSource = cateService.GetAll();
            cmbCategories.DisplayMember = "CategoryName";
            cmbCategories.ValueMember = "CategoryId";
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                Product p = service.SelectById(product.ProductID);
                p.ProductName = txtName.Text;
                p.UnitsInStock = short.Parse(txtStock.Text);
                p.UnitPrice = int.Parse(txtPrice.Text);
                p.CategoryID = ((Category)cmbCategories.SelectedItem).CategoryID;
                service.Update(p);
                MessageBox.Show("Güncelleme Başarılı");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
