using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExoMVC.Models;

namespace ExoMVC.Dtos
{
    public class ProductsCategoriesDto
    {
        public List<Product> Products { get; set; }
        public List<ProductCategory> Categories { get; set; }
    }
}