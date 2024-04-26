using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Mvc;
using MvcCoreInsights.Models;
using System.Diagnostics;

namespace MvcCoreInsights.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private TelemetryClient telemetryClient;

        public HomeController(ILogger<HomeController> logger, TelemetryClient telemetryClient)
        {
            _logger = logger;
            this.telemetryClient = telemetryClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string usuario, int cantidad)
        {
            ViewData["MENSAJE"] = usuario + "|" + cantidad;
            telemetryClient.TrackEvent("DonativosRequest");
            MetricTelemetry metric = new MetricTelemetry();
            metric.Name = "Donativos";
            metric.Sum = cantidad;
            this.telemetryClient.TrackMetric(metric);
            string mensaje = "";
            SeverityLevel severityLevel;
            switch (cantidad)
            {
                case
                0:
                    severityLevel = SeverityLevel.Error;
                    break;
                case var _ when (cantidad <= 5):
                    severityLevel = SeverityLevel.Critical;
                    break;
                default:
                    severityLevel = SeverityLevel.Information;
                    break;
            }
            TraceTelemetry traceTelemetry = new TraceTelemetry(mensaje,severityLevel);
            telemetryClient.TrackTrace(traceTelemetry);
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
