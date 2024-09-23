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
    public class UsuarioInternoService : ServiceBase<UsuarioInterno>, IUsuarioInternoService
    {
        private readonly IUsuarioInternoRepository _usuarioInternoRepository;

        public UsuarioInternoService(IUsuarioInternoRepository repository) : base(repository)
        {
            _usuarioInternoRepository = repository;
        }
    }
}
