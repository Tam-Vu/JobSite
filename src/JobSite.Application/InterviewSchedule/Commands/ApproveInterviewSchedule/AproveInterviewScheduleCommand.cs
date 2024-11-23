using JobSite.Application.Common.Models;
using JobSite.Application.InterviewSchedule.Common;

namespace JobSite.Application.InterviewSchedule.Commands.ApproveInterviewSchedule;

public record ApproveInterviewScheduleCommand
(
    Guid id,
    int method
) : IRequest<Result<CommandsInterviewScheduleResponse>>;