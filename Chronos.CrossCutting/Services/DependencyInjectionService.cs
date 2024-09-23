using Chronos.Application.AppService;
using Chronos.Application.Interfaces;
using Chronos.Application.Tokens;
using Chronos.Domain.Interfaces.Repository;
using Chronos.Domain.Interfaces.Services;
using Chronos.Domain.Services;
using Chronos.Infraestructure.Context;
using Chronos.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace Chronos_CrossCutting.Services
{
    public class DependencyInjectionService
    {
        public static void RegisterDependencies(IConfiguration configuration, IServiceCollection services)
        {
            RegisterDatabase(configuration, services);
            RegisterRepositories(services);
            RegisterServices(services);
            RegisterApplicationServices(services);
            RegisterInfrastructures(services);
        }

        private static void RegisterDatabase(IConfiguration configuration, IServiceCollection services)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<ApplicationDbContext>( option => option.UseSqlServer(connectionString));  
        }

        private static void RegisterServices(IServiceCollection services)
        {
               services.AddScoped<IUsuarioExternoService, UsuarioExternoService>();
               services.AddScoped<IUsuarioInternoService, UsuarioInternoService>();
        }

        private static void RegisterApplicationServices(IServiceCollection services)
        {
            services.AddScoped<IUsuarioExternoAppService, UsuarioExternoAppService>();
            services.AddScoped<IUsuarioInternoAppService, UsuarioInternoAppService>();
        }

        private static void RegisterInfrastructures(IServiceCollection services)
        {
             services.AddScoped<ITokenService, TokenService>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IUsuarioExternoRepository, UsuarioExternoRepository>();
            services.AddScoped<IUsuarioInternoRepository, UsuarioInternoRepository>();
        }
    }
}
