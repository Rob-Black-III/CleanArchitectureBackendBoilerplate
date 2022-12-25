using CleanArchitectureBoilerplate.Domain;

namespace CleanArchitectureBoilerplate.Application.Common.Status
{
    public class Status : ICleanArchitectureBoilerplateStatus
    {
        private string Message;
        private StatusSeverity Severity;

        // Inject logger?
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

        // public void AddExpectedError(string message)
        // {
        //     throw new NotImplementedException();
        // }

        // public void AddPrivateInfo(string message)
        // {
        //     throw new NotImplementedException();
        // }

        // public void AddPublicInfo(string message)
        // {
        //     throw new NotImplementedException();
        // }

        // public void AddUnexpectedError()
        // {
        //     AddUnexpectedError("An internal server error occured.");
        // }

        // public void AddUnexpectedError(string message)
        // {
        //     throw new NotImplementedException();
        // }

        // public void AddWarning(string message)
        // {
        //     throw new NotImplementedException();
        // }
    }

}