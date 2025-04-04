using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExoMVC.Models;

namespace ExoMVC.Repositories
{
    public class UserRepository
    {
        private MyContext context = new MyContext();

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        public void AddUser(User user) { 
        context.Users.Add(user);
            context.SaveChanges();
        }

        public User FindByEmail(string email)
        {
            return context.Users.Where(u => u.Email == email).SingleOrDefault();
        }
    }
}