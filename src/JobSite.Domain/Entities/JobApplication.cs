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

    public JobApplication(Guid id, Guid jobId, Guid resumeId)
        : base(id == Guid.Empty ? Guid.NewGuid() : id)
    {
        this.JobId = jobId;
        this.ResumeId = resumeId;
        this.Status = ApplicationStatus.Pending;
    }
}