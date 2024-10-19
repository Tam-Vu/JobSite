using System.Net;
using static JobSite.Application.Common.Models.CustomResponseError;

namespace JobSite.Application.Common.Exceptions;
public class IntervalServerException : BaseException
{
    public IntervalServerException(string errorMessage) : base(errorMessage)
    {
        Code = ErrorCodes.InternalServerError;
    }
}