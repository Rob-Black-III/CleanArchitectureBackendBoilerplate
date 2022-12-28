using CleanArchitectureBoilerplate.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CleanArchitectureBoilerplate.Application.Common.Status
{
    public class Status
    {
        [JsonProperty]
        private string Message;
        
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty]
        private StatusSeverity Severity;

        // Inject logger?
        [JsonConstructor]
        public Status(string message, StatusSeverity severity){
            Message = message;
            Severity = severity;
        }

        public string GetMessage(){
            return Message;
        }

        public StatusSeverity GetSeverity(){
            return Severity;
        }
    }

}