using Chronos.Domain.Entities;
using Chronos.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Infraestructure.Mapping
{
    public class UsuariosMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            // Configurar a chave primária
            builder.HasKey(p => p.Id);

           
           
            builder.HasDiscriminator(u => u.Tipo_Usuario)
             .HasValue<Usuario>(TipoUsuario.Interno)
             .HasValue<Usuario>(TipoUsuario.Externo); 

            // Configurar as propriedades
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            // Configurar o nome da tabela
            builder.ToTable("Usuarios");

        }
    }
}
