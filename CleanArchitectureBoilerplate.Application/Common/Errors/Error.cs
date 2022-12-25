using CleanArchitectureBoilerplate.Domain;

namespace CleanArchitectureBoilerplate.Application.Common.Errors
{
    public class Error : IError
    {
        private string message;
        private StatusSeverity severity;

        // Inject logger?
        private Error(){
        }

        public void AddExpectedError(string message)
        {
            throw new NotImplementedException();
        }

        public void AddPrivateInfo(string message)
        {
            throw new NotImplementedException();
        }

        public void AddPublicInfo(string message)
        {
            throw new NotImplementedException();
        }

        public void AddUnexpectedError()
        {
            AddUnexpectedError("An internal server error occured.");
        }

        public void AddUnexpectedError(string message)
        {
            throw new NotImplementedException();
        }

        public void AddWarning(string message)
        {
            throw new NotImplementedException();
        }
    }

}