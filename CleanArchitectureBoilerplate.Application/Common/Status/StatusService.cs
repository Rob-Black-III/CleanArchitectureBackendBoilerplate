namespace CleanArchitectureBoilerplate.Application.Common.Status
{
    public class StatusService : ICleanArchitectureBoilerplateStatusService
    {
        private List<Status> status;

        public StatusService()
        {
            // CTOR called every request.
            status = new List<Status>();
        }

        public void AddStatus(Status e)
        {
            status.Add(e);
        }

        public void AddStatus(string message, StatusSeverity severity){
            Status s = new Status(message, severity);
            AddStatus(s);
        }

        public void AddStatus(string title, string message, StatusSeverity severity)
        {
            Status s = new Status(message, severity, title);
            AddStatus(s);
        }
        public void AddStatus(string title, List<string> messages, StatusSeverity severity)
        {
            Status s = new Status(messages, severity, title);
            AddStatus(s);
        }

        public List<Status> GetAllStatus()
        {
            return status;
        }
    }
}