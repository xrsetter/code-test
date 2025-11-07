using CodeTest.Application.Services;

namespace CodeTest.Tests;

[TestFixture]
public class Tests
{
    private ClockConversionService _clockConversionService;

    [SetUp]
    public void Setup()
    {
        _clockConversionService = new ClockConversionService();
    }

    [TestCase(2, 14, 120)]
    [TestCase(12, 42, 240)]
    [TestCase(2, 16, 150)]
    public async Task ClockConversion_ReturnsCorrectSum(int hours, int minutes, int expected)
    {
        var time = new TimeSpan(hours, minutes, 00);
        int response = await _clockConversionService.CalculateTimeAngle(time, default);
        Assert.That(response, Is.EqualTo(expected));
    }
}
