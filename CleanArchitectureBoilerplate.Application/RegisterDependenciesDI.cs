using System.Reflection;
using CleanArchitectureBoilerplate.Application.Common.Authentication;
using CleanArchitectureBoilerplate.Application.Common.Status;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureBoilerplate.Application;

    public static class RegisterDependenciesDI
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ICleanArchitectureBoilerplateStatusService, StatusService>();

            services.AddApplicationMapsterMappings();

            return services;
        }

        private static IServiceCollection AddApplicationMapsterMappings(this IServiceCollection services)
        {
            // Mappings
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>(); // ServiceMapper is included with DI package.

            return services;
        }
    }
