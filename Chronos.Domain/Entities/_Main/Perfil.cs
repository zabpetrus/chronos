using Chronos.Domain.Entities._Base;
using Chronos.Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace Chronos.Domain.Entities._Main
{
    public abstract class Perfil : Entity
    {
        public string Nome { get; set; }

        public string Description { get; set; }

        public TipoPerfil TipoPerfil { get; set; }

    }
}
