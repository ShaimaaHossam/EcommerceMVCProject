using Ecommerce.Data.Context;
using Ecommerce.Data.Models;
using Ecommerce.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Web.Api
{
    public class CategoriesController
    {
        ICategoryData db;
        public CategoriesController(ICategoryData db)
        {
            this.db = db;
        }
        public IEnumerable<Category> Get()
        {
            return db.GetAll();
        }

    }
}