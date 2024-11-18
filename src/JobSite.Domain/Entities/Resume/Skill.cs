using JobSite.Domain.Common;

namespace JobSite.Domain.Entities;

public class Skill : BaseAuditableEntity
{
    public required string Name { get; set; }
}