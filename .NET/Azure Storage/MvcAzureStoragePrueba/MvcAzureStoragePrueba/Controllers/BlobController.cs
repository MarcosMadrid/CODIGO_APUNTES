using Microsoft.AspNetCore.Mvc;
using MvcAzureStorageBlobs.Models;
using MvcAzureStoragePrueba.Services;

namespace MvcAzureStoragePrueba.Controllers
{
    public class BlobController : Controller
    {
        private ServiceStorageBlobs serviceStorageBlobs;

        public BlobController(ServiceStorageBlobs storageBlobs)
        {
            this.serviceStorageBlobs = storageBlobs;
        }

        public async Task<IActionResult> Index()
        {
            List<string> containeers = await serviceStorageBlobs.GetContainersAsync();
            return View(containeers);
        }

        [HttpGet]
        public async Task<IActionResult> CreateContainer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContainer(string containerName)
        {
            await this.serviceStorageBlobs.CreateContainersAsync(containerName);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteContainer(string containerName)
        {
            await serviceStorageBlobs.DeleteContainerAsync(containerName);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ListBlobs(string containerName)
        {
            await serviceStorageBlobs.GetBlobModelsAsync(containerName);
            return View();
        }

        public async Task<IActionResult> DeleteBlob(string containerName, string blobName)
        {
            await serviceStorageBlobs.DeleteBlobAsync(containerName, blobName);
            return RedirectToAction("ListBlobs", new {containerName = containerName});
        }

        public IActionResult UploadBlob(string containerName)
        {
            ViewData["CONTAINER"] = containerName;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadBlob(string containerName, IFormFile file)
        {
            string blobName = file.FileName;
            using(Stream stream = file.OpenReadStream())
            {
                await serviceStorageBlobs.UploadBlobAsync(containerName, blobName, stream);
            }
            return RedirectToAction("ListBlobs", new {containerName = containerName});
        }
    }
}
