using Chronos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Infraestructure.Mapping
{
    public class PerfisExternosMap : IEntityTypeConfiguration<PerfisExternos>
    {
        public void Configure(EntityTypeBuilder<PerfisExternos> builder)
        {
            // Configurar a chave primária
            builder.HasKey(p => p.Id);

            // Configurar o nome da tabela
            builder.UseTptMappingStrategy().ToTable("PerfisExternos");

           
            // Configurar as propriedades
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .HasMaxLength(255);
        }
    }
}
