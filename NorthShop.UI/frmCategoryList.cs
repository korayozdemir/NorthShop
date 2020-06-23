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
    public partial class frmCategoryList : Form
    {
        public frmCategoryList()
        {
            InitializeComponent();
        }
        NorthwindEntities db = new NorthwindEntities();
        Category selectedCategory;

        private void frmCategoryList_Load(object sender, EventArgs e)
        {
            DataFill();
        }

        private void DataFill()
        {
            listView1.Items.Clear();
            List<Category> clist = db.Categories.ToList();
            foreach (Category category in clist)
            {
                ListViewItem li = new ListViewItem();
                li.Tag = category;
                li.Text = category.CategoryName;
                li.SubItems.Add(category.Description);
                listView1.Items.Add(li);
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedCategory == null)
            {
                MessageBox.Show("Lütfen ordan kategori seç");
            }
            try
            {
                DialogResult result = MessageBox.Show("Silicem Bak", "Son Silici",
                          MessageBoxButtons.OKCancel,
                          MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.OK)
                {
                    db.Categories.Remove(selectedCategory);
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
            MessageBox.Show("Güncellendi");
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
                selectedCategory = (Category)listView1.SelectedItems[0].Tag;
        }
    }
}
