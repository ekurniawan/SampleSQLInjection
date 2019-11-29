using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleASPCore.Models;
using Newtonsoft.Json;

namespace SampleASPCore.Controllers
{
    public class CekSessionController : Controller
    {
        public IActionResult Index()
        {
            var student = new Student
            {
                StudentID = 1,
                FirstMidName = "Erick",
                LastName = "Kurniawan"
            };

            var serStudent = JsonConvert.SerializeObject(student);
            HttpContext.Session.SetString("username", serStudent);
            return Content("Session berhasil dibuat");
        }

        public IActionResult GetSession()
        {
            if (HttpContext.Session.GetString("username")!=null)
            {
                var data = HttpContext.Session.GetString("username");
                var dataDes = JsonConvert.DeserializeObject<Student>(data);
                return Content($"Session :{dataDes.FirstMidName} {dataDes.LastName}");
            }
            else
            {
                return Content("Session tidak ditemukan");
            }
        }

        public IActionResult HapusSession()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Clear();
            return Content("Session berhasil didelete");
        }
    }
}