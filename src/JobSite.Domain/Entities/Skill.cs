using JobSite.Domain.Common;

namespace JobSite.Domain.Entities;

public class Skill : BaseAuditableEntity
{
    public required string name { get; set; }
    public string? description { get; set; }

    public Skill(Guid id, string name, string description)
        : base(id == Guid.Empty ? Guid.NewGuid() : id)
    {
        this.name = name;
        this.description = description;
    }
}