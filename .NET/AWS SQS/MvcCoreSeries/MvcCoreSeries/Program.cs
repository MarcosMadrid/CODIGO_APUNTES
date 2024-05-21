using Microsoft.EntityFrameworkCore;
using MvcCoreSeries.Data;
using MvcCoreSeries.Repositories;

var builder = WebApplication.CreateBuilder(args);

string connectionString =
    builder.Configuration.GetValue<string>("TelevisionSql")!;
builder.Services.AddTransient<RepositoryTelevisionMySql>();
builder.Services.AddDbContext<TelevisionDbContext>
    (options => options.UseMySql(connectionString
    , ServerVersion.AutoDetect(connectionString)));
builder.Services.AddControllersWithViews();
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
