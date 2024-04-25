using ApiHospitalesNet.Data;
using ApiHospitalesNet.Repositories;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
string connectionString = string.Empty;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Add services to the container.
builder.Services.AddAzureClients(factory =>
{
    factory.AddSecretClient
    (builder.Configuration.GetSection("KeyVault"));
});

//DEBEMOS PODER RECUPERAR UN OBJETO INYECTADO EN CLASES 
//QUE NO TIENEN CONSTRUCTOR
SecretClient secretClient = builder.Services.BuildServiceProvider().GetService<SecretClient>()!;
KeyVaultSecret secret = await secretClient.GetSecretAsync("secreto1-prueba");
connectionString = secret.Value;

#region SQLServer Connection
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
