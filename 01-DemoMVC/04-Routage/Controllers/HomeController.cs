using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _04_Routage.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
        
        [Route("About/test")] //request param About/test?autorise
        public ActionResult About2(string autorise)
        {
            ViewBag.Message = "Your application description page.";
          

            return View();
        }
        
        [Route("About/{name:minlength(3)?}")] // ? param optionnel + contrainte -> path variable
        public ActionResult About(string name) // option2 pour les params optionnels: les initialiser dans la méthode
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Route("ContactUs/{id:int}")]
        public ActionResult Contact(int id)
        {
            ViewBag.Message = "Your contact page.";

            string url = Request.RawUrl;

            //Extraire les request param: ?autorise=true
            string autorise = Request.Params["autorise"].ToString();
            string autorise2 = Request.QueryString["autorise"];

            //Les variables de path:/{id}
            int id2 = (int)RouteData.Values["id"];
            string controllerName = RouteData.Values["controller"].ToString();
            string actionName = RouteData.Values["action"].ToString();



            return View();
        }
    }
}

/*
 Liste des contraintes pour les path variables

{param:bool} = Boolean value
{param:datetime} = DateTime value
{param:decimal} = Decimal value
{param:double} = Double value
{param:float} = Single value
{param:guid} = Guid value
{param:int} = Int32 value
{param:long} = Int64 value
{param:minlength(n)} = string value with at least N number of characters (i.e. {param:minlength(5)} )
{param:maxlength(n)} = string value with less than N number of characters (i.e. {param:maxlength(5)} )
{param:length(n)} = string value with exactly N number of characters (i.e. {param:length(3)})
{param:length(minNumber,maxNumber)} = string value with minimum character and maximum character length.
{param:min(n)} = An Int64 value that is greater than or equal to N.(i.e. {param:min(2)})
{param:max(n)} = An Int64 value that is less than or equal to N.(i.e. {param:min(10)})
{param:range(min,max)}= An Int64 value that should be within range. (i.e. {param:range(2,5)})
{param:alpha} =s tring value containing only the A–Z and a–z characters
{param:regex (pattern)} = (i.e {param:regex (\d+)}) match only number
 */