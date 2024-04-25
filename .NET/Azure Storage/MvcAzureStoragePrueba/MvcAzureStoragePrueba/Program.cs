using Azure.Storage.Blobs;
using MvcAzureStoragePrueba.Services;

var builder = WebApplication.CreateBuilder(args);
string azureKeys = builder.Configuration.GetValue<string>("AzureKeys:StorageAccount")!;
BlobServiceClient blobServiceClient = new BlobServiceClient(azureKeys);
builder.Services.AddTransient<ServiceStorageBlobs>();
builder.Services.AddTransient<BlobServiceClient>(service => blobServiceClient);
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ServiceStorageFiles>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AzureFile}/{action=Index}/{id?}");

app.Run();
