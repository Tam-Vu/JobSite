using System.Net;
using static JobSite.Application.Common.Models.CustomResponseError;
namespace JobSite.Application.Common.Exceptions;
public class ForbiddenException : BaseException
{
    public ForbiddenException(string errorMessage) : base(errorMessage)
    {
        Code = ErrorCodes.Forbidden;
    }
}