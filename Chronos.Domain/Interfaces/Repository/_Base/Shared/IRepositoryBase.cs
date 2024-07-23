using Chronos.Domain.Entities._Base.Interface;
using Chronos.Domain.Entities._Base.Main;
using Chronos.Domain.Interfaces.Services._Base.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Domain.Interfaces.Repository._Base.Shared
{
    public interface IRepositoryBase<T, P> : IMainService where T : class where P : class
    {
    }
}
