using Chronos.Domain.Entities;
using Chronos.Domain.Enum;
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
    public class PerfisMap : IEntityTypeConfiguration<Perfis>
    {
        public void Configure(EntityTypeBuilder<Perfis> builder)
        {
            // Configurar a chave primária
            builder.HasKey(p => p.Id);

            
            builder.HasDiscriminator(u => u.Tipo_Perfil)
                .HasValue<Perfis>(TipoPerfil.Interno)
                .HasValue<Perfis>(TipoPerfil.Externo);   
            
           
            // Configurar as propriedades
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .HasMaxLength(255);

            // Configurar o nome da tabela
            builder.ToTable("Perfis");

        }
    }
}
