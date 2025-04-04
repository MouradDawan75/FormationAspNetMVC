using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExoMVC.Models;
using ExoMVC.Repositories;

namespace ExoMVC.Services
{
    public class ProductService
    {
        private ProductRepository productRepository = new ProductRepository();

        public List<Product> GetAll()
        {
            return productRepository.GetAll();
        }

        public void AddProduct(Product product) { 
            productRepository.AddProduct(product);
        }

        public Product GetProductById(int id)
        {
            return productRepository.GetById(id);
        }
    }
}