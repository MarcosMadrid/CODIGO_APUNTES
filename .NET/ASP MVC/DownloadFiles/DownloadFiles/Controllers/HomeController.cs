using DownloadFiles.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;

namespace DownloadFiles.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IWebHostEnvironment CurrentEnvironment { get; set; }
        private string cancionNombre = "cancion.mp3";

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment currentEnvironment)
        {
            _logger = logger;
            CurrentEnvironment = currentEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DownloadFileZip()
        {
            string filePath = Path.Combine(CurrentEnvironment.WebRootPath, "Archivos", cancionNombre);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            using (var zipFileMemoryStream = new MemoryStream())
            {
                using (ZipArchive archive = new ZipArchive(zipFileMemoryStream, ZipArchiveMode.Create, leaveOpen: true))
                {
                    var fileName = Path.GetFileName(filePath);
                    var entry = archive.CreateEntry(fileName);
                    using (var entryStream = entry.Open())
                    using (var fileStream = System.IO.File.OpenRead(filePath))
                    {
                        await fileStream.CopyToAsync(entryStream);
                    }
                }
                var finalMemoryStream = new MemoryStream(zipFileMemoryStream.ToArray());
                finalMemoryStream.Seek(0, SeekOrigin.Begin);
                return File(finalMemoryStream, "application/octet-stream", "archivo-zip.zip");
            }
        }

        public IActionResult DownloadFile()
        {
            string filePath = Path.Combine(CurrentEnvironment.WebRootPath, "Archivos", cancionNombre);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }
            return File(System.IO.File.OpenRead(filePath), "application/octet-stream", Path.GetFileName(filePath));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
