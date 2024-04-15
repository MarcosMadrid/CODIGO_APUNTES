using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using MvcAzureStorageBlobs.Models;

namespace MvcAzureStoragePrueba.Services
{
    public class ServiceStorageBlobs
    {
        private BlobServiceClient client;

        public ServiceStorageBlobs(BlobServiceClient client)
        {
            this.client = client;
        }

        public async Task<List<string>> GetContainersAsync()
        {
            List<string> containers = new List<string>();
            await foreach (BlobContainerItem item in client.GetBlobContainersAsync())
            {
                containers.Add(item.Name);
            }
            return containers;
        }

        public async Task CreateContainersAsync(string containerName)
        {
            await client.CreateBlobContainerAsync(containerName, PublicAccessType.Blob);

        }

        public async Task DeleteContainerAsync(string name)
        {
            await client.DeleteBlobContainerAsync(name);
        }

        public async Task<List<BlobModel>> GetBlobModelsAsync(string name)
        {
            BlobContainerClient containerClient = client.GetBlobContainerClient(name);
            List<BlobModel> models = new List<BlobModel>();
            await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
            {
                BlobClient blobClient = containerClient.GetBlobClient(blobItem.Name);

                BlobModel blobModel = new BlobModel()
                {
                    Name = blobItem.Name,
                    Url = blobClient.Uri.AbsoluteUri,
                    Contenedor = name
                };
                models.Add(blobModel);
            }
            return models;
        }

        public async Task DeleteBlobAsync(string containerName, string blobName)
        {
            BlobContainerClient containerClient = client.GetBlobContainerClient(containerName);
            await containerClient.DeleteBlobIfExistsAsync(blobName);
        }

        public async Task UploadBlobAsync(string containerName, string blobName, Stream stream)
        {
            BlobContainerClient blobContainer = client.GetBlobContainerClient(containerName);
            await blobContainer.UploadBlobAsync(blobName, stream);
        }
    }
}
