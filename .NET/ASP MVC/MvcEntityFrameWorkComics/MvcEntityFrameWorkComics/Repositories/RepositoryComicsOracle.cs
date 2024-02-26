using Microsoft.EntityFrameworkCore;
using MvcEntityFrameWorkComics.Data;
using MvcEntityFrameWorkComics.Models;
using Oracle.ManagedDataAccess.Client;

namespace MvcEntityFrameWorkComics.Repositories
{
    public class RepositoryComicsOracle : IRepositoryBBDD
    {
        ComicBBDDContext context;
        public RepositoryComicsOracle(ComicBBDDContext context)
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
            string sql = "SP_INSERT_COMIC :nombre , :imagen, :descripcion ";
            OracleParameter sqlNombre = new OracleParameter("nombre", Nombre);
            OracleParameter sqlImagen = new OracleParameter("imagen", Imagen);
            OracleParameter sqlDescripcion = new OracleParameter("descripcion", Descripcion);

            context.Database.ExecuteSqlRaw(sql, sqlNombre, sqlImagen, sqlDescripcion);
        }

        public void UpdateComic(int IdComic, string Nombre, string Imagen, string Descripcion)
        {
            string sql = "SP_INSERT_COMIC  @Nombre , @imagen, @descripcion ";
            OracleParameter sqlId = new OracleParameter("id", IdComic);
            OracleParameter sqlNombre = new OracleParameter("Nombre", Nombre);
            OracleParameter sqlImagen = new OracleParameter("imagen", Imagen);
            OracleParameter sqlDescripcion = new OracleParameter("descripcion", Descripcion);

            context.Database.ExecuteSqlRaw(sql, sqlNombre, sqlImagen, sqlDescripcion);
        }
    }
}
