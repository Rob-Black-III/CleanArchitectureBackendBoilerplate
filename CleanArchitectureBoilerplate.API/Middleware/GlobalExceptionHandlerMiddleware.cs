using CleanArchitectureBoilerplate.Application.Common.Services;
using CleanArchitectureBoilerplate.Domain;

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
             logger.Log(ex.ToString(), StatusSeverity.UNEXPECTED_ERROR);

            // var errorMessageObject = 
            //     new { Message = ex.Message, Code = "system_error" };
           
            // var errorMessage = JsonConvert.SerializeObject(errorMessageObject);
            // context.Response.ContentType = "application/json";
            // context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            // return context.Response.WriteAsync(errorMessage);
        }
    }
}