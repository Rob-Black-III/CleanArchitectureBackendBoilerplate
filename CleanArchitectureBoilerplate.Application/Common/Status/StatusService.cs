using CleanArchitectureBoilerplate.Application.Common.Services;

namespace CleanArchitectureBoilerplate.Application.Common.Status
{
    public class StatusService : ICleanArchitectureBoilerplateStatusService
    {
        private List<Status> status;

        private readonly ICleanArchitectureBoilerplateLogger _logger;
        public StatusService(ICleanArchitectureBoilerplateLogger logger)
        {
            // CTOR called every request.
            status = new List<Status>();
            _logger = logger;
        }

        public void AddStatus(Status e)
        {
            status.Add(e);
            _logger.Log(e.GetMessage(),e.GetSeverity());
        }

        public List<Status> GetAllStatus()
        {
            _logger.Log("Retrieving statuses...",Domain.StatusSeverity.INFO);
            return status;
        }
    }
}