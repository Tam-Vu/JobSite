using JobSite.Domain.Common;

namespace JobSite.Domain.Entities;

public class Requirement : BaseAuditableEntity
{
    public required string name { get; set; }
    public string? description { get; set; }
    public required Guid jobId { get; set; }
    public Job? job { get; set; }
    public Requirement(Guid id, string name, string description, Guid jobId)
        : base(id == Guid.Empty ? Guid.NewGuid() : id)
    {
        this.name = name;
        this.description = description;
        this.jobId = jobId;
    }
}