using System.Net;
using static JobSite.Application.Common.Models.CustomResponseError;
namespace JobSite.Application.Common.Exceptions;

public class BadRequestException : BaseException
{
    public BadRequestException(string errorMessage) : base(errorMessage)
    {
        Code = ErrorCodes.BadRequest;
    }
}