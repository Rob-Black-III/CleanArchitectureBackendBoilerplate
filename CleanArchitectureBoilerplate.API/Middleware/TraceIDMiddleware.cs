using CleanArchitectureBoilerplate.Application.Common.Services;

namespace CleanArchitectureBoilerplate.API.Middleware
{
    public class TraceIDMiddleware
    {
        private readonly RequestDelegate _next;

        public TraceIDMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ICleanArchitectureBoilerplateLogger logger)
        {
            context.TraceIdentifier = Guid.NewGuid().ToString();
            string id = context.TraceIdentifier;
            context.Response.Headers["X-Trace-Id"] = id;

            logger.SetTraceID(id);
            logger.LogDebug($"Created GUID traceID: {id}");

            await _next(context);
        }
    }
}