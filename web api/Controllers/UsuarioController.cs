using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api.Models;
using web_api.Repositorios;
using web_api.Repositorios.Interfaces;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpPost("validarsenha")]
        public async Task<ActionResult> ValidarSenha([FromBody] UsuarioModel model)
        {
            if (string.IsNullOrEmpty(model.senha))
            {
                return BadRequest("A senha não pode estar vazia.");
            }

            if (await _usuarioRepositorio.ValidarSenha(model.senha,model.nome,model.email))
            {
                return Ok("Usuario Criado Com sucesso.");
            }
            else
            {
                return BadRequest("A senha precisa conter, letra maiscula, caracter especial, numero, letra minuscula.");
            }
        }
    }
}
