using Chronos.Domain.Entities;
using Chronos.Infraestructure.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Chronos.Infraestructure.Context
{
    public class ApplicationDbContext : DbContext
    {                                                                                  
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<UsuarioExterno> UsuariosExternos { get; set; }
        public DbSet<UsuarioInterno> UsuariosInternos { get; set; }
        public DbSet<PerfilExterno> PerfisExternos { get; set; }
        public DbSet<PerfilInterno> PerfisInternos { get; set; }          

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Usuario>().UseTptMappingStrategy();
            //modelBuilder.Entity<Perfil>().UseTptMappingStrategy();
            //modelBuilder.Entity<Permissao>().UseTptMappingStrategy();
            //modelBuilder.Entity<RegrasUsuarios>().UseTptMappingStrategy();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsuarioExternoTypeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsuarioInternoTypeConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);

        }
    }
}
