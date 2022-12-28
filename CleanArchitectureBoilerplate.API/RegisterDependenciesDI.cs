using CleanArchitectureBoilerplate.API.APIResponseWrapper;
using CleanArchitectureBoilerplate.Application.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureBoilerplate.API;

public static class RegisterDependenciesDI
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        //services.AddScoped<IActionResultExecutor<ObjectResult>, APIResponseExecutor>();

        return services;
    }
}
