using CleanArchitectureBoilerplate.API.APIResponseWrapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CleanArchitectureBoilerplate.API;

public static class RegisterDependenciesDI
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        services.AddScoped<IActionResultExecutor<ObjectResult>, APIResponseExecutor>();

        // Adds all our validators. All validators must implement 'IAssemblyMarker'
        services.AddValidatorsFromAssemblyContaining<Program>();

        services.Configure<ApiBehaviorOptions>(options =>
        {
            // We want to use our own error handling.
            // Suppresses automatic 400 BadRequest provided via the [ApiController]
            // https://stackoverflow.com/questions/59922693/fluentvalidation-use-custom-iactionfilter
            options.SuppressModelStateInvalidFilter = true;
        });

        services.Configure<RouteHandlerOptions>(options =>
        {
            // We want to use our own error handling.
            //options.ThrowOnBadRequest = true;
        });

        return services;
    }
}
