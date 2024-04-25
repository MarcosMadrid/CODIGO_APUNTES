using Microsoft.AspNetCore.Mvc;
using MvcAzureStoragePrueba.Services;
using System.Diagnostics;

namespace MvcAzureStoragePrueba.Controllers
{
    public class AzureFileController : Controller
    {
        private ServiceStorageFiles serviceStorage;

        public AzureFileController(ServiceStorageFiles storageFiles)
        {
            this.serviceStorage = storageFiles;
        }

        public async Task<IActionResult> Index()
        {
            List<string> fileNames = await serviceStorage.GetFilesAsync();
            return View(fileNames);
        }

        public async Task<IActionResult> LoadFile(string fileName)
        {
            string data = await serviceStorage.ReadFilesAsync(fileName);
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> UploadFile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                Stream stream = file.OpenReadStream();
                string fileName = file.FileName;
                await serviceStorage.UploadFile(fileName, stream);
                ViewData["MENSAJE"] = "Archivo subido";
            }
            catch (Exception ex)
            {
                ViewData["MENSAJE"] = "Error: " + ex.Message;

            }
            return View();
        }

        public async Task<IActionResult> ReadFile(string fileName)
        {
            string data = await serviceStorage.ReadFilesAsync(fileName);
            ViewData["DATA"] = data;
            return View();
        }

        public async Task<IActionResult> DeleteFile(string fileName)
        {
            await serviceStorage.DeleteFile(fileName);
            return RedirectToAction("Index");
        }
    }
}
