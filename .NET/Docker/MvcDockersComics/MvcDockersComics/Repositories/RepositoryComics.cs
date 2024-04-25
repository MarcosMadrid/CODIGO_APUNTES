using Microsoft.EntityFrameworkCore;
using MvcDockersComics.Data;
using MvcDockersComics.Models;

namespace MvcDockersComics.Repositories
{
    public class RepositoryComics
    {
        private ComicsContext comicsContext;

        public RepositoryComics(ComicsContext comicsContext)
        {
            this.comicsContext = comicsContext;
        }

        public async Task<List<Comic>?> GetComics()
        {
            return
                await comicsContext.Comics.ToListAsync();
        }

        public async Task<int> GetMaxId()
        {
            return
                await comicsContext.Comics
                .Select(comic => comic.Id)
                .MaxAsync();
        }

        public async Task InsertComic(string nombre, string imagen)
        {
            Comic comic = new Comic()
            {
                Id = await GetMaxId() + 1,
                Name = nombre,
                Imagen = imagen
            };
            await comicsContext.Comics.AddAsync(comic);
            await comicsContext.SaveChangesAsync();
        }

    }
}
