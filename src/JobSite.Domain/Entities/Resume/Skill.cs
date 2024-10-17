using JobSite.Domain.Common;

namespace JobSite.Domain.Entities;

public class Skill : BaseAuditableEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required Guid ResumeId { get; init; }
    public Resume Resume { get; set; } = null!;

    public Skill(Guid id, string name, string description, Guid resumeId)
        : base(id == Guid.Empty ? Guid.NewGuid() : id)
    {
        this.Name = name;
        this.Description = description;
        this.ResumeId = resumeId;
    }
}