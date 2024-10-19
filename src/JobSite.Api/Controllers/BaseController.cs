
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using JobSite.Application;
// using JobSite.Application.Common.Exceptions;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    protected ActionResult Problem(List<Exception> exceptions)
    {
        if (exceptions.Count is 0)
        {
            return Problem();
        }

        if (exceptions.All(exception => exception is ValidationException))
        {
            return ValidationProblem(exceptions);
        }

        return Problem(exceptions[0]);
    }

    private ObjectResult Problem(Exception exception)
    {
        var statusCode = exception switch
        {
            // ConflictException => StatusCodes.Status409Conflict,
            ValidationException => StatusCodes.Status400BadRequest,
            KeyNotFoundException => StatusCodes.Status404NotFound,
            UnauthorizedAccessException => StatusCodes.Status403Forbidden,
            _ => StatusCodes.Status500InternalServerError,
        };

        return Problem(statusCode: statusCode, title: exception.Message);
    }

    private ActionResult ValidationProblem(List<Exception> exceptions)
    {
        var modelStateDictionary = new ModelStateDictionary();

        exceptions.ForEach(exception => modelStateDictionary.AddModelError(exception.GetType().Name, exception.Message));

        return ValidationProblem(modelStateDictionary);
    }
}