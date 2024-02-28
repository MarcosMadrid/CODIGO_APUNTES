using MvcEntityFrameWorkComics.Models;

namespace MvcEntityFrameWorkComics.Repositories
{
    public interface IRepositoryBBDD
    {
        Task<List<Comic>> GetComics();
        Task<Comic?> GetComic(int IdComic);
        void InsertComic(string nombre, string Imagen, string Descripcion);
        void UpdateComic(int IdComic, string nombre, string Imagen, string Descripcion);
        void DeleteComic(int IdComic);
    }
}
