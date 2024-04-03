using ServiceReferenceEscenasPelis;

namespace MvcCoreCliente.Services
{
    public class ServiceEscenas
    {
        PeliculasContractClient peliculas;

        public ServiceEscenas()
        {
            this.peliculas = new PeliculasContractClient();
        }

        public async Task<Pelicula[]> GetPeliculasAsync()
        {
            return
                await peliculas.GetPeliculasAsync();
        }
    }
}
