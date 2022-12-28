using CleanArchitectureBoilerplate.API.APIResponseWrapper;
using CleanArchitectureBoilerplate.Application.Common.Services;
using CleanArchitectureBoilerplate.Application.Common.Status;
using Newtonsoft.Json;

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
            var currentBody = context.Response.Body;

            using (var memoryStream = new MemoryStream())
            {
                //set the current response to the memorystream.
                context.Response.Body = memoryStream;

                //Set the traceID for execution
                context.TraceIdentifier = Guid.NewGuid().ToString();
                string id = context.TraceIdentifier;
                context.Response.Headers["X-Trace-Id"] = id;

                logger.LogDebug($"Created GUID traceID: {id}");

                await _next(context);

                //reset the body 
                context.Response.Body = currentBody;
                memoryStream.Seek(0, SeekOrigin.Begin);

                var readToEnd = new StreamReader(memoryStream).ReadToEnd();
                var objResult = JsonConvert.DeserializeObject(readToEnd);

                APIResponse result = new APIResponse();
                result.issues = statusService.GetAllStatus();
                result.traceID = context.TraceIdentifier;
                result.payload = objResult;

                logger.LogDebug("Writing API Response Wrapper payload...");

                await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
            }
        }
    }
}