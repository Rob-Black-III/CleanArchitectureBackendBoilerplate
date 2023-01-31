using CleanArchitectureBoilerplate.Application.Common.Services;

namespace CleanArchitectureBoilerplate.Infrastructure.Common.Services
{
    internal class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}