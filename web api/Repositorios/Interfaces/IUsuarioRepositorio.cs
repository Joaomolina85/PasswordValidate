using web_api.Models;

namespace web_api.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<bool> ValidarSenha(string senha,string nome,string email);
    }
}
