using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SampleASPCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("From ASP MVC Core !");
        }

        public IActionResult About()
        {
            return Content("Hello from from About");
        }
    }
}