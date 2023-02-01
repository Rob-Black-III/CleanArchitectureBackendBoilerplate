using CleanArchitectureBoilerplate.API.APIResponseWrapper;
using CleanArchitectureBoilerplate.Application.Common.Services;
using CleanArchitectureBoilerplate.Application.Common.Status;
using Newtonsoft.Json;

/*
TODO couples our api to payload of type JSON. Need to find a better implementation.
See 'APIResponseExecutor'. Couldn't get it working. If so, replace this.
*/
namespace CleanArchitectureBoilerplate.API.Middleware
{
    public class ResponseWrapperMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseWrapperMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ICleanArchitectureBoilerplateStatusService statusService, ICleanArchitectureBoilerplateLogger logger)
        {

            // Before we mess up anything, set the traceID so we can figure it out later.
            //APIResponse result = new APIResponse(context.TraceIdentifier);
            APIResponse result = new APIResponse();
            
            var currentBody = context.Response.Body;

            using (var memoryStream = new MemoryStream())
            {
                //set the current response to the memorystream.
                context.Response.Body = memoryStream;

                await _next(context);

                //reset the body 
                context.Response.Body = currentBody;
                memoryStream.Seek(0, SeekOrigin.Begin);

                var readToEnd = new StreamReader(memoryStream).ReadToEnd();
                var objResult = JsonConvert.DeserializeObject(readToEnd);

                // On the response, fill out scoped response info (payload and issues)
                result.Issues = statusService.GetAllStatus();
                result.Payload = objResult;

                logger.LogDebug("Writing API Response Wrapper payload...");

                await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
            }
        }
    }
}