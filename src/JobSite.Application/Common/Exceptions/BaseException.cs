namespace JobSite.Application.Common.Exceptions;

[Serializable]
public abstract class BaseException(int statusCode, string errorMessage) : Exception
{
    public int StatusCode { get; } = statusCode;
    public string ErrorMessage { get; } = errorMessage;
}