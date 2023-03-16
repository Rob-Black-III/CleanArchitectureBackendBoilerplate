using System.Diagnostics;
using CleanArchitectureBoilerplate.Application.Common.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanArchitectureBoilerplate.API.Common.BaseController.ActionFilters
{
    public class LoggingActionFilter : IAsyncActionFilter
    {
        private readonly ICleanArchitectureBoilerplateLogger _logger;

        public LoggingActionFilter(ICleanArchitectureBoilerplateLogger logger)
        {
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var sw = Stopwatch.StartNew();

            // Get the IP address of the request
            var ipAddress = context.HttpContext.Connection.RemoteIpAddress?.ToString();

            // Log the start of the request
            _logger.LogInfo($"[Request] {context.HttpContext.Request.Method} {context.HttpContext.Request.Path} from {ipAddress}");

            // Call the next action filter or the action method itself
            var resultContext = await next();

            // Log the end of the request
            sw.Stop();
            var elapsedMilliseconds = sw.ElapsedMilliseconds;
            _logger.LogInfo($"[Response] {context.HttpContext.Request.Method} {context.HttpContext.Request.Path} completed in {elapsedMilliseconds} ms");
        }
    }
}