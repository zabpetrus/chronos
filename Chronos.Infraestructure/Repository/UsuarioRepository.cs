using Chronos.Domain.Entities;
using Chronos.Domain.Interfaces.Repository;
using Chronos.Infraestructure.Context;
using Chronos.Infraestructure.Repository._Base;
using Chronos.Infraestructure.Tokens;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Infraestructure.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario, IdentityUser>, IUsuariosRepository
    {
        public UsuarioRepository(ApplicationDbContext context, ITokenService tokenService) : base(context, tokenService)
        {
        }
    }
}
