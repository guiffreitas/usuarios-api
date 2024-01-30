using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly UsuarioService usuarioService;

        public UsuarioController(IMapper mapper, UsuarioService usuarioService)
        {
            this.mapper = mapper;
            this.usuarioService = usuarioService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto usuarioDto)
        {
            try
            {
                var usuario = mapper.Map<Usuario>(usuarioDto);

                var retorno = await usuarioService.CriarUsuario(usuario, usuarioDto.Password);

                if (retorno.Succeeded)
                {
                    return Ok();
                }

                return BadRequest(retorno?.Errors?.ToList()?.FirstOrDefault()?.Description);

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUsuario(LoginUsuarioDto loginDto)
        {
            try
            {
                var usuario = await usuarioService.ObterUsuario(loginDto.Username);

                var retorno = await usuarioService.LogarUsuario(usuario, loginDto.Password);

                if (retorno.SignInResult.Succeeded)
                {
                    return Ok(retorno.Token);
                }

                return BadRequest("Login not authorized");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
