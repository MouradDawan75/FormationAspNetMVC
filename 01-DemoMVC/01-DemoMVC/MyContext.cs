using System;
using System.Data.Entity;
using System.Linq;
using _01_DemoMVC.Models;

namespace _01_DemoMVC
{
    public class MyContext : DbContext
    {
        
        public MyContext()
            : base("name=MyContext")
        {
        }
        public DbSet<Produit>   Produits { get; set; }

    }

   
}