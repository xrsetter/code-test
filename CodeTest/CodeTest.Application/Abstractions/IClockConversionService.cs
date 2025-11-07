namespace CodeTest.Application.Abstractions;

public interface IClockConversionService
{
    Task<int> CalculateTimeAngle(TimeSpan time, CancellationToken cancellationToken);
}
