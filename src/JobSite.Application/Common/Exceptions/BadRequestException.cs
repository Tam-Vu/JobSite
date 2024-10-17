using System.Net;

namespace JobSite.Application.Common.Exceptions;

public class BadRequestException(string errorMessage) : BaseException((int)HttpStatusCode.BadRequest, errorMessage);