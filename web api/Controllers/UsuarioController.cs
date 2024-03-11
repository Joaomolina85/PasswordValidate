using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api.Data;
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
        private readonly BancoContext _bancoContext;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio, BancoContext bancoContext)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _bancoContext = bancoContext;
        }

        [HttpPost("validarsenha")]
        public async Task<ActionResult> ValidarSenha([FromBody] UsuarioModel dados)
        {
            if (string.IsNullOrEmpty(dados.senha))
            {
                return BadRequest("A senha não pode estar vazia.");
            }

            if (await _usuarioRepositorio.ValidarSenha(dados))
            {
                return Ok("Usuario Criado Com sucesso.");
            }
            else
            {
                return BadRequest("A senha precisa conter, letra maiscula, caracter especial, numero, letra minuscula.");
            }
        }

        [HttpGet("trazertodosusuarios")]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            var dados =   await _usuarioRepositorio.BuscarTodosUsuarios();

            return Ok(dados);

        }

       [HttpDelete("Deletar")]
       public async Task<ActionResult<UsuarioModel>> Deletar(int Id)
        {
            var dados  = await _usuarioRepositorio.Deletar(Id);
            return Ok(dados);
        }

        [HttpPut]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel dados, int Id)
        {
            dados.Id = Id;
            UsuarioModel salvar = await _usuarioRepositorio.Atualizar(dados, Id);
            return Ok(salvar);
        }

        [HttpGet("listarporid")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int Id)
        {
            var dados = await _usuarioRepositorio.BuscarPorId(Id);
            if(dados == null)
            {
                return BadRequest("Usuario não existe");
            }
            else
            {
                return Ok(dados);
            }          
        }
    }
}
