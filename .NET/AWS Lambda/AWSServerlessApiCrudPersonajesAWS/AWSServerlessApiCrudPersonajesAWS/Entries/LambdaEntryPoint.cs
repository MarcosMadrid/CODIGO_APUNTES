using Amazon.Lambda.AspNetCoreServer;
using Microsoft.AspNetCore.Hosting;

public class LambdaEntryPoint : APIGatewayProxyFunction
{
    protected override void Init(IWebHostBuilder builder)
    {
        builder
            .ConfigureServices(services =>
            {
                // Add services configuration here
                var startup = new Startup();
                startup.ConfigureServices(services);
            })
            .UseStartup<Startup>();
    }
}
