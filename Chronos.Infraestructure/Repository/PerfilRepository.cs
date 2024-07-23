using Chronos.Domain.Entities._Base.Main;
using Chronos.Domain.Entities;
using Chronos.Domain.Interfaces.Repository;
using Chronos.Infraestructure.Repository._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Chronos.Infraestructure.Context;
using Chronos.Infraestructure.Tokens;

namespace Chronos.Infraestructure.Repository
{
    public class PerfilRepository : RepositoryBase<Perfis, IdentityRole>, IPerfilRepository
    {
        public PerfilRepository(ApplicationDbContext context, ITokenService tokenService) : base(context, tokenService)
        {
        }
    }
}
