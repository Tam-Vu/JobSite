namespace JobSite.Application.InterviewSchedule.Common;
public record CommandsInterviewScheduleResponse
(
    Guid id,
    DateTimeOffset created,
    DateTimeOffset lastModified
);