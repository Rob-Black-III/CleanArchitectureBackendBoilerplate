using System.Runtime.Serialization;
using Newtonsoft.Json;
using CleanArchitectureBoilerplate.Application.Common.Status;

namespace CleanArchitectureBoilerplate.API.APIResponseWrapper
{
    // Considered using generics "APIResponse<T>; payload T". TODO
    [DataContract]
    public class APIResponse
    {
        // For logging. GUID
        [DataMember]
        public string traceID = null!;
        // Will likely be an Task<IActionResult<ENDPOINT_RESPONSE>>

        [DataMember(EmitDefaultValue = false)]
        public object payload;
        [DataMember(EmitDefaultValue = false)]

        public List<Status> issues;

        [DataMember]
        public List<string> test => new List<string>{"this is example 1","this is another example."};

        [DataMember]
        public static string test2 = "testy test.";

        public APIResponse(){
        }
    }

}