namespace JobSite.Application.Common.Exceptions;
[Serializable]
public abstract class BaseException : Exception
{
    public int Code { get; protected set; }
    public string ErrorMessage { get; protected set; }
    public BaseException(string errorMessage) : base(errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}