using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExoMVC.Models;
using ExoMVC.Services;

namespace ExoMVC.Controllers
{
    public class UserController : Controller
    {
        private UserService userService = new UserService();
        public ActionResult Index()
        {
            return View(userService.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User u)
        {
            userService.AddUser(u);
            return RedirectToAction("Index");
        }
    }
}