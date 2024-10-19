using System.Net;
using static JobSite.Application.Common.Models.CustomResponseError;

namespace JobSite.Application.Common.Exceptions;

public class NotFoundException : BaseException
{
    public NotFoundException(string errorMessage) : base(errorMessage)
    {
        Code = ErrorCodes.NotFound;
    }
}