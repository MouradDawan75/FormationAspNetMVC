using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExoMVC.Models;

namespace ExoMVC.Dtos
{
    public class ProductCategoriesDto
    {
        public Product Product { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}