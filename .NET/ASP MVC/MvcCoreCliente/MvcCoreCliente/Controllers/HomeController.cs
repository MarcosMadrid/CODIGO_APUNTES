using Microsoft.AspNetCore.Mvc;
using MvcCoreCliente.Models;
using MvcCoreCliente.Services;
using System.Diagnostics;

namespace MvcCoreCliente.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        MetodosVariosService metodosVariosService;

        public HomeController(ILogger<HomeController> logger, MetodosVariosService metodosVariosService)
        {
            _logger = logger;
            this.metodosVariosService = metodosVariosService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Multiplicar(int num)
        {
            int[] ints = await metodosVariosService.GetMultiplicar(num);
            return View(ints);
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
