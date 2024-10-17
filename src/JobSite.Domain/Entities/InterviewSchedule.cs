using JobSite.Domain.Common;
using JobSite.Domain.Enums;
using JobSite.Domain.Entities;

namespace JobSite.Domain.Entities;
public class InterviewSchedule : BaseAuditableEntity
{
    public required Guid JobId { get; init; }
    public Job Job { get; set; } = null!;
    public required Guid ResumeId { get; init; }
    public Resume Resume { get; set; } = null!;
    public DateTime InterviewDate { get; set; }
    public string? Location { get; set; }
    public TimeOnly StartTime { get; set; }
    public InterviewStatus Status { get; set; } = InterviewStatus.Scheduled;
    public InterviewSchedule(Guid id, Guid jobId, Guid resumeId, DateTime interviewDate, string location, TimeOnly startTime)
        : base(id == Guid.Empty ? Guid.NewGuid() : id)
    {
        this.JobId = jobId;
        this.ResumeId = resumeId;
        this.InterviewDate = interviewDate;
        this.Location = location;
        this.StartTime = startTime;
        this.Status = InterviewStatus.Scheduled;
    }
}