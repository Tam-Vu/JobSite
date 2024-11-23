using JobSite.Domain.Common;
using JobSite.Domain.Enums;
using JobSite.Domain.Entities;

namespace JobSite.Domain.Entities;
public class InterviewSchedule : BaseAuditableEntity
{
    public required Guid JobApplicationId { get; init; }
    public JobApplication JobApplication { get; set; } = null!;
    public DateOnly InterviewDate { get; set; }
    public string? Location { get; set; }
    public TimeOnly StartTime { get; set; }
    public InterviewStatus Status { get; set; } = InterviewStatus.Scheduled;
}