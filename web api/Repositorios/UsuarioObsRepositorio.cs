using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using web_api.Data;
using web_api.Models;
using web_api.Repositorios.Interfaces;

namespace web_api.Repositorios
{
    public class UsuarioObsRepositorio : IUsuarioObsRepositorio
    {
        private readonly BancoContext _bancoContext;

        public UsuarioObsRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public async Task<UsuarioObs> criarObs(UsuarioObs dados)
        {
            _bancoContext.Add(dados);
            await _bancoContext.SaveChangesAsync();
            return dados;
        }
    }
}
