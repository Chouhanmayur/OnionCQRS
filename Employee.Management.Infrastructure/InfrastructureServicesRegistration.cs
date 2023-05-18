using Employee.Management.Application.Contracts.Logging;
using Employee.Management.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Employee.Management.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            return services;
        }
    }
}