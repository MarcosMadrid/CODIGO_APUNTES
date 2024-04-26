using Microsoft.AspNetCore.Mvc;
using MvcCoreLogicApps.Models;
using MvcCoreLogicApps.Services;
using System.Diagnostics;

namespace MvcCoreLogicApps.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ServiceLogicApps serviceLogicApps;

        public HomeController(ILogger<HomeController> logger, ServiceLogicApps serviceLogic)
        {
            _logger = logger;
            serviceLogicApps = serviceLogic;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string email, string asunto, string mensaje)
        {
            string result = "";
            try
            {
                await serviceLogicApps.SendEmail(email, asunto, mensaje);
                result = "Ok";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            ViewData["MENSAJE"] = result;
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
