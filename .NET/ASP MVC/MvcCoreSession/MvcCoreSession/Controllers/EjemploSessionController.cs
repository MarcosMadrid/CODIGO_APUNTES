using Microsoft.AspNetCore.Mvc;
using MvcCoreSession.Helper.HelperBinarySection;
using MvcCoreSession.Helpers.Path;
using MvcCoreSession.Models;

namespace MvcCoreSession.Controllers
{
    public class EjemploSessionController : Controller
    {

        private HelperPathProvider helperPathProvider;
        static int numero = 1;

        public EjemploSessionController(HelperPathProvider pathProvider)
        {
            this.helperPathProvider = pathProvider;
        }

        public IActionResult Index()
        {
            numero++;
            ViewData["NUMERO"] = numero;
            return View();
        }

        public IActionResult SessionSimple(string? accion)
        {
            if (accion != "mostrar")
            {
                return View();
            }
            HttpContext.Session.SetString("nombre", "Programeitor");
            HttpContext.Session.SetString("hora", DateTime.Now.ToString());

            ViewData["USUARIO"] = HttpContext.Session.GetString("nombre");
            ViewData["hora"] = HttpContext.Session.GetString("hora");
            return RedirectToAction("Index");
        }

        public IActionResult SessionMascotaJson(string accion)
        {
            if (accion == null)
            {
                return View();
            }

            if (accion.ToLower() == "almacenar")
            {
                Mascota mascota = new Mascota();
                mascota.Nombre = "Yo";
                mascota.Raza = "Humano";
                mascota.Edad = 21;

                byte[] mascotaByte = HelperBinarySection.ObjectToByte(mascota);
                HttpContext.Session.Set("MASCOTA", mascotaByte);
            }
            else if (accion.ToLower() == "mostrar")
            {
                byte[]? mascotaByte = HttpContext.Session.Get("MASCOTA");
                if (mascotaByte != null)
                {
                    Mascota? mascota = HelperBinarySection.ByteToObject<Mascota>(mascotaByte);
                    ViewData["MASCOTA"] = mascota;
                }
            }

            return View();
        }

        public IActionResult SessionMascotaString(string accion)
        {
            if (accion == null)
            {
                return View();
            }

            if (accion.ToLower() == "almacenar")
            {
                Mascota mascota = new Mascota();
                mascota.Nombre = "Yo";
                mascota.Raza = "Humano";
                mascota.Edad = 21;

                string mascotaJson = HelperJson.ObjectToJson(mascota);
                HttpContext.Session.SetString("MASCOTA", mascotaJson);
            }
            else if (accion.ToLower() == "mostrar")
            {
                string? mascotaJson = HttpContext.Session.GetString("MASCOTA");
                if (mascotaJson != null)
                {
                    Mascota? mascota = HelperJson.JsonToObject<Mascota>(mascotaJson);
                    ViewData["MASCOTA"] = mascota;
                }
            }

            return View();
        }

        public IActionResult FormFile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FormFile(IFormFile file)
        {
            string pathFile = this.helperPathProvider.MapPath(file.FileName, Folders.Uploads);
            string pathServer = this.helperPathProvider.CreateHostPath(pathFile);
            using (Stream stream = new FileStream(pathFile, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            ViewBag.src = pathServer;
            return View();
        }
    }
}
