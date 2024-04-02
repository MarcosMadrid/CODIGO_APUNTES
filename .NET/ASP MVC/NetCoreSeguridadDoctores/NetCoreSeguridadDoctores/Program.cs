using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using NetCoreSeguridadDoctores.Data;
using NetCoreSeguridadDoctores.Policies;
using NetCoreSeguridadDoctores.Repositories;

var builder = WebApplication.CreateBuilder(args);
string connectionString = "";
// Add services to the container.
builder.Services.AddControllersWithViews(options => options.EnableEndpointRouting = false);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("PERMISOSELEVADOS",
        policy => policy.RequireRole("Psiquiatría", "Cardiología"));
    options.AddPolicy("SOLO RICOS",
        policy => policy.Requirements.Add(new OverSalarioRequirement()));
});

#region Sql Server
connectionString = builder.Configuration.GetConnectionString("SqlServerHospital")!;
builder.Services.AddTransient<IRepositoryHospital, RepositoryHospitalSqlServer>();
builder.Services.AddDbContext<HospitalContext>(options =>
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

app.UseAuthentication();
app.UseAuthorization();

app.UseMvc(
    routes =>
    {
        routes.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}");
    });


app.Run();
