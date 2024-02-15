using Microsoft.AspNetCore.Mvc;
using NetCoreLinqToSqlInjection.Models;

namespace NetCoreLinqToSqlInjection.Controllers
{
    public class CochesController : Controller
    {
        private ICoche car;

        public CochesController(ICoche coche)
        {
            car = coche;
        }

        public IActionResult Index()
        {
            return View(car);
        }

        [HttpPost]
        public IActionResult Action(string action)
        {
            if (action.ToLower().Equals("acelerar"))
            {
                car.Acelerar();
            }
            else
            {
                car.Frenar();
            }
            return RedirectToAction("Index");
        }
    }
}
