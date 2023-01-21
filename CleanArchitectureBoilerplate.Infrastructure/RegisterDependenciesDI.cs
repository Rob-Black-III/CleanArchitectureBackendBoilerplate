using CleanArchitectureBoilerplate.Application.Common.Interfaces.Authentication;
using CleanArchitectureBoilerplate.Application.Common.Interfaces.Persistence;
using CleanArchitectureBoilerplate.Application.Common.Services;
using CleanArchitectureBoilerplate.Infrastructure.Authentication;
using CleanArchitectureBoilerplate.Infrastructure.Logging;
using CleanArchitectureBoilerplate.Infrastructure.Persistence;
using CleanArchitectureBoilerplate.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureBoilerplate.Infrastructure
{
    public static class RegisterDependenciesDI
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            
            // Services
            services.AddSingleton<IJwtTokenGenerator,JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider,DateTimeProvider>();
            services.AddScoped<ICleanArchitectureBoilerplateLogger,SerilogLogger>(); // scoped due to scoped statusService

            // Repositories
            services.AddScoped<IProductRepository, ProductRepository>();
        
            services.AddDbContext<CleanArchitectureBoilerplateDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            //services.AddScoped<IMyDbContext, MyDbContext>();
            
            return services;
        }
    }
}