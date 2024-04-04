using ConsoleAppChollometro.Models;
using ConsoleAppChollometro.Repositories;
using Microsoft.AspNetCore.Mvc;
using MvcCoreChollometro.Models;
using System.Diagnostics;

namespace MvcCoreChollometro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private RepositoryChollometro repositoryChollometro;

        public HomeController(ILogger<HomeController> logger, RepositoryChollometro repositoryChollometro)
        {
            _logger = logger;
            this.repositoryChollometro = repositoryChollometro;
        }

        public async Task<IActionResult> Index()
        {
            List<Chollo> chollos = await repositoryChollometro.GetChollosAsync();
            chollos = chollos.OrderByDescending(x => x.Fecha).ToList();
            return View(chollos);
        }

        public async Task<IActionResult> Details(int id)
        {
            Chollo? chollo = await repositoryChollometro.GetCholloAsync(id);
            return View(chollo);
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
