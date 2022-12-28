namespace CleanArchitectureBoilerplate.API.Middleware
{
    public static class RegisterMiddleware
    {
        public static IApplicationBuilder RegisterCustomMiddleware(this IApplicationBuilder builder){
            // Error Handling goes before other middleware  (logging, etc.)
            // https://stackoverflow.com/questions/56691859/net-core-order-of-middleware
            builder.UseMiddleware<ResponseWrapperMiddleware>();
            builder.UseMiddleware<GlobalExceptionHandlerMiddleware>();
            // Used for having a GUID for logs. Also show on frontend in event of 'Unexpected Error'
            //builder.UseMiddleware<TraceIDMiddleware>();

            return builder;
        }
    }
}