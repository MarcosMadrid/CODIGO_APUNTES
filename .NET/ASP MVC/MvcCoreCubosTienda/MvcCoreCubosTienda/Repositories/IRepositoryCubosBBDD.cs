using MvcCoreCubosTienda.Models;

namespace MvcCoreCubosTienda.Repositories
{
    public interface IRepositoryCubosBBDD
    {
        public Task<List<Cubo>?> GetCubos();
        public Task<Cubo?> GetCuboById(int id);
        public Task<List<Compra>?> GetCompras();
        public Compra? GetCompraById(int id);
        public Task CreateCompraAsync(string name, int precio, DateTime fechaPedido);
    }
}
