using CleanArchitectureBoilerplate.Application.Common.Interfaces.Authentication;
using CleanArchitectureBoilerplate.Application.Common.Services;
using CleanArchitectureBoilerplate.Infrastructure.Authentication;
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
            
            services.AddSingleton<IJwtTokenGenerator,JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider,DateTimeProvider>();
            
            return services;
        }
    }
}