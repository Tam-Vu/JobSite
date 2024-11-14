using JobSite.Domain.Common;

namespace JobSite.Domain.Entities;

public class ExperienceDetail : BaseAuditableEntity
{
    public required string CompanyName { get; set; }
    public required int StartYear { get; set; }
    public required int StartMonth { get; set; }
    public required int EndYear { get; set; }
    public required int EndMonth { get; set; }
    public string? Description { get; set; }
    public required Guid ResumeId { get; init; }
}