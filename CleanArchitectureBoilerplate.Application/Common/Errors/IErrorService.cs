namespace CleanArchitectureBoilerplate.Application.Common.Errors
{
    public interface IErrorService
    {
        public void AddError(Error e);
        public List<Error> GetAllErrors();
    }
}