using CleanArchitectureBoilerplate.Application.Common.Services;
using CleanArchitectureBoilerplate.Application.Common.Status;
using Microsoft.AspNetCore.Mvc;

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
        
        public async Task Invoke(HttpContext context, [FromServices] ICleanArchitectureBoilerplateLogger logger, [FromServices] ICleanArchitectureBoilerplateStatusService statusService)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                HandleException(context, ex, logger, statusService);
            }
        }
        private async void HandleException(HttpContext context, Exception ex, ICleanArchitectureBoilerplateLogger logger, ICleanArchitectureBoilerplateStatusService statusService)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            logger.LogUnknownError(ex.ToString());
            //statusService.AddStatus("Unknown Error","An Internal Server Error has Occured.",StatusSeverity.UNEXPECTED_ERROR);
            //logger.LogUnknownError($"HTTP Status Code: {context.Response.StatusCode} - {ex.Message}");
        }
    }
}