using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace NetCoreSeguridadDoctores.Filters
{
    public class AuthenFilterUser : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity!.IsAuthenticated == false)
            {
                ITempDataProvider? provider = context.HttpContext.RequestServices.GetService<ITempDataProvider>();

                var TempData = provider!.LoadTempData(context.HttpContext);
                string? controller = context.RouteData.Values["controller"]!.ToString();
                string? action = context.RouteData.Values["action"]!.ToString();

                TempData["controller"] = controller;
                TempData["action"] = action;

                provider.SaveTempData(context.HttpContext, TempData);

                context.Result = RedirectTo("Managed", "LogIn");
            }
        }

        private static RedirectToRouteResult RedirectTo(string controller, string action)
        {
            RouteValueDictionary ruta =
                new(
                    new { action, controller }
                );
            RedirectToRouteResult redirect = new(ruta);
            return redirect;
        }
    }
}
