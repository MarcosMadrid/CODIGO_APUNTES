using Microsoft.EntityFrameworkCore;
using MvcCoreSeries.Data;
using MvcCoreSeries.Models;

namespace MvcCoreSeries.Repositories
{
    public class RepositoryTelevisionMySql
    {
        private TelevisionDbContext dbContext;

        public RepositoryTelevisionMySql(TelevisionDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Serie>> GetSeriesAsync()
        {
            return
                await dbContext.Series.ToListAsync();
        }

        public async Task<int> GetMaxId()
        {
            return
                await dbContext.Series
                .Select(serie => serie.Id)
                .MaxAsync();
        }

        public async Task CreateSerie(string nombre, string imagen, int anyo)
        {
            Serie serie = new Serie()
            {
                Id = await GetMaxId() + 1,
                Nombre = nombre,
                Imagen = imagen,
                Anyo = anyo
            };

            dbContext.Series.Add(serie);
            await dbContext.SaveChangesAsync();
            return;
        }
    }
}
