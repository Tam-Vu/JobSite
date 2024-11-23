namespace JobSite.Contracts.InterviewSchedule;
public record UpdateInterviewScheduleRequest
(
    DateOnly interviewDate,
    TimeOnly startTime,
    string location
);