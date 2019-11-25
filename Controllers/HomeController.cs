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

        public IActionResult LuasSegitiga(double alas,double tinggi){
            var hasil = 0.5 * alas * tinggi;
            ViewBag.Alas = alas;
            ViewBag.Tinggi = tinggi;
            ViewBag.Hasil = hasil;
            ViewBag.Username = "ekurniawan";
            return View("Index");
        }

        public IActionResult About(string nama,string alamat)
        {
            return Content($"Nama anda {nama} dan alamat {alamat}");
        }

        public IActionResult GetById(string id, string nama){
            return Content($"ID anda {id} dan nama {nama}");
        }

        public IActionResult GetData()
        {
            string[] arrName = new string[] { "CSharp", "Blazor", "Java", "React Redux", "FSharp" };
            return new JsonResult(arrName);
        }
    }
}