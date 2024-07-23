using Chronos.Domain.Entities._Base.Main;
using Chronos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Chronos.Domain.Interfaces.Repository._Base.Shared;

namespace Chronos.Domain.Interfaces.Repository
{
    public interface IPerfilRepository : IRepositoryBase<Perfis, IdentityRole>
    {
    }
}
