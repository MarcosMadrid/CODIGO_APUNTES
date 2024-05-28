using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationPeliculas.Models;
using WebApplicationPeliculas.Services;

namespace WebApplicationPeliculas.Controllers
{
    public class PeliculasController : Controller
    {
        private ServicePeliculas servicePeliculas;

        public PeliculasController(ServicePeliculas servicePeliculas)
        {
            this.servicePeliculas = servicePeliculas;
        }

        // GET: PeliculasController
        public async Task<ActionResult> Index()
        {
            List<Pelicula>? peliculas = new List<Pelicula>();
            peliculas = await servicePeliculas.GetPeliculas();
            return View(peliculas);
        }

        // GET: PeliculasController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Pelicula? pelicula = new Pelicula();
            pelicula = await servicePeliculas.GetPelicula(id);
            return View(pelicula);
        }

        // GET: PeliculasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeliculasController/Create
        [HttpPost]
        public ActionResult Create(Pelicula pelicula)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PeliculasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PeliculasController/Edit/5
        [HttpPost]
        public ActionResult Edit(Pelicula pelicula)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PeliculasController/Delete/5
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }
    }
}
