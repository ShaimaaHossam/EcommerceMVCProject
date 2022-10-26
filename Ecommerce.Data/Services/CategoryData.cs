using Ecommerce.Data.Context;
using Ecommerce.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Ecommerce.Data.Services
{
    public class CategoryData : ICategoryData
    {
        private readonly ShopContext db;
        public CategoryData(ShopContext db)
        {
            this.db = db;
        }
        public IEnumerable<Category> GetAll()
        {
            return db.Categories;
        }

        public Category GetCategory(int id)
        {
            var category = db.Categories.Find(id);
            return category;      
        }

        public IEnumerable<Product> GetProductsInCategory(int id)
        {
            var products = db.Categories.Find(id).Products;
            return products;
        }

        public IEnumerable<Category> GetSubCategories(int id)
        {
            var subcategories = GetCategory(id).SubCategories;
            return subcategories;
        }

        void ICategoryData.Add(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        void ICategoryData.Delete(int id)
        {
            var category = db.Categories.Find(id);
            category.IsDeleted = true;
            db.SaveChanges();
        }

        void ICategoryData.Update(Category category)
        {
            var entry = db.Entry(category);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
