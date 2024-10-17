


using System.Diagnostics;
using JobSite.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace JobSite.Application.Common.Behaviours;
public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly Stopwatch _timer;
    private readonly ILogger<TRequest> _logger;
    private readonly IUser _user;
    private readonly IIdentityService _identityService;
    public PerformanceBehavior(ILogger<TRequest> logger, IUser user, IIdentityService identityService)
    {
        _timer = new Stopwatch();
        _logger = logger;
        _user = user;
        _identityService = identityService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _timer.Start();
        var response = await next();
        _timer.Stop();
        var elapsedMilliseconds = _timer.ElapsedMilliseconds;
        if (elapsedMilliseconds > 500)
        {
            var requestName = typeof(TRequest).Name;
            var userName = string.Empty;
            var userId = _user.Id ?? string.Empty;
            if (!string.IsNullOrEmpty(userId))
            {
                userName = await _identityService.GetUserNameAsync(userId);
            }
            _logger.LogWarning("Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@UserName} {@Request}",
                requestName, elapsedMilliseconds, userId, userName, request);
        }
        throw new NotImplementedException();
    }
}