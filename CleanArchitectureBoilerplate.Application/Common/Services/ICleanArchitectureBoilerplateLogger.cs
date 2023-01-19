namespace CleanArchitectureBoilerplate.Application.Common.Services
{
    public interface ICleanArchitectureBoilerplateLogger
    {
        void LogInfo(string message);
        void LogDebug(string message);
        void LogWarning(string message);
        void LogKnownCritical(string message);
        void LogUnknownCritical(string message);
    }
}