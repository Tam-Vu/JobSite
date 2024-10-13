using JobSite.Domain.Common;
using JobSite.Domain.Enums;
using JobSite.Domain.Entities;

namespace JobSite.Domain.Entities;
public class InterviewSchedule : BaseAuditableEntity
{
    public required Guid jobId { get; init; }
    public Job? job { get; set; }
    public required Guid resumeId { get; init; }
    public Resume? resume { get; set; }
    public DateTime interviewDate { get; set; }
    public string? location { get; set; }
    public TimeOnly startTime { get; set; }
    public InterviewStatus status { get; set; } = InterviewStatus.Scheduled;
    public InterviewSchedule(Guid id, Guid jobId, Guid resumeId, DateTime interviewDate, string location, TimeOnly startTime)
        : base(id == Guid.Empty ? Guid.NewGuid() : id)
    {
        this.jobId = jobId;
        this.resumeId = resumeId;
        this.interviewDate = interviewDate;
        this.location = location;
        this.startTime = startTime;
    }
}