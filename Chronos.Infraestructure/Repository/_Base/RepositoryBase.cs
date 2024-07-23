using Chronos.Domain.Entities._Base.Main;
using Chronos.Domain.Interfaces.Repository._Base.Shared;
using Chronos.Infraestructure.Context;
using Chronos.Infraestructure.Tokens;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Infraestructure.Repository._Base
{
    public abstract class RepositoryBase<T, P> : Notifiable<Notification>, IRepositoryBase<T, P> where T : class where P : class
    {
        protected readonly ApplicationDbContext _context;
        private readonly ITokenService _tokenService;

        protected RepositoryBase(ApplicationDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public virtual void Add<T1>(T1 entity) where T1 : class
        {
            _context.Set<T1>().Add(entity);
            _context.SaveChanges();
        }

        public virtual void Update<T1>(T1 entity) where T1 : class
        {
            _context.Set<T1>().Update(entity);
            _context.SaveChanges();
        }

        public virtual void Delete<T1>(T1 entity) where T1 : class
        {
            _context.Set<T1>().Remove(entity);
            _context.SaveChanges();
        }

        public virtual T1 GetById<T1>(int id) where T1 : class
        {
            return _context.Set<T1>().Find(id);
        }

        public virtual IEnumerable<T1> GetAll<T1>() where T1 : class
        {
            return _context.Set<T1>().ToList();
        }

        public async Task<string> GenerateTokenAsync(string userName, string password)
        {
            return await _tokenService.GenerateTokenAsync(userName, password);
        }

        public async Task<string> GenerateRefreshTokenAsync(string userName)
        {
            return await _tokenService.GenerateRefreshTokenAsync(userName);
        }

        public async Task<bool> ValidateCredentialsAsync(string userName, string password)
        {
            return await _tokenService.ValidateCredentialsAsync(userName, password);
        }

        public async Task<Usuario> GetUserByEmailAsync(string email)
        {
            return await _context.Set<Usuario>().FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<Usuario>> SearchUsersByKeywordAsync(string keyword)
        {
            return await _context.Set<Usuario>()
                .Where(u => u.Nome.Contains(keyword) || u.Email.Contains(keyword))
                .ToListAsync();
        }
    }

}
