using CleanArchitectureBoilerplate.Application.Common.Status;

namespace CleanArchitectureBoilerplate.API.APIResponseWrapper
{
    // Considered using generics "APIResponse<T>; payload T". TODO
    public class APIResponse
    {
        // For logging. GUID
        public string traceID = null!;
        public object? payload;

        public List<Status>? issues;
    }
}