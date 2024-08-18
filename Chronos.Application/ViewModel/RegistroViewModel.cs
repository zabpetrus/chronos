using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Application.ViewModel
{
    public class RegistroViewModel
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public DateTime DataNascimento { get; set; }

        public byte[] Documentos { get; set; }
    }
}
