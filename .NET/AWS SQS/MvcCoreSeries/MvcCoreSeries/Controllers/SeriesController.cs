using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcCoreSeries.Models;
using MvcCoreSeries.Repositories;

namespace MvcCoreSeries.Controllers
{
    public class SeriesController : Controller
    {
        private RepositoryTelevisionMySql repository;

        public SeriesController(RepositoryTelevisionMySql repository)
        {
            this.repository = repository;
        }
        // GET: SeriesController
        public async Task<ActionResult> Index()
        {
            List<Serie> serieList = new List<Serie>();
            serieList = await repository.GetSeriesAsync();
            return View(serieList);
        }

        // GET: SeriesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Serie serie = new Serie();
            serie = (await repository.GetSeriesAsync()).FirstOrDefault(serie => serie.Id == id)!;
            return View(serie);
        }

        // GET: SeriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SeriesController/Create
        [HttpPost]
        public async Task<ActionResult> Create(Serie serie)
        {
            try
            {
                await repository.CreateSerie(serie.Nombre!, serie.Imagen!, serie.Anyo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
