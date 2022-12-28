using CleanArchitectureBoilerplate.Domain;

namespace CleanArchitectureBoilerplate.Application.Common.Status
{
    public interface ICleanArchitectureBoilerplateStatusService
    {
        public List<Status> GetAllStatus();

        public void AddStatus(string message, StatusSeverity severity);

        public void AddStatus(Status s);
    }
}