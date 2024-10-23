using System.Net;
namespace JobSite.Application.Common.Exceptions;

public class UnauthorizedException : BaseException
{
    public UnauthorizedException(string errorMessage) : base(errorMessage)
    {
        Code = (int)HttpStatusCode.Unauthorized;
    }
}