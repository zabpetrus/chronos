using Chronos.Domain.Entities;
using Chronos.Domain.Interfaces.Repository._Base.Shared;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Domain.Interfaces.Services
{
    public interface IUsuarioService : IRepositoryBase<Usuario, IdentityUser>
    {
    }
}
