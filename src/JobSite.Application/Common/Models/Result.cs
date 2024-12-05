using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobSite.Application.Jobs;
namespace JobSite.Application.Common.Models;
public class Result<T>
{
    // private Result()
    // {
    // }

    private Result(bool isSuccess, T data, IEnumerable<ResultError> errors)
    {
        IsSuccess = isSuccess;
        Errors = errors;
        Data = data;
    }
    public IEnumerable<ResultError> Errors { get; set; }
    public bool IsSuccess { get; set; }
    public T Data { get; set; }

    public static Result<T> Success(T data)
    {
        return new Result<T>(true, data, new List<ResultError>());
    }

    public static Result<T> Fail(IEnumerable<ResultError> errors)
    {
        return new Result<T>(false, default!, errors);
    }
}

public class ResultError
{
    public int Code { get; set; }
    public string Message { get; set; }

    public ResultError(int code, string message)
    {
        Code = code;
        Message = message;
    }

}