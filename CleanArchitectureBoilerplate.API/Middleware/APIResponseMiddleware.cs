// using CleanArchitectureBoilerplate.API.APIResponseWrapper;
// using CleanArchitectureBoilerplate.Application.Common.Services;
// using CleanArchitectureBoilerplate.Application.Common.Status;
// using Newtonsoft.Json;

// namespace CleanArchitectureBoilerplate.API.Middleware
// {
//     public class APIResponseMiddleware
//     {
//         private readonly RequestDelegate _next;
//         public APIResponseMiddleware(RequestDelegate next)
//         {
//             _next = next;
//         }
        
//         // Have to inject logger here. Cannot inject scoped into middleware.
//         public async Task Invoke
//         (HttpContext context, ICleanArchitectureBoilerplateLogger logger, 
//         ICleanArchitectureBoilerplateStatusService statusService)
//         {
//             // Loosely stolen from:
//             // https://github.com/nayanbunny/dotnet-webapi-response-wrapper-sample/blob/main/DotNet.ResponseWrapper.Sample.Api/Middleware/ResponseWrapperMiddleware.cs

//             // REQUEST
            
//             // Get the APIResponse 'wrapper' object.
//             APIResponse<Object> responseWrapper = new APIResponse<Object>();

//             // 1. Get traceID that was updated in a prior middleware.
//             responseWrapper.traceID = context.TraceIdentifier;

//             // Storing Context Body Response
//             var currentBody = context.Response.Body;

//             // Using MemoryStream to hold Controller Response
//             using var memoryStream = new MemoryStream();
//             context.Response.Body = memoryStream;

//             await _next(context);

//             // NOTE: PAYLOAD MAPPING WILL HAPPEN IN CONTROLLER.
//             // EACH CONTROLLER WILL MODIFY THE PAYLOAD VARIABLE DIRECTLY USING THE DI APIRESPONSE SERVICE

//             // On return trip, add all the errors to the API response
//             responseWrapper.issues =  statusService.GetAllStatus();

//             // Replace the entire result with the APIResponseWrapper
//             // var apiResponseObject = JsonConvert.SerializeObject(responseWrapper);
//             // context.Response.ContentType = "application/json";
//             // context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
//             // await context.Response.WriteAsync(apiResponseObject);

//             // Resetting Context Body Response
//             context.Response.Body = currentBody;

//             // Setting Memory Stream Position to Beginning
//             memoryStream.Seek(0, SeekOrigin.Begin);

//             // Read Memory Stream data to the end
//             var readToEnd = new StreamReader(memoryStream).ReadToEnd();

//             // Deserializing Controller Response to an object
//             var result = JsonConvert.DeserializeObject(readToEnd);

//             // Copy existing payload to apiResponse.payload and map to HTTP response object.
//             responseWrapper.payload = result;
//             var response = responseWrapper;

//             // returing response to caller
//             await context.Response.WriteAsync(JsonConvert.SerializeObject(response));

            
//         }
//     }
// }