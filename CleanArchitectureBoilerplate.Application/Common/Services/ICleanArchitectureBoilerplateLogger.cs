
using CleanArchitectureBoilerplate.Domain;

namespace CleanArchitectureBoilerplate.Application.Common.Services
{
    public interface ICleanArchitectureBoilerplateLogger
    {
        void Log(string message, StatusSeverity severity, Boolean isPublic);

        void Log(string message, StatusSeverity severity);
    }
}