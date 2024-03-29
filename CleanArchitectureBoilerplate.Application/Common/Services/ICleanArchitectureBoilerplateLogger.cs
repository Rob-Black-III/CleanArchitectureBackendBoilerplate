namespace CleanArchitectureBoilerplate.Application.Common.Services
{
        public enum LogLevel
    {
        Debug,
        Information,
        Warning,
        Error,
        UnexpectedError
    }

    public interface ICleanArchitectureBoilerplateLogger
    {
        void SetTraceID(string traceId);
        void LogInfo(string message);
        void LogDebug(string message);
        void LogWarning(string message);
        void LogKnownError(string message);
        void LogUnknownError(string message);
    }
}