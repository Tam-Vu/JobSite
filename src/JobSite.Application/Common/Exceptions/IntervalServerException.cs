using System.Net;
namespace JobSite.Application.Common.Exceptions;
public class IntervalServerException : BaseException
{
    public IntervalServerException(string errorMessage) : base(errorMessage)
    {
        Code = (int)HttpStatusCode.InternalServerError;
    }
}