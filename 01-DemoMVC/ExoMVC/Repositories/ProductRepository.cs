using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExoMVC.Models;

namespace ExoMVC.Repositories
{
    public class ProductRepository
    {
        private MyContext context = new MyContext();

        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public void AddProduct(Product product) { 
            context.Products.Add(product);
            context.SaveChanges();
        }

        public Product GetById(int id)
        {
            return context.Products.Find(id);
        }
    }
}