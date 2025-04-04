using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExoMVC.Dtos;
using ExoMVC.Models;
using ExoMVC.Services;

namespace ExoMVC.Controllers
{
    public class LoginController : Controller
    {
        private UserService userService = new UserService();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginDto loginDto)
        {
            User u = userService.FindByEmail(loginDto.Email);
            if (u != null && u.Password.Equals(loginDto.Password))
            {
                //Connexion OK
                Session.Timeout = 30;
                Session["user"] = u;

                if (u.IsAdmin)
                {
                    Session["admin"] = u.IsAdmin;
                }

                return RedirectToAction("Index", "Home");

            }
            ViewBag.Error = "Connection failed.....";
            return View(loginDto);
        }
        public ActionResult Create()
        {
            ViewBag.Success = false;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoginDto loginDto)
        {
            User u = new User { Email=loginDto.Email, Password=loginDto.Password, IsAdmin=false };
            userService.AddUser(u);
            ViewBag.Success = true;
            return View(loginDto);
        }



        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }
    }
}