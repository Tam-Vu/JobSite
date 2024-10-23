using System.Net;
namespace JobSite.Application.Common.Exceptions;

public class BadRequestException : BaseException
{
    public BadRequestException(string errorMessage) : base(errorMessage)
    {
        Code = (int)HttpStatusCode.BadRequest;
    }
}