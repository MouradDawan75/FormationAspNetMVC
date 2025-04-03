using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _06_DemoHtmlHelpers.Models;

namespace _06_DemoHtmlHelpers.Controllers
{
    public class EmployeController : Controller
    {
        
        public ActionResult Index()
        {
            List<Departement> departements = new List<Departement>()
            {
                new Departement{DepartementId = 1, Nom = "Informatique"},
                new Departement{DepartementId = 2, Nom = "Recherche"},
                new Departement{DepartementId = 3, Nom = "Développement"}
            };

            SelectList sl = new SelectList(departements, "DepartementId", "Nom");
            TempData["DepartementId"] = sl;
            TempData.Keep();

            Employe emp = new Employe
            {
                Id = 1,
                Nom = "Jean",
                Salaire = 2500,
                isActif = false,
                DateEntree = DateTime.Now,
                DepartementId = 3,
                EmployeType = EmployeType.SENIOR
            };


            return View(emp);
        }

        [HttpPost]
        public ActionResult Index(Employe emp)
        {
            /*
             * Un client envoi une rêquête vers le server
             * 1- Un objet ModelState est crée en memoire et contient les données transmises par le client
             * 2- Dans la vue un objet Employe (Model) est crée à partir du ModelState
             * 3- Les Html Helper utilisent le ModelState à la place du Model
             * 
             * Option1: modifier le ModelState
             * Option2: utiliser la validation des formulaires
             * 
             */
            ModelState.Clear();
            emp.Nom = "New Name"; //un nouvel ModelState sera crée à partir de emp
            return View(emp);
        }
    }
}