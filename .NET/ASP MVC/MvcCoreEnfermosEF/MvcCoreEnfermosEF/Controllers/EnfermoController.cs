using Microsoft.AspNetCore.Mvc;
using MvcCoreEnfermosEF.Models;
using MvcCoreEnfermosEF.Repositories;

namespace MvcCoreEnfermosEF.Controllers
{
    public class EnfermoController : Controller
    {
        private EnfermoRepository enfermoRepository;

        public EnfermoController(EnfermoRepository enfermoRepository)
        {
            this.enfermoRepository = enfermoRepository;
        }

        public IActionResult Index()
        {
            List<Enfermo> enfermo = enfermoRepository.GetEnfermos();
            return View(enfermo);
        }

        public IActionResult Details(string id)
        {
            Enfermo? enfermo = enfermoRepository.GetEnfermo(id);
            return View(enfermo);
        }

        public IActionResult UpdateForm(string id)
        {
            return View();
        }

        public IActionResult UpdateAction(Enfermo enfermo)
        {
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEnfermo(string id)
        {
            enfermoRepository.DeleteEnfermo(id);
            return RedirectToAction("Index");
        }

        public IActionResult InsertForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertForm(Enfermo enfermo)
        {
            enfermoRepository.InsertEnfermo(enfermo.Apellido, enfermo.NSS, enfermo.GeneroBioogico, enfermo.Direccion, enfermo.Fecha_Nac);
            return RedirectToAction("Index");
        }
    }
}
