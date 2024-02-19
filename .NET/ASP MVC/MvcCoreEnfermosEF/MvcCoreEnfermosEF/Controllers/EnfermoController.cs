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
    }
}
