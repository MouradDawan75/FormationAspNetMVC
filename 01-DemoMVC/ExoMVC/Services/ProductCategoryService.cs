using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExoMVC.Models;
using ExoMVC.Repositories;

namespace ExoMVC.Services
{
    public class ProductCategoryService
    {
        private ProductCategoryRepository productCategoryRepository = new ProductCategoryRepository();

        public List<ProductCategory> GetAll()
        {
            return productCategoryRepository.GetAll();
        }

        public void Add(ProductCategory productCategory)
        {
            productCategoryRepository.AddCategory(productCategory);
        }
    }
}