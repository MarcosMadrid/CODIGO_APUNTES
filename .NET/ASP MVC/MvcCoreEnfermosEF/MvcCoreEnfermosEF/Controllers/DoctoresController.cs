using Microsoft.AspNetCore.Mvc;
using MvcCoreEnfermosEF.Models;
using MvcCoreEnfermosEF.Repositories;

namespace MvcCoreEnfermosEF.Controllers
{
    public class DoctoresController : Controller
    {
        private readonly RepositoryDoctores repositoryDoctores;

        public DoctoresController(RepositoryDoctores repositoryDoctores)
        {
            this.repositoryDoctores = repositoryDoctores;
        }

        public IActionResult Index()
        {
            List<Doctor>? doctors = repositoryDoctores.GetDoctors();
            ViewData["ESPECIALIDADES"] = repositoryDoctores.GetDoctorEspecialidades();
            return View(doctors);
        }

        public IActionResult IncrementarSalario(string especialidad, int incremento)
        {
            repositoryDoctores.SubirSalarioDoctoresEspecialidad(especialidad, incremento);
            ViewData["ESPECIALIDADES"] = repositoryDoctores.GetDoctorEspecialidades();
            List<Doctor>? doctors = repositoryDoctores.DoctoresEspecialidad(especialidad);
            return View("Index", doctors);
        }


    }
}
