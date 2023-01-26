using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CleanArchitectureBoilerplate.Application.Common.Status
{
    // 1/26/23 - TODO Swap out with ProblemDetails?
    // Do we need support for IEnumerable. Will we ever have multiple error's
    // https://stackoverflow.com/questions/45758024/use-custom-validation-responses-with-fluent-validation
    public class Status
    {

        [JsonProperty]
        private string Title; // Human readable title for the error (i.e. Validation Error)

        [JsonProperty]
        private List<string> Messages; // Messages
        
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty]
        private StatusSeverity Severity;

        // Inject logger?
        public Status(string message, StatusSeverity severity, string title = "Status"){
            Messages = new List<string>();
            Messages.Add(message);
            Severity = severity;
            Title = title;
        }

        // Inject logger?
        [JsonConstructor]
        public Status(List<string> messages, StatusSeverity severity, string title = "Status")
        {
            Messages = messages;
            Severity = severity;
            Title = title;
        }

        public StatusSeverity GetSeverity()
        {
            return Severity;
        }
        public List<string> GetMessages(){
            return Messages;
        }

        public string GetTitle(){
            return Title;
        }
    }

}