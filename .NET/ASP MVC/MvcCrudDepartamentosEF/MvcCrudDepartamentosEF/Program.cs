using Microsoft.EntityFrameworkCore;
using MvcCrudDepartamentosEF.Data;
using MvcCrudDepartamentosEF.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
string connectioncString = builder.Configuration.GetConnectionString("SqlDept");
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

builder.Services.AddTransient<RepositoryDepartamento>();
builder.Services.AddDbContext<DepartamentosContext>
    (options => options.UseSqlServer(connectioncString));
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
