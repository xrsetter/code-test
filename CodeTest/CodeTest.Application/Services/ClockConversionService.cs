using CodeTest.Application.Abstractions;
using CodeTest.Application.Helpers;

namespace CodeTest.Application.Services;

public class ClockConversionService : IClockConversionService
{
    private readonly Dictionary<int, int> _conversionHelper;

    public ClockConversionService()
    {
        _conversionHelper = ClockConversionsHelpers.HourConversion;
    }

    public Task<int> CalculateTimeAngle(TimeSpan time, CancellationToken cancellationToken)
    {
        var hourHand = time.Hours > 12 ? time.Hours - 12 : time.Hours;
        var minuteHand = time.Minutes == 0 ? 12 : (int)Math.Floor(time.Minutes / 60.0 * 12);
        return Task.FromResult(_conversionHelper[hourHand] + _conversionHelper[minuteHand]);
    }
}
