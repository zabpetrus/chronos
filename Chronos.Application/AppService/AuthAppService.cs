using Chronos.Application.Interfaces;
using Chronos.Application.Tokens;
using Chronos.Domain.Entities;
using System;

namespace Chronos.Application.AppService
{
    public class AuthAppService : IAuthAppService
    {
        private readonly JwtTokenGenerator _jwtTokenGenerator;


        public AuthAppService(JwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public TokenResult Login(string username, string password)
        {
            if (username == "admin" && password == "123456")
            {
                // Criar o objeto UsuarioInterno para passar para o método
                var usuarioInterno = new UsuarioInterno
                {
                    Id = 1, // Preencher com o ID correto, se disponível
                    Nome = "Admin" // Exemplo, pode ser personalizado
                };

                // Gerar o token utilizando a instância de JwtTokenGenerator
                var token = _jwtTokenGenerator.GenerateTokenForInternalUser(usuarioInterno);
                return token;
            }
            else
            {
                return null;
            }
        }
    }
}
