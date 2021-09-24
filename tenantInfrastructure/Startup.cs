using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using tenantCore.Interfaces;
using tenantCore.Services;
using tenantInfrastructure.Data;
using tenantInfrastructure.Models;
using tenantInfrastructure.Repositories;

namespace tenantInfrastructure
{
    public static class Startup
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<SignInManager<ApplicationUser>>();
            services.AddTransient<UserManager<ApplicationUser>>();

            return services;
        }

        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<IConfigRepo, ConfigRepo>();
            services.AddTransient<IConfigService, ConfigService>();

            return services;
        }

        public static IApplicationBuilder UpdateDatabase(this IApplicationBuilder applicationBuilder, MultitenantDbContext appDbContext, IHttpContextAccessor accessor, IConfiguration configuration)
        {
            applicationBuilder.Use(async (context, next) => {
                using (var tenantDbContext = new MultitenantDbContext(accessor, configuration))
                {
                    if (accessor.HttpContext.User.Identity.IsAuthenticated)
                    {
                        tenantDbContext.Database.Migrate();
                    }                        
                }
                await next();
            });

            return applicationBuilder;
        }

    }
}
