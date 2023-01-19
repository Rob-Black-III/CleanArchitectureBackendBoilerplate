
using CleanArchitectureBoilerplate.Application.Common.Services;
using CleanArchitectureBoilerplate.Application.Common.Status;
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
            Log(message,StatusSeverity.DEBUG);
        }

        public void LogInfo(string message)
        {
            Log(message,StatusSeverity.INFO);
        }

        public void LogKnownCritical(string message)
        {
            Log(message,StatusSeverity.ERROR);
        }

        public void LogUnknownCritical(string message)
        {
            Log(message,StatusSeverity.UNEXPECTED_ERROR);
        }

        public void LogWarning(string message)
        {
            Log(message,StatusSeverity.WARN);
        }

        /*
        Helper
        Logs the request, and optionally adds a public-facing status message to the API Response.
        Abstraction layer from our logging status to Serilog's status.
        */
        private void Log(string message, StatusSeverity severity)
        {
            switch(severity){
                case StatusSeverity.DEBUG:
                    // TODO Check if debug is set in configuration.
                    Serilog.Log.Debug(message);
                    break;
                case StatusSeverity.INFO:
                    Serilog.Log.Information(message);
                    break;
                case StatusSeverity.ERROR or StatusSeverity.UNEXPECTED_ERROR:
                    Serilog.Log.Error(message);
                    break;
                case StatusSeverity.WARN:
                    Serilog.Log.Warning(message);
                    break;
                default:
                    Serilog.Log.Warning(message);
                    break;
            }
        }
    }
}