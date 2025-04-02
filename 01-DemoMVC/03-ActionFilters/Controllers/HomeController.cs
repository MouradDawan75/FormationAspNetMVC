using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03_ActionFilters.Controllers
{
   
    public class HomeController : Controller
    {
        [HttpGet]
        [OutputCache(Duration = 10)] //mise en cache pour 10 secondes - Duration est en secondes
        public ActionResult Index()
        {
            TempData["Heure"] =  DateTime.Now.ToLongTimeString();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string demo)
        {
            ViewBag.Demo = demo;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //[HandleError]
        public ActionResult Contact()
        {
            // ViewBag.Message = "Your contact page.";

            //return View();
            throw new Exception("Erreur......");
        }

        //Action pour la gestion des URLs invalides

        public ActionResult Erreur404()
        {
            return View();
        }
    }
}
/*
 * Pour la gestion des exceptions:
 * 1- Pour activer la page d'erreurs par défaut:
 * Dans web.config:
 * Section:  <system.web>
 * ajoutez le tag:<customErrors mode="on"></customErrors>
 * 
 * Pour afficher une page personnalisée en cas d'erreur 404:
 * 
 * Ajoutez une action renvoyant une page (voir action Erreur404)
 * Complètez la section <System.web> dans Web.config pour appeler cette action:
 * 
 * <customErrors mode="On">
		  <error statusCode="404" redirect="Home/Erreur404"/>
   </customErrors>
 * 
 * 3 niveaux d'application des ActionFiler:
 * 
 * niveau Action: filtrer une action particulière
 * niveau Controller: filter es actions d'un controller particulier
 * niveau Global: filtre déclaré dans App_Start/FilterConfig.cs, permettant de filtrer tous les controllers de l'application
 * 
 * Les status des réponses HTTP:
 * 1xx: informations générales
 * 2xx: requête exécutée avec succès
 * 3xx: redirections
 * 4xx: erreurs côté client
 * 5xx: erreurs côté serveur
 * 
 */