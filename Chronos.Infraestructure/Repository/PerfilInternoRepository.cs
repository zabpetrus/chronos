using Chronos.Domain.Entities;
using Chronos.Domain.Interfaces.Repository;
using Chronos.Infraestructure.Context;
using Chronos.Infraestructure.Repository._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Infraestructure.Repository
{
    public class PerfilInternoRepository : RepositoryBase<ApplicationDbContext, PerfilInterno>, IPerfilInternoRepository
    {
        public PerfilInternoRepository(ApplicationDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
