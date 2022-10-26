using Ecommerce.Data.Context;
using Ecommerce.Data.Models;
using Ecommerce.Data.Services;
using Ecommerce.Web.ViewModels;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Web.Mvc;

namespace Ecommerce.Web.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        IProductData db;
        public ProductsController(IProductData db)
        {
            this.db = db;
        }
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            ProductsCategoryViewModel model = new ProductsCategoryViewModel();
            model.Categories = db.GetAllCategories();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(ProductsCategoryViewModel product)
        {

            //if (ModelState.IsValid)
            
                Product p = new Product() { 
                    Category = product.Category, 
                    Name=product.Name, 
                    Description=product.Description, 
                    Price=product.Price, 
                    Quantity=product.Quantity 
                };
                db.Add(p);
                return RedirectToAction("Index");
            
            //return View(new ProductsCategoryViewModel());
        }
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            var product = db.Get(id);
            if(product == null)
            {
                return View("NotFound");
            }
            return View(product);
        }
        [ValidateAntiForgeryToken, HttpPost]
        public ActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Update(product);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Details(int id)
        {
            var product = db.Get(id);
            return View(product);
        }
       [HttpGet]
       public ActionResult Delete(int id)
       {
            var product = db.Get(id);
            if(product == null)
            {
                return View("NotFound");
            }
            return View(product);
        }
        [ValidateAntiForgeryToken, HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult GetCategories()
        {
            ShopContext db = new ShopContext();
            var res = Json((db.Categories).ToList(), JsonRequestBehavior.AllowGet);
            return res;
        }
    }
}