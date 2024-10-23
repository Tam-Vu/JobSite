using JobSite.Domain.Common;

namespace JobSite.Domain.Entities;

public class Skill : BaseAuditableEntity
{
    public required string Name { get; set; }

    // public Skill(Guid id, string name, string description, Guid resumeId)
    //     : base(id == Guid.Empty ? Guid.NewGuid() : id)
    // {
    //     this.Name = name;
    //     this.Description = description;
    //     this.ResumeId = resumeId;
    // }
}