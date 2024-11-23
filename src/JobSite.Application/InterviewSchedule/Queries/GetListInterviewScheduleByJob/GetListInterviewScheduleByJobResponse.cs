using JobSite.Domain.Enums;

namespace JobSite.Application.InterviewSchedule.Queries.GetListInterviewScheduleByJob;

public record GetListInterviewScheduleByJobResponse
(
    Guid id,
    InterviewStatus status,
    string fullname,
    string email,
    string image
);