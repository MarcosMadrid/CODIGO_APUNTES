using Microsoft.EntityFrameworkCore;
using MvcDockersComics.Data;
using MvcDockersComics.Repositories;

var builder = WebApplication.CreateBuilder(args);
string connectionString = string.Empty;
// Add services to the container.


connectionString = builder.Configuration.GetConnectionString("MySql")!;
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<RepositoryComics>();
builder.Services.AddDbContext<ComicsContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});


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
