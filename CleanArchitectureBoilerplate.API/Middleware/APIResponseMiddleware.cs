using CleanArchitectureBoilerplate.Application.Common.Errors;
using CleanArchitectureBoilerplate.Application.Common.Services;

namespace CleanArchitectureBoilerplate.API.Middleware
{
    public class APIResponseMiddleware
    {
        private readonly RequestDelegate _next;
        public APIResponseMiddleware
        (RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task Invoke(HttpContext context, ICleanArchitectureBoilerplateLogger logger, IErrorService errorService)
        {

            // REQUEST
            APIResponse apiResponseWrapper = new APIResponse();

            // 1. Get traceID;
            apiResponseWrapper.traceID = context.TraceIdentifier;

            await _next(context);
            
            // RESPONSE
            
            // Map endpoint payload to payload variable
            

            // On return trip, add all the errors to the API response
            apiResponseWrapper.issues =  errorService.GetAllErrors();
        }
    }
}