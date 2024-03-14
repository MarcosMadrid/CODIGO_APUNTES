using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MvcNetCoreSeguridadEmpleados.Models;
using MvcNetCoreSeguridadEmpleados.Repositories;
using System;
using System.Security.Claims;

namespace MvcNetCoreSeguridadEmpleados.Controllers
{
    public class ManagedController : Controller
    {
        readonly RepositoryEmpleados empleados;

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
                ClaimsIdentity identity = new
                    (
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        ClaimTypes.Name,
                        ClaimTypes.Role
                    );
                Claim claimName = new(ClaimTypes.Name, apellido);
                Claim claimRole = new(ClaimTypes.Role, empleado.Oficio!);
                Claim claimIdUser = new("idUser", empleado.Id.ToString());
                Claim claimIdDept = new("idDept", empleado.IdDepart.ToString());

                identity.AddClaim(claimName);
                identity.AddClaim(claimRole);
                identity.AddClaim(claimIdUser);
                identity.AddClaim(claimIdDept);

                ClaimsPrincipal principal = new(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction(TempData["action"]!.ToString(), TempData["controller"]!.ToString());
            }
        }

        public IActionResult ErrorAcceso()
        {
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Empleados");
        }
    }
}
