using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Domain.Entities
{
    public class RegraUsuarioInterno : RegrasUsuarios
    {
        public long UsuarioInternoId { get; set; }

        public long PerfiInternoId { get; set; }
    }
}
