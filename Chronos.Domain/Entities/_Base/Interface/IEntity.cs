using Chronos.Domain.Entities._Base.Main;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Domain.Entities._Base.Interface
{
    public interface IEntity<T, P> where T : class where P : Entity
    {
    }

}
