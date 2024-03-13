using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MvcCoreEmpleados.Data;
using MvcCoreEmpleados.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

string connectionString = "";

#region Sql Server BBDD
connectionString = builder.Configuration.GetConnectionString("SqlServerEmpleados")!;
builder.Services.AddTransient<RepositoryViewEmpleadosSQLServer>();
builder.Services.AddDbContext<HospitalBBDDContext>(
    options =>
    {
        options.UseSqlServer(connectionString);
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
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
