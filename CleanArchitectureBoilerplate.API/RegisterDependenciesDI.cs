using CleanArchitectureBoilerplate.API.APIResponseWrapper;
using CleanArchitectureBoilerplate.Application.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureBoilerplate.API;

public static class RegisterDependenciesDI
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        return services;
    }
}
