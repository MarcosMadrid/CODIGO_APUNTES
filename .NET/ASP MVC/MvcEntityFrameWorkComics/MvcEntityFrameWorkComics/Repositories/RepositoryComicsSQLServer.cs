using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MvcEntityFrameWorkComics.Data;
using MvcEntityFrameWorkComics.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MvcEntityFrameWorkComics.Repositories
{
    public class RepositoryComicsSQLServer : IRepositoryBBDD
    {
        ComicBBDDContext context;
        public RepositoryComicsSQLServer(ComicBBDDContext context)
        {
            this.context = context;
        }

        public void DeleteComic(int IdComic)
        {
            throw new NotImplementedException();
        }

        public Task<Comic?> GetComic(int IdComic)
        {
            return context.Comics.Where(comic => comic.Id.Equals(IdComic)).FirstOrDefaultAsync();
        }

        public async Task<List<Comic>> GetComics()
        {
            return await context.Comics.ToListAsync();
        }

        public void InsertComic(string Nombre, string Imagen, string Descripcion)
        {
            string sql = "SP_INSERT_COMIC @Nombre , @imagen, @descripcion ";
            SqlParameter sqlNombre = new SqlParameter("Nombre", Nombre);
            SqlParameter sqlImagen = new SqlParameter("imagen", Imagen);
            SqlParameter sqlDescripcion = new SqlParameter("descripcion", Descripcion);

            context.Database.ExecuteSqlRaw(sql, sqlNombre, sqlImagen, sqlDescripcion);
        }

        public void UpdateComic(int IdComic, string Nombre, string Imagen, string Descripcion)
        {
            string sql = "SP_INSERT_COMIC  @Nombre , @imagen, @descripcion ";
            SqlParameter sqlId = new SqlParameter("id", IdComic);
            SqlParameter sqlNombre = new SqlParameter("Nombre", Nombre);
            SqlParameter sqlImagen = new SqlParameter("imagen", Imagen);
            SqlParameter sqlDescripcion = new SqlParameter("descripcion", Descripcion);

            context.Database.ExecuteSqlRaw(sql, sqlNombre, sqlImagen, sqlDescripcion);
        }
    }
}
