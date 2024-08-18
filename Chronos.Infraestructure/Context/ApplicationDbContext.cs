using Chronos.Domain.Entities;
using Chronos.Infraestructure.Mapping;
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
    public class ApplicationDbContext : IdentityDbContext<Usuario,  Perfil, long>
    {                                                                                  
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Registro> Registros { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<UsuarioExterno> UsuariosExternos { get; set; }
        public DbSet<UsuarioInterno> UsuariosInternos { get; set; }
        public DbSet<PerfilExterno> PerfisExternos { get; set; }
        public DbSet<PerfilInterno> PerfisInternos { get; set; }
        public DbSet<RegraUsuarioExterno> RegrasUsuariosExternos { get; set; }
        public DbSet<RegraUsuarioInterno> RegrasUsuariosInternos { get; set; }
        public DbSet<PermissaoExterna> PermissoesExternas { get; set; }
        public DbSet<PermissaoInterna> PermissoesInternas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Usuario>();
            modelBuilder.Ignore<Perfil>();
            modelBuilder.Ignore<Permissao>();
            modelBuilder.Ignore<RegrasUsuarios>();

            modelBuilder.Entity<UsuarioExterno>().ToTable("UsuariosExternos").HasKey(u => u.Id); 
            modelBuilder.Entity<UsuarioInterno>().ToTable("UsuariosInternos").HasKey(u => u.Id); 
            modelBuilder.Entity<PerfilExterno>().ToTable("PerfisExternos").HasKey(u => u.Id);
            modelBuilder.Entity<PerfilInterno>().ToTable("PerfisInternos").HasKey(u => u.Id);
            modelBuilder.Entity<PermissaoExterna>().ToTable("PermissoesExternas");
            modelBuilder.Entity<PermissaoInterna>().ToTable("PermissoesInternas");
            modelBuilder.Entity<RegraUsuarioExterno>().ToTable("RegrasUsuariosExternos");
            modelBuilder.Entity<RegraUsuarioInterno>().ToTable("RegrasUsuariosInternos");

            base.OnModelCreating(modelBuilder);

        }
    }
}
