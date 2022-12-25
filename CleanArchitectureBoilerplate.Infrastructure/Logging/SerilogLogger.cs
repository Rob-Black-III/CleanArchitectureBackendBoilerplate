
using CleanArchitectureBoilerplate.Application.Common.Services;
using CleanArchitectureBoilerplate.Domain;
using Serilog;

namespace CleanArchitectureBoilerplate.Infrastructure.Logging
{
    public class SerilogLogger : ICleanArchitectureBoilerplateLogger
    {

        public SerilogLogger(){
            Serilog.Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public void Log(string message, StatusSeverity severity)
        {
            switch(severity){
                case StatusSeverity.INFO or StatusSeverity.PRIVATE_INFO:
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
        }
    }
}