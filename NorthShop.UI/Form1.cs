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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            frmCategoryAdd frm = new frmCategoryAdd();
            frm.ShowDialog();
        }

        private void btnCategoryList_Click(object sender, EventArgs e)
        {
            frmCategoryList frm = new frmCategoryList();
            frm.ShowDialog();
        }

        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            frmProductAdd frm = new frmProductAdd();
            frm.Show();
        }

        private void btnProductList_Click(object sender, EventArgs e)
        {
            frmProductList frm = new frmProductList();
            frm.Show();
        }
    }
}
