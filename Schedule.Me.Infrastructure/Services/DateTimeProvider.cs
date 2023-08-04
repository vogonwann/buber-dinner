using Schedule.Me.Application.Common.Interfaces.Services;

namespace Schedule.Me.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}