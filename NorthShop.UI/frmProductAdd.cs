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
        NorthwindEntities db = new NorthwindEntities();
        private void btnKaydet_Click(object sender, EventArgs e)
        {

            try
            {
                Product p = new Product();
                p.ProductName = txtName.Text;
                p.UnitsInStock = short.Parse(txtStock.Text);
                p.UnitPrice = int.Parse(txtPrice.Text);
                p.CategoryID = ((Category)cmbCategories.SelectedItem).CategoryID;
                db.Products.Add(p);
                db.SaveChanges();
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
            cmbCategories.DataSource = db.Categories.ToList();
            cmbCategories.DisplayMember = "CategoryName";
            cmbCategories.ValueMember = "CategoryId";
        }

    }
}
