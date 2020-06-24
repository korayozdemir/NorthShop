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
    public partial class frmProductList : Form
    {
        public frmProductList()
        {
            InitializeComponent();
        }
        NorthwindEntities db = new NorthwindEntities();
        Product selectedProduct;
        private void frmProductList_Load(object sender, EventArgs e)
        {
            DataFill();
        }

        private void DataFill()
        {
            db = new NorthwindEntities();
            listView1.Items.Clear();
            List<Product> plist = db.Products.ToList();
            foreach (Product product in plist)
            {
                ListViewItem li = new ListViewItem(product.ProductName);
                li.Tag = product;
                li.SubItems.Add(product.UnitPrice.ToString());
                li.SubItems.Add(product.UnitsInStock.ToString());
                li.SubItems.Add(product.Category.CategoryName);
                listView1.Items.Add(li);
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedProduct == null)
            {
                MessageBox.Show("Lütfen ordan urun seç");
            }
            try
            {
                DialogResult result = MessageBox.Show("Silicem Bak", "Son Silici",
                          MessageBoxButtons.OKCancel,
                          MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.OK)
                {
                    db.Products.Remove(selectedProduct);
                    db.SaveChanges();
                    MessageBox.Show("Silindi");
                    DataFill();
                }
                else
                {
                    MessageBox.Show("Vazgeçildi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductUpdate updateForm = new frmProductUpdate(selectedProduct);
            updateForm.FormClosed += UpdateForm_FormClosed;
            updateForm.ShowDialog();
        }

        private void UpdateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataFill();
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
                selectedProduct = (Product)listView1.SelectedItems[0].Tag;
        }
    }
}
