using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _07_AuthentificationAutorisation.Filters;

namespace _07_AuthentificationAutorisation.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //Roles: admin, normal

        [MyAutorisationFilter("Admin", "Normal")]
        [LoginFilter]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //Roles: admin, manager
        [MyAutorisationFilter("Admin", "Manager")]
        [LoginFilter]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}