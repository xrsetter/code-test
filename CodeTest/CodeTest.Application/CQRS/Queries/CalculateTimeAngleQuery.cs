using MediatR;

namespace CodeTest.Application.CQRS.Queries;

public sealed record CalculateTimeAngleQuery(TimeSpan Time) : IRequest<int>;
