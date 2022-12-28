namespace CleanArchitectureBoilerplate.Application.Common.Services
{
    public interface ICleanArchitectureBoilerplateLogger
    {

        void LogInfo(string message);
        void LogInfo(string message, bool toClient = false);
        void LogDebug(string message);
        void LogDebug(string message, bool toClient = false);
        void LogWarning(string message);
        void LogWarning(string message, bool toClient = false);
        void LogKnownCritical(string message);
        void LogKnownCritical(string message, bool toClient = false);
        void LogUnknownCritical(string message);
        void LogUnknownCritical(string message, bool toClient = false);
    }
}