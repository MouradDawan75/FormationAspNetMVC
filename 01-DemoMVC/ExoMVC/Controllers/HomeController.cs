using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExoMVC.Dtos;
using ExoMVC.Models;
using ExoMVC.Services;

namespace ExoMVC.Controllers
{
    public class HomeController : Controller
    {
        private ProductCategoryService productCategoryService = new ProductCategoryService();
        private ProductService productService = new ProductService();

        public ActionResult Index(string Category = null)
        {
            ProductsCategoriesDto dto = new ProductsCategoriesDto();
            dto.Categories = productCategoryService.GetAll();

            List<Product> products;

            if(Category == null)
            {
                products = productService.GetAll();
            }
            else
            {
                products = productService.GetAll().Where(x => x.Category == Category).ToList();
            }

            dto.Products = products;

            return View(dto);
        }
    }
}