using System.Net;
namespace JobSite.Application.Common.Exceptions;
public class ForbiddenException(string errorMessage) : BaseException((int)HttpStatusCode.Forbidden, errorMessage);