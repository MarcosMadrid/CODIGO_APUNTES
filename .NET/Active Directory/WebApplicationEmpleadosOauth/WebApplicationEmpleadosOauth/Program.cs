using Microsoft.EntityFrameworkCore;
using WebApplicationEmpleadosOauth.Data;
using WebApplicationEmpleadosOauth.Helpers;
using WebApplicationEmpleadosOauth.Repositories;

var builder = WebApplication.CreateBuilder(args);
string connectionString = string.Empty;
HelperActionServicesOauth helper = new HelperActionServicesOauth(builder.Configuration);

#region SqlServer
connectionString = builder.Configuration.GetConnectionString("SqlServerHospital")!;
builder.Services.AddTransient<RepositoryHospital>();
builder.Services.AddDbContext<HospitalContext>(options =>
{
    options.UseSqlServer(connectionString);
});
#endregion

builder.Services.AddSingleton<HelperActionServicesOauth>(helper);
builder.Services.AddAuthentication(helper.GetAuthenticationSchema());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Api Emp Hospitales");
    options.RoutePrefix = "";
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();