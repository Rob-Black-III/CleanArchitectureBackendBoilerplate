using CleanArchitectureBoilerplate.Application.Common.Status;

namespace CleanArchitectureBoilerplate.API.APIResponseWrapper
{
    // DEPRECATED
    // Considered using generics "APIResponse<T>; payload T". TODO
    // Considered getting rid of this and either returning 
    // an endpoint-specific payload or a problemdetail object.
    // The question: Is there any additional meta data we need on a succesful request?
    internal class APIResponse
    {
        // For logging. GUID
        public string TraceID {get; set;} = null!;
        public object Payload;
        public List<Status>? Issues;
    }

    // https://stackoverflow.com/questions/4424030/c-system-object-vs-generics
    internal class ResponseEnvelope<T>
    {
        public T Payload { set; get; }
        public string TraceID { get; set; } = null!;
        public List<Status>? Issues;
    }
}