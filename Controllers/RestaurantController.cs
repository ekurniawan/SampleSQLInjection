using Microsoft.AspNetCore.Mvc;
using SampleASPCore.Models;

namespace SampleASPCore.Controllers
{
    public class RestaurantController : Controller
    {
        public IActionResult Index(){
            var model = new Restaurant{
                Id=1,
                Name="Gudeg Yu Djum"
            };

            return View(model);
        }
    }
}