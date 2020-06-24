using NorthShop.DAL;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product SelectById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
