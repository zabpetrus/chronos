using Chronos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chronos.Infraestructure.Configuration
{
    public class PerfilInternoTypeConfiguration : IEntityTypeConfiguration<PerfilInterno>
    {
        public void Configure(EntityTypeBuilder<PerfilInterno> builder)
        {
            builder.HasKey(x => x.Id);  
        }
    }
}
