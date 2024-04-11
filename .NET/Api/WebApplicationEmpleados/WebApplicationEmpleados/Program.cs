using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApplicationEmpleados.Data;
using WebApplicationEmpleados.Repositories;

var builder = WebApplication.CreateBuilder(args);
string connectionString = string.Empty;
// Add services to the container.


#region SqlServer Connection
connectionString = builder.Configuration.GetConnectionString("SqlServerEmpleados")!;
builder.Services.AddTransient<IRepositoryEmpleado, RepositoryEmpleadoSqlServer>();
builder.Services.AddDbContext<EmpleadosContext>(options =>
{
    options.UseSqlServer(connectionString);
});
#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api de empleados",
        Version = "v1",
        Description = "",
        Contact = new OpenApiContact()
        {
            Name = "Marcos Tajamar 2024",
            Email = "marcos@gmail.com"
        }
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(
        url: "/swagger/v1/swagger.json", name: "Api v1");

    options.RoutePrefix = "";
});



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
