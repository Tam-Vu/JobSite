using JobSite.Application.Common.Models;

namespace JobSite.Application.InterviewSchedule.Queries.GetMyListInterviewSchedule;

public record GetMyListInterviewScheduleQuery() : IRequest<Result<List<GetMyListInterviewScheduleResponse>>>;
