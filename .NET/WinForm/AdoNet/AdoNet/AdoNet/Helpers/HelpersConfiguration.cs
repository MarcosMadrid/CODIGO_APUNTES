using Microsoft.Extensions.Configuration;

namespace AdoNet.Helpers
{
    public class HelpersConfiguration
    {
        public static string GetConnectionString()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("config.json", true, true);
            IConfiguration configuration = builder.Build();
            string connectionString = configuration["SqlHospital"];
            return connectionString;
        }
    }
}
