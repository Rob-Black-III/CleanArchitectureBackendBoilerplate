using CleanArchitectureBoilerplate.Application.Authentication;
using CleanArchitectureBoilerplate.Application.Common.Errors;
using CleanArchitectureBoilerplate.Application.Products;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureBoilerplate.Application;

    public static class RegisterDependenciesDI
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IErrorService, ErrorService>();
            return services;
        }
    }
