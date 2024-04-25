using Microsoft.Azure.Cosmos;
using MvcCosmosAzure.Models;

namespace MvcCosmosAzure.Services
{
    public class ServiceCosmosDb
    {
        private CosmosClient clientCosmos;
        private Container containerCosmos;

        public ServiceCosmosDb(CosmosClient client, Container container)
        {
            this.clientCosmos = client;
            this.containerCosmos = container;
        }

        public async Task CreateDatabaseAsync()
        {
            ContainerProperties properties = new ContainerProperties("containercoches", "/id");

            await this.clientCosmos.CreateDatabaseIfNotExistsAsync("vehiculoscosmos");
            await this.clientCosmos.GetDatabase("vehiculoscosmos").CreateContainerIfNotExistsAsync(properties);
        }

        public async Task InsertVehiculoAsync(Vehiculo car)
        {
            await this.containerCosmos.CreateItemAsync<Vehiculo>(car, new PartitionKey(car.Id));
        }

        public async Task<List<Vehiculo>> GetVehiculosAsync()
        {
            var query = this.containerCosmos.GetItemQueryIterator<Vehiculo>();
            List<Vehiculo> coches = new List<Vehiculo>();
            while (query.HasMoreResults)
            {
                var results = await query.ReadNextAsync();
                coches.AddRange(results);
            }
            return coches;
        }

        public async Task UpdateVehiculoAsync(Vehiculo car)
        {
            await this.containerCosmos.UpsertItemAsync<Vehiculo>(car, new PartitionKey(car.Id));
        }

        public async Task DeleteVehiculoAsync(string id)
        {
            await this.containerCosmos.DeleteItemAsync<Vehiculo>(id, new PartitionKey(id));
        }

        public async Task<Vehiculo> FindVehiculoAsync(string id)
        {
            ItemResponse<Vehiculo> response = await this.containerCosmos.ReadItemAsync<Vehiculo>(id, new PartitionKey(id));
            return response.Resource;
        }

        
    }
}
