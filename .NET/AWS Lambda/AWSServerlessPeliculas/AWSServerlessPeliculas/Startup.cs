using AWSServerlessPeliculas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Amazon.Lambda.Annotations;
using AWSServerlessPeliculas.Repositories;

namespace AWSServerlessPeliculas;

[LambdaStartup]
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true);

        var configuration = builder.Build();
        services.AddSingleton<IConfiguration>(configuration);

        var connectionString = configuration.GetConnectionString("MySql")!;

        services.AddTransient<RepositoryPelicula>();
        services.AddDbContext<PeliculasDbContext>(options =>
            options.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString)
            )
        );
    }
}
