using Microsoft.EntityFrameworkCore;
using MvcCoreCubosTienda.Data;
using MvcCoreCubosTienda.Models;

namespace MvcCoreCubosTienda.Repositories
{
    public class RepositorySqlServer : IRepositoryCubosBBDD
    {
        public CubosContextBBDD contextBBDD;

        public RepositorySqlServer(CubosContextBBDD contextBBDD)
        {
            this.contextBBDD = contextBBDD;
        }

        public async Task CreateCompraAsync(string name, int precio, DateTime fechaPedido)
        {
            int id = (await contextBBDD.Cubos.MaxAsync(cuboRow => cuboRow.Id));
            Compra compra = new Compra
            {
                Id = id,
                Name = name,
                Precio = precio,
                FechaPedido = fechaPedido
            };

            await contextBBDD.Compras.AddAsync(compra);
        }

        public Compra GetCompraById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Compra>?> GetCompras()
        {
            return await contextBBDD.Compras.ToListAsync();
        }

        public async Task<List<Cubo>?> GetCubos()
        {
            return await contextBBDD.Cubos.ToListAsync();
        }

        public async Task<Cubo?> GetCuboById(int id)
        {
            return await contextBBDD.Cubos.FirstAsync(empleado => empleado.Id.Equals(id));
        }
    }
}
