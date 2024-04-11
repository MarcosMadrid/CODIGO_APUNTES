using ServiceReferenceCoches;

namespace MvcCoreCliente.Services
{
    public class ServiceCoches
    {
        private CochesContractClient client;

        public ServiceCoches()
        {
            this.client = new CochesContractClient();
        }

        public async Task<Coche> GetCoche(int id)
        {
            return
                await client.GetCocheAsync(id);
        }

        public async Task<Coche[]> GetCoches()
        {
            return
                await client.GetCochesAsync();
        }
    }
}
