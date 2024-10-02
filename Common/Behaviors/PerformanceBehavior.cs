using System.Diagnostics;
using MediatR;

namespace WorldTour.Common.Behaviors;

internal class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly Stopwatch _timer = new();
    private readonly ILogger<TRequest> _logger;

    public PerformanceBehavior(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _timer.Start();
        var response = await next();
        _timer.Stop();
        var elapsedMilliseconds = _timer.ElapsedMilliseconds;
        if (elapsedMilliseconds <= 500) return response;
        var requestName = typeof(TRequest).Name;
        _logger.LogWarning(
            "Tour Long Running Request: {Name} ({ElapsedMilliseconds} ms) {@Request}",
            requestName,
            elapsedMilliseconds,
            request
        );
        return response;
    }
}