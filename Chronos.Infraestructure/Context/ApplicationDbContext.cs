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

namespace Chronos.Infraestructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<Usuario, Perfis, long>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        DbSet<UsuariosInternos> UsuariosInternos { get; set; }
        DbSet<UsuariosExternos> UsuariosExternos { get; set; }
        DbSet<PerfisInternos> PerfisInternos { get; set; }
        DbSet<PerfisExternos> PerfisExternos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PerfisExternosMap());
            modelBuilder.ApplyConfiguration(new PerfisInternosMap());
            modelBuilder.ApplyConfiguration(new UsuariosExternosMap());
            modelBuilder.ApplyConfiguration(new UsuariosInternosMap());

         }



    }
}
