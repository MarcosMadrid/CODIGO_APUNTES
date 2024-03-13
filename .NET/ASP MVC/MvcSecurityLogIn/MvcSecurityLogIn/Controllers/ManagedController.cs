using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MvcSecurityLogIn.Controllers
{
    public class ManagedController : Controller
    {
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(string username, string password)
        {
            if (username.ToLower() == "admin" && password.ToLower() == "admin")
            {
                ClaimsIdentity identity =
                    new ClaimsIdentity
                    (
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        ClaimTypes.Name,
                        ClaimTypes.Role
                    );
                Claim ClaimName = new Claim(ClaimTypes.Name, username);
                Claim ClaimRole = new Claim(ClaimTypes.Role, "USER");
                identity.AddClaim(ClaimName);
                identity.AddClaim(ClaimRole);

                ClaimsPrincipal userPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    userPrincipal,
                    new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.Now.AddMinutes(15)
                    }
                    );

                return RedirectToAction("Perfil", "User");
            }
            else
            {
                ViewData["MENSAJE"] = "Credenciales Incorrectas";
                return View();
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
