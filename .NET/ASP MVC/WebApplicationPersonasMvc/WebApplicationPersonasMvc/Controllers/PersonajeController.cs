using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplicationPersonasMvc.Models;
using WebApplicationPersonasMvc.Repositories;

namespace WebApplicationPersonasMvc.Controllers
{
    public class PersonajeController : Controller
    {
        private IRepositoryPersonas repositoryPersonas;

        public PersonajeController(IRepositoryPersonas repostory)
        {
            repositoryPersonas = repostory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Personaje>? personajes;

            personajes = repositoryPersonas.GetPersonajes();

            return View(personajes);
        }

        [HttpGet, HttpPost]
        public IActionResult Details(int id)
        {
            Personaje personaje;
            personaje = repositoryPersonas.GetPersonaje(id);
            return View(personaje);
        }

        [HttpGet]
        public IActionResult PersonajeForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePersonaje(Personaje personaje)
        {
            repositoryPersonas.InsertPersonaje(personaje.IDPERSONAJE, personaje.Nombre, personaje.Imagen);
            return RedirectToAction("Index");
        }

        public IActionResult DeletePersonaje(int id)
        {
            repositoryPersonas.DeletePersonaje(id);
            return RedirectToAction("Index");
        }

        public IActionResult UpdatePersonaje(int id)
        {
            Personaje personaje;
            personaje = repositoryPersonas.GetPersonaje(id);
            return View("PersonajeModificar", personaje);
        }

        [HttpPost]
        public IActionResult PersonajeModificar(Personaje personaje)
        {
            repositoryPersonas.UpdatePersonaje(personaje.IDPERSONAJE, personaje.Nombre, personaje.Imagen);
            return RedirectToAction("index");
        }
    }
}
