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
    public partial class frmProductAdd : Form
    {
        public frmProductAdd()
        {
            InitializeComponent();
        }
        ProductService service = new ProductService();
        CategoryService cateService = new CategoryService();
        private void btnKaydet_Click(object sender, EventArgs e)
        {

            try
            {
                Product p = new Product();
                p.ProductName = txtName.Text;
                p.UnitsInStock = short.Parse(txtStock.Text);
                p.UnitPrice = int.Parse(txtPrice.Text);
                p.CategoryID = ((Category)cmbCategories.SelectedItem).CategoryID;
                service.Add(p);
                MessageBox.Show("Ekleme Başarılı");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void frmProductAdd_Load(object sender, EventArgs e)
        {
            DataFill();

        }
        private void DataFill()
        {
            cmbCategories.DataSource = cateService.GetAll();
            cmbCategories.DisplayMember = "CategoryName";
            cmbCategories.ValueMember = "CategoryId";
        }

    }
}
