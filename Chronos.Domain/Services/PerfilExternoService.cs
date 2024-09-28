using Chronos.Domain.Entities;
using Chronos.Domain.Interfaces.Repository;
using Chronos.Domain.Interfaces.Repository._Base;
using Chronos.Domain.Interfaces.Services;
using Chronos.Domain.Services._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Domain.Services
{
    public class PerfilExternoService : ServiceBase<PerfilExterno>, IPerfilExternoService
    {
        private readonly IPerfilExternoRepository _perfilExternoRepository;
        public PerfilExternoService(IPerfilExternoRepository repository) : base(repository)
        {
            _perfilExternoRepository = repository;
        }
    }
}
