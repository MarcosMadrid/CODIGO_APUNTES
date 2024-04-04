// See https://aka.ms/new-console-template for more information
using ConsoleAppChollometro.Data;
using ConsoleAppChollometro.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

string connectionString = "Data Source=marcossql.database.windows.net;Initial Catalog=AZURETAJAMAR;Persist Security Info=True;User ID=adminsql;Password=Admin123;Trust Server Certificate=True";

var provider = new ServiceCollection()
    .AddTransient<RepositoryChollometro>()
    .AddDbContext<CholloContext>(options =>
        {
            options.UseSqlServer(connectionString);
        })
    .BuildServiceProvider();

RepositoryChollometro repository = provider.GetService<RepositoryChollometro>();
await repository.PopulateChollosAzure();