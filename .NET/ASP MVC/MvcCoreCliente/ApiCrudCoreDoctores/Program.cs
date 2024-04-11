using ApiCrudCoreDoctores.Data;
using ApiCrudCoreDoctores.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connectionString = string.Empty;

#region SQLServer Doct
connectionString = builder.Configuration.GetConnectionString("SqlServerDoct");
builder.Services.AddTransient<IRepositoryDoct, RepositoryDoctores>();
builder.Services.AddDbContext<ContextDoctores>(options =>
{
    options.UseSqlServer(connectionString);
});
#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
