
using JobSite.Application.Common.Models;
using JobSite.Application.Jobs;
using JobSite.Application.Jobs.Commands.CreateJob;
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
    [Route("create-job")]
    public async Task<JobResponseData> CreateNewJob(CreateJobCommand request, CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }
}