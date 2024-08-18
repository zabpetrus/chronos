using Chronos.Domain.Interfaces.Services._Base.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Domain.Interfaces.Services._Base.Shared
{
    public interface IServiceBase<T, P> : IMainService where T : class where P : class
    {
    }
}
