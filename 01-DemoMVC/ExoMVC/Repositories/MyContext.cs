using System;
using System.Data.Entity;
using System.Linq;
using ExoMVC.Models;

namespace ExoMVC.Repositories
{
    public class MyContext : DbContext
    {
        
        public MyContext()
            : base("name=MyContext")
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<User> Users { get; set; }

    }

    
}