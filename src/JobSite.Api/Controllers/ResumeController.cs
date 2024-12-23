using JobSite.Application.Common.Models;
using JobSite.Application.Resumes.Commands;
using JobSite.Application.Resumes.Commands.CreateResumeCommand;
using JobSite.Application.Resumes.Commands.UpdateResumeCommand;
using JobSite.Application.Resumes.Common;
using JobSite.Application.Resumes.Queries.GetListResumeQuery;
using JobSite.Application.Resumes.Queries.GetResumeDetailsQuery;
using JobSite.Contracts.Resume;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSite.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ResumeController(IMediator _mediator) : ControllerBase
{

    [HttpPost]
    [Authorize(Roles = "Employee")]
    public async Task<Result<ResponseResumeCommand>> CreateNewResume(CreateResumeCommand request, CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [HttpPut]
    [Authorize(Roles = "Employee")]
    [Route("{id}")]
    public async Task<Result<ResponseResumeCommand>> UpdateResume(Guid id, UpdateResumeRequest request, CancellationToken cancellationToken)
    {
        var command = (request, id).Adapt<UpdateResumeCommand>();
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    [Route("get-all-resume")]
    public async Task<List<ResponseResumeQuery>> GetAllResume(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetListResumeQuery(), cancellationToken);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ResponseResumeQuery> GetResumeDetails(Guid id, CancellationToken cancellationToken)
    {
        var request = new GetResumeDetailsQuery(id);
        return await _mediator.Send(request, cancellationToken);
    }

    [HttpDelete]
    [Authorize(Roles = "Admin, Employee")]
    [Route("{id}")]
    public async Task<Result<string>> DeleteResume(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteResumeCommand(id);
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpGet]
    [Authorize(Roles = "Employee")]
    [Route("my-resumes")]
    public async Task<List<ResponseResumeQuery>> GetMyResumes(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetListResumeQuery(), cancellationToken);
    }
}