using Microsoft.AspNetCore.Mvc;
using web_api.Data;
using web_api.Models;
using web_api.Repositorios;
using web_api.Repositorios.Interfaces;

namespace web_api.Controllers
{
    [Route("obs/[controller]")]
    [ApiController]
    public class UsuarioObsController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IUsuarioObsRepositorio _usuarioObsRepositorio;
        private readonly BancoContext _bancoContext;

        public UsuarioObsController(IUsuarioRepositorio usuarioRepositorio, BancoContext bancoContext, IUsuarioObsRepositorio usuarioObsRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _bancoContext = bancoContext;
            _usuarioObsRepositorio = usuarioObsRepositorio;
        }

        [HttpPost("criarObs")]
        public async Task<IActionResult> criarObs([FromBody]UsuarioObs dados)
        {       
          var  salvar = await  _usuarioObsRepositorio.criarObs(dados);
            return Ok("Salvo com sucesso");
        }

    }
}
