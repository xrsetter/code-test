using CodeTest.Application.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CodeTest.Application.CQRS.Queries;

public class CalculateTimeAngleQueryHandler(IClockConversionService clockConversionService, ILogger<CalculateTimeAngleQueryHandler> logger) : IRequestHandler<CalculateTimeAngleQuery, int>
{
    private readonly IClockConversionService _clockConversionService = clockConversionService;
    private readonly ILogger<CalculateTimeAngleQueryHandler> _logger = logger;

    public async Task<int> Handle(CalculateTimeAngleQuery request, CancellationToken cancellationToken)
    {
        return await _clockConversionService.CalculateTimeAngle(request.Time, cancellationToken);
    }
}