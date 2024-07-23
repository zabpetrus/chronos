using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Domain.Interfaces.Services._Base.Main
{
    public interface IMainService
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        T GetById<T>(int id) where T : class;
        IEnumerable<T> GetAll<T>() where T : class;

        // Métodos adicionais
        Task<string> GenerateTokenAsync(string userName, string password);
        Task<string> GenerateRefreshTokenAsync(string userName);
        Task<bool> ValidateCredentialsAsync(string userName, string password);
        Task<Usuario> GetUserByEmailAsync(string email);
        Task<IEnumerable<Usuario>> SearchUsersByKeywordAsync(string keyword);
    }
}
