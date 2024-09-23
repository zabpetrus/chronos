using Chronos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Infraestructure.Configuration
{
    public class UsuarioInternoTypeConfiguration : IEntityTypeConfiguration<UsuarioInterno>
    {
        public void Configure(EntityTypeBuilder<UsuarioInterno> builder)
        {
            builder.HasKey(x => x.Id);  
        }
    }
}
