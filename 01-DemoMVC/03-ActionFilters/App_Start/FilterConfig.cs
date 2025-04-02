using System.Web;
using System.Web.Mvc;
using _03_ActionFilters.Filters;

namespace _03_ActionFilters
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new MyFilter());
        }
    }
}
