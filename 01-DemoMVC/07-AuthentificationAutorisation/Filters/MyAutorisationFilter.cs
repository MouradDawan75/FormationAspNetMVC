using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _07_AuthentificationAutorisation.Filters
{
    public class MyAutorisationFilter : AuthorizeAttribute
    {
        private readonly string[] allowedRoles;

        public MyAutorisationFilter(params string[] allowedRoles)
        {
            this.allowedRoles = allowedRoles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var userId = Convert.ToString(httpContext.Session["UserId"]);
            if (!string.IsNullOrEmpty(userId)) 
            {
                var id = Convert.ToInt32(userId);

                using (var context = new MyContext())
                {
                    var userRole = (from u in context.Users
                                   join r in context.Roles on u.RoleId equals r.Id
                                   where u.Id == id
                                   select new {r.Name}).FirstOrDefault();

                    foreach (var role in allowedRoles)
                    {
                        if(role == userRole.Name)
                        {
                            return true;
                        }
                    }
                }
            
            }


            return false;
        }

        //Méthode optionnelle: permet de personnaliser la réponse à renvoyer au client
        //si ce dernier n'a pas l'autorisation nécessaire
        //Méthode qui s'exécute si autorisation refusée 
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //Afficher une page particulière
            //filterContext.HttpContext.Response.Redirect("~/Account/UnAuthorized");
            filterContext.Result = new RedirectToRouteResult(

                new RouteValueDictionary
                    {
                        {"controller","Account" },
                        {"action", "UnAuthorized" }
                    }

                );
        }
    }
}