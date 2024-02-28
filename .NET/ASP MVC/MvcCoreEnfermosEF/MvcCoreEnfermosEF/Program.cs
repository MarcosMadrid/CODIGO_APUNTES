using Microsoft.EntityFrameworkCore;
using MvcCoreEnfermosEF.Data;
using MvcCoreEnfermosEF.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//string connectionString = builder.Configuration.GetConnectionString("HospitalOracle");
//string connectionString = builder.Configuration.GetConnectionString("HospitalSqlServer");
string connectionString = builder.Configuration.GetConnectionString("HospitalMySQL");
builder.Services.AddTransient<IRepoitoryHospital, RepositoryViewEmpleadosMySQL>();
builder.Services.AddDbContextPool<HospitalBBDDContext>
     (options => options.UseMySql(connectionString
    , ServerVersion.AutoDetect(connectionString)));

builder.Services.AddTransient<EnfermoRepository>();
builder.Services.AddTransient<RepositoryDoctores>();
builder.Services.AddTransient<RepositoryTrabajadores>();

//builder.Services.AddDbContext<HospitalBBDDContext>
//    (options => options.UseSqlServer(connectionString));

//builder.Services.AddTransient<IRepoitoryHospital, RepositoryEmpleadosViewOracle>();
//builder.Services.AddDbContext<HospitalBBDDContext>
//    (options => options.UseOracle(connectionString,
//    options => options.UseOracleSQLCompatibility("11")));



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
