using Ecommerce.Data.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ecommerce.Web.ViewModels
{
    public class ProductsCategoryViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public Category Category { get; set; }

    }
}