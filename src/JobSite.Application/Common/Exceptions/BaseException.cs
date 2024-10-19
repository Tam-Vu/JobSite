using static JobSite.Application.Common.Models.CustomResponseError;
namespace JobSite.Application.Common.Exceptions;
[Serializable]
public abstract class BaseException : Exception
{
    public ErrorCodes Code { get; protected set; }
    public string ErrorMessage { get; }
    public BaseException(string errorMessage) : base(errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}