using CleanArchitectureBoilerplate.Application.Common.Services;

namespace CleanArchitectureBoilerplate.API.Middleware
{
    // This global handler is never intended to be used.
    // Exceptions should be caught as Errors and logged in lower layers.
    // Exceptions should never be thrown.
    // This middleware exists as a 'catch-all'.
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task Invoke(HttpContext context, ICleanArchitectureBoilerplateLogger logger)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                HandleException(context, ex, logger);
            }
        }
        private async void HandleException(HttpContext context, Exception ex, ICleanArchitectureBoilerplateLogger logger)
        {
             logger.LogUnknownCritical(ex.ToString());
        }
    }
}