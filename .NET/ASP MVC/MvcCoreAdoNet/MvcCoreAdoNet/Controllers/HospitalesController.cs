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
    }
}
