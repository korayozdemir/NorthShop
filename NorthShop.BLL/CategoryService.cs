using NorthShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthShop.BLL
{
    public class CategoryService
    {
        NorthwindEntities db = new NorthwindEntities();
        public void Add(Category c)
        {
            db.Categories.Add(c);
            db.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }
        public void Delete(Category c)
        {
            db.Categories.Remove(c);
            db.SaveChanges();
        }

        public void Update(Category c)
        {
            Category updateCategory = db.Categories.FirstOrDefault(z => z.CategoryID == c.CategoryID);
            updateCategory.CategoryName = c.CategoryName;
            updateCategory.Description = c.Description;
            db.SaveChanges();
        }
    }
}
