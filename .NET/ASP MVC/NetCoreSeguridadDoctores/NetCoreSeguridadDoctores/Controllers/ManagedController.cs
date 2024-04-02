using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NetCoreSeguridadDoctores.Models;
using NetCoreSeguridadDoctores.Repositories;
using System.Security.Claims;

namespace NetCoreSeguridadDoctores.Controllers
{
    public class ManagedController : Controller
    {
        readonly IRepositoryHospital repositoryHospital;

        public ManagedController(IRepositoryHospital repositoryHospital)
        {
            this.repositoryHospital = repositoryHospital;
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(string apellido, string doctorId)
        {
            Doctor? doctor = await repositoryHospital.GetDoctor(apellido, doctorId);

            if (doctor == null) { return View(); }
            else
            {
                ClaimsIdentity identity = new(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        ClaimTypes.Name,
                        ClaimTypes.Role
                    );

                Claim idHospital = new("idHospital", doctor.HospitalId.ToString());
                Claim idDoctor = new("idDoctor", doctor.Id.ToString());
                Claim name = new(ClaimTypes.Name, doctor.HospitalId.ToString());
                Claim salario = new("SALARIO", doctor.Salario.ToString());
                Claim rol = new(ClaimTypes.Role, doctor.Especialidad ?? "");

                identity.AddClaim(idHospital);
                identity.AddClaim(idDoctor);
                identity.AddClaim(salario);
                identity.AddClaim(name);
                identity.AddClaim(rol);

                ClaimsPrincipal claimsPrincipal = new(identity);

                await HttpContext.SignInAsync(claimsPrincipal);

                return RedirectToAction(TempData["action"]!.ToString(), TempData["controller"]!.ToString());
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("LogIn");
        }

    }
}
