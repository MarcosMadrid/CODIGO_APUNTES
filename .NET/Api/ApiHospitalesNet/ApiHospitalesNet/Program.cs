using ApiHospitalesNet.Data;
using ApiHospitalesNet.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
string connectionString = string.Empty;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

#region SQLServer Connection
connectionString = builder.Configuration.GetConnectionString("SqlServerHospital")!;
builder.Services.AddTransient<RepositoryHospital>();
builder.Services.AddDbContext<HospitalContext>(options =>
{
    options.UseSqlServer(connectionString);
});
#endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Hospitales Api Prueba",
        Description = "Api de prueba en clase",
        Version = "1",
        Contact = new OpenApiContact()
        {
            Name = "Test",
            Email = "prueba@gmail.com"
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(
        url: "swagger/v1/swagger.json", name: "Api v1"
        );
    options.RoutePrefix = "";
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
