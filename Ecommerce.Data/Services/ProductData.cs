using Ecommerce.Data.Context;
using Ecommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Services
{
    public class ProductData : IProductData
    {
        private readonly ShopContext db;
        public ProductData(ShopContext db)
        {
            this.db = db;
        }
        public void Add(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var prod = db.Products.Find(id);
            prod.IsDeleted = true;
            db.SaveChanges();
        }

        public Product Get(int id)
        {
            var prod = db.Products.Find(id);
            return prod;
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products.Where(P => !P.IsDeleted).ToList();
        }

        public void Update(Product product)
        {
            var entry = db.Entry(product);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

  

        public Category GetCategory(int id)
        {
            var product = db.Products.Find(id);
            return product.Category;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return db.Categories.Where(C => !C.IsDeleted).ToList();
        }
    }
}
