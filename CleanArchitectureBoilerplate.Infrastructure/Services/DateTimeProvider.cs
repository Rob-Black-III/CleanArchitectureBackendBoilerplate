using CleanArchitectureBoilerplate.Application.Common.Services;

namespace CleanArchitectureBoilerplate.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}