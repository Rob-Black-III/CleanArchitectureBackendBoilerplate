using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureBoilerplate.API
{
    public static class RegisterDependenciesDI
    {
        // TODO figure out why this can't be added to Program.cs
        public static IServiceCollection AddAPIServices(this IServiceCollection services)
        {
            /*
            services.addScoped<IAuthenticationService, AuthenticationService>();
            return services;
            */
            return null;
        }
    }
}