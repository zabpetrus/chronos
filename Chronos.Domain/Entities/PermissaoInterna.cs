using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Domain.Entities
{
    public class PermissaoInterna : Permissao
    {
        public long UsuarioInternoId { get; set; }

        public string TipoPermissao { get; set; }

        public string ValorPermissao { get; set; }
    }
}
