using Microsoft.AspNetCore.Mvc;
using MvcCoreSasStorage.Models;
using MvcCoreSasStorage.Services;

namespace MvcCoreSasStorage.Controllers
{
    public class HomeController : Controller
    {
        ServiceAzureAlumnos azureAlumnos;

        public HomeController(ServiceAzureAlumnos azureAlumnos)
        {
            this.azureAlumnos = azureAlumnos;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListAlumnos(string curso)
        {
            List<Alumno>? alumnos = new List<Alumno>();
            alumnos = await azureAlumnos.GetAlumnosAsync(curso);
            return View(alumnos);
        }
    }
}
