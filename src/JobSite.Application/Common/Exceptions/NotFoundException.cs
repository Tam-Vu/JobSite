using System.Net;
namespace JobSite.Application.Common.Exceptions;

public class NotFoundException : BaseException
{
    public NotFoundException(string errorMessage) : base(errorMessage)
    {
        Code = (int)HttpStatusCode.NotFound;
    }
}