namespace CleanArchitectureBoilerplate.Application.Common.Errors
{
    public class ErrorService : IErrorService
    {
        private List<Error> errors;
        public ErrorService()
        {
            // CTOR called every request.
            errors = new List<Error>();
        }

        public void AddError(Error e)
        {
            errors.Add(e);
        }

        public List<Error> GetAllErrors()
        {
            return errors;
        }
    }
}