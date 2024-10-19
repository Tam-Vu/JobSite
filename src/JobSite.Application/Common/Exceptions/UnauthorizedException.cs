using System.Net;
using static JobSite.Application.Common.Models.CustomResponseError;

namespace JobSite.Application.Common.Exceptions;

public class UnauthorizedException : BaseException
{
    public UnauthorizedException(string errorMessage) : base(errorMessage)
    {
        Code = ErrorCodes.Unauthorized;
    }
}