﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExoMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}