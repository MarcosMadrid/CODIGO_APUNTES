using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;
using MvcCoreAdoNet.Repositories;

namespace MvcCoreAdoNet.Controllers
{
    public class HospitalesController : Controller
    {
        HOSPITALBBDDConnector connectorHOSPITALES = new HOSPITALBBDDConnector();

        [HttpGet]
        public IActionResult HospitalesTable()
        {
            List<Hospital> hospitales = connectorHOSPITALES.GetHospitales();

            return View(hospitales);
        }

        [HttpGet]
        public IActionResult DetallesHospital(string idHospital)
        {
            Hospital hospital = connectorHOSPITALES.GetHospital(idHospital);
            return View(hospital);
        }
        [HttpPost, HttpGet]
        public IActionResult CrearHospital(Hospital? hospital)
        {

            if (hospital.IdHospital == 0)
            {
                return View();
            }
            connectorHOSPITALES.InsertHospital(hospital);
            return RedirectToAction("HospitalesTable");
        }

        [HttpGet]
        public IActionResult ModificarHospital(string idHospital)
        {
            Hospital hospital = connectorHOSPITALES.GetHospital(idHospital);
            return View(hospital);
        }

        [HttpPost]
        public IActionResult ModificarHospital(Hospital hospital)
        {
            connectorHOSPITALES.UpdateHospital(hospital);
            return RedirectToAction("HospitalesTable");
        }

        [HttpPost, HttpGet]
        public IActionResult EliminarHospital(string idHospital)
        {
            connectorHOSPITALES.DeleteHospital(idHospital);
            return RedirectToAction("HospitalesTable");
        }
    }
}
