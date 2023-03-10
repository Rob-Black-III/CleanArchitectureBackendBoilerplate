
using CleanArchitectureBoilerplate.Application.Common.Services;
using CleanArchitectureBoilerplate.Application.Common.Status;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Exceptions;

namespace CleanArchitectureBoilerplate.Infrastructure.Common.Logging
{
    internal class SerilogLogger : ICleanArchitectureBoilerplateLogger
    {
        private readonly ICleanArchitectureBoilerplateStatusService _statusService;

        private string? traceID = default;

        public SerilogLogger(ICleanArchitectureBoilerplateStatusService statusService)
        {
            _statusService = statusService;

            Serilog.Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.WithExceptionDetails()
                .WriteTo.Console()
                .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public void SetTraceID(string tId){
            traceID = tId;
        }

        public void LogDebug(string message)
        {
            // Performance wrapper. Saves unneccesary call and heap allocation.
            if (Serilog.Log.Logger.IsEnabled(Serilog.Events.LogEventLevel.Debug))
            {
                Log(message, StatusSeverity.DEBUG);
            }
        }

        public void LogInfo(string message)
        {
            // Performance wrapper. Saves unneccesary call and heap allocation.
            if (Serilog.Log.Logger.IsEnabled(Serilog.Events.LogEventLevel.Information))
            {
                Log(message, StatusSeverity.INFO);
            }
        }

        public void LogKnownError(string message)
        {
            // Performance wrapper. Saves unneccesary call and heap allocation.
            if (Serilog.Log.Logger.IsEnabled(Serilog.Events.LogEventLevel.Error))
            {
                Log(message, StatusSeverity.ERROR);
            }
        }

        public void LogUnknownError(string message)
        {
            // Performance wrapper. Saves unneccesary call and heap allocation.
           if(Serilog.Log.Logger.IsEnabled(Serilog.Events.LogEventLevel.Error)){
            Log(message, StatusSeverity.UNEXPECTED_ERROR);
           }
        }

        public void LogWarning(string message)
        {
            // Performance wrapper. Saves unneccesary call and heap allocation.
            if (Serilog.Log.Logger.IsEnabled(Serilog.Events.LogEventLevel.Warning))
            {
                Log(message, StatusSeverity.WARN);
            }
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
                    Serilog.Log.Debug(traceID + ": " + message);
                    break;
                case StatusSeverity.INFO:
                    Serilog.Log.Information(traceID + ": " + message);
                    break;
                case StatusSeverity.ERROR or StatusSeverity.UNEXPECTED_ERROR:
                    Serilog.Log.Error(traceID + ": " + message);
                    break;
                case StatusSeverity.WARN:
                    Serilog.Log.Warning(traceID + ": " + message);
                    break;
                default:
                    Serilog.Log.Warning(traceID + ": " + message);
                    break;
            }
        }
    }
}