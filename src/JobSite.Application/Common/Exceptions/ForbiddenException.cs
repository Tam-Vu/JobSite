using System.Net;
namespace JobSite.Application.Common.Exceptions;
public class ForbiddenException : BaseException
{
    public ForbiddenException(string errorMessage) : base(errorMessage)
    {
        Code = (int)HttpStatusCode.Forbidden;
    }
}