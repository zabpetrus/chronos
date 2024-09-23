using Chronos.Domain.Entities;
using Chronos.Domain.Interfaces.Repository;
using Chronos.Domain.Interfaces.Repository._Base;
using Chronos.Infraestructure.Context;
using Chronos.Infraestructure.Repository._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Infraestructure.Repository
{
    public class UsuarioExternoRepository : RepositoryBase<ApplicationDbContext, UsuarioExterno>, IUsuarioExternoRepository
    {
        public UsuarioExternoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override UsuarioExterno Create(UsuarioExterno model)
        {
           var user = _databaseContext.Add(model).Entity;
            return user;
        }
    }
}
