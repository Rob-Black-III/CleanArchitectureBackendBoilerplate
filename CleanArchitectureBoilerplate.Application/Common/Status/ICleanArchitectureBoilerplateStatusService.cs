namespace CleanArchitectureBoilerplate.Application.Common.Status
{
    public interface ICleanArchitectureBoilerplateStatusService
    {
        public void AddStatus(Status e);
        public List<Status> GetAllStatus();
    }
}