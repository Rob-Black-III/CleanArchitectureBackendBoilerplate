using CleanArchitectureBoilerplate.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CleanArchitectureBoilerplate.Application.Common.Status
{
    public class Status
    {

        [JsonProperty]
        private string Title; // Human readable title for the error (i.e. Validation Error)

        [JsonProperty]
        private string Message; // Message 
        
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty]
        private StatusSeverity Severity;

        // Inject logger?
        [JsonConstructor]
        public Status(string message, StatusSeverity severity, string title = "Status"){
            Message = message;
            Severity = severity;
            Title = title;
        }

        public StatusSeverity GetSeverity()
        {
            return Severity;
        }
        public string GetMessage(){
            return Message;
        }

        public string GetTitle(){
            return Title;
        }
    }

}