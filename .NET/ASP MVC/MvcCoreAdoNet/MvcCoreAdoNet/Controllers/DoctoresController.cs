using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Repositories;
using MvcCoreAdoNet.Models;

namespace MvcCoreAdoNet.Controllers
{
    public class DoctoresController : Controller
    {
        RepositoryDoctores repositoryDoctores = new RepositoryDoctores();

        [HttpGet, HttpPost]
        public IActionResult DoctoresTable(string? especialidad)
        {
            List<Doctor> doctors = new List<Doctor>();
            List<string> especialidades = repositoryDoctores.GetEspecialidadesDoctores();
            if (especialidad == null)
            {
                doctors = repositoryDoctores.GetDoctores();
            }
            else
            {
                doctors = repositoryDoctores.GetDoctoresEspecialidad(especialidad);

            }
            ViewBag.Especialidades = especialidades;

            return View(doctors);
        }

        [HttpPost]
        public IActionResult ModificarDoctor(Doctor doctor)
        {
            repositoryDoctores.UpdateDoctor(doctor);
            return RedirectToAction("DoctoresTable");
        }

    }
}
