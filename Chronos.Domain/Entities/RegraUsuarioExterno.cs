using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Domain.Entities
{
    public class RegraUsuarioExterno : RegrasUsuarios
    {
        public long UsuarioExternoId { get; set; }

        public long PerfilExternoId { get; set; }
    }
}
