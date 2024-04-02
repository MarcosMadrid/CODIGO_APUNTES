using Microsoft.EntityFrameworkCore;
using PracticaMvcCore2Iniciales.Data;
using PracticaMvcCore2Iniciales.Models;

namespace PracticaMvcCore2Iniciales.Repositories
{
    public class RepositorySqlServer : IRepositoryTiendaLibros
    {
        TiendaLibrosContext tiendaContext;
        public RepositorySqlServer(TiendaLibrosContext tiendaContext)
        {
            this.tiendaContext = tiendaContext;
        }

        public async Task<List<Genero>> GetGeneros()
        {
            return
                await tiendaContext.Generos.ToListAsync();
        }

        public async Task<Libro> GetLibro(int idLibro)
        {
            return
                await tiendaContext.Libros.FirstOrDefaultAsync(libro => libro.LibroId == idLibro);
        }

        public async Task<List<Libro>> GetLibros()
        {
            return
                await tiendaContext.Libros.ToListAsync();
        }

        public async Task<List<Libro>?> GetLibrosByIdGenero(int idGenero)
        {
            return
                await tiendaContext.Libros.Where(libro => libro.IdGenero == idGenero).ToListAsync();
        }

        public async Task<Usuario?> GetUsuarioById(int id)
        {
            return
                await tiendaContext.Usuarios.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<Usuario?> GetUsuarioLogIn(string email, string password)
        {
            return
                await tiendaContext.Usuarios.Where(user => user.Password == password && user.Email == email).FirstOrDefaultAsync();
        }

        public async Task<List<VistaPedidos>> GetVistaPedidosByUser(int idUser)
        {
            return
                await tiendaContext.VistaPedidos.Where(vista => vista.IdUsuario == idUser).ToListAsync();
        }

        public async Task CreatePedido(List<Pedido> pedidos)
        {
            int idMax = await tiendaContext.Pedidos.MaxAsync(ped => ped.Id);
            for (int i = 0; i < pedidos.Count(); i++)
            {
                pedidos[i].Id = idMax + 1;
                await tiendaContext.Pedidos.AddAsync(pedidos[i]);
            }
            await tiendaContext.SaveChangesAsync();
        }
    }
}
