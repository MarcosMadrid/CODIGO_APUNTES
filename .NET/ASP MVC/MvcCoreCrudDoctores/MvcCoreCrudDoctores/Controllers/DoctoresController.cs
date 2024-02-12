using Microsoft.AspNetCore.Mvc;
using MvcCoreCrudDoctores.Models;
using MvcCoreCrudDoctores.Repositories;

namespace MvcCoreCrudDoctores.Controllers
{
    public class DoctoresController : Controller
    {
        RepositoryDoctores repositoryDoctores = new RepositoryDoctores();

        [HttpGet]
        public IActionResult DoctoresTable()
        {
            List<Doctor> doctores = repositoryDoctores.GetDoctoresAsync().Result;
            return View(doctores);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteDoctor(string doctor_cod)
        {
            await repositoryDoctores.DeleteDoctor(doctor_cod);
            return RedirectToAction("DoctoresTable");
        }

        [HttpGet]
        public IActionResult PostDoctor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostDoctor(Doctor doctor)
        {
            await repositoryDoctores.InsertDoctor(doctor);
            return RedirectToAction("DoctoresTable");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDoctor(string doctor_cod)
        {
            Doctor? doctor = await repositoryDoctores.GetDoctorAsync(doctor_cod);
            return View(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDoctor(Doctor doctor)
        {
            await repositoryDoctores.UpdateDoctor(doctor);
            return RedirectToAction("DoctoresTable");
        }

        [HttpGet]
        public async Task<IActionResult> ViewDoctor(string doctor_cod)
        {
            Doctor? doctor = await repositoryDoctores.GetDoctorAsync(doctor_cod);

            if (doctor == null)
            {
                return RedirectToAction("DoctoresTable");
            }
            else
            {
                return View();
            }
        }
    }
}
