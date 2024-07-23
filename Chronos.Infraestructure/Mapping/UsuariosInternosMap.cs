using Chronos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Infraestructure.Mapping
{
    public class UsuariosInternosMap : IEntityTypeConfiguration<UsuariosInternos>
    {
        public void Configure(EntityTypeBuilder<UsuariosInternos> builder)
        {
            // Configurar a chave primária
            builder.HasKey(p => p.Id);

            // Configurar o nome da tabela
            builder.UseTptMappingStrategy().ToTable("UsuariosInternos");

            // Configurar as propriedades
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

        }
    }
}
