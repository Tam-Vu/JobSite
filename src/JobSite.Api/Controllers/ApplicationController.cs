
using JobSite.Application.Application.Commands.ApproveApplication;
using JobSite.Application.Application.Commands.CreateApplication;
using JobSite.Application.Application.Commands.DeleteApplication;
using JobSite.Application.Application.Common;
using JobSite.Application.Application.Queries.GetListApplicationByResume;
using JobSite.Application.Application.Queries.GetListApplicationsByJob;
using JobSite.Application.Application.Queries.GetMyListApplications;
using JobSite.Application.Application.QueriesGetListApplicationsByJob;
using JobSite.Application.Common;
using JobSite.Application.Common.Models;
using JobSite.Contracts.Application;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSite.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ApplicationController(ISender _mediator) : ControllerBase
{
    [HttpPost("{id}")]
    public async Task<Result<CommandApplicationResponse>> CreateApplication(Guid id, [FromBody] CommandApplicationRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateApplicationCommand(id, request.ResumeId);
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpDelete("{id}")]
    public async Task<Result<CommandApplicationResponse>> DeleteApplication(Guid id, [FromBody] CommandApplicationRequest request, CancellationToken cancellationToken)
    {
        var command = new DeleteApplicationCommand(id, request.ResumeId);
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<Result<string>> UpdateApplication(Guid id, [FromBody] ApproveApplicationRequest request, CancellationToken cancellationToken)
    {
        var command = new ApproveApplicationCommand(id, request.method);
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpGet("Job/{id}")]
    public async Task<Result<List<ApplicationDto>>> GetApplication(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetListApplicationsByJobQuery(id);
        return await _mediator.Send(query, cancellationToken);
    }

    [HttpGet("Resume/{id}")]
    public async Task<Result<GetListApplicationByResumeResponse>> GetApplicationByResume(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetListApplicationByResumeQuery(id);
        return await _mediator.Send(query, cancellationToken);
    }

    [HttpGet("My")]
    public async Task<Result<List<JustApplicationDto>>> GetMyApplication(CancellationToken cancellationToken)
    {
        var query = new GetMyListApplicationsQuery();
        return await _mediator.Send(query, cancellationToken);
    }
}