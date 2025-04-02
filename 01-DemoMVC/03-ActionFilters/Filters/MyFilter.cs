using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _03_ActionFilters.Filters
{
    public class MyFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //base.OnActionExecuted(filterContext);
            log("OnActionExecuted", filterContext.RouteData);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //base.OnActionExecuting(filterContext);
            log("OnActionExecuting", filterContext.RouteData);
            
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //base.OnResultExecuted(filterContext);
            log("OnResultExecuted", filterContext.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            // base.OnResultExecuting(filterContext);
            log("OnResultExecuting", filterContext.RouteData);
        }

        private void log(string methodName, RouteData routeData)
        {
            //Accéder aux valeurs du routage
            string actionName, controllerName;
            controllerName = routeData.Values["controller"].ToString();
            actionName = routeData.Values["action"].ToString();

            string result = string.Format("1-Méthode: {0} - Controller Name: {1} - Action Name: {2}", methodName, controllerName, actionName);
            System.Diagnostics.Debug.WriteLine(result);

            //Le context de l'application: l'application en cours d'exécution
            HttpContext.Current.Response.Write(result);
        }
    }
}