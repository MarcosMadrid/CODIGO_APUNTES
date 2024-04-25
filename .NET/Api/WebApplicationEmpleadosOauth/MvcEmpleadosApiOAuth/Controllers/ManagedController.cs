using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MvcEmpleadosApiOAuth.Services;
using System.Security.Claims;
using WebApplicationEmpleadosOauth.Models;

namespace MvcEmpleadosApiOAuth.Controllers
{
    public class ManagedController : Controller
    {
        private IServiceEmpleados serviceEmpleados;

        public ManagedController(IServiceEmpleados serviceEmpleados)
        {
            this.serviceEmpleados = serviceEmpleados;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            string? token = await serviceEmpleados.GetToken(loginModel.UserName, loginModel.Password);
            if (token is null)
            {
                ViewData["MENSAJE"] = "Usuario/Password incorrecto";
            }
            else
            {
                ViewData["MENSAJE"] = "Logged";                
                ClaimsIdentity identity = new ClaimsIdentity(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    ClaimTypes.Name,
                    ClaimTypes.Role
                );
                identity.AddClaim(new Claim(ClaimTypes.Name, loginModel.UserName));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, loginModel.Password));
                identity.AddClaim(new Claim("token", token));
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    principal,
                    new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(15),
                    }
                    );
                return RedirectToAction("Index", "Empleados");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Empleados");
        }
    }
}
