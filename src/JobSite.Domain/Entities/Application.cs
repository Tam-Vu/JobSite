using JobSite.Domain.Common;
using JobSite.Domain.Enums;

namespace JobSite.Domain.Entities;
public class Application : BaseAuditableEntity
{
    public required Guid jobId { get; init; }
    public Job? job { get; set; }
    public required Guid resumeId { get; init; }
    public Resume? resume { get; set; }
    public ApplicationStatus status { get; set; } = ApplicationStatus.Pending;

    public Application(Guid id, Guid jobId, Guid resumeId)
        : base(id == Guid.Empty ? Guid.NewGuid() : id)
    {
        this.jobId = jobId;
        this.resumeId = resumeId;
    }
}