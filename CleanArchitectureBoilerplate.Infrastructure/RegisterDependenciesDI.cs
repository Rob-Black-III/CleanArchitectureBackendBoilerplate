using CleanArchitectureBoilerplate.Application.Accounts;
using CleanArchitectureBoilerplate.Application.Common.Authentication;
using CleanArchitectureBoilerplate.Application.Common.Services;
using CleanArchitectureBoilerplate.Infrastructure.Accounts;
using CleanArchitectureBoilerplate.Infrastructure.Common.Authentication;
using CleanArchitectureBoilerplate.Infrastructure.Common.Logging;
using CleanArchitectureBoilerplate.Infrastructure.Common.Persistence;
using CleanArchitectureBoilerplate.Infrastructure.Common.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureBoilerplate.Infrastructure
{
    public static class RegisterDependenciesDI
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            
            // Services - Domain-Agnostic Functionality (Boilerplate)
            services.AddSingleton<IJwtTokenGenerator,JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider,DateTimeProvider>();
            services.AddScoped<ICleanArchitectureBoilerplateLogger,SerilogLogger>();

            // Services - Domain-Specific Functionality
            services.AddScoped<IAccountService, AccountService>();

            // Repositories
            services.AddScoped<IAccountRepository, AccountRepository>();
            
            // Add DB Context
            services.AddDbContext<CleanArchitectureBoilerplateDbContext>();
            //services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            //services.AddScoped<IMyDbContext, MyDbContext>();
            
            return services;
        }
    }
}