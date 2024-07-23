using Chronos.Domain.Entities._Base.Interface;
using Chronos.Domain.Entities._Base.Main;
using Chronos.Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace Chronos.Domain.Entities
{
    public class Perfis : IdentityRole<long>, IEntity<IdentityRole<long>, Entity>
    {
        public string Nome {  get; set; }

        public string Description { get; set; }

        public TipoPerfil Tipo_Perfil { get; set; } 

    }
}
