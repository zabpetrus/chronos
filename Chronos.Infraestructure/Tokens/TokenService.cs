using Chronos.Infraestructure.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Infraestructure.Tokens
{
    public class TokenService : ITokenService
    {
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly ApplicationDbContext _context;

        public TokenService(ApplicationDbContext context, IConfiguration configuration)
        {
            _secretKey = configuration["Jwt:SecretKey"];
            _issuer = configuration["Jwt:Issuer"];
            _audience = configuration["Jwt:Audience"];
            _context = context;
        }

        public string GenerateToken(string userName, string password)
        {
            // Validar credenciais do usuário
            var user = _context.Set<Usuario>().FirstOrDefault(u => u.Nome == userName);
            if (user == null || !ValidatePassword(user, password))
            {
                throw new UnauthorizedAccessException("Credenciais inválidas.");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, userName),
                // Adicione mais claims conforme necessário
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                CompressionAlgorithm = new SymmetricSecurityKey(key).ToString(),
                Audience = _audience,
                Issuer = _issuer
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken(string userName)
        {
            // Implementar a lógica para gerar o refresh token
            var refreshToken = Guid.NewGuid().ToString(); // Exemplo simples
            return refreshToken;
        }

        public bool ValidateCredentials(string userName, string password)
        {
            // Validar credenciais do usuário
            var user = _context.Set<Usuario>().FirstOrDefault(u => u.Nome == userName);
            return user != null && ValidatePassword(user, password);
        }

        public Usuario GetUserByEmail(string email)
        {
            return _context.Set<Usuario>().FirstOrDefault(u => u.Email == email);
        }

        private bool ValidatePassword(Usuario user, string password)
        {
            // Implementar a lógica para validar a senha (por exemplo, comparar hash)
            return user.SenhaHash == GerarHash(password, user.Sal);
        }

        private string GerarHash(string senha, string sal)
        {
            using (var hashAlgorithm = SHA256.Create())
            {
                var senhaComSal = senha + sal;
                var senhaBytes = Encoding.UTF8.GetBytes(senhaComSal);
                var hashBytes = hashAlgorithm.ComputeHash(senhaBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public Task<bool> ValidateCredentialsAsync(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerateRefreshTokenAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerateTokenAsync(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
