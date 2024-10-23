using JobSite.Application.Common.Exceptions;

namespace JobSite.Application.Common.Behaviours;

public class ValidationBahaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    public ValidationBahaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                _validators.Select(v =>
                    v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
                .Where(e => e.Errors.Any())
                .SelectMany(e => e.Errors)
                .ToList();

            if (failures.Any())
            {
                throw new ValidationsException(failures);
            }
        }
        return await next();
    }
}