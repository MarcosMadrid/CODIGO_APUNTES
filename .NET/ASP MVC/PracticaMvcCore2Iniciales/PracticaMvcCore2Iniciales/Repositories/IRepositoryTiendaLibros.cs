using PracticaMvcCore2Iniciales.Models;

namespace PracticaMvcCore2Iniciales.Repositories
{
    public interface IRepositoryTiendaLibros
    {
        Task<Usuario?> GetUsuarioLogIn(string email, string password);
        Task<List<Genero>> GetGeneros();
        Task<List<Libro>> GetLibros();
        Task<Libro> GetLibro(int idLibro);
        Task<Usuario?> GetUsuarioById(int id);
        Task<List<Libro>?> GetLibrosByIdGenero(int idGenero);
        Task<List<VistaPedidos>> GetVistaPedidosByUser(int idUser);
        Task CreatePedido(List<Pedido> pedidos);
    }
}
