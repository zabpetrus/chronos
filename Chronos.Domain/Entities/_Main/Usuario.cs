using Chronos.Domain.Entities._Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Domain.Entities._Main
{
    public abstract class Usuario : Entity
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Cpf { get; set; }

        private string SenhaHash { get; set; }

        private string Sal { get; set; }


        // Método para definir a senha com hash e sal
        public void DefinirSenha(string senha)
        {
            // Gera um novo sal
            Sal = GerarSal();

            // Gera o hash da senha utilizando o sal
            SenhaHash = GerarHash(senha, Sal);
        }

        // Método para verificar se a senha fornecida é válida
        public bool VerificarSenha(string senha)
        {
            // Gera o hash da senha fornecida utilizando o sal armazenado
            var hashVerificacao = GerarHash(senha, Sal);

            // Compara o hash gerado com o hash armazenado
            return hashVerificacao == SenhaHash;
        }

        // Método para gerar um hash com base na senha e no sal
        private string GerarHash(string senha, string sal)
        {
            using (var sha256 = SHA256.Create())
            {
                // Concatena a senha com o sal
                var senhaComSal = senha + sal;

                // Converte a senha e o sal concatenados em bytes
                var bytes = Encoding.UTF8.GetBytes(senhaComSal);

                // Gera o hash
                var hashBytes = sha256.ComputeHash(bytes);

                // Converte o hash gerado para string e retorna
                return Convert.ToBase64String(hashBytes);
            }
        }

        // Método para gerar um sal aleatório
        private string GerarSal()
        {
            // Gera 16 bytes aleatórios
            var randomBytes = new byte[16];

            using (var rng = new RNGCryptoServiceProvider())
            {
                // Preenche o array com bytes aleatórios
                rng.GetBytes(randomBytes);
            }

            // Retorna o sal como uma string Base64
            return Convert.ToBase64String(randomBytes);
        }
    }

}
