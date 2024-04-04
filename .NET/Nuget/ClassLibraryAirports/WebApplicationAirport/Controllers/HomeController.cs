using ClassLibraryAirports.Models;
using ClassLibraryAirports.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationAirport.Models;

namespace WebApplicationAirport.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ServiceAirport serviceAirport;

        public HomeController(ILogger<HomeController> logger, ServiceAirport service)
        {
            _logger = logger;
            serviceAirport = service;
        }

        public async Task<IActionResult> Index()
        {
            AirportList airports = await serviceAirport.GetAirportsAsync();
            return View(airports.Airports);
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
