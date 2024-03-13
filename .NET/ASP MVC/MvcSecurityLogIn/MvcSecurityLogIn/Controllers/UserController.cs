using Microsoft.AspNetCore.Mvc;
using MvcSecurityLogIn.Filters;

namespace MvcSecurityLogIn.Controllers
{
    [AuthorizeUsers]
    public class UserController : Controller
    {
        public IActionResult Perfil()
        {
            return View();
        }
    }
}
