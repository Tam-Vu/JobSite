using JobSite.Application.Common.Models;
using JobSite.Application.Employers.Commands;
using JobSite.Application.Employers.Commands.UpdateEmployer;
using JobSite.Application.Employers.Common;
using JobSite.Application.Employers.Queries.GetListEmployers;
using JobSite.Application.Employers.Queries.GetSingleEmployer;
using JobSite.Application.Employers.Queries.GetSingleEmployerResponse;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSite.Api.Controllers;

public class EmployerController : ControllerBase
{
    private readonly IMediator _mediator;
    public EmployerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<Result<GetSingleEmployereResponse>> GetSingleEmployer(Guid id, CancellationToken cancellationToken)
    {
        var request = new GetSingleEmployerQuery(id);
        return await _mediator.Send(request, cancellationToken);
    }

    [HttpDelete]
    [Route("delete-my-account")]
    public async Task<Result<string>> DeleteEmployer(CancellationToken cancellationToken)
    {
        var request = new DeleteEmployerCommand();
        return await _mediator.Send(request, cancellationToken);
    }

    [HttpPut]
    [Route("update-my-information")]
    public async Task<Result<EmployerCommandRespose>> UpdateEmployer([FromBody] UpdateEmployerCommand command, CancellationToken cancellationToken)
    {
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpGet]
    [Route("get-all-Employers")]
    [AllowAnonymous]
    public async Task<Result<List<GetListEmployersResponse>>> GetListEmployers(CancellationToken cancellationToken)
    {
        var request = new GetListEmployersQuery();
        return await _mediator.Send(request, cancellationToken);
    }
}