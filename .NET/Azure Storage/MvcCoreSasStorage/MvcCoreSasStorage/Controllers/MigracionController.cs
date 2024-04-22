using Azure.Data.Tables;
using Microsoft.AspNetCore.Mvc;
using MvcCoreSasStorage.Helpers;
using MvcCoreSasStorage.Models;

namespace MvcCoreSasStorage.Controllers
{
    public class MigracionController : Controller
    {
        HelperXml helperXml;

        public MigracionController(HelperXml helperXml)
        {
            this.helperXml = helperXml;
        }

        public async Task<IActionResult> Index()
        {
            string azureKeys = "UseDevelopmentStorage=true";
            TableServiceClient serviceClient = new TableServiceClient(azureKeys);
            TableClient tableClient = serviceClient.GetTableClient("alumnos");
            await tableClient.CreateIfNotExistsAsync();
            List<Alumno> alumnos = this.helperXml.GetAlumnos();
            foreach (Alumno alm in alumnos)
            {
                await tableClient.AddEntityAsync(alm);
            }
            return View();
        }
    }
}
