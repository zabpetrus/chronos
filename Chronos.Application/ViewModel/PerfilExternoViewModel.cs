using Chronos.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Application.ViewModel
{
    public class PerfilExternoViewModel
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public string Description { get; set; }

        public TipoPerfilExterno TipoPerfil { get; set; }
    }
}
