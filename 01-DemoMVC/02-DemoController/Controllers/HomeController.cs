using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using _02_DemoController.Models;

namespace _02_DemoController.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /*
             * Envoyer des données à la vue:
             * 4 dictionnaires peuvent être utilisés:
             * ViewBag: contenu supprimé entre 2 requêtes
             * ViewData: contenu supprimé entre 2 requêtes
             * TempData: possibilité de maintenir le contenu entre 2 requêtes via la méthode keep()
             * Session:
             * 
             * 
             * ViewBag, ViewData et TempData: ne peuvent contenir que des types simples de données
             */

            ViewBag.Texte = "contenu du ViewBag";
            ViewData["Texte"] = "contenu du ViewData";
            TempData["Texte"] = "contenu du TempData";
         
            Session["Texte1"] = "contenu de la session"; //durée par défaut est entre 20 et 25 mn

            //TempData.Keep();

            Employe e = new Employe { Nom = "DAWAN", Prenom = "Jehann" };
            Session["empoye"] = e;

            return View(e); //e est le model du pattern MVC
            //return new ActionResult();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            //return View();
            //return Content("Texte de la réponse");
            //return Content("<Personne><nom>DUPONT</nom></Personne>", "text/xml");

            //return File(Server.MapPath("~/demo.txt"), "text/plain"); //le contenu s'affiche dans la page web
            //return File(Server.MapPath("~/demo.txt"), "text/plain", "content.txt"); //permet de télécharger le fichier sur le poste client
            //return JavaScript("alert('test javascript')"); //dans index: ajoutez un lien vers cette action
            //return null; //EmptyResult
            Employe emp = new Employe { Nom = "DUPONT", Prenom = "Jean" };
            //return Json(emp, JsonRequestBehavior.AllowGet);
            //Possibilté de renvoyer un fichier json
            string chaineJson = JsonTool.ToJson(emp);
            byte[] tab = Encoding.UTF8.GetBytes(chaineJson);

            //return File(tab,"application/json", "employe.json");
            //return HttpNotFound("Page introuvable."); 404
            // return new HttpUnauthorizedResult("Accès refusé......"); 401
            //return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, "Mauvaise requête"); //renvoyer un autre status

            string vbagContent = ViewBag.Texte;
            string content = (string)TempData["Texte"];

            return View();

        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            //return View();
            //return Redirect("/Home/About"); //redirection vers une action définie dans ce controller
            return RedirectToAction("Index", "Test"); //redirection vers une action d'un autre controller

        }
    }
}