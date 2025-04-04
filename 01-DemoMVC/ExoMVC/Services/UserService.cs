using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExoMVC.Models;
using ExoMVC.Repositories;

namespace ExoMVC.Services
{
    public class UserService
    {
        private UserRepository userRepository = new UserRepository();

        public List<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public void AddUser(User user)
        {
            userRepository.AddUser(user);
        }

        public User FindByEmail(string email) { 
        return userRepository.FindByEmail(email);
        }
    }
}