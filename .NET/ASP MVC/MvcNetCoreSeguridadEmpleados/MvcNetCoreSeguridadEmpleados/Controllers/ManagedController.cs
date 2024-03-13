using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MvcNetCoreSeguridadEmpleados.Models;
using MvcNetCoreSeguridadEmpleados.Repositories;
using System.Security.Claims;

namespace MvcNetCoreSeguridadEmpleados.Controllers
{
    public class ManagedController : Controller
    {
        RepositoryEmpleados empleados;

        public ManagedController(RepositoryEmpleados empleados)
        {
            this.empleados = empleados;
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(string apellido, int idEmp)
        {
            Empleado? empleado = await empleados.GetEmpleadoAsync(apellido, idEmp);
            if (empleado == null)
            {
                ViewData["MENSAJE"] = "Usuario/Password Incorrecto.";
                return View();
            }
            else
            {
                ClaimsIdentity identity = new ClaimsIdentity
                    (
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        ClaimTypes.Name,
                        ClaimTypes.Role
                    );
                Claim claimName = new Claim(ClaimTypes.Name, apellido);
                identity.AddClaim(claimName);
                //Claim claimRole = new Claim(ClaimTypes.Role, idEmp );
                //identity.AddClaim(claimRole);

                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                RedirectToAction("Index", "Empleados");
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("Index", "Home");
        }
    }
}
