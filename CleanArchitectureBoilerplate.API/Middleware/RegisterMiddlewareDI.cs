namespace CleanArchitectureBoilerplate.API.Middleware
{
    public static class RegisterMiddleware
    {
        public static IApplicationBuilder RegisterCustomMiddleware(this IApplicationBuilder builder){
            // Error Handling goes before other middleware  (logging, etc.)
            // https://stackoverflow.com/questions/56691859/net-core-order-of-middleware
            builder.UseMiddleware<GlobalExceptionHandlerMiddleware>();
            builder.UseMiddleware<ResponseWrapper>();

            // Construct our API Response Payload;
            // TraceID has to resolve first for this, therefore it is placed after.
            //builder.UseMiddleware<APIResponseMiddleware>();

            // Used for having a GUID for logs. Also show on frontend in event of 'Unexpected Error'
            //builder.UseMiddleware<TraceIDMiddleware>();

            return builder;
        }
    }
}