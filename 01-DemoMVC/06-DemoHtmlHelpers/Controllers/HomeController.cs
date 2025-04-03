using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _06_DemoHtmlHelpers.Controllers
{

    public class Formation
    {
        public int Id { get; set; }
        public string Nom { get; set; }

    }

    public class Centre
    {
        public int Id { get; set; }
        public string Nom { get; set; }

    }

    public class HomeController : Controller
    {

        public List<Formation> lstFormations = new List<Formation>()
        {
            new Formation {Id = 1, Nom = "ASP.NET" },
            new Formation {Id = 2, Nom = "Java" },
            new Formation {Id = 1, Nom = "Android" }
        };

        public List<Centre> lstCentres = new List<Centre>()
        {
            new Centre {Id = 1, Nom = "Paris" },
            new Centre {Id = 2, Nom = "Nantes" },
            new Centre {Id = 1, Nom = "Toulouse" }
        };

        public ActionResult Index()
        {
            SelectList formations = new SelectList(lstFormations, "Id","Nom");
            ViewBag.formations = formations;

            SelectList centres = new SelectList(lstCentres, "Id", "Nom");
            ViewBag.centres = centres;

            return View();
        }

        [HttpPost]
        public ActionResult Bonjour(string nom, string prenom, string poste, int formations, int centres)
        {
            return Content("Nom: " + nom + " Prénom: " + prenom + " Poste: " + poste+" Formation: " 
                + lstFormations[formations - 1].Nom+" Centre: " + lstCentres[centres - 1].Nom);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}