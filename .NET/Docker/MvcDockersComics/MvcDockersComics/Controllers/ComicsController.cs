using Microsoft.AspNetCore.Mvc;
using MvcDockersComics.Models;
using MvcDockersComics.Repositories;

namespace MvcDockersComics.Controllers
{
    public class ComicsController : Controller
    {
        private RepositoryComics repositoryComics;

        public ComicsController(RepositoryComics repositoryComics)
        {
            this.repositoryComics = repositoryComics;
        }

        public async Task<IActionResult> Index()
        {
            List<Comic>? comics = await repositoryComics.GetComics();
            return View(comics);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Comic comic)
        {
            await repositoryComics.InsertComic(comic.Name!, comic.Imagen!);
            return RedirectToAction("Index");
        }
    }
}
