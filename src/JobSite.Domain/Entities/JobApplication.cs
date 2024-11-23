using JobSite.Domain.Common;
using JobSite.Domain.Enums;

namespace JobSite.Domain.Entities;
public class JobApplication : BaseAuditableEntity
{
    public required Guid JobId { get; init; }
    public Job Job { get; set; } = null!;
    public required Guid ResumeId { get; init; }
    public Resume Resume { get; set; } = null!;
    public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;
    public ICollection<InterviewSchedule> InterviewSchedules { get; set; } = new List<InterviewSchedule>();
}