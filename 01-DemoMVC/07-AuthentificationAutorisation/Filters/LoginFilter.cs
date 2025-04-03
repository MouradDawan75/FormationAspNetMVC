using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _07_AuthentificationAutorisation.Filters
{
    public class LoginFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["Username"] == null)
            {
                //redirection vers la page login
                filterContext.HttpContext.Response.Redirect("~/Account/Login");
            }
            
        }
    }
}