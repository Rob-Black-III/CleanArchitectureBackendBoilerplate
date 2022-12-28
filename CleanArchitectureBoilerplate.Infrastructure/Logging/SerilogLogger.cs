
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

        public void Log(string message, StatusSeverity severity, bool isPublic)
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

        public void Log(string message, StatusSeverity severity)
        {
            Log(message, severity, false);
        }
    }
}