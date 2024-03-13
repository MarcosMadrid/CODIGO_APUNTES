using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MvcSecurityLogIn.Filters
{
    public class AuthorizeUsersAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (!user.Identity!.IsAuthenticated)
            {
                RouteValueDictionary rutaLogin =
                    new RouteValueDictionary
                    (
                        new { controller = "Managed", action = "LogIn" }
                    );
                context.Result = new RedirectToRouteResult(rutaLogin);
            }
        }
    }
}
