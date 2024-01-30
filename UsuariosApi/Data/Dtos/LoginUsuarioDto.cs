using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Dtos
{
    public class LoginUsuarioDto
    {
        [Required]
        public string Username {  get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
