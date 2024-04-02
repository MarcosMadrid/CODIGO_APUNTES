using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using PracticaMvcCore2Iniciales.Data;
using PracticaMvcCore2Iniciales.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

string connectionString = string.Empty;
builder.Services.AddControllersWithViews(options => options.EnableEndpointRouting = false);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie();
builder.Services.AddSession();

#region Sql Server Connection
connectionString = builder.Configuration.GetConnectionString("SqlServerTiendaLibro")!;
builder.Services.AddTransient<IRepositoryTiendaLibros, RepositorySqlServer>();
builder.Services.AddDbContext<TiendaLibrosContext>
    (options => options.UseSqlServer(connectionString));
#endregion

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "default",
        template: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
