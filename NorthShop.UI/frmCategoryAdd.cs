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
    public partial class frmCategoryAdd : Form
    {
        public frmCategoryAdd()
        {
            InitializeComponent();
        }
        CategoryService service = new CategoryService();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Category c = new Category();
            c.CategoryName = txtCategoryName.Text;
            c.Description = txtDesc.Text;
            service.Add(c);
            MessageBox.Show("Kategori Eklendi");
        }
    }
}
