using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace UsuariosApi.Authorization
{
    public class AuthHanlder : AuthorizationHandler<AuthRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthRequirement requirement)
        {
            var dateOfBirth = context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);

            if (dateOfBirth == null)
            {
                Console.WriteLine("Token de acesso não informado");

                return Task.CompletedTask;
            }

            if (Convert.ToDateTime(dateOfBirth.Value).AddYears(requirement.IdadeMinima) >= DateTime.Now)
            {
                context.Succeed(requirement);

                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }
    }
}
