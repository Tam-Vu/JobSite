using JobSite.Application.Common.Models;
using JobSite.Application.Resumes.Commands;
using JobSite.Application.Resumes.Commands.Common;
using JobSite.Application.Resumes.Commands.CreateResumeCommand;
using JobSite.Application.Resumes.Commands.UpdateResumeCommand;
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
    public async Task<Result<ResponseResumeCommand>> CreateNewResume(CreateResumeCommand request, CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<Result<ResponseResumeCommand>> UpdateResume(Guid id, UpdateResumeRequest request, CancellationToken cancellationToken)
    {
        var command = (request, id).Adapt<UpdateResumeCommand>();
        return await _mediator.Send(command, cancellationToken);
    }
}