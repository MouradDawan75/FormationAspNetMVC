using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExoMVC.Dtos;
using ExoMVC.Models;
using ExoMVC.Services;

namespace ExoMVC.Controllers
{
    public class ProductController : Controller
    {
        private ProductService productService = new ProductService();
        private ProductCategoryService productCategoryService = new ProductCategoryService();
        public ActionResult Index()
        {
            return View(productService.GetAll());
        }

        public ActionResult Create()
        {
            ProductCategoriesDto dto = new ProductCategoriesDto();
            dto.Product = new Product();
            dto.ProductCategories = productCategoryService.GetAll();

            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCategoriesDto dto, HttpPostedFileBase file)
        {
           Product p = new Product();
           //personnaliser le nom de l'image
           string path = dto.Product.Name + Path.GetExtension(file.FileName);
            p.Image = path;
            file.SaveAs(Server.MapPath("~/Content/productImages/" + path));

            p.Name = dto.Product.Name;
            p.Description = dto.Product.Description;
            p.Price = dto.Product.Price;
            p.Category = dto.Product.Category;

            productService.AddProduct(p);

            return RedirectToAction("Index");
        }
    }
}