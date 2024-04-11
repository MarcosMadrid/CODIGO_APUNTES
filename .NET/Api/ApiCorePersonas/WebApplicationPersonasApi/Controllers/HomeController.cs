using ApiCorePersonas.Controllers;
using ApiCorePersonas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationPersonasApi.Models;

namespace WebApplicationPersonasApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Persona> personaList = new List<Persona>
                {
                    new Persona { Id = 1, Name = "John Doe", Email = "john@example.com", Age = 30 },
                    new Persona { Id = 2, Name = "Jane Smith", Email = "jane@example.com", Age = 25 },
                    new Persona { Id = 3, Name = "Michael Johnson", Email = "michael@example.com", Age = 40 },
                    new Persona { Id = 4, Name = "Emily Brown", Email = "emily@example.com", Age = 35 },
                    new Persona { Id = 5, Name = "David Lee", Email = "david@example.com", Age = 28 },
                    new Persona { Id = 6, Name = "Sarah Williams", Email = "sarah@example.com", Age = 32 },
                    new Persona { Id = 7, Name = "Chris Wilson", Email = "chris@example.com", Age = 45 }
                };
            return View();
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
