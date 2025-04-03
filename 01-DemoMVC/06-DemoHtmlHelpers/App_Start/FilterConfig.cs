using System.Web;
using System.Web.Mvc;

namespace _06_DemoHtmlHelpers
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
