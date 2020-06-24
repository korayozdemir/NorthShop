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
    public partial class frmCategoryUpdate : Form
    {
        private Category category;
        CategoryService service = new CategoryService();
        public frmCategoryUpdate(Category _category)
        {
            category = _category;
            InitializeComponent();
        }

        private void frmCategoryUpdate_Load(object sender, EventArgs e)
        {
            txtCategoryName.Text = category.CategoryName;
            txtDesc.Text = category.Description;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            category.CategoryName = txtCategoryName.Text;
            category.Description = txtDesc.Text;
            service.Update(category);
            MessageBox.Show("Guncellendi");
        }
    }
}
