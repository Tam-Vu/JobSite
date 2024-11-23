using JobSite.Application.Common.Models;

namespace JobSite.Application.InterviewSchedule.Queries.GetListInterviewScheduleByJob;

public record GetListInterviewScheduleByJobQuery
(
    Guid JobId
) : IRequest<Result<List<GetListInterviewScheduleByJobResponse>>>;