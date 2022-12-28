
using CleanArchitectureBoilerplate.Application.Common.Services;
using CleanArchitectureBoilerplate.Application.Common.Status;
using CleanArchitectureBoilerplate.Domain;
using Serilog;

namespace CleanArchitectureBoilerplate.Infrastructure.Logging
{
    public class SerilogLogger : ICleanArchitectureBoilerplateLogger
    {
        private readonly ICleanArchitectureBoilerplateStatusService _statusService;

        public SerilogLogger(ICleanArchitectureBoilerplateStatusService statusService)
        {
            _statusService = statusService;

            Serilog.Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public void LogDebug(string message)
        {
            Log(message,StatusSeverity.DEBUG,false);
        }

        public void LogDebug(string message, bool isPublic)
        {
            Log(message,StatusSeverity.DEBUG,isPublic);
        }

        public void LogInfo(string message)
        {
            Log(message,StatusSeverity.INFO,false);
        }

        public void LogInfo(string message, bool isPublic)
        {
            Log(message,StatusSeverity.INFO,isPublic);
        }

        public void LogKnownCritical(string message)
        {
            Log(message,StatusSeverity.EXPECTED_ERROR,false);
        }

        public void LogKnownCritical(string message, bool isPublic)
        {
            Log(message,StatusSeverity.EXPECTED_ERROR,isPublic);
        }

        public void LogUnknownCritical(string message)
        {
            Log(message,StatusSeverity.UNEXPECTED_ERROR,false);
        }

        public void LogUnknownCritical(string message, bool isPublic)
        {
            Log(message,StatusSeverity.UNEXPECTED_ERROR,isPublic);
        }

        public void LogWarning(string message)
        {
            Log(message,StatusSeverity.WARN,false);
        }

        public void LogWarning(string message, bool isPublic)
        {
            Log(message,StatusSeverity.WARN,isPublic);
        }

        /*
        Helper
        Logs the request, and optionally adds a public-facing status message to the API Response.
        Abstraction layer from our logging status to Serilog's status.
        */
        private void Log(string message, StatusSeverity severity, bool isPublic)
        {
            switch(severity){
                case StatusSeverity.DEBUG:
                    // TODO Check if debug is set in configuration.
                    Serilog.Log.Debug(message);
                    break;
                case StatusSeverity.INFO:
                    Serilog.Log.Information(message);
                    break;
                case StatusSeverity.EXPECTED_ERROR or StatusSeverity.UNEXPECTED_ERROR:
                    Serilog.Log.Error(message);
                    break;
                case StatusSeverity.WARN:
                    Serilog.Log.Warning(message);
                    break;
                default:
                    Serilog.Log.Warning(message);
                    break;
            }

            if(isPublic){
                _statusService.AddStatus(message,severity);
            }
        }

        /*
        Helper
        If isPublic is unspecified, assume false.
        */
        private void Log(string message, StatusSeverity severity)
        {
            Log(message, severity, false);
        }
    }
}