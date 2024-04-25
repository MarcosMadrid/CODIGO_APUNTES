using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Mvc;
using MvcKeyVault.Models;
using System.Diagnostics;

namespace MvcKeyVault.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SecretClient secretClient;

        public HomeController(ILogger<HomeController> logger, SecretClient secretClient)
        {
            _logger = logger;
            this.secretClient = secretClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string secretKey)
        {
            KeyVaultSecret keyVaultSecret = await secretClient.GetSecretAsync(secretKey);
            ViewData["MENSAJE"] = keyVaultSecret.Value;
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
