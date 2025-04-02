using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02_DemoController.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public string Index()
        {
            return "Nom: Dawan";
        }
    }
}