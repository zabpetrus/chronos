using Chronos.Application.Interfaces._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Application.AppService._Base
{
    public class AppServiceBase <T, P> : IAppServiceBase<T> where T : class where P : class
    {
    }
}
