using JobSite.Application.Common.Models;
using JobSite.Application.InterviewSchedule.Common;

namespace JobSite.Application.InterviewSchedule.Commands.UpdateInterviewSchedule;

public record UpdateInterviewScheduleCommand
(
    Guid id,
    DateOnly interviewDate,
    TimeOnly startTime,
    string location
) : IRequest<Result<CommandsInterviewScheduleResponse>>;