using System.Net.Cache;
using JobSite.Domain.Common;

namespace JobSite.Domain.Entities;

public class ExperienceDetail : BaseAuditableEntity
{
    public required string CompanyName { get; set; }
    public required string StartDate { get; set; }
    public required string EndDate { get; set; }
    public string? Description { get; set; }
    public required Guid ResumeId { get; init; }
}