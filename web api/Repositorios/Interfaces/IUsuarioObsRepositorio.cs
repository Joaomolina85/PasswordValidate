using web_api.Models;
namespace web_api.Repositorios.Interfaces
{
    public interface IUsuarioObsRepositorio
    {
        Task<UsuarioObs> criarObs(UsuarioObs dados);
    }
}
