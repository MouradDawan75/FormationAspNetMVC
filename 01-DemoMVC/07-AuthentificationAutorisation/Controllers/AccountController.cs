using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using _07_AuthentificationAutorisation.Models;
using Microsoft.Ajax.Utilities;

namespace _07_AuthentificationAutorisation.Controllers
{
    public class AccountController : Controller
    {
        private MyContext context = new MyContext();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User model)
        {
            if (ModelState.IsValid) 
            { 
                User user = context.Users
                    .Where(u => u.Username.Equals(model.Username) && u.Password.Equals(model.Password))
                    .FirstOrDefault();
                if (user!= null)
                {
                    //connexion ok
                    /*
                     * Une session à une durée de 20 mn
                     */
                    Session["Username"] = model.Username;
                    Session["UserId"] = user.Id;
                    Session.Timeout = 30;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Echec connexion....");
                    return View(model);
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Abandon(); //supprime l'objet session en mémoire

            //Sinon choisir les clés à supprimer dans la session
            // Session["Username"] = string.Empty;
            return RedirectToAction("Login", "Account");
        }

        public ActionResult UnAuthorized()
        {
            return View();
        }
    }
}