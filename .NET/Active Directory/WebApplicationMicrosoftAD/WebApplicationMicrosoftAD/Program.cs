using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApplicationMicrosoftAD.Data;

var builder = WebApplication.CreateBuilder(args);
string connectionString = string.Empty;
string appId = builder.Configuration.GetValue<string>("Authentication:Microsoft:ApplicationID")!;
string secretKey = builder.Configuration.GetValue<string>("Authentication:Microsoft:SecretKey")!;

#region SqlServer 
connectionString = builder.Configuration.GetConnectionString("SqlLocal")!;
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(connectionString);
});
#endregion

builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<ApplicationContext>();
builder.Services.AddAuthentication().AddMicrosoftAccount(options =>
{
    options.ClientId = appId;
    options.ClientSecret = secretKey;
});

builder.Services.AddControllersWithViews(options =>
{
    options.EnableEndpointRouting = false;
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseMvc(routes =>
{
    routes.MapRoute(name: "default", template: "{controller=Usuarios}/{action=Index}/{id?}");
});

app.Run();
