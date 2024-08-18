using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Domain.Entities
{
    public abstract class Usuario : IdentityUser<long>
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string SenhaHash { get; set; }
        public string Sal { get; set; }
    }
}
