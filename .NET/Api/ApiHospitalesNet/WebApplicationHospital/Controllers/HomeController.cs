using ApiHospitalesNet.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Text.Json.Serialization;
using WebApplicationHospital.Models;
using WebApplicationHospital.Services;

namespace WebApplicationHospital.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        SeviceHospitalesApi serviceHospitales;

        public HomeController(ILogger<HomeController> logger, SeviceHospitalesApi seviceHospitales)
        {
            _logger = logger;
            this.serviceHospitales = seviceHospitales;

        }

        public async Task<IActionResult> Index()
        {
            List<Hospital> hospitalList = await serviceHospitales.GetHospitales();
            ViewData["HostApiHospital"] = serviceHospitales.domainHospitalApi;
            return View(hospitalList);
        }

        public async Task<IActionResult> Details(int id)
        {
            Hospital hospital = await serviceHospitales.GetHospital(id);            
            return View(hospital);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
