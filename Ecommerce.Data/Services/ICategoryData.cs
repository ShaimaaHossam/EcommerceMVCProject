using Ecommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Services
{
    public interface ICategoryData
    {
        IEnumerable<Category> GetAll();
        IEnumerable<Category> GetSubCategories(int id);
        IEnumerable<Product> GetProductsInCategory(int id);
        Category GetCategory(int id);
        void Add(Category category);
        void Delete(int id);
        void Update(Category category);



    }
}
