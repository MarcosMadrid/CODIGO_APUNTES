using Microsoft.AspNetCore.Mvc;
using MvcCoreLinqToSql.Models;
using MvcCoreLinqToSql.Repositories;

namespace MvcCoreLinqToSql.Controllers
{
    public class EnfermosController : Controller
    {
        private RepositoryEnfermos repositoryEnfermos = new RepositoryEnfermos();

        public IActionResult EnfermosTable()
        {
            List<Enfermo>? enfermos = null;

            enfermos = repositoryEnfermos.GetEnfermosList();

            return View(enfermos);
        }

        [HttpGet, HttpPost]
        public async Task<IActionResult> DeleteEnfermo(string idEnfermo)
        {
            await repositoryEnfermos.DeleteEnfermoAsync(idEnfermo);
            return RedirectToAction("EnfermosTable");
        }

        [HttpGet]
        public IActionResult GetEnfermo(string idEnfermo)
        {
            Enfermo? enfermo = null;
            enfermo = repositoryEnfermos.GetEnfermo(idEnfermo);
            return View(enfermo);
        }
    }
}
