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
        NorthwindEntities db = new NorthwindEntities();
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
            //Category updateCategory = db.Categories.Where(z => z.CategoryID == category.CategoryID).FirstOrDefault();
            Category updateCategory = db.Categories.FirstOrDefault(z => z.CategoryID == category.CategoryID);
            updateCategory.CategoryName = txtCategoryName.Text;
            updateCategory.Description = txtDesc.Text;
            db.SaveChanges();
            MessageBox.Show("Guncellendi");
        }
    }
}
