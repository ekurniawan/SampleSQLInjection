using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleASPCore.Models;
using SampleASPCore.Services;

namespace SampleASPCore.Controllers
{
    public class LoginController : Controller
    {
        private ILogin _login;
        public LoginController(ILogin login)
        {
            _login = login;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            var model = _login.ProcessLogin(login);
            if (model.Email != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}