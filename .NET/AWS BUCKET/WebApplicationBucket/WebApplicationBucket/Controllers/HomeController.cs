using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationBucket.Models;
using WebApplicationBucket.Services;

namespace WebApplicationBucket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ServiceStorageS3 serviceStorageS3;
        private object file;

        public HomeController(ILogger<HomeController> logger, ServiceStorageS3 serviceStorageS)
        {
            _logger = logger;
            serviceStorageS3 = serviceStorageS;
        }

        public async Task<IActionResult> Index()
        {
            List<S3Object>? objects = await serviceStorageS3.GetFiles();
            List<string> urls = new List<string>();
            if (objects != null)
            {
                foreach (S3Object item in objects)
                {
                    urls.Add(item.Key);
                }
            }
            return View(urls);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            await serviceStorageS3.UploadFile(file.FileName, file.OpenReadStream());
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetPrivate(string fileName)
        {
            using (var fs = await serviceStorageS3.StreamAsync(fileName))
            {
                file = new FormFile(fs, 0, fs.Length, "name", fileName);
            }
            return File(file);
        }

        public async Task<IActionResult> DeleteFile(string name)
        {
            await serviceStorageS3.DeleteFile(name);
            return RedirectToAction("Index");
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
