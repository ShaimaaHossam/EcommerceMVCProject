using Ecommerce.Data.Models;
using Ecommerce.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Web.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        ICategoryData db;
        public CategoriesController(ICategoryData db)
        {
            this.db = db;
        }
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View("AddCategory");
        }
        [ValidateAntiForgeryToken, HttpPost]
        public ActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Add(category);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}