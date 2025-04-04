using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExoMVC.Models;

namespace ExoMVC.Repositories
{
    public class ProductCategoryRepository
    {
        private MyContext context = new MyContext();

        public List<ProductCategory> GetAll()
        {
            return context.ProductCategories.ToList();
        }

        public void AddCategory(ProductCategory category) { 
            context.ProductCategories.Add(category);
            context.SaveChanges();
        }
    }
}