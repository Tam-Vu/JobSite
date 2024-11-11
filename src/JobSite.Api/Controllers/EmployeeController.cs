using JobSite.Application.Employees.Commands;
using JobSite.Application.Employees.Commands.CreateEmployee;
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

    [HttpPost]
    public async Task<EmployeeCommandRespose> CreateEmployee(CreateEmployeeComamnd request, CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [HttpGet("{id}")]
    public async Task<GetSingleEmployeeResponse> GetSingleEmployee(Guid id, CancellationToken cancellationToken)
    {
        var request = new GetSingleEmployeeQuery(id);
        return await _mediator.Send(request, cancellationToken);
    }
}