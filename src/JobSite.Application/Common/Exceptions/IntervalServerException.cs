using System.Net;

namespace JobSite.Application.Common.Exceptions;
public class IntervalServerException(string errorMessage) : BaseException((int)HttpStatusCode.InternalServerError, errorMessage);