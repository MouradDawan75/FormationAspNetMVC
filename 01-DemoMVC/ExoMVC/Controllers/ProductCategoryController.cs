using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExoMVC.Models;
using ExoMVC.Services;

namespace ExoMVC.Controllers
{
    public class ProductCategoryController : Controller
    {
        private ProductCategoryService productCategoryService = new ProductCategoryService();
        public ActionResult Index()
        {
            return View(productCategoryService.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCategory cat)
        {
            productCategoryService.Add(cat);
            return RedirectToAction("Index");
        }
    }
}