using JobSite.Domain.Common;

namespace JobSite.Domain.Entities;

public class Requirement : BaseAuditableEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required Guid JobId { get; set; }
    public Job Job { get; set; } = null!;
    public Requirement(Guid id, string name, string description, Guid jobId)
        : base(id == Guid.Empty ? Guid.NewGuid() : id)
    {
        this.Name = name;
        this.Description = description;
        this.JobId = jobId;
    }
}