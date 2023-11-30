

using Eclipseworks.Application.Interfaces;

namespace Eclipseworks.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}