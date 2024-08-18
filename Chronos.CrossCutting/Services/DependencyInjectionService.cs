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

        }

        private static void RegisterServices(IServiceCollection services)
        {

        }

        private static void RegisterApplicationServices(IServiceCollection services)
        {

        }

        private static void RegisterInfrastructures(IServiceCollection services)
        {

        }

        private static void RegisterRepositories(IServiceCollection services)
        {

        }
    }
}
