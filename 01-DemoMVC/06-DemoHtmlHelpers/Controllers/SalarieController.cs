using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _06_DemoHtmlHelpers.Models;

namespace _06_DemoHtmlHelpers.Controllers
{
    public class SalarieController : Controller
    {
       
        public ActionResult Index()
        {
            Salarie s = new Salarie();
            return View(s);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Salarie salarie, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                //insertion en BD
                return View("Contact", salarie);
            }

            return View(salarie);
        }
    }
}