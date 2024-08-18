using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Domain.Interfaces.Repository._Base
{
    public interface IRepositoryBase<in T> where T : class
    {
    }
}
