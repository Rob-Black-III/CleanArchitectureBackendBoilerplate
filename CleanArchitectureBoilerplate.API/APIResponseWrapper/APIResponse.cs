using CleanArchitectureBoilerplate.Application.Common.Status;

namespace CleanArchitectureBoilerplate.API.APIResponseWrapper
{
    // Considered using generics "APIResponse<T>; payload T". TODO
    // Considered getting rid of this and either returning 
    // an endpoint-specific payload or a problemdetail object.
    // The question: Is there any additional meta data we need on a succesful request?
    internal class APIResponse
    {
        // For logging. GUID
        private string TraceID {get; init;} = null!;
        public object? payload;

        public List<Status>? issues;

        public APIResponse(string traceID)
        {
            TraceID = traceID;
        }
    }
}