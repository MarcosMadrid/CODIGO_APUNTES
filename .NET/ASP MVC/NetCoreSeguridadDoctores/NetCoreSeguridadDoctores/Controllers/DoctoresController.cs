using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreSeguridadDoctores.Filters;
using NetCoreSeguridadDoctores.Models;
using NetCoreSeguridadDoctores.Repositories;

namespace NetCoreSeguridadDoctores.Controllers
{
    [AuthenFilterUser]
    public class DoctoresController : Controller
    {

        IRepositoryHospital repositoryHospital;

        public DoctoresController(IRepositoryHospital repositoryHospital)
        {
            this.repositoryHospital = repositoryHospital;
        }

        public async Task<IActionResult> Index()
        {
            List<Enfermo>? enfermos = await repositoryHospital.GetEnfermos();
            return View(enfermos);
        }

        public async Task<IActionResult> Details(string id)
        {
            Enfermo? enfermo = await repositoryHospital.GetEnfermo(id);
            return View(enfermo);
        }

        public async Task<IActionResult> EnfermosPartialView()
        {
            List<Enfermo>? enfermos = await repositoryHospital.GetEnfermos();
            return PartialView("_EnfermosTable", enfermos);
        }

        [AuthenFilterUser(Policy = "PERMISOSELEVADOS")]
        public async Task<IActionResult> DeleteEnfermo(string id)
        {
            Enfermo? enfermo = await repositoryHospital.GetEnfermo(id);
            if (enfermo == null)
            {
                return NotFound();
            }
            bool accion = await repositoryHospital.DeleteEnfermo(id);
            if (accion)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [AuthenFilterUser(Policy = "SOLO RICOS")]
        public IActionResult SoloRicos()
        {
            return View();
        }
    }
}
