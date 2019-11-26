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

        public IActionResult Index(){
            var model = new Restaurant{
                Id=1,
                Name="Gudeg Yu Djum"
            };

            return View(model);
        }
    }
}