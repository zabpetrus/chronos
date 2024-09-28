using Chronos.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Chronos.Application.Tokens
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {

        
        public JwtTokenGenerator() {     
        
        }

        private TokenResult GenerateToken(long usuarioId)
        {
            var key = Encoding.ASCII.GetBytes(Key.Secret);

            // Adicionando um GUID para garantir que cada token seja único
            var tokenId = Guid.NewGuid().ToString();

            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("usuarioId", usuarioId.ToString()), // Converte o Id de long para string
                 }),

                Expires = DateTime.UtcNow.AddHours(24), // Expiração do token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfig);
            var tokenString = tokenHandler.WriteToken(token);

            return new TokenResult
            {
                Token = tokenString,
                Expiration = tokenConfig.Expires.Value 
            };
        }

        // Gera token para UsuarioInterno
        public TokenResult GenerateTokenForInternalUser(UsuarioInterno usuario)
        {
            return GenerateToken(usuario.Id); // Passa o Id como long, o método cuida da conversão
        }

        // Gera token para UsuarioExterno
        public TokenResult GenerateTokenForExternalUser(UsuarioExterno usuario)
        {
            return GenerateToken(usuario.Id); // Passa o Id como long, o método cuida da conversão
        }
    }
}
