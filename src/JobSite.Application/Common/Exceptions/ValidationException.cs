using FluentValidation.Results;
namespace JobSite.Application.Common.Exceptions;

public class ValidationException : BaseException
{
    public ValidationException() : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(FailureGroup => FailureGroup.Key, FailureGroup => FailureGroup.ToArray());
    }

    public Dictionary<string, string[]> Errors { get; }
}