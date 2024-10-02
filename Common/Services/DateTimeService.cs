using WorldTour.Common.Interfaces;

namespace WorldTour.Common.Services;

public class DateTimeService : IDateTime
{
    public DateTime NowUtc => DateTime.UtcNow;
}