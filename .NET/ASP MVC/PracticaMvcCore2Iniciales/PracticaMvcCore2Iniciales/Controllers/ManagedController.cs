using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PracticaMvcCore2Iniciales.Models;
using PracticaMvcCore2Iniciales.Repositories;
using System.Security.Claims;

namespace PracticaMvcCore2Iniciales.Controllers
{
    public class ManagedController : Controller
    {
        IRepositoryTiendaLibros repositoryTienda;

        public ManagedController(IRepositoryTiendaLibros repositoryTiendaLibros)
        {
            repositoryTienda = repositoryTiendaLibros;
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(string email, string password)
        {
            Usuario? user = await repositoryTienda.GetUsuarioLogIn(email, password);
            if (user is null)
            {
                ViewData["MENSAJE"] = "Email o contraseña incorrectos";
                return View();
            }
            else
            {
                ClaimsIdentity identity = new(
                       CookieAuthenticationDefaults.AuthenticationScheme,
                       ClaimTypes.Name,
                       ClaimTypes.Email
                   );
                Claim claimName = new(ClaimTypes.Name, user.Nombre!);
                Claim claimEmail = new(ClaimTypes.Email, user.Email!);
                Claim claimIdUser = new("IdUser", user.Id.ToString());

                identity.AddClaim(claimName);
                identity.AddClaim(claimEmail);
                identity.AddClaim(claimIdUser);

                ClaimsPrincipal claimsPrincipal = new(identity);

                await HttpContext.SignInAsync(claimsPrincipal);

                return RedirectToAction("Home" , "Tienda");
            }
        }
    }
}
