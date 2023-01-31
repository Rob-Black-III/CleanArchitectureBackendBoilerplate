using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureBoilerplate.API;

public static class RegisterDependenciesDI
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        //services.AddScoped<IActionResultExecutor<ObjectResult>, APIResponseExecutor>();

        // Adds all our validators. All validators must implement 'IAssemblyMarker'
        services.AddValidatorsFromAssemblyContaining<Program>();

        services.Configure<ApiBehaviorOptions>(options =>
        {
            // We want to use our own error handling.
            options.SuppressModelStateInvalidFilter = true;
        });

        return services;
    }
}
