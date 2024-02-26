using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcEntityFrameWorkComics.Data;
using MvcEntityFrameWorkComics.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//string connectionString = builder.Configuration.GetConnectionString("ComicsSqlServer");
//builder.Services.AddTransient<IRepositoryBBDD, RepositoryComicsSQLServer>();
//builder.Services.AddDbContext<ComicBBDDContext>
//    (options => options.UseSqlServer(connectionString));

string connectionString = builder.Configuration.GetConnectionString("ComicsOracle");
builder.Services.AddTransient<IRepositoryBBDD, RepositoryComicsOracle>();
builder.Services.AddDbContext<ComicBBDDContext>
    (options => options.UseOracle(connectionString,
    options => options.UseOracleSQLCompatibility("11")));

//string connectionString = builder.Configuration.GetConnectionString("ComicsMySQL");
//builder.Services.AddTransient<IRepoitoryHospital, RepositoryViewEmpleadosMySQL>();
//builder.Services.AddDbContextPool<HospitalBBDDContext>
//     (options => options.UseMySql(connectionString
//    , ServerVersion.AutoDetect(connectionString)));

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
