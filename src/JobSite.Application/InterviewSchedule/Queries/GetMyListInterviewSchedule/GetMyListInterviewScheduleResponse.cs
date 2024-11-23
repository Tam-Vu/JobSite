using JobSite.Domain.Enums;

namespace JobSite.Application.InterviewSchedule.Queries.GetMyListInterviewSchedule;

public record GetMyListInterviewScheduleResponse
(
    Guid id,
    DateOnly interviewDate,
    TimeOnly interviewTime,
    InterviewStatus status,
    string interviewLocation,
    Guid jobId,
    string jobTitle,
    string jobDescription,
    Decimal salary,
    JobType jobType,
    Guid companyId,
    string comanyName,
    string companyWebsite
);