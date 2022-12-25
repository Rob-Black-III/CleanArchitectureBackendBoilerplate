using System.Net;
using CleanArchitectureBoilerplate.API.APIResponseWrapper;
using CleanArchitectureBoilerplate.Application.Common.Errors;
using CleanArchitectureBoilerplate.Application.Common.Services;
using Newtonsoft.Json;

namespace CleanArchitectureBoilerplate.API.Middleware
{
    public class APIResponseMiddleware
    {
        private readonly RequestDelegate _next;
        public APIResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        // Have to inject logger here. Cannot inject scoped into middleware.
        public async Task Invoke
        (HttpContext context, ICleanArchitectureBoilerplateLogger logger, 
        IAPIResponseService responseService, IErrorService errorService)
        {

            // REQUEST
            
            // Get the APIResponse 'wrapper' object.
            APIResponse responseWrapper = responseService.GetResponseObject();

            // 1. Get traceID that was updated in a prior middleware.
            responseWrapper.traceID = context.TraceIdentifier;

            await _next(context);

            // NOTE: PAYLOAD MAPPING WILL HAPPEN IN CONTROLLER.
            // EACH CONTROLLER WILL MODIFY THE PAYLOAD VARIABLE DIRECTLY USING THE DI APIRESPONSE SERVICE

            // On return trip, add all the errors to the API response
            responseWrapper.issues =  errorService.GetAllErrors();

            // Replace the entire result with the APIResponseWrapper
            var apiResponseObject = JsonConvert.SerializeObject(responseWrapper);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(apiResponseObject);
        }
    }
}