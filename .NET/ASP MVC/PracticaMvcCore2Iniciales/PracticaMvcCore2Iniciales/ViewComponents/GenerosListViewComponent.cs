using Microsoft.AspNetCore.Mvc;
using PracticaMvcCore2Iniciales.Models;
using PracticaMvcCore2Iniciales.Repositories;

namespace PracticaMvcCore2Iniciales.ViewComponents
{
    public class GenerosListViewComponent : ViewComponent
    {
        IRepositoryTiendaLibros tiendaLibros;

        public GenerosListViewComponent(IRepositoryTiendaLibros tiendaLibros)
        {
            this.tiendaLibros = tiendaLibros;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Genero> gemeros = await tiendaLibros.GetGeneros();
            return View(gemeros);
        }
    }
}
