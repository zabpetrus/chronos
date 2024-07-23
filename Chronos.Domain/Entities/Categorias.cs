using Chronos.Domain.Entities._Base.Interface;
using Chronos.Domain.Entities._Base.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Domain.Entities
{
    public class Categorias : Entity, IEntity<Entity, Entity>
    {  
        public string Nome {  get; set; }
    }
}
