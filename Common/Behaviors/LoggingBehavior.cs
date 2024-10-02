using MediatR.Pipeline;

namespace WorldTour.Common.Behaviors;

public class LoggingBehavior<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;

    public LoggingBehavior(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        _logger.LogInformation(
            "Tour Request: {Name} {@Request}",
            requestName,
            request
        );
    }
}