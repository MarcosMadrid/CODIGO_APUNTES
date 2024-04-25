using Azure.Data.Tables;
using Azure.Data.Tables.Sas;

namespace ApiStorageTokens.Services
{
    public class ServiceSasToken
    {
        private TableClient tablaAlumnos;

        public ServiceSasToken(IConfiguration configuration)
        {
            string azureKey = configuration.GetValue<string>("AzureKeys:StorageAccount")!;
            TableServiceClient tableService = new TableServiceClient(azureKey);
            tableService.CreateTableIfNotExistsAsync("alumnos").Wait();
            tablaAlumnos = tableService.GetTableClient("alumnos");
        }

        public string GenerateToken(string curso)
        {
            TableSasPermissions permissions = TableSasPermissions.Read;
            TableSasBuilder sasBuilder = new TableSasBuilder("alumnos", permissions, DateTime.Now.AddMinutes(15));
            sasBuilder.PartitionKeyStart = curso;
            sasBuilder.PartitionKeyEnd = curso;
            Uri token = tablaAlumnos.GenerateSasUri(sasBuilder);
            return
                token.AbsoluteUri;
        }
    }
}
