using Chronos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Infraestructure.Tokens
{
    public interface ITokenService
    {
        string GenerateToken(string userName, string password);
        string GenerateRefreshToken(string userName);
        bool ValidateCredentials(string userName, string password);
        Usuario GetUserByEmail(string email);
        Task<bool> ValidateCredentialsAsync(string userName, string password);
        Task<string> GenerateRefreshTokenAsync(string userName);
        Task<string> GenerateTokenAsync(string userName, string password);
    }
}
