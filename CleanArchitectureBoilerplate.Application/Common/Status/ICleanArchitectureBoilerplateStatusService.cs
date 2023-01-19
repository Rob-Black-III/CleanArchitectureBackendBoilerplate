using CleanArchitectureBoilerplate.Domain;

namespace CleanArchitectureBoilerplate.Application.Common.Status
{
    public interface ICleanArchitectureBoilerplateStatusService
    {
        public List<Status> GetAllStatus();

        public void AddStatus(string title, string message, StatusSeverity severity);
        public void AddStatus(string title, List<string> messages, StatusSeverity severity);

        public void AddStatus(Status s);
    }
}