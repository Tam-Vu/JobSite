using JobSite.Application.Common.Models;
using JobSite.Application.Employees.Commands;
using JobSite.Application.Employees.Commands.UpdateEmployee;
using JobSite.Application.Employees.Common;
using JobSite.Application.Employees.Queries.GetListEmployees;
using JobSite.Application.Employees.Queries.GetSingleEmployee;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace JobSite.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;
    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<GetSingleEmployeeResponse> GetSingleEmployee(Guid id, CancellationToken cancellationToken)
    {
        var request = new GetSingleEmployeeQuery(id);
        return await _mediator.Send(request, cancellationToken);
    }

    [HttpDelete]
    [Authorize(Roles = "Employee")]
    [Route("delete-my-account")]
    public async Task<Result<string>> DeleteEmployee(CancellationToken cancellationToken)
    {
        var request = new DeleteEmployeeCommand();
        return await _mediator.Send(request, cancellationToken);
    }

    [HttpPut]
    [Authorize(Roles = "Employee")]
    [Route("update-my-information")]
    public async Task<Result<EmployeeCommandRespose>> UpdateEmployee([FromBody] UpdateEmployeeCommand command, CancellationToken cancellationToken)
    {
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    [Route("get-all-employees")]
    [AllowAnonymous]
    public async Task<Result<List<EmployeeResponse>>> GetListEmployees(CancellationToken cancellationToken)
    {
        var request = new GetListEmployeesQuery();
        return await _mediator.Send(request, cancellationToken);
    }
}