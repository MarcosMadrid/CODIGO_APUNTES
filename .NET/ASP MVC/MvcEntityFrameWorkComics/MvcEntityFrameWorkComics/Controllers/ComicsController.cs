using Microsoft.AspNetCore.Mvc;
using MvcEntityFrameWorkComics.Models;
using MvcEntityFrameWorkComics.Repositories;

namespace MvcEntityFrameWorkComics.Controllers
{
    public class ComicsController : Controller
    {
        IRepositoryBBDD repository;
        public ComicsController(IRepositoryBBDD repositoryBBDD)
        {
            repository = repositoryBBDD;
        }

        public async Task<IActionResult> Index()
        {
            List<Comic> list;
            list = await repository.GetComics();
            return View(list);
        }

        public async Task<IActionResult> Details(int id)
        {
            Comic? comic = await repository.GetComic(id);
            return View(comic);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Comic comic)
        {
            repository.InsertComic(comic.Nombre, comic.Imagen, comic.Descripcion);
            return RedirectToAction("Index");
        }
    }
}
