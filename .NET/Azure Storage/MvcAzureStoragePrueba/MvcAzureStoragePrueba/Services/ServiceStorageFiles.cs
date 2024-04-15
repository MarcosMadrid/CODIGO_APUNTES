using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

namespace MvcAzureStoragePrueba.Services
{
    public class ServiceStorageFiles
    {
        private ShareDirectoryClient root;

        public ServiceStorageFiles(IConfiguration configuration)
        {
            string keys = configuration.GetValue<string>("AzureKeys:StorageAccount")!;
            ShareClient client = new ShareClient(keys, "ejemplosfiles");
            root = client.GetRootDirectoryClient();
        }

        public async Task<List<string>> GetFilesAsync()
        {
            List<string> files = new List<string>();
            await foreach (ShareFileItem file in root.GetFilesAndDirectoriesAsync())
            {
                files.Add(file.Name);
            }
            return files;
        }

        public async Task<string> ReadFilesAsync(string fileName)
        {
            ShareFileClient fileClient = root.GetFileClient(fileName);
            ShareFileDownloadInfo downloadInfo = await fileClient.DownloadAsync();
            using (StreamReader reader = new StreamReader(downloadInfo.Content))
            {
                return
                    await reader.ReadToEndAsync();
            }
        }

        public async Task UploadFile(string fileName, Stream stream)
        {
            ShareFileClient fileClient = root.GetFileClient(fileName);
            await fileClient.CreateAsync(stream.Length);
            await fileClient.UploadAsync(stream);
        }

        public async Task DeleteFile(string fileName)
        {
            ShareFileClient fileClient = root.GetFileClient(fileName);
            await fileClient.DeleteIfExistsAsync();
        }
    }
}
