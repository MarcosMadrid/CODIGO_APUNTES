using Microsoft.EntityFrameworkCore;
using NSwag.Generation.Processors.Security;
using NSwag;
using WebApplicationEmpleadosOauth.Data;
using WebApplicationEmpleadosOauth.Helpers;
using WebApplicationEmpleadosOauth.Repositories;

var builder = WebApplication.CreateBuilder(args);
string connectionString = string.Empty;
HelperActionServicesOauth helper = new HelperActionServicesOauth(builder.Configuration);
builder.Services.AddOpenApiDocument(document =>
{
    document.Title = "Api TechRiders";
    document.Description = "Api TechRiders.  Proyecto Alumnos 2023";
    // CONFIGURAMOS LA SEGURIDAD JWT PARA SWAGGER,
    // PERMITE AÑADIR EL TOKEN JWT A LA CABECERA.
    document.AddSecurity("JWT", Enumerable.Empty<string>(),
        new NSwag.OpenApiSecurityScheme
        {
            Type = OpenApiSecuritySchemeType.ApiKey,
            Name = "Authorization",
            In = OpenApiSecurityApiKeyLocation.Header,
            Description = "Copia y pega el Token en el campo 'Value:' así: Bearer {Token JWT}."
        }
    );
    document.OperationProcessors.Add(
    new AspNetCoreOperationSecurityScopeProcessor("JWT"));
});
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
#region SqlServer
connectionString = builder.Configuration.GetConnectionString("SqlServerHospital")!;
builder.Services.AddTransient<RepositoryHospital>();
builder.Services.AddDbContext<HospitalContext>(options =>
{
    options.UseSqlServer(connectionString);
});
#endregion

builder.Services.AddSingleton<HelperActionServicesOauth>(helper);
builder.Services.AddAuthentication(helper.GetAuthenticationSchema()).AddJwtBearer(helper.GetJwtBearerOptions());
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