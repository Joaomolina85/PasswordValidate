using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Text.RegularExpressions;
using web_api.Data;
using web_api.Models;
using web_api.Repositorios.Interfaces;

namespace web_api.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel dados, int Id)
        {
            var novoDados = await BuscarPorId(Id);

            if(novoDados == null)
            {
                throw new Exception("Usuario nao encontrado");
            }

            novoDados.nome = dados.nome;
            novoDados.senha = dados.senha;
            novoDados.email = dados.email;

             _bancoContext.usuario.Update(novoDados);
             _bancoContext.SaveChanges();

            return novoDados;
        }

        public async Task<UsuarioModel> Deletar(int Id)
        {
            var dados = await BuscarPorId(Id);

            _bancoContext.usuario.Remove(dados);
            _bancoContext.SaveChanges();
            return dados;
        }

        public async Task<UsuarioModel> BuscarPorId(int Id)
        {
            return await _bancoContext.usuario.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _bancoContext.usuario.ToListAsync();
        }

        public async Task<bool> ValidarSenha(UsuarioModel dados)
        {
            bool senhaTamanho = dados.senha.Length >= 9;
            bool senhaMinuscula = Regex.IsMatch(dados.senha, @"[a-z]");
            bool senhaMaiscula = Regex.IsMatch(dados.senha, @"[A-Z]");
            bool senhaCaracterEsp = Regex.IsMatch(dados.senha, @"[!@#$%^&*()-+]");
            bool senhaEspaco = !dados.senha.Any(x => char.IsWhiteSpace(x));
            bool stringRepetida = false;

            //verificando se existe letras repetidas na senha.
            for (int i = 0; i < dados.senha.Length; i++)
            {
                for (int j = 0; j < dados.senha.Length; j++)
                {
                    if (dados.senha[i] == dados.senha[j])
                    {
                        stringRepetida = true;
                        break;
                    }
                    else
                    {
                        stringRepetida = false;
                    }
                }
            }

            if (senhaTamanho && senhaMinuscula && senhaMaiscula && senhaCaracterEsp && senhaEspaco)
            {
                _bancoContext.Add(dados);
                await _bancoContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
