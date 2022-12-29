using CleanArchitectureBoilerplate.Application.Common.Interfaces.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace CleanArchitectureBoilerplate.API;

public static class RegisterDependenciesDI
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        //services.AddScoped<IActionResultExecutor<ObjectResult>, APIResponseExecutor>();

        // Adds all our validators. All validators must implement 'IAssemblyMarker'
        services.AddValidatorsFromAssemblyContaining<Program>();

        return services;
    }
}
