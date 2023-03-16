using CleanArchitectureBoilerplate.API.Common.ResponseEnvelope;

namespace CleanArchitectureBoilerplate.API.Middleware
{
    public static class RegisterMiddleware
    {
        public static IApplicationBuilder RegisterCustomMiddleware(this IApplicationBuilder builder){

            // Sets up a TraceID for the request. Associated to the logger.
            builder.UseMiddleware<TraceIDMiddleware>();

            // Since we might want our wrapper to add public issues, 
            // add error handling after so it resolves first.
            // Error Handling goes before other middleware - usually (logging, etc.)
            // https://stackoverflow.com/questions/56691859/net-core-order-of-middleware
            //builder.UseMiddleware<GlobalExceptionHandlerMiddleware>();
            builder.UseMiddleware<ErrorHandlerMiddleware>();

            // API Response wrapper. Contains meta-info and 'payload' endpoint-specific field.
            //builder.UseMiddleware<ResponseWrapperMiddleware>();

            return builder;
        }
    }
}