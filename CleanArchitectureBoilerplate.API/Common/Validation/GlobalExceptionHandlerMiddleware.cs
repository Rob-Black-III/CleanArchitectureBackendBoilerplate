using System.Net;
using CleanArchitectureBoilerplate.Application.Common.Services;
using CleanArchitectureBoilerplate.Application.Common.Validation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureBoilerplate.API.Middleware
{
    // This global handler is never intended to be used.
    // Exceptions should be caught as Errors and logged in lower layers.
    // Exceptions should never be thrown.
    // This middleware exists as a 'catch-all'.
    public class ErrorHandlerMiddleware
    {
        private const string GENERIC_UNKNOWN_ERROR_MESSAGE = "An unhandled exception occurred and was caught by the middleware.";
        private readonly RequestDelegate _next;
        private readonly ICleanArchitectureBoilerplateLogger _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, [FromServices] ICleanArchitectureBoilerplateLogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogUnknownError(GENERIC_UNKNOWN_ERROR_MESSAGE + " - " + ex.Message);

                var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                if (exceptionHandlerFeature != null)
                {
                    // Specific error is logged here
                    //error = new Error(ErrorType.Unknown, exceptionHandlerFeature.Error, exceptionHandlerFeature.Error.Message);
                }

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                // Only creating an error here (and not just using a message) because the APIResponseExecutor maps Error Object Results to the appropriate fields.
                var result = new ObjectResult(Error.UnknownError())
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };

                await result.ExecuteResultAsync(new ActionContext
                {
                    HttpContext = context
                });
            }
        }
    }
}