using Microsoft.AspNetCore.Mvc;
using MvcCoreCryptography.Models;
using MvcCoreCryptography.Repository;
using System.Text.Json;

namespace MvcCoreCryptography.Controllers
{
    public class UserController : Controller
    {
        RepositoryUsers repository;
        public UserController(RepositoryUsers repository)
        {
            this.repository = repository;
        }

        public IActionResult Index(string? userJson)
        {
            User? user = null;
            if(userJson != null) 
            {
                user = JsonSerializer.Deserialize<User>(userJson);
            }
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(string email, string password)
        {
            User? user = new User();
            user = await repository.LogIn(email, password);
            if (user != null)
            {
                return RedirectToAction("Index", "User", new { userJson = JsonSerializer.Serialize(user) });
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(User user, string password)
        {
            await repository.Register(user.Nombre, user.Email, password, user.Imagen);

            return RedirectToAction("Index");
        }
    }
}
