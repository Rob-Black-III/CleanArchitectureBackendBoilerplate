using CleanArchitectureBoilerplate.Application.Common.Services;
using CleanArchitectureBoilerplate.Domain;

namespace CleanArchitectureBoilerplate.API.Middleware
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ICleanArchitectureBoilerplateLogger _logger;
        public GlobalExceptionHandlerMiddleware
        (RequestDelegate next, ICleanArchitectureBoilerplateLogger logger)
        {
            _next = next;
            _logger = logger;
        }
        
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                HandleException(context, ex);
            }
        }
        private async void HandleException(HttpContext context, Exception ex)

        {
             _logger.Log(ex.ToString(), StatusSeverity.UNEXPECTED_ERROR);

            // var errorMessageObject = 
            //     new { Message = ex.Message, Code = "system_error" };
           
            // var errorMessage = JsonConvert.SerializeObject(errorMessageObject);
            // context.Response.ContentType = "application/json";
            // context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            // return context.Response.WriteAsync(errorMessage);
        }
    }
}