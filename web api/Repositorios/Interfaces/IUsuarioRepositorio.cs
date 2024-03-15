using web_api.Models;

namespace web_api.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<bool> ValidarSenha(UsuarioModel dados);
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarPorId(int Id);
        Task<UsuarioModel> Atualizar(UsuarioModel dados, int Id);
        Task<UsuarioModel> Deletar(int Id);
    }
}
