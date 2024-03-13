using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MvcNetCoreSeguridadEmpleados.Filters
{
    public class AuthorizeEmpleadosAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public AuthorizeEmpleadosAttribute() { }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated == false)
            {
                this.RedirectTo("Managed", "LogIn");
            }
        }

        private RedirectToRouteResult RedirectTo(string controller, string action)
        {
            RouteValueDictionary ruta =
                new RouteValueDictionary(
                    new { action = action, controller = controller }
                );
            RedirectToRouteResult redirect = new RedirectToRouteResult(ruta);
            return redirect;
        }
    }
}
