using Chronos.Domain.Entities;
using Chronos.Domain.Entities._Base.Main;
using Chronos.Domain.Interfaces.Repository._Base.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Domain.Interfaces.Services
{
    public interface IEnderecoService: IRepositoryBase<Endereco, Entity>
    {
    }
}
