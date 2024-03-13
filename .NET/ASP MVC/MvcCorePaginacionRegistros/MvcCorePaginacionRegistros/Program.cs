using Microsoft.EntityFrameworkCore;
using MvcCorePaginacionRegistros.Data;
using MvcCorePaginacionRegistros.Repositories;

var builder = WebApplication.CreateBuilder(args);
string ConnectionString = "";
// Add services to the container.
builder.Services.AddControllersWithViews();

#region Sql Server
ConnectionString = builder.Configuration.GetConnectionString("SqlServerHospital")!;
builder.Services.AddTransient<RepositoryHospital>();
builder.Services.AddDbContext<HospitalContext>(
options => { options.UseSqlServer(ConnectionString); }
);
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
