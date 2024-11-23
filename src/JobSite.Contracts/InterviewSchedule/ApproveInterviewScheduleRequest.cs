namespace JobSite.Contracts.InterviewSchedule;

public record ApproveInterviewScheduleRequest
(
    int method
// 0 : Approve
// 1 : Reject
);