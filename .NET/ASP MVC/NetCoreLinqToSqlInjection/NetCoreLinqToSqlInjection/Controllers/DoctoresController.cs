using Microsoft.AspNetCore.Mvc;
using NetCoreLinqToSqlInjection.Models;
using NetCoreLinqToSqlInjection.Repositories;

namespace NetCoreLinqToSqlInjection.Controllers
{
    public class DoctoresController : Controller
    {
        IRepositoryBBDDConnectorDocotres repositoryBBDD;

        public DoctoresController(IRepositoryBBDDConnectorDocotres repositoryBBDD)
        {
            this.repositoryBBDD = repositoryBBDD;
        }

        public IActionResult Index()
        {
            List<Doctor>? doctors = null;
            List<string?>? especialidades;

            doctors = repositoryBBDD.GetDoctors();
            especialidades = repositoryBBDD.GetEspecialidadesDoctores();

            ViewData["ESPECIALIDADES"] = especialidades;
            return View(doctors);
        }

        [HttpGet]
        public IActionResult DoctorForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostDoctor(Doctor doctor)
        {
            repositoryBBDD.InsertDoctor(doctor.DOCTOR_NO, doctor.APELLIDO, doctor.ESPECIALIDAD, doctor.SALARIO, doctor.HOSPITAL_COD);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetDoctor(string idDoctor)
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteDoctor(string idDoctor)
        {
            repositoryBBDD.DeleteDoctor(idDoctor);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DoctoresEspecialidad(string especialidad)
        {
            List<Doctor>? doctors = null;
            List<string?>? especialidades;

            doctors = repositoryBBDD.GetDoctorsEspecialidad(especialidad);
            especialidades = repositoryBBDD.GetEspecialidadesDoctores();

            ViewData["ESPECIALIDADES"] = especialidades;
            return View("Index", doctors);
        }
    }
}
