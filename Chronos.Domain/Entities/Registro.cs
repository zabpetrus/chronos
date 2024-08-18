using Chronos.Domain.Entities._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Domain.Entities
{
    public class Registro : Entity { 

        public string Nome {  get; set; }

        public string Cpf { get; set; }

        public DateTime DataNascimento { get; set; }

        public byte[] Documentos { get; set; }

    }
}
