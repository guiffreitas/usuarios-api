using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class TokenService
    {
        public string ObterToken(Usuario usuario)
        {
            var claims = new Claim[] {
                new("id", usuario.Id),
                new("name", usuario.UserName),
                new(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SDKA12312eSDOs345kSDASDdas01djqwd091dj1d913dj"));

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                expires: DateTime.UtcNow.AddMinutes(10),
                claims: claims,
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
