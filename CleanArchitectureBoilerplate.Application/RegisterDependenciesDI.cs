using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureBoilerplate.Application
{
    public static class RegisterDependenciesDI
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            /*
            services.addScoped<IAuthenticationService, AuthenticationService>();
            return services;
            */
            return null;
        }
    }
}