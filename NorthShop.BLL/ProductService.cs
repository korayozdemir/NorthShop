using NorthShop.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthShop.BLL
{
    public class ProductService : IRepository<Product>
    {
        NorthwindEntities db = new NorthwindEntities();
        public void Add(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
        }

        public void Delete(Product entity)
        {
            db.Products.Remove(entity);
            db.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public Product SelectById(int Id)
        {
            return db.Products.FirstOrDefault(z => z.ProductID == Id);
        }

        public void Update(Product entity)
        {
            Product updateProduct = SelectById(entity.ProductID);
            updateProduct.ProductName = entity.ProductName;
            updateProduct.UnitsInStock = entity.UnitsInStock;
            updateProduct.UnitPrice = entity.UnitPrice;
            updateProduct.CategoryID = entity.CategoryID;
            db.SaveChanges();
        }
    }
}
