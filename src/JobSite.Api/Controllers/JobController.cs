
using JobSite.Application.Common.Models;
using JobSite.Application.Jobs;
using JobSite.Application.Jobs.Commands.CreateJob;
using JobSite.Application.Jobs.Commands.UpdateJob;
using JobSite.Application.Jobs.Common;
using JobSite.Application.Jobs.Queries.GetJobDetails;
using JobSite.Application.Jobs.Queries.GetListJob;
using JobSite.Application.Jobs.Queries.GetListJobOfCompany;
using JobSite.Contracts.Job;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSite.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class JobController(ISender _mediator) : ControllerBase
{

    [HttpPost]
    public async Task<Result<JobCommandResponse>> CreateNewJob(CreateJobCommand request, CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<Result<List<JobQueryResponse>>> GetListJob(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetListJobQuery(), cancellationToken);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<Result<JobQueryResponse>> GetJobDetails(Guid id, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetJobDetailsQuery(id), cancellationToken);
    }

    [HttpGet("company/{id}")]
    [AllowAnonymous]
    public async Task<Result<List<JobQueryResponse>>> GetListJobOfCompany(Guid id, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetListJobOfCompanyQuery(id), cancellationToken);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<Result<JobCommandResponse>> UpdateJob(Guid id, [FromBody] UpdateJobRequest request, CancellationToken cancellationToken)
    {
        var command = (request, id).Adapt<UpdateJobCommand>();
        return await _mediator.Send(command, cancellationToken);
    }
}