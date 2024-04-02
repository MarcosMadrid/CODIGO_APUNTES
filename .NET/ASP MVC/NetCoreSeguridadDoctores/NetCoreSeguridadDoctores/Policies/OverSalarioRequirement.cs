using Microsoft.AspNetCore.Authorization;

namespace NetCoreSeguridadDoctores.Policies
{
    public class OverSalarioRequirement : AuthorizationHandler<OverSalarioRequirement>, IAuthorizationRequirement
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OverSalarioRequirement requirement)
        {
            string data = context.User.FindFirst("SALARIO")!.Value;
            int salario = int.Parse(data);
            if (salario > 22000)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
}
