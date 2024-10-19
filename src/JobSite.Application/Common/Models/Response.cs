using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace JobSite.Application.Common.Models;
public class CustomResponse<T>
{
    // private CustomResponse()
    // {
    // }

    private CustomResponse(bool isSuccess, T data, IEnumerable<CustomResponseError> errors)
    {
        IsSuccess = isSuccess;
        Errors = errors;
        Data = data;
    }
    public IEnumerable<CustomResponseError> Errors { get; set; }
    public bool IsSuccess { get; set; }
    public T Data { get; set; }

    public static CustomResponse<T> Success(T data)
    {
        return new CustomResponse<T>(true, data, new List<CustomResponseError>());
    }

    public static CustomResponse<T> Fail(IEnumerable<CustomResponseError> errors)
    {
        return new CustomResponse<T>(false, default, errors);
    }
}

public class CustomResponseError
{
    public string Code { get; set; }
    public string Message { get; set; }

    public CustomResponseError(ErrorCodes code, string message)
    {
        Code = code.ToString();
        Message = message;
    }

    public enum ErrorCodes
    {
        NotFound,
        Invalid,
        Unauthorized,
        Forbidden,
        Conflict,
        InternalServerError,
        PermissionValidation,
        BadRequest
    }
}