using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcessoController : ControllerBase
    {
        [HttpGet]
        [Authorize(Policy = "AuthRequirement")]
        public IActionResult Acessar()
        {
            return Ok("Usuario autenticado!");
        } 
    }
}
