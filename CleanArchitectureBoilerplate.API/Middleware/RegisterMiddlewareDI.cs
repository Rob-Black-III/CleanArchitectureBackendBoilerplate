namespace CleanArchitectureBoilerplate.API.Middleware
{
    public static class RegisterMiddleware
    {
        public static IApplicationBuilder RegisterCustomMiddleware(this IApplicationBuilder builder){
            // API Response wrapper. Contains meta-info and 'payload' endpoint-specific field.
            builder.UseMiddleware<ResponseWrapperMiddleware>();

            // Since we might want our wrapper to add public issues, 
            // add error handling after so it resolves first.
            // Error Handling goes before other middleware - usually (logging, etc.)
            // https://stackoverflow.com/questions/56691859/net-core-order-of-middleware
            builder.UseMiddleware<GlobalExceptionHandlerMiddleware>();

            // Used for having a GUID for logs. Also show on frontend in event of 'Unexpected Error'
            //builder.UseMiddleware<TraceIDMiddleware>();

            return builder;
        }
    }
}