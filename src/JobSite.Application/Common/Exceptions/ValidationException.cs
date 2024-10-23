using System.Net;
using FluentValidation.Results;
namespace JobSite.Application.Common.Exceptions;

public class ValidationsException : BaseException
{
    public ValidationsException() : base("One or more validation failures have occurred.")
    {
        Code = (int)HttpStatusCode.BadRequest;
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationsException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }

    public IDictionary<string, string[]> Errors { get; }
}