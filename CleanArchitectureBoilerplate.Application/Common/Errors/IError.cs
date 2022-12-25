namespace CleanArchitectureBoilerplate.Application.Common.Errors
{
    public interface IError{
        void AddPublicInfo(string message);
        void AddPrivateInfo(string message);
        void AddWarning(string message);
        void AddExpectedError(string message);
        void AddUnexpectedError();
        void AddUnexpectedError(string message);
    }

}