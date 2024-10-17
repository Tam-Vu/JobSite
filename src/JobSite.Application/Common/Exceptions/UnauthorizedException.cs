using System.Net;

namespace JobSite.Application.Common.Exceptions;

public class UnauthorizedException(string errorMessage) : BaseException((int)HttpStatusCode.Unauthorized, errorMessage);