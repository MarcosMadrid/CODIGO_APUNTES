using Microsoft.EntityFrameworkCore;
using MvcCoreCryptography.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MvcCoreCryptography.Repository;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MvcCoreCryptography.Helpers;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "your-issuer",
        ValidAudience = "your-audience",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HOLA"))
    };
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<RepositoryUsers>();

string ConnectionString = builder.Configuration.GetConnectionString("SqlServerUserBBDD");
builder.Services.AddDbContext<UsersContext>
    (options => options.UseSqlServer(ConnectionString));
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
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

    // Define your token issuing endpoint
    endpoints.MapPost("/logIn", async context =>
    {
        var repository = context.RequestServices.GetRequiredService<RepositoryUsers>();
        var email = context.Request.Form["email"];
        var password = context.Request.Form["password"];

        var user = await repository.LogIn(email, password);
        if (user != null)
        {
            // Redirect to User/Index with user data serialized as JSON
            context.Response.Redirect($"/User/Index?userJson={JsonSerializer.Serialize(user)}");
        }
        else
        {
            // Redirect to Home/Index if login fails
            context.Response.Redirect("/Home/Index");
        }
    });
});



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
