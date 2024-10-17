using System.Net;

namespace JobSite.Application.Common.Exceptions;

public class NotFoundException(string errorMessage) : BaseException((int)HttpStatusCode.NotFound, errorMessage);