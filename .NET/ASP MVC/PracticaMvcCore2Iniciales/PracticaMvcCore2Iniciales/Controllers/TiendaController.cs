using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PracticaMvcCore2Iniciales.Filters;
using PracticaMvcCore2Iniciales.Models;
using PracticaMvcCore2Iniciales.Repositories;
using System.Security.Claims;
using System.Text.Json;

namespace PracticaMvcCore2Iniciales.Controllers
{
    public class TiendaController : Controller
    {
        IRepositoryTiendaLibros tiendaLibros;

        public TiendaController(IRepositoryTiendaLibros tiendaLibros)
        {
            this.tiendaLibros = tiendaLibros;
        }

        [AuthUserFilter]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Home");
        }

        public async Task<IActionResult> Home()
        {
            List<Libro>? libros = await tiendaLibros.GetLibros();
            return View(libros);
        }

        public async Task<IActionResult> GetLibrosByGenero(int idGenero)
        {
            List<Libro>? libros = await tiendaLibros.GetLibrosByIdGenero(idGenero);
            return View("Home", libros);
        }


        public IActionResult DeleteLibroCarrito(string idLibro)
        {
            string carrito = HttpContext.Session.GetString("CARRITO");
            List<string> idLibros = new List<string>();
            if (carrito != null)
            {
                idLibros = JsonSerializer.Deserialize<List<string>>(carrito);
            }
            idLibros.Remove(idLibro);
            HttpContext.Session.SetString("CARRITO", JsonSerializer.Serialize(idLibros));

            return Ok();
        }


        public IActionResult AyadirLibroCarrito(string idLibro)
        {
            string carrito = HttpContext.Session.GetString("CARRITO");
            List<string> idLibros = new List<string>();

            if (carrito != null)
            {
                idLibros = JsonSerializer.Deserialize<List<string>>(carrito);
            }

            idLibros.Add(idLibro);
            HttpContext.Session.SetString("CARRITO", JsonSerializer.Serialize(idLibros));

            return Ok();
        }

        public async Task<IActionResult> Carrito()
        {
            string carrito = HttpContext.Session.GetString("CARRITO");
            List<string> idLibros = new List<string>();

            if (carrito != null)
            {
                idLibros = JsonSerializer.Deserialize<List<string>>(carrito);
            }
            List<Libro> libros = new List<Libro>();
            if (idLibros.Count > 0)
            {
                for (global::System.Int32 i = 0; i < idLibros.Count(); i++)
                {
                    Libro libro = await tiendaLibros.GetLibro(int.Parse(idLibros[i]));
                    libros.Add(libro);
                }
            }
            int precioTotal = libros.Sum(libro => libro.Precio);
            ViewData["TOTAL"] = precioTotal;
            return View(libros);
        }

        [AuthUserFilter]
        public async Task<IActionResult> DetailsPedidos()
        {
            int idUser = int.Parse(User.FindFirst("IdUser")!.Value);
            List<VistaPedidos> vistaPedidos = await tiendaLibros.GetVistaPedidosByUser(idUser);
            return View(vistaPedidos);
        }

        [AuthUserFilter]
        public async Task<IActionResult> CreatePedido()
        {
            string carrito = HttpContext.Session.GetString("CARRITO");
            int idUser = int.Parse(User.FindFirst("IdUser").Value);
            List<string> idLibros = new List<string>();
            List<Pedido> pedidos = new List<Pedido>();
            if (carrito != null)
            {
                idLibros = JsonSerializer.Deserialize<List<string>>(carrito);
            }
            List<Libro> libros = new List<Libro>();
            if (idLibros.Count > 0)
            {
                for (global::System.Int32 i = 0; i < idLibros.Count(); i++)
                {
                    Libro libro = await tiendaLibros.GetLibro(int.Parse(idLibros[i]));
                    Pedido pedido = new Pedido()
                    {
                        Cantidad = idLibros.Count(),
                        IdFactura = i,
                        IdLibro = int.Parse(idLibros[i]),
                        IdUsuario = idUser,   
                        Fecha = DateTime.UtcNow,
                    };
                    pedidos.Add(pedido);
                }
                await tiendaLibros.CreatePedido(pedidos);
                idLibros.Clear();
                HttpContext.Session.SetString("CARRITO", JsonSerializer.Serialize(idLibros));
                return RedirectToAction("DetailsPedidos");
            }
            else
            {
                return RedirectToAction("Carrito");
            }
        }


        [AuthUserFilter]
        public async Task<IActionResult> Perfil(int id)
        {
            Usuario? user = await tiendaLibros.GetUsuarioById(id);
            return View(user);
        }
    }
}
