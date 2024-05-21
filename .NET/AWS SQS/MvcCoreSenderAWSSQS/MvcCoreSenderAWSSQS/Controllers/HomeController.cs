using Microsoft.AspNetCore.Mvc;
using MvcCoreSenderAWSSQS.Models;
using MvcCoreSenderAWSSQS.Services;
using System.Diagnostics;

namespace MvcCoreSenderAWSSQS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ServiceSQS service;


        public HomeController(ILogger<HomeController> logger, ServiceSQS serviceSQS)
        {
            _logger = logger;
            this.service = serviceSQS;
        }

        [HttpPost]
        public async Task<IActionResult> Index(Mensaje mensaje)
        {
            await this.service.SendMessageAsync(mensaje);
            ViewData["MENSAJE"] = "Mensaje enviado a Queue SQS";
            return View();
        }

        public async Task<IActionResult> SeeMsj()
        {
           List<Mensaje> mensajes = new List<Mensaje>();
            mensajes = await this.service.RecieveMessagesAsync();
            return View(mensajes);
        }

        public async Task<IActionResult> Delete(string ReceiptHandler)
        {
            await this.service.DeleteMessage(ReceiptHandler);
            return RedirectToAction("SeeMsj");
        }

        public IActionResult Index()
        {
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
