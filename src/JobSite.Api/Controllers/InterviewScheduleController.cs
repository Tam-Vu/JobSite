
using JobSite.Application.Common.Models;
using JobSite.Application.InterviewSchedule.Commands.ApproveInterviewSchedule;
using JobSite.Application.InterviewSchedule.Commands.CreateInterviewSchedule;
using JobSite.Application.InterviewSchedule.Commands.UpdateInterviewSchedule;
using JobSite.Application.InterviewSchedule.Common;
using JobSite.Application.InterviewSchedule.Queries.GetListInterviewScheduleByJob;
using JobSite.Application.InterviewSchedule.Queries.GetMyListInterviewSchedule;
using JobSite.Contracts.InterviewSchedule;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSite.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class InterviewScheduleController : ControllerBase
{
    private readonly IMediator _mediator;

    public InterviewScheduleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize(Roles = "Employer")]
    public async Task<Result<CommandsInterviewScheduleResponse>> CreateInterviewSchedule([FromBody] CreateInterviewScheduleCommand request, CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Employer")]
    public async Task<Result<CommandsInterviewScheduleResponse>> UpdateInterviewSchedule(Guid id, [FromBody] UpdateInterviewScheduleRequest request, CancellationToken cancellationToken)
    {
        var command = new UpdateInterviewScheduleCommand(id, request.interviewDate, request.startTime, request.location);
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpPatch("Approve/{id}")]
    [Authorize(Roles = "Employer")]
    public async Task<Result<CommandsInterviewScheduleResponse>> ApproveInterviewSchedule(Guid id, [FromBody] ApproveInterviewScheduleRequest request, CancellationToken cancellationToken)
    {
        var command = new ApproveInterviewScheduleCommand(id, request.method);
        return await _mediator.Send(command, cancellationToken);
    }

    [HttpGet("{JobId}")]
    [Authorize(Roles = "Employer")]
    public async Task<Result<List<GetListInterviewScheduleByJobResponse>>> GetInterviewSchedule(Guid JobId, CancellationToken cancellationToken)
    {
        var query = new GetListInterviewScheduleByJobQuery(JobId);
        return await _mediator.Send(query, cancellationToken);
    }

    [HttpGet("My-Interview")]
    [Authorize(Roles = "Employee")]
    public async Task<Result<List<GetMyListInterviewScheduleResponse>>> GetMyInterviewSchedule(CancellationToken cancellationToken)
    {
        var query = new GetMyListInterviewScheduleQuery();
        return await _mediator.Send(query, cancellationToken);
    }
}