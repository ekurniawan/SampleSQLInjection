using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SampleASPCore.Controllers
{
    //[Route("company/[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return Content("Hello from from About");
        }

        public IActionResult GetData()
        {
            string[] arrName = new string[] { "CSharp", "Blazor", "Java", "React Redux", "FSharp" };
            return new JsonResult(arrName);
        }
    }
}