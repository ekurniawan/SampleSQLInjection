using Microsoft.AspNetCore.Mvc;
using SampleASPCore.Models;
using SampleASPCore.Services;

namespace SampleASPCore.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantData _resto;
        public RestaurantController(IRestaurantData resto)
        {
            _resto = resto;
        }

        public IActionResult GetData(){
            var models = _resto.GetAll();
            return View(models);
        }

        public IActionResult Details(int id){
            var model = _resto.GetById(id);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Restaurant resto)
        {
            try
            {
                _resto.Insert(resto);
                return RedirectToAction("GetData");
            }
            catch (System.Exception ex)
            {
                ViewBag.Error = $"Kesalahan: {ex.Message}";
                return View();
            }
        }

        public IActionResult Index(){
            var model = new Restaurant{
                Id=1,
                Name="Gudeg Yu Djum"
            };

            return View(model);
        }
    }
}