using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult Index([Bind(Exclude = "Photo")]Salarie salarie, HttpPostedFileBase photo)
        {
            /*
             * D'une manière générale, les fichiers sont exclus dans le processus de la validation du model.
             * Ils doivent être gérés à part.
             * 
             * [Bind(Exclude = "Photo")]: permet d'exclure l'attribut Photo dans la validation car 
             * le fichier est contenu dans HttpPostedFileBase photo
             * 
             */
            if(photo == null)
            {
                ViewBag.Photo = "Photo obligatoire....";
                return View(salarie);
            }
            //Vérifier l'extension du fichier

            string extension = Path.GetExtension(photo.FileName);

            if(extension.Equals(".jpg") || extension.Equals(".jpeg") || extension.Equals(".png"))
            {
                if (ModelState.IsValid)
                {
                    //Save de l'image

                    //personnaliser le nom de l'image
                    string fileName = salarie.UserName + Path.GetFileName(photo.FileName);
                    salarie.Photo = fileName;
                    string path = Server.MapPath("~/Content/images/"+fileName);
                    photo.SaveAs(path);

                    //inserer en BD


                    return View("Contact", salarie);
                }
            }
            else
            {
                ViewBag.Extension = "Formats valides: jpg,jpeg,png";
                return View(salarie);
            }

           

            return View(salarie);
        }
    }
}