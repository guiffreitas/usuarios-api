using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class UsuarioService
    {
        private readonly UserManager<Usuario> userManager;
        private readonly SignInManager<Usuario> signInManager;
        private readonly TokenService tokenService;

        public UsuarioService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, TokenService tokenService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
        }

        public async Task<IdentityResult> CriarUsuario(Usuario usuario, string password)
        {
            return await userManager.CreateAsync(usuario, password);
        }

        public async Task<Usuario> ObterUsuario(string username)
        {
            return await userManager.FindByNameAsync(username);
        }

        public async Task<(SignInResult SignInResult, string Token)> LogarUsuario(Usuario usuario, string password)
        {
            var signInResult = await signInManager.PasswordSignInAsync(usuario.UserName, password, false, false);

            if (!signInResult.Succeeded)
            {
                return new (signInResult, string.Empty);
            }

            return new(signInResult, tokenService.ObterToken(usuario));
        }
    }
}
