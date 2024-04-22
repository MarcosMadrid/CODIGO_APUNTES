using MvcCoreCacheRedis.Helpers;
using MvcCoreCacheRedis.Repositories;
using MvcCoreCacheRedis.Services;

var builder = WebApplication.CreateBuilder(args);
string cacheRedisKeys = builder.Configuration.GetValue<string>("ApiKeys:CacheRedis")!;

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = cacheRedisKeys;
});
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<RepositoryProductos>();
builder.Services.AddTransient<HelperPathProvider>();
builder.Services.AddTransient<ServiceCacheRedis>();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
