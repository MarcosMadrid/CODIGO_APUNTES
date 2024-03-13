using Microsoft.EntityFrameworkCore;
using MvcCoreCubosTienda.Data;
using MvcCoreCubosTienda.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

string conectionString = "";

builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();

#region SQL Server
conectionString = builder.Configuration.GetConnectionString("SqlServerCubos")!;
builder.Services.AddTransient<IRepositoryCubosBBDD, RepositorySqlServer>();
builder.Services.AddDbContext<CubosContextBBDD>(options =>
{
    options.UseSqlServer(conectionString);
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
