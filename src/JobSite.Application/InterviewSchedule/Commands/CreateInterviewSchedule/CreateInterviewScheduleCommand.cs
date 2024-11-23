using JobSite.Application.Common.Models;
using JobSite.Application.InterviewSchedule.Common;

namespace JobSite.Application.InterviewSchedule.Commands.CreateInterviewSchedule;

public record CreateInterviewScheduleCommand
(
    Guid jobApplicationId,
    DateOnly interviewDate,
    TimeOnly startTime,
    string location
) : IRequest<Result<CommandsInterviewScheduleResponse>>;