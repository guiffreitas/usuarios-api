    using Microsoft.AspNetCore.Authorization;

namespace UsuariosApi.Authorization
{
    public class AuthRequirement : IAuthorizationRequirement
    {
        public int IdadeMinima {  get; set; }

        public AuthRequirement(int idadeMinima)
        {
            IdadeMinima = idadeMinima;
        }
    }
}
