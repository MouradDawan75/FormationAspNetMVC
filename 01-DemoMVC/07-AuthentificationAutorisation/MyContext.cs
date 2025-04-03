using System;
using System.Data.Entity;
using System.Linq;
using _07_AuthentificationAutorisation.Models;

namespace _07_AuthentificationAutorisation
{
    public class MyContext : DbContext
    {
        
        public MyContext()
            : base("name=MyContext")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

    }

 
}