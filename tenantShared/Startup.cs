using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace tenantShared
{
    public static class Startup
    {
        public static IServiceCollection AddDependenciesShared(this IServiceCollection services, IConfiguration configuration)
        {


            return services;
        }
    }
}
