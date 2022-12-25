using CleanArchitectureBoilerplate.Application.Common.Status;

namespace CleanArchitectureBoilerplate.API.APIResponseWrapper
{
    // Considered using generics "APIResponse<T>; payload T". TODO
    public class APIResponse
    {
        // For logging. GUID
        public string traceID;
        // Will likely be an Task<IActionResult<ENDPOINT_RESPONSE>>
        public dynamic payload;
        public List<Status> issues;
    }
}