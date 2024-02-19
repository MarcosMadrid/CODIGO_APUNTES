using Microsoft.AspNetCore.Mvc;
using MvcNetCoreEF.Models;
using MvcNetCoreEF.Repositories;

namespace MvcNetCoreEF.Controllers
{
    public class HospitalesController : Controller
    {
        private RepositoryHospital repositoryHospital;
        public HospitalesController(RepositoryHospital repositoryHospital)
        {
            this.repositoryHospital = repositoryHospital;
        }

        public IActionResult Index()
        {
            List<Hospital>? hospitals = repositoryHospital.GetHospitales();
            return View(hospitals);
        }

        public IActionResult Details(int id)
        {
            Hospital? hospital = repositoryHospital.GetHospital(id);
            return View(hospital);
        }

        public IActionResult HospitalForm()
        {
            return View();
        }

        public IActionResult InsertHospital(Hospital hospital)
        {
            repositoryHospital.InsertHospital(hospital.IdHospital, hospital.Nombre, hospital.Direccion, hospital.Telefono, hospital.Camas);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteHospital(int id)
        {
            repositoryHospital.DeleteHospital(id);
            return RedirectToAction("Index");
        }
    }
}
