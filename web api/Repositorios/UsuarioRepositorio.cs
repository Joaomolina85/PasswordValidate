using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Text.RegularExpressions;
using web_api.Models;
using web_api.Repositorios.Interfaces;

namespace web_api.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public async Task<bool> ValidarSenha(string senha, string nome, string email)
        {
            bool senhaTamanho = senha.Length >= 9;
            bool senhaMinuscula = Regex.IsMatch(senha, @"[a-z]");
            bool senhaMaiscula = Regex.IsMatch(senha, @"[A-Z]");
            bool senhaCaracterEsp = Regex.IsMatch(senha, @"[!@#$%^&*()-+]");
            bool senhaEspaco = !senha.Any(x => char.IsWhiteSpace(x));
            bool stringRepetida = false;

            //verificando se existe letras repetidas na senha.
            for (int i = 0; i < senha.Length; i++)
            {
                for (int j = 0; j < senha.Length; j++)
                {
                    if (senha[i] == senha[j])
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
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
